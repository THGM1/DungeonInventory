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

    public void UpdateUI()
    {
        atk.text = player.Atk.ToString();
        def.text = player.Def.ToString();
        health.text = $"{player.CurHealth}/{player.MaxHealth}";
        critical.text = player.Critical.ToString();
    }
    private void AddButtonListener()
    {
        closeBtn.onClick.AddListener(UIManager.Instance.OpenStatus);
    }
}
