using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance
    {
        get
        {
            if (instance == null) 
                instance = new GameObject("GameManager").AddComponent<GameManager>();
            return instance;
        }
    }

    public Character Player { get; private set; }

    private int[] expTable = { 10, 20, 30, 40, 50 };
    private int[] maxHealth = { 10, 20, 30, 40, 50 };

    public int equipAtk;
    public int equipDef;
    public int equipCri;


    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            if(instance != this)
            {
                Destroy(gameObject);
            }
        }
        SetData();
    }

    public int GetExpForLevel(int level)
    {
        if(level >= expTable.Length) return expTable[expTable.Length - 1];
        return expTable[level];
    }

    public int GetMaxHealth(int level)
    {
        if(level >= maxHealth.Length) return maxHealth[maxHealth.Length -1];
        return maxHealth[level];    
    }

    public void SetData()
    {
        SetPlayer();
        SetItem();
    }

    public void SetPlayer()
    {
        Player = new Character("GON", 3, 14, 1000, 4, 2, 1);
    }

    public void SetItem()
    {
        Sprite swordIcon = Resources.Load<Sprite>("ItemSprite/Sword");
        Sprite shieldIcon = Resources.Load<Sprite>("ItemSprite/Shield");
        Sprite potionIcon = Resources.Load<Sprite>("ItemSprite/Potion");

        EquipItem sword = new EquipItem("��", swordIcon, 10, 0, 1);
        EquipItem shield = new EquipItem("����", shieldIcon, 0, 5, 0);
        ConsumableItem potion = new ConsumableItem("����", potionIcon, 1, 3);

        Player.AddItem(sword);
        Player.AddItem(sword);
        Player.AddItem(sword);
        Player.AddItem(sword);
        Player.AddItem(sword);
        Player.AddItem(shield);
        Player.AddItem(shield);
        Player.AddItem(shield);
        Player.AddItem(shield);
        Player.AddItem(shield);
        Player.AddItem(potion);

    }

    public void SetEquipStat(EquipItem item)
    {
        if (!item.isEquipped)
        {
            Player.Atk += equipAtk;
            Player.Def += equipDef;
            Player.Critical += equipCri;
        }
        else
        {
            Player.Atk -= equipAtk;
            Player.Def -= equipDef;
            Player.Critical -= equipCri;
        }
    }
}
