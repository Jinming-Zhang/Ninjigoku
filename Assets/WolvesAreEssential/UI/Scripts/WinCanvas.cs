using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WinCanvas : UIScreen<WinCanvas>
{
    private static WinCanvas instance;
    public static WinCanvas Instance
    {
        get
        {
            if (!instance)
            {
                Object go = Instantiate(Resources.Load("WinCanvas"));
                instance = go.GetComponent<WinCanvas>();
                instance.gameObject.SetActive(false);
            }
            return instance;
        }
    }
    private void OnDestroy()
    {
        instance = null;
    }
}
