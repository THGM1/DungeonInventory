using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIStatus : MonoBehaviour
{
    Character player;
    [Header("½ºÅÈ")]
    [SerializeField] private TextMeshProUGUI atk;
    [SerializeField] private TextMeshProUGUI def;
    [SerializeField] private TextMeshProUGUI health;
    [SerializeField] private TextMeshProUGUI critical;

    [Header("¹öÆ°")]
    [SerializeField] private Button closeBtn;

    private void Start()
    {
        player = GameManager.Instance.Player;
        AddButtonListener();
        UpdateUI();
    }

    private void UpdateUI()
    {
        atk.text = player.atk.ToString();
        def.text = player.def.ToString();
        health.text = $"{GameManager.Instance.GetMaxHealth(player.level)}";
        critical.text = player.critical.ToString();
    }
    private void AddButtonListener()
    {
        closeBtn.onClick.AddListener(UIManager.Instance.OpenStatus);
    }
}
