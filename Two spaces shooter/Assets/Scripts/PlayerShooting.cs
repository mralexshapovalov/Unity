using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    //Debug all.........................
    // The bullet prefab to be spawned

    public GameObject obj_Bullet;
    //How long between each bullet spawn;

    public float time_Bullet_Spawn = 0.3f;

    //Timer  to be determine when to shoot 


    [HideInInspector]

    public float timer_Shoot;


    private void Update()
    {
        if (Time.time > timer_Shoot)
        {
            timer_Shoot = Time.time + time_Bullet_Spawn;

            //create bullet

            Instantiate(obj_Bullet,transform.position,Quaternion.identity);
        }
    }
}
