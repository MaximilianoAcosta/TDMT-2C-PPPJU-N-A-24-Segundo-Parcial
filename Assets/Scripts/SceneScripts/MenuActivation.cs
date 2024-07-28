using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuActivation : MonoBehaviour
{
    private int openedMenu = -1;
    [SerializeField] List<GameObject> Menus;
    public void OpenMenu(int index)
    {
        foreach (var menu in Menus)
        {
            menu.SetActive(false);
        }
        if(openedMenu != index)
        {
            Menus[index].SetActive(true);
            openedMenu = index;

        }
        else { openedMenu = -1; }
    }
}
