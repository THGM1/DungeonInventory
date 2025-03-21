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

    private void Start()
    {
        UpdateUI();
        AddButtonListener();
    }

    private void UpdateUI()
    {
        countTxt.text = $"{curCount}/{maxCount}";
    }

    private void AddButtonListener()
    {
        //useBtn.onClick.AddListener();
        //equipBtn.onClick.AddListener();
        closeBtn.onClick.AddListener(UIManager.Instance.OpenInventory);
    }
}
