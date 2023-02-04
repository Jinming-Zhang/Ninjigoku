using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    [SerializeField]
    GameObject playerTemplate;
    private void Start()
    {
        GameObject p = Instantiate(playerTemplate, transform.position, Quaternion.identity);
        p.SetActive(true);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(transform.position, Vector3.one * 1.5f);
    }

}
