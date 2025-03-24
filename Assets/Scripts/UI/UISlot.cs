using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UISlot : MonoBehaviour
{
    [SerializeField] private Image icon;
    [SerializeField] private TextMeshProUGUI itemName;
    [SerializeField] private TextMeshProUGUI itemCount;

    public Item item;

    public void SetItem(Item item, int count = 0)
    {
        this.item = item;
        icon.sprite = item.icon;
        itemName.text = item.name;
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
}
