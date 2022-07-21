using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowthePatch : MonoBehaviour
{
    //An array of waypoints along which the enemy moves in a wave 

    public Transform[] path_points;

    //The speed at which the enemy moves.

    public float speed_Enemy;

    //Destroy the surviving enemies at the end of the path or send then tj the beginning pf the path

    public bool is_return;


    //Store Vector3 or all waypoints Bebug___________________________________________________________

    public Vector3[] _new_Position;

    ///_________________________________
    ///


    //Current waypoint to whitch the enemy is moving

    private int  cur_Pos;

    private void Start()
    {
        _new_Position = NewPositionByPath(path_points);
    }

    private void Update()
    {
        //Move the current enemy to the points of the path at a given speed

        transform.position = Vector3.MoveTowards(transform.position, _new_Position[cur_Pos],speed_Enemy *Time.deltaTime);
        //If the current enemy has reached the point of the path...
        if (Vector3.Distance(transform.position, _new_Position[cur_Pos]) < 0.2f)
        {
            //Set the next waypoint.
            cur_Pos++;
            //If the current enemy reaches the last point an is reurn =true,sen the enemy th the starting waypoint...

            if (is_return && Vector3.Distance(transform.position, _new_Position[_new_Position.Length - 1]) < 0.3f) cur_Pos = 0;
        }
        //If the current enemy reaches the last point and is_return =false ,destroy the enemy

        if (Vector3.Distance(transform.position, _new_Position[_new_Position.Length-1])<0.2f && !is_return)
        {
            Destroy(gameObject);
        }

    }
    Vector3[] NewPositionByPath(Transform[] pathPos)
    {
        Vector3[] pathHositions = new Vector3[pathPos.Length];
        for(int i = 0; i < pathPos.Length; i++)
        {
            pathHositions[i] = pathPos[i].position;
        }
        return pathHositions;
    }


}
