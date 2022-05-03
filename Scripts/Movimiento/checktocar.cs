using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checktocar : MonoBehaviour
{

    //cojo las posiciones con el SerializseField
    //transformando objetos públicos en privados
    [SerializeField] Transform Checkpoint;
    [SerializeField] Transform spawnpoint;

    private Animator Animator;

    private BoxCollider2D BoxCollider2D;

    private void Start()
    {
        //Adquiero los componentes tanto del rigidbody como del animador
        Animator = GetComponent<Animator>();
        BoxCollider2D = GetComponent<BoxCollider2D>();

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            //Inicializo la animación
            Animator.SetBool("tocar", true);

            //transformo la posición del spawn a la del checkpoint
            //esto se puede usar como prefab
            spawnpoint.position = Checkpoint.transform.position;

            //Destruyo el boxcollider para que no se vuelva a activar el trigger
            Destroy(BoxCollider2D);
        }
    }
}
