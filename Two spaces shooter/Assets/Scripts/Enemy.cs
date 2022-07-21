using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //Enemt health
    public int enemy_health;


    //Method of taking damage by the enemy

    public void GetDamege (int damege)
    {
        //Reduce the health by the damage amount.
        enemy_health -= damege;

        //If the enemy does not have a health...

        if (enemy_health <= 0)
        {
            //Call the enemy destruction methoud 
            Destruction();
        }

    }
    //Methoud destruction enemy;

    private void Destruction()
    {
        //Destoy the current player object
        Destroy(gameObject);
    }
    //If enemy collides player,Player gets the damage

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            GetDamege(1);
            Player_health.instance.GetDamage(1);
        }
       
    }
}
