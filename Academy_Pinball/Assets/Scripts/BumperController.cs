using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BumperController : MonoBehaviour
{
    public Collider bola;
    public float multiplier;
    public Animator animator;

    public Color[] colors;
    

    private int hitCounter;
    private Renderer ren;

    private void Start()
    {
        hitCounter = 0;
        ren = GetComponent<Renderer>();
        animator = GetComponent<Animator>();

        ren.material.color = colors[hitCounter];
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider == bola)
        {
            Rigidbody bolaRb = bola.GetComponent<Rigidbody>();
            bolaRb.velocity *= multiplier;

            animator.SetTrigger("hit");
            ChangeColorOnHit();
            Debug.Log("nabrak");
        }
    }

    private void ChangeColorOnHit()
    {
        hitCounter++;
        ren.material.color = colors[hitCounter % 3];
    }
}
