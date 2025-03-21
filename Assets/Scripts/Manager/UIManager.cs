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

    public UIMainMenu MainMenu { get; private set; }
    public UIStatus Status { get; private set; }
    public UIInventory Inventory { get; private set; }

    private void Awake()
    {
        instance = this;
        MainMenu = FindObjectOfType<UIMainMenu>();
        Inventory = FindObjectOfType<UIInventory>();
        Status = FindObjectOfType<UIStatus>();
    }
    private void Start()
    {
        Status.gameObject.SetActive(false);
        Inventory.gameObject.SetActive(false);
        //MainMenu.gameObject.SetActive(false);
    }
    public void OpenStatus()
    {
        Status.gameObject.SetActive(!Status.gameObject.activeSelf);
    }

    public void OpenInventory()
    {
        Inventory.gameObject.SetActive(!Inventory.gameObject.activeSelf);
    }

    public void OpenMainMenu()
    {
        MainMenu.gameObject.SetActive(!MainMenu.gameObject.activeSelf);
    }
}
