using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public Image healthBar;
    public float healthAmount = 100;

    public void Start()
    {
        
    }

    private void Update()
    {

        //if (collision.gameObject. == "Player2")
        if(Input.GetKeyDown(KeyCode.G))
        {
            TakeDamage(20);
        }                     
    }

    public void TakeDamage(float Damage)
    {
        healthAmount -= Damage;
        healthBar.fillAmount = healthAmount / 100;

        if(healthAmount <= 0)
        {
            Destroy(GameObject.FindWithTag("Player"));
        }
    }

    public void Healing(float healPoints)
    {
        healthAmount += healPoints;
        healthAmount = Mathf.Clamp(healthAmount, 0, 100);

        healthBar.fillAmount = healthAmount / 100;
    }

    //public void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.gameObject == "Ball")
    //    {
    //        TakeDamage(20);
    //    }
    //}

}
