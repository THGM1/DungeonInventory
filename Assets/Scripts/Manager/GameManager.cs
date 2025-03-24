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

    [SerializeField] private Sprite swordIcon;
    [SerializeField] private Sprite shieldIcon;
    [SerializeField] private Sprite potionIcon;

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

    public void SetData()
    {
        SetPlayer();
        SetItem();
        //UIManager.Instance.MainMenu.UpdateUI();
        //UIManager.Instance.Status.UpdateUI();
    }

    public void SetPlayer()
    {
        Player = new Character("GON", 3, 14, 1000, 4, 2, 1);
    }

    public void SetItem()
    {
        EquipItem sword = new EquipItem("Sword", swordIcon, 10, 0, 1);
        EquipItem shield = new EquipItem("Shield", shieldIcon, 0, 5, 0);
        ConsumableItem potion = new ConsumableItem("Potion", potionIcon, 20, 3);
        if (sword == null) Debug.Log("sword null");
        Player.AddItem(sword);
        Player.AddItem(shield);
        Player.AddItem(potion);

        foreach(var item in Player.Inventory)
        {
            if (item == null) Debug.Log("null");
        }
    }
}
