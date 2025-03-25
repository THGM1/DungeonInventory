using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIInventory : MonoBehaviour
{
    private int curCount; // 현재 아이템 수
    private int maxCount = 100; // 최대 아이템 수
    [SerializeField] TextMeshProUGUI countTxt;

    [Header("버튼")]
    [SerializeField] private Button useBtn; // 사용 버튼
    [SerializeField] private Button equipBtn; // 장착 버튼
    [SerializeField] private Button closeBtn; // 닫기 버튼
    [SerializeField] private Button unEquipBtn; // 해제 버튼

    [Header("슬롯")]
    [SerializeField] private UISlot slotPrefab;
    [SerializeField] private Transform slotParent;

    [Header("선택된 아이템")]
    [SerializeField] private TextMeshProUGUI selectedItemName;

    List<Item> inventory;
    Item selectedItem;
    int selectedIndex;
    private List<UISlot> slots = new();

    private void Start()
    {
        inventory = GameManager.Instance.Player.Inventory;

        AddButtonListener();
        InitInventoryUI();
        UpdateUI();
        useBtn.gameObject.SetActive(false);
        equipBtn.gameObject.SetActive(false);
    }

    public void UpdateUI()
    {
        if (inventory != null)
        {
            curCount = inventory.Count;
            countTxt.text = $"{curCount} / {maxCount}";
        }

        selectedItemName.text = selectedItem != null ? selectedItem.Name : string.Empty;
        if (selectedItem != null)
            slots[selectedIndex].RefreshUI();
        if (selectedItem is EquipItem item)
        {
            equipBtn.gameObject.SetActive(!item.isEquipped);
            unEquipBtn.gameObject.SetActive(item.isEquipped);
        }
        else unEquipBtn.gameObject.SetActive(false);

    }

    private void AddButtonListener()
    {
        useBtn.onClick.AddListener(UseItem);
        equipBtn.onClick.AddListener(UseItem);
        unEquipBtn.onClick.AddListener(UseItem);
        closeBtn.onClick.AddListener(UIManager.Instance.OpenInventory);

    }

    private void InitInventoryUI()
    {
        foreach (Transform slot in slotParent)
        {
            Destroy(slot.gameObject);
        }
        slots.Clear();

        foreach (Item item in inventory)
        {
            AddSlot(item, item.Count);
        }
        unEquipBtn.gameObject.SetActive(false);

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
        if (selectedItem is EquipItem item)
        {
            equipBtn.gameObject.SetActive(!item.isEquipped);
            unEquipBtn.gameObject.SetActive(item.isEquipped);
        }
        else unEquipBtn.gameObject.SetActive(false);
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
            inventory.Remove(slots[selectedIndex].item);
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
        unEquipBtn.gameObject.SetActive(false);
    }

}
