using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class John_Movement : MonoBehaviour
{
    public GameObject Bullet;
    public float Speed;
    public float JumpForce;
    public GameObject John;

    [SerializeField] Transform spawnpoint;
    private Rigidbody2D Rigidbody2D;
    private Animator Animator;
    private float Horizontal;
    private bool Grounded;
    private float LastShoot;
    private int Health = 5;

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        Animator = GetComponent<Animator>();

        John.transform.position = spawnpoint.transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        Animator.SetBool("Jumping", false);
        Horizontal = Input.GetAxisRaw("Horizontal");

        if (Horizontal < 0.0f) transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
        else if (Horizontal > 0.0f) transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        Animator.SetBool("Running", Horizontal != 0.0f);

        //Detecta si estás tocando el suelo
        if (Physics2D.Raycast(transform.position, Vector3.down, 0.1f))
        {
            Grounded = true;
        }
        else Grounded = false;


        if (Input.GetKeyDown(KeyCode.W) && Grounded || Input.GetKeyDown(KeyCode.UpArrow) && Grounded)
        {
            Animator.SetBool("Jumping", true);

            Jump();
        }
        if (Input.GetKeyDown(KeyCode.Space) && Time.time > LastShoot + 0.25f)
        {
            Shoot();
            LastShoot = Time.time;
        }
    
    }

    //Fisicas
    private void FixedUpdate()
    {
        Rigidbody2D.velocity = new Vector2(Horizontal, Rigidbody2D.velocity.y);
    }
    private void Jump()
    {
        Rigidbody2D.AddForce(Vector2.up * JumpForce);
    } 
    private void Shoot()
    {
        Vector3 direction;
        if (transform.localScale.x == 1.0f) direction = Vector3.right;
        else direction = Vector3.left;

        GameObject bullet = Instantiate(Bullet, transform.position + direction * 0.1f, Quaternion.identity);
        bullet.GetComponent<Bullet>().SetDirection(direction);
    }
    public void Hit()
    {
        Health = Health - 1;
        if (Health == 0) Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "plataformaMovible")
        {
            transform.parent = collision.transform;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "plataformaMovible")
        {
            transform.parent = null;
        }
    }

}
