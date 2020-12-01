using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DamageObject : MonoBehaviour

{
    Animator animator;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        

        if (collision.transform.CompareTag("Player"))
        {
            Debug.Log("Te han pegao bro");
            animator = collision.gameObject.GetComponent<Animator>();
            animator.SetBool("Hit", true);
            Destroy(collision.gameObject,0.55f);
        }
    }
}
