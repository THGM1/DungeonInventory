using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConsumableItem : Item
{
    public int Value { get; private set; }

    public ConsumableItem(string name, Sprite icon, int value, int count = 1) : base(name, icon, count)
    {
        this.Value = value;
    }

    public override void Use(Character player)
    {
        if(player.CurHealth < player.MaxHealth && Count > 0)
        {
            player.CurHealth = Mathf.Min(player.CurHealth + Value, player.MaxHealth);
            Count--;
        }
    }
}
