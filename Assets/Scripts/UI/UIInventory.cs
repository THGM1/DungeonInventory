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
    [SerializeField] private TextMeshProUGUI selectedItemCount;

    Item selectedItem;
    int selectedIndex;
    private List<UISlot> slots = new();

    private void Start()
    {
        UpdateUI();
        AddButtonListener();


    }

    private void UpdateUI()
    {
        countTxt.text = $"{curCount} / {maxCount}";
        
        foreach(var slot in slots)
        {
            if (slot != null) slot.SetItem(slot.item, slot.item.count);
            else slot.Clear();
            
        }
    }

    private void AddButtonListener()
    {
        //useBtn.onClick.AddListener();
        //equipBtn.onClick.AddListener();
        closeBtn.onClick.AddListener(UIManager.Instance.OpenInventory);
    }

    private void InitInventoryUI(List<Item> items)
    {
        foreach(Transform slot in slotParent)
        {
            Destroy(slot.gameObject);
        }
        slots.Clear();

        foreach(Item item in items)
        {
            AddSlot(item, item.count);
        }
    }
    
    public void AddSlot(Item item, int count)
    {
        UISlot newSlot = Instantiate(slotPrefab, slotParent);
        newSlot.SetItem(item, count);
        slots.Add(newSlot);
    }

    UISlot GetEmptySlot()
    {
        foreach(var slot in slots)
        {
            if (slot == null) return slot;
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

        selectedItemName.text = selectedItem.name;
        
        
    }

    void RemoveSelectedItem()
    {
        slots[selectedIndex].item.count--;
        if (slots[selectedIndex].item.count <= 0)
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

    public void OnEquipButton()
    {
        
    }
}
