using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class UIScreen<T> : MonoBehaviour where T : MonoBehaviour
{
    public static int SORTING_ORDER = 0;
    protected Canvas canvas;
    protected CanvasGroup cg;

    float targetCgAlpha = 0;

    private void Awake()
    {
        canvas = GetComponent<Canvas>();
        cg = GetComponent<CanvasGroup>();
    }

    public void PushToTop()
    {
        ++SORTING_ORDER;
        canvas.sortingOrder = SORTING_ORDER;
    }

    public virtual void Show()
    {
        gameObject.SetActive(true);
    }

    public virtual void Shutdown()
    {
        Destroy(gameObject);
    }


}
