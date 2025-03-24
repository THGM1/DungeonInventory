using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UISlot : MonoBehaviour
{
    [SerializeField] private Image icon;
    [SerializeField] private TextMeshProUGUI itemCount;
    [SerializeField] private Image equipped;

    private int index;
    public Item item;

    public void SetItem(Item item, int index, int count = 0)
    {
        this.item = item;
        this.index = index;
        icon.sprite = item.Icon;
        itemCount.text = count > 0 ? count.ToString() : string.Empty;
    }

    public void RefreshUI(int count)
    {
        itemCount.text = count.ToString();
        // 착용 상태 업데이트
    }

    public void Clear()
    {
        item = null;
        icon.gameObject.SetActive(false);
        itemCount.text = string.Empty;
    }

    public void SetEquipped()
    {
        if(item is EquipItem equipItem) equipped.gameObject.SetActive(equipItem.isEquipped);
    }

    public void AddButtonListener()
    {
        Button button = GetComponent<Button>();
        button.onClick.AddListener(SelectItem);
    }

    public void SelectItem()
    {
        UIManager.Instance.Inventory.SelectItem(index);
    }
}
