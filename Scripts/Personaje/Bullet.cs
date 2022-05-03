using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public AudioClip Sound;
    public float Speed;
    private Vector2 Direction;

    private Rigidbody2D Rigidbody2D;
    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Rigidbody2D.velocity = Direction * Speed;
    }

    public void SetDirection(Vector2 direction)
    {
        Direction = direction;
    }
    public void DestroyBullet()
    {
        Destroy(gameObject);
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        John_Movement john = collision.GetComponent<John_Movement>();
        GruntScriptç grunt = collision.GetComponent<GruntScriptç>();

        if (john != null)
        {
            john.Hit();
        } 
        if(grunt != null)
        {
            grunt.Hit();
        }
        DestroyBullet();
    }
}
