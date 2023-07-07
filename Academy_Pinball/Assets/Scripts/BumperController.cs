using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BumperController : MonoBehaviour
{
    public Collider bola;
    public float multiplier;
    public Animator animator;

    public Color color;

    private void Start()
    {
        GetComponent<Renderer>().material.color = color;
        animator = GetComponent<Animator>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider == bola)
        {
            Rigidbody bolaRb = bola.GetComponent<Rigidbody>();
            bolaRb.velocity *= multiplier;

            animator.SetTrigger("hit");
            Debug.Log("nabrak");
        }
    }
}
