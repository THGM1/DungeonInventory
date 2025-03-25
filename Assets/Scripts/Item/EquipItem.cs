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
        if (isEquipped) UnEquip();
        else Equip();
    }

    public void Equip()
    {
        if (!isEquipped)
        {
            GameManager.Instance.equipAtk += Atk;
            GameManager.Instance.equipDef += Def;
            GameManager.Instance.equipCri += Critical;
            GameManager.Instance.SetEquipStat(this);
            isEquipped = true;
        }
    }

    public void UnEquip()
    {
        if (isEquipped)
        {
            GameManager.Instance.equipAtk -= Atk;
            GameManager.Instance.equipDef -= Def;
            GameManager.Instance.equipCri -= Critical;
            GameManager.Instance.SetEquipStat(this);
            isEquipped = false;
        }
    }
}
