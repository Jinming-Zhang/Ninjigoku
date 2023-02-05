using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour
{
    [SerializeField]
    GameObject graphics;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetTransform(Transform rhs)
    {
        transform.position = rhs.position;
    }

    private void OnCollisionEnter(Collision collision)
    {
        PlayerShooting ps = collision.gameObject.GetComponent<PlayerShooting>();
        if (ps)
        {
            Debug.Log("Star picked up by player");
            ps.IncrementAtk();
            Destroy(gameObject);
        }
    }
}
