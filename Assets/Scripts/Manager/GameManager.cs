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

    public Character player;
    public Character Player
    {
        get { return player; }
        set { player = value; }
    }

    private int[] expTable = { 10, 20, 30, 40, 50 };
    private int[] maxHealth = { 10, 20, 30, 40, 50 };
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
}
