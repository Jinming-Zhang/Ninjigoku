using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class RemoveController : MonoBehaviour
{
    public bool isDisabled = false;

    void Start() {
        StartCoroutine(playerCutScene());
        GetComponent<PlayableDirector>().played += DisableControl;
        GetComponent<PlayableDirector>().stopped += EnableControl;
    }

    void DisableControl(PlayableDirector pd) {
        isDisabled = true;
        Debug.LogError("DisableControl");

    }

    void EnableControl(PlayableDirector pd) {
        isDisabled = false;
        Debug.LogError("EnableControl");
    }
    //need a manager to play the playable director
    IEnumerator playerCutScene() {
        yield return new WaitForSeconds(3);
        GetComponent<PlayableDirector>().Play();

    }
}
