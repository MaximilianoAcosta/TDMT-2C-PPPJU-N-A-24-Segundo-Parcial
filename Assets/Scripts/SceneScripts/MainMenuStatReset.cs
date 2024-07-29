using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuStatReset : MonoBehaviour
{
   [SerializeField] SaveValueManager SaveValueManager;
    void Start()
    {
        SaveValueManager.ResetDefaultDataSourceValues();
    }

}
