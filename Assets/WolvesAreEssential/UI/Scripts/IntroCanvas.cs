using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class IntroCanvas : UIScreen<IntroCanvas>
{
    private static IntroCanvas instance;
    public static IntroCanvas Instance
    {
        get
        {
            if (!instance)
            {
                Object go = Instantiate(Resources.Load("IntroCanvas"));
                instance = go.GetComponent<IntroCanvas>();
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
