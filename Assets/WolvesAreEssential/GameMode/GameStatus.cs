using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStatus : MonoBehaviour
{
    private static GameStatus instance;
    public static GameStatus Instance => instance;
    public bool freeze = false;

    private void Awake()
    {
        if (!instance)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlayerLose()
    {

    }
    public void PlayerWin()
    {
        WinCanvas.Instance.Show();
    }
}
