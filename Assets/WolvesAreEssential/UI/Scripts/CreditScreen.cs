using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class CreditScreen : UIScreen<CreditScreen>
{
    private static CreditScreen instance;
    public static CreditScreen Instance
    {
        get
        {
            if (!instance)
            {
                Object go = Instantiate(Resources.Load("CreditCanvas"));
                instance = go.GetComponent<CreditScreen>();
            }
            return instance;
        }
    }
    [SerializeField]
    [Range(0f, 1f)]
    float scrollIndex;
    [SerializeField]
    ScrollRect creditScrollView;
    [SerializeField]
    float scrollSpeed;
    [SerializeField]
    AudioClip creditClip;
    public override void Show()
    {
        base.Show();
        AudioSystem.Instance.TransitionToBGM(creditClip, 1f);
        creditScrollView.verticalNormalizedPosition = 1;
    }
    private void OnDestroy()
    {
        instance = null;
    }

    void Update()
    {
        if (creditScrollView.verticalNormalizedPosition > 0)
        {
            creditScrollView.verticalNormalizedPosition -= (scrollSpeed * Time.deltaTime);
            Debug.Log(creditScrollView.verticalNormalizedPosition);
        }
    }
}
