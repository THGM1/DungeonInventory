using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIMainMenu : MonoBehaviour
{
    [Header("플레이어 정보")]
    [SerializeField] private TextMeshProUGUI name;// 이름 텍스트
    [SerializeField] private TextMeshProUGUI level;// 레벨 텍스트
    [SerializeField] private Image expBar;// EXP 바
    [SerializeField] private TextMeshProUGUI expText;// EXP 텍스트
    [SerializeField] private TextMeshProUGUI gold;// Gold 텍스트

    [Header("버튼")]
    [SerializeField] public Button statusBtn;// Status 버튼
    [SerializeField] public Button InventoryBtn;// Inventory 버튼

    Character player;

    private void Start()
    {
        player = GameManager.Instance.Player;
        if (player == null) Debug.Log("player null");
        AddButtonListener();
        UpdateUI();
    }

    public void UpdateUI()
    {
        name.text = player.PlayerName;
        level.text = $"Lv. {player.Level.ToString()}";
        expText.text = $"{player.Exp}/{player.MaxExp}";
        gold.text = player.Gold.ToString();
        expBar.fillAmount = (float)player.Exp / player.MaxExp;
    }

    private void AddButtonListener()
    {
        statusBtn.onClick.AddListener(UIManager.Instance.OpenStatus);
        InventoryBtn.onClick.AddListener(UIManager.Instance.OpenInventory);

    }

}
