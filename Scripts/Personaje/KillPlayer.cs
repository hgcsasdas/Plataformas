using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlayer : MonoBehaviour
{
    [SerializeField] Transform spawnpoint;

    private void OnCollisionEnter2D(Collision2D collision)
    {


        if (collision.transform.CompareTag("Player"))
        {

            collision.transform.position = spawnpoint.position;
            
        }
    }
}
