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
    [SerializeField] private Button statusBtn;// Status 버튼
    [SerializeField] private Button InventoryBtn;// Inventory 버튼

    Character player;

    private void Start()
    {
        player = GameManager.Instance.Player;
        UpdateUI();
    }

    private void UpdateUI()
    {
        name.text = player.playerName;
        level.text = $"Lv. {player.level.ToString()}";
        expText.text = $"{player.exp}/{GameManager.Instance.GetExpForLevel(player.level)}";
        gold.text = player.gold.ToString();
        expBar.fillAmount = (float)player.exp / GameManager.Instance.GetExpForLevel(player.level);
    }

}
