using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drone : MonoBehaviour
{
    public GameObject player;
    public float distanceScale = 1f;
    public float height = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if(!player){
            player = GameObject.Find("Player");
        }
        if(!player)
        {
            return;
        }
        teleport();
    }

    void teleport() {
        Vector2 mousePos = Input.mousePosition;
        Vector3 mousePosWorld = Vector3.one;
        mousePosWorld.x = mousePos.x;
        mousePosWorld.y = mousePos.y;
        mousePosWorld.z = Vector3.Distance(player.transform.position, Camera.main.transform.position);
        mousePosWorld = Camera.main.ScreenToWorldPoint(mousePosWorld);
        mousePosWorld.y = player.transform.position.y;

        Vector3 targetDir = mousePosWorld - player.transform.position;
        Vector3 c = Vector3.Normalize(targetDir) * distanceScale;
        transform.position = new Vector3(c.x, height, c.z) + player.transform.position;
    }
}
