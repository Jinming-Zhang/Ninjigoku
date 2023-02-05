using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroCanvas : UIScreen<IntroCanvas>
{

    [SerializeField]
    AudioClip ambientSFXs;

    public void Start()
    {
        AudioSystem.Instance.TransitionToBGM(ambientSFXs, 1);
    }

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

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
    public void Quit()
    {
        Application.Quit();
    }

}
