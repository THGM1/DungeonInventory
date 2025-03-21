using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [Header("기본 정보")]
    public string playerName;
    public int level;
    public int exp;
    public int gold;

    [Header("스탯")]
    public int atk;
    public int def;
    public int curHealth;
    public int maxHealth;   
    public int critical;

    private void Start()
    {
        curHealth = maxHealth;
    }

}
