using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Item
{
    public Sprite Icon { get; private set; }
    public string Name { get; private set; }
    public int Count { get; set; }

    public Item(string name, Sprite icon, int count = 1)
    {
        this.Name = name;
        this.Icon = icon;
        this.Count = count;
    }

    public abstract void Use(Character player);


}
