using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStatus : MonoBehaviour
{
    private static GameStatus instance;
    public static GameStatus Instance => instance;
    public bool freeze = false;
    [SerializeField]
    float autoLoseInSec;
    float loseCounter;
    [SerializeField]
    TMPro.TextMeshProUGUI counterUI;

    public bool shouldCount;
    public PlayerCollision player;

    private void Awake()
    {
        loseCounter = autoLoseInSec;
        shouldCount = false;
        counterUI.gameObject.SetActive(shouldCount);

        if (!instance)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        counterUI.gameObject.SetActive(shouldCount);
        if (shouldCount)
        {
            loseCounter -= Time.deltaTime;
        }

        if (loseCounter < 0)
        {
            shouldCount = false;
            PlayerLose();
        }
        else
        {
            updateCounterUI();
        }

    }
    public void updateCounterUI()
    {
        counterUI.text = loseCounter.ToString("0.00");
    }

    public void PlayerLose()
    {
        player.isDead = true;
        LoseCanvas.Instance.Show();
    }

    public void PlayerWin()
    {
        WinCanvas.Instance.Show();
    }
}
