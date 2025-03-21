using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    private static UIManager instance;
    public static UIManager Instance
    {
        get { return instance; }
    }

    private Character player;
    public Character Player { get { return player; } }

    [SerializeField] public Canvas mainMenu;
    [SerializeField] public Canvas status;
    [SerializeField] public Canvas inventory;

    private void Awake()
    {
        instance = this;
        player = GameManager.Instance.Player;
    }

    public void ShowStatus()
    {
        status.gameObject.SetActive(!status.gameObject.activeSelf);
    }
    public void ShowInventory()
    {
        inventory.gameObject.SetActive(!inventory.gameObject.activeSelf);
    }

}
