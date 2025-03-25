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
        if (selectedItem == null) return;

        int prevIndex = selectedIndex;

        selectedItem.Use(GameManager.Instance.Player);

        if (selectedItem is ConsumableItem)
        {
            RemoveSelectedItem();
        }
        else if (selectedItem is EquipItem)
        {
            slots[selectedIndex].SetEquipped();
        }

        selectedIndex = prevIndex;
        if (selectedIndex >= 0 && selectedIndex < slots.Count)
        {
            selectedItem = slots[selectedIndex].item;
        }
        else
        {
            selectedItem = null;
        }

        UpdateUI();
    }

    void RemoveSelectedItem()
    {
        if (selectedIndex < 0 || selectedIndex >= slots.Count) return;
        if (slots[selectedIndex].item.Count == 0)
        {
            slots[selectedIndex].RefreshUI();
            selectedItem = null;
            slots[selectedIndex].item = null;
            selectedIndex = -1;
            ClearSelectedItem();
        }
    }

    void ClearSelectedItem()
    {
        selectedItemName.text = string.Empty;
        useBtn.gameObject.SetActive(false);
        equipBtn.gameObject.SetActive(false);
    }

}
