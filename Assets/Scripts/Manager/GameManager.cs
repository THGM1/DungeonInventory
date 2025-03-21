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
        SetData("GON", 3, 5, 1000, 5, 3, 1);
    }
    private void Start()
    {
        
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

    public void SetData(string playerName, int level, int exp, int gold, int atk, int def, int critical)
    {
        Player = new GameObject("Player").AddComponent<Character>();
        Player = new Character(playerName, level, exp, gold, atk, def, critical);

        //UIManager.Instance.MainMenu.UpdateUI();
        //UIManager.Instance.Status.UpdateUI();
    }
}
