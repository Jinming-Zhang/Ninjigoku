using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class CreditScreen : UIScreen<CreditScreen>
{
    private static CreditScreen instance;
    //public static CreditScreen Instance =>{
    //    get{
    [SerializeField]
    [Range(0f, 1f)]
    float scrollIndex;
    [SerializeField]
    ScrollRect creditScrollView;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        creditScrollView.verticalNormalizedPosition = scrollIndex;

    }
}
