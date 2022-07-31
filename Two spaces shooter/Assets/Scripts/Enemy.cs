using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //Enemt health
    public int enemy_health;



    [Space]
    //The Bullet prefab to be spawned
    public GameObject obj_Bullet;

    //time interval within which the shot occurs 

    public float shot_time_Min,shot_time_Max;

    //the probability pf the enemy's shot;

    public int shot_Chance;


    private void Start()
    {
        //Call the OpenFire in the time interval between shot_Time_Min and shot_Time_Max

        Invoke("OpenFire", Random.Range(shot_time_Min, shot_time_Max));
    }
    //Method openFire

    private void OpenFire()
    {
        if(Random.value < (float)shot_Chance / 100)
        {
            //create an instance of the prefab obj_Bullet int the enemy possition and without rotation

            Instantiate(obj_Bullet,transform.position,Quaternion.identity);
        }
    }



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
