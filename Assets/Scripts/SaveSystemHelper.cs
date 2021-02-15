// Helpers for SaveSystem

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveSystemHelper : MonoBehaviour
{
    public void SaveHelper()
    {
        SaveSystem.SaveData();
    }

    public void ResetHelper()
    {
        SaveSystem.ResetData();
    }
}
