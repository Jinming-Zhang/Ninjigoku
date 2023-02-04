using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[RequireComponent(typeof(CanvasGroup))]
public class TransitionScreen : UIScreen<TransitionScreen>
{
    public struct TransitionConfig
    {
        public float duration;
    }

    public enum TransitionType
    {
        TransitionIn,
        TransitionOut,
    }

    [Header("Config")]
    [SerializeField]
    bool playOnAwake = false;
    [SerializeField]
    TransitionType transitionType;
    [SerializeField]
    AnimationCurve curve;

    //CanvasGroup cg;

    TransitionConfig config;
    private void Awake()
    {
        //cg = GetComponent<CanvasGroup>();
    }
    // Start is called before the first frame update

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    [ContextMenu("Trans out")]
    public void TransOut()
    {
        SetTransitionConfig(new TransitionConfig() { duration = 3f });
        transitionType = TransitionType.TransitionOut;
        StartTransition();
    }
    [ContextMenu("Trans in")]
    public void TransiIn()
    {
        SetTransitionConfig(new TransitionConfig() { duration = 3f });
        transitionType = TransitionType.TransitionIn;
        StartTransition();
    }

    public void SetTransitionConfig(TransitionConfig config)
    {
        this.config = config;
    }

    public void StartTransition(Action onTransitionFinished = null)
    {
        StartCoroutine(TransitionCR());
    }

    public void StopTransition()
    {

    }

    IEnumerator TransitionCR()
    {
        float target = 1;
        int sign = 1;
        switch (transitionType)
        {
            case TransitionType.TransitionIn:
                cg.alpha = 1f;
                target = 0;
                sign = -1;
                break;
            case TransitionType.TransitionOut:
                cg.alpha = 0f;
                target = 1;
                sign = 1;
                break;
            default:
                break;
        }
        while (Mathf.Abs(cg.alpha - target) > .001f)
        {
            float delta = 1f / config.duration * Time.deltaTime * sign;
            cg.alpha += delta;
            yield return new WaitForEndOfFrame();
        }
        cg.alpha = target;
    }
}
