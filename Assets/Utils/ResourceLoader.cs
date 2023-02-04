using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public static class ResourceLoader
{
    public static T LoadResource<T>(string path)
    {
        Object go = Object.Instantiate(Resources.Load(path));
        return go.GetComponent<T>();
    }
}
