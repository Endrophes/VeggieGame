using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


public class MenuController : MonoBehaviour
{
    //Debugging flag when editing menus and you want to test on just one menu
    public bool RunStart = true;

    //
    [Range(1.0f, 100f)]
    public float transitionSpeed;

    //Menus
    public List<MenuOption> menus;

    private Dictionary<string, MenuOption> menuStorage;

    private MenuOption currentMenu;
    private MenuOption lastMenu;

    void Start()
    {
        menuStorage = new Dictionary<string, MenuOption>();

        foreach (MenuOption mo in menus)
        {
            menuStorage[mo.name] = mo;
            mo.hide();
        }

        currentMenu = menus[0];
        currentMenu.toggleVisability(true);
    }

    void Update()
    {

    }

    //Tell the controller what page to go too
    public void GoToPage(string pageName)
    {
        //Debug.Log("Got To Page: " + pageName);

        if (menuStorage.ContainsKey(pageName))
        {
            lastMenu = currentMenu;
            currentMenu = menuStorage[pageName];

            lastMenu.toggleVisability(false);
            currentMenu.toggleVisability(true);
        }
    }

    //
    public void GoToBack()
    {
        var temp = lastMenu;
        lastMenu = currentMenu;
        currentMenu = temp;

        lastMenu.toggleVisability(false);
        currentMenu.toggleVisability(true);
    }
}
