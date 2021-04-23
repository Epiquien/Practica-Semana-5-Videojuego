using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieController : MonoBehaviour
{
    private SpriteRenderer sr;

    private Animator _animator;

    private Rigidbody2D rb2d;
    
    public float speed ;
    public float dirx;
    

    private int velocidad ;
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        dirx = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * dirx * speed);
        if (dirx > 0)
        {
            sr.flipX = false;
        }

        if (dirx < 0)
        {
            sr.flipX = true;
        }



    }

     void OnTriggerEnter2D(Collider2D obj)
    {
        velocidad = velocidad - 2;
    }

    private void SetRunZombie()
    {
        _animator.SetInteger("Estado", 0);
    }
}
