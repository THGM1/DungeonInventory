using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character 
{
    public string PlayerName { get; private set; }
    public int Level { get; private set; }
    public int Exp { get; private set; }
    public int MaxExp { get; private set; }
    public int Gold { get; private set; }
    public int Atk { get; set; }
    public int Def { get;  set; }
    public int CurHealth { get; set; }
    public int MaxHealth { get; private set; }
    public int Critical { get; set; }

    public List<Item> Inventory { get; private set; }

    private void Start()
    {

    }
    public Character(string name, int level, int exp, int gold, int atk, int def,int critical)
    {
        PlayerName = name;
        Level = level;
        Exp = exp;
        Gold = gold;
        Atk = atk;
        Def = def;
        Critical = critical;
        MaxExp = GameManager.Instance.GetExpForLevel(Level);
        MaxHealth = GameManager.Instance.GetMaxHealth(Level);
        CurHealth = 1;

        Inventory = new List<Item>();
    }
    public void AddItem(Item item)
    {
        Inventory.Add(item);
    }
}
