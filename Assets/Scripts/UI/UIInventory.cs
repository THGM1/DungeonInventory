using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIInventory : MonoBehaviour
{
    [SerializeField] private int curCount; // 현재 아이템 수
    [SerializeField] private int maxCount;
    [SerializeField] TextMeshProUGUI countTxt;

    [Header("버튼")]
    [SerializeField] private Button useBtn; // 사용 버튼
    [SerializeField] private Button equipBtn; // 장착 버튼
    [SerializeField] private Button closeBtn;

    [Header("슬롯")]
    [SerializeField] private UISlot slotPrefab;
    [SerializeField] private Transform slotParent;

    [Header("선택된 아이템")]
    [SerializeField] private TextMeshProUGUI selectedItemName;

    Item selectedItem;
    int selectedIndex;
    private List<UISlot> slots = new();

    private void Start()
    {
        UpdateUI();
        AddButtonListener();
        InitInventoryUI();

        useBtn.gameObject.SetActive(false);
        equipBtn.gameObject.SetActive(false);
    }

    public void UpdateUI()
    {
        countTxt.text = $"{curCount} / {maxCount}";

        foreach(var slot in slots)
        {
            if (slot != null) slot.SetItem(slot.item, slot.item.Count);
            else slot.Clear();
            
        }
        
        selectedItemName.text = selectedItem != null ? selectedItem.Name : string.Empty;
        if(selectedItem != null)
            slots[selectedIndex].RefreshUI();
    }

    private void AddButtonListener()
    {
        useBtn.onClick.AddListener(UseItem);
        equipBtn.onClick.AddListener(UseItem);
        closeBtn.onClick.AddListener(UIManager.Instance.OpenInventory);

    }

    private void InitInventoryUI()
    {
        foreach(Transform slot in slotParent)
        {
            Destroy(slot.gameObject);
        }
        slots.Clear();

        List<Item> inventory = GameManager.Instance.Player.Inventory;

        foreach(Item item in inventory)
        {
            AddSlot(item, item.Count);
        }
    }
    
    public void AddSlot(Item item, int count)
    {
        UISlot newSlot = Instantiate(slotPrefab, slotParent);
        int index = slots.Count;
        newSlot.SetItem(item, index, count);

        slots.Add(newSlot);
    }

    UISlot GetEmptySlot()
    {
        foreach(var slot in slots)
        {
            if (slot.item == null) return slot;
        }
        return null;
    }

    UISlot GetItemSlot(Item item)
    {
        foreach(var slot in slots)
        {
            if (slot.item == item) return slot;
        }
        return null;
    }

    public void SelectItem(int index)
    {
        if (slots[index].item == null) return;

        selectedItem = slots[index].item;
        selectedIndex = index;

        selectedItemName.text = selectedItem.Name;
        
        useBtn.gameObject.SetActive(selectedItem is ConsumableItem);
        equipBtn.gameObject.SetActive(selectedItem is EquipItem);
        
    }

    private void UseItem()
    {
        selectedItem.Use(GameManager.Instance.Player);
        if(selectedItem is ConsumableItem)
        {
            RemoveSelectedItem();
        }
        slots[selectedIndex].SetEquipped();
        UpdateUI();
    }

    void RemoveSelectedItem()
    {
        //slots[selectedIndex].item.Count--;
        if (slots[selectedIndex].item.Count <= 0)
        {
            selectedItem = null;
            slots[selectedIndex].item = null;
            selectedIndex = -1;
            ClearSelectedItem();
        }
        UpdateUI();
    }

    void ClearSelectedItem()
    {
        selectedItemName.text = string.Empty;
        useBtn.gameObject.SetActive(false);
        equipBtn.gameObject.SetActive(false);
    }

}
