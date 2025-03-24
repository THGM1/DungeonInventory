using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipItem : Item
{
    public int Atk {  get; private set; }
    public int Def {  get; private set; }
    public int Critical {  get; private set; }
    public bool isEquipped { get; private set; }

    public EquipItem(string name, Sprite icon, int atk, int def, int critical) : base(name, icon, 1)
    {
        this.Atk = atk;
        this.Def = def;
        this.isEquipped = false;
        Critical = critical;    
    }

    public override void Use(Character player)
    {
        if (isEquipped) UnEquip(player);
        else Equip(player);
    }

    public void Equip(Character player)
    {
        if (!isEquipped)
        {
            player.Atk += Atk;
            player.Def += Def;
            player.Critical += Critical;
            isEquipped = true;
        }
    }

    public void UnEquip(Character player)
    {
        if (isEquipped)
        {
            player.Atk -= Atk;
            player.Def -= Def;
            player.Critical -= Critical;
            isEquipped = false;
        }
    }
}
