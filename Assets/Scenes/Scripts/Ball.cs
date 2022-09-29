using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public int damage;
    public PlayerHealth playerHealth;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<PlayerHealth>(out PlayerHealth playerHealth))
        {
            playerHealth.TakeDamage(damage);
            
        }
        Destroy(gameObject);
    }
    //private void Awake()
    //{
    //    Destroy(gameObject, life);
    //}

    //public void BallCollisionEnter(Collision collision)
    //{


    //    Destroy(collision.gameObject);
    //    Destroy(gameObject);
    //}

}
