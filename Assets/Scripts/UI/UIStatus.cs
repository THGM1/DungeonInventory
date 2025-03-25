using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
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
        atk.text = $"{player.Atk.ToString()}{EquipStat(0)}";
        def.text = $"{player.Def.ToString()}{EquipStat(1)}";
        health.text = $"{player.CurHealth}/{player.MaxHealth}";
        critical.text = $"{player.Critical.ToString()}{EquipStat(2)}";
    }
    private void AddButtonListener()
    {
        closeBtn.onClick.AddListener(UIManager.Instance.OpenStatus);
    }

    public string EquipStat(int num)
    {
        int stat = 0;
        switch (num)
        {
            case 0:
                stat = GameManager.Instance.equipAtk;
                break;
            case 1:
                stat = GameManager.Instance.equipDef;
                break;
            case 2:
                stat = GameManager.Instance.equipCri;
                break;
            default:
                stat = 0;
                break;
        }
        string str = $" (+{stat.ToString()})";
        if (stat != 0) return str;
        return null;
    }
}
