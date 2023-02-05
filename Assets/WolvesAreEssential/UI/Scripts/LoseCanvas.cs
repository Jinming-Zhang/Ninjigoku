using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.VisualScripting;

public class LoseCanvas : MonoBehaviour
{
    private static LoseCanvas instance;
    public static LoseCanvas Instance
    {
        get
        {
            if (!instance)
            {
                Object go = Instantiate(Resources.Load("LoseCanvas"));
                instance = go.GetComponent<LoseCanvas>();
                instance.gameObject.SetActive(false);
            }
            return instance;
        }
    }
}
