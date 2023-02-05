using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;

public class LoseCanvas : UIScreen<LoseCanvas>
{
    [SerializeField]
    AudioClip loseAmbientAudio;

    public void Start()
    {
        AudioSystem.Instance.TransitionToBGM(loseAmbientAudio, 2);
    }

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
    public void Restart()
    {
        SceneManager.LoadScene(0);
    }
    public void Continue()
    {
        SceneManager.LoadScene(2);
    }
    public void Quit()
    {
        Application.Quit();
    }
}
