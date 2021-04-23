using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogController : MonoBehaviour
{
    private SpriteRenderer sr;

    private Animator _animator;

    private Rigidbody2D rb2d;

    public GameObject righBullet;
    
    public float  UpSpeed = 80;
    public float speed = 20;

    private int cantidadSaltos = 2;

    private bool puedoSaltar = false;
   
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
                _animator = GetComponent<Animator>();
                rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        SetIdleAnimation();
        
        if (Input.GetKey(KeyCode.RightArrow))
        {
            SetRunAnimation();
            rb2d.velocity = new Vector2(speed, rb2d.velocity.y);
            sr.flipX = false; //Mover Personaje a la derecha
        }
        
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            SetRunAnimation();
            rb2d.velocity = new Vector2(-speed, rb2d.velocity.y);
            sr.flipX = true;  //Mover personaje a la izquierda
        }
        else
        {
            rb2d.velocity = new Vector2(0, rb2d.velocity.y);
            
        }

        if (puedoSaltar)
        {
            cantidadSaltos = 2;
        }
        if (cantidadSaltos > 0)
        {
            if (Input.GetKeyDown( KeyCode.Space) && puedoSaltar)
            {
                cantidadSaltos--;
             
                rb2d.velocity = Vector2.up * UpSpeed;
                puedoSaltar = false;
            }
        }
    }
    
    
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.layer == 8)
            puedoSaltar = true;

    }
    
    private void SetRunAnimation()
    {
        _animator.SetInteger("Estado", 1);
    }

    private void SetIdleAnimation()
    {
        _animator.SetInteger("Estado",0);
    }

    private void SetJumpAnimation()
    {
        _animator.SetInteger("Estado",3);
    }
    private void SetRnJumpAnimation()
    {
        _animator.SetInteger("Estado",2);
    }
    
}
