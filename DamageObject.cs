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
            if (gameObject.tag == "LanzaFuego") 
            {
                Debug.Log("Has tocado el lanzafuego");
                Invoke("FireStart", 0.5f);
                Invoke("FireEnd", 3f);
            }
            else 
            {
                Debug.Log("Te han pegao bro");
                animator = collision.gameObject.GetComponent<Animator>();
                animator.SetBool("Hit", true);
                Destroy(collision.gameObject, 0.55f);
            }
        }
    }

    private void FireStart() 
    {
        gameObject.GetComponent<Animator>().enabled = true;
        gameObject.transform.GetChild(0).GetComponent<Collider2D>().enabled = true;
    }

    private void FireEnd() 
    {
        gameObject.GetComponent<Animator>().enabled = false;
        gameObject.transform.GetChild(0).GetComponent<Collider2D>().enabled = false;
    }
}
