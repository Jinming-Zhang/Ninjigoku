using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private CharacterController player;
    private float Timer = 0;
    private float CD=5;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float hori = Input.GetAxis("Horizontal");
        float vert = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(hori,vert,0);
        player.Move(direction/100);

        if ((Input.GetKey(KeyCode.LeftShift)) && (CD<=0) && (Timer<=0.4)){
            Timer += Time.deltaTime;
            player.Move(direction/5);
        }

        if ((Input.GetKeyUp(KeyCode.LeftShift)) && (CD<=0)){ 
            Timer=0;
            CD = 5;
        }
        
        CD -= Time.deltaTime;
        
    }
}
