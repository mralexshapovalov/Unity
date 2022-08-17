using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ShootingSettings
{
    //Change of a shot enemy in the form of a slider 
    [Range(0, 100)]
    public int shot_Chance;
    //time interval within which the shot occurs
    public float shot_Time_Min, shot_Time_max;
}
public class Wave : MonoBehaviour
{
    public ShootingSettings shootingSettings;
    [Space]
    // The enemy prefab to be spawned
    public GameObject obj_Enemy;
    //Amout of enemies in one wave
    public int count_in_Wave;
    //The speeed if whitch the enemy moves
    public float speed_Enemy;
    //time between spawn enemy in wave
    public float time_Spawn;
    //An array of waypoints along whitch the enemy moves is a wave
    public Transform[] path_Points;
    //Destroy the survining enemies at the en of the path or send then to the begining of the path
    public bool is_return;


    // Test Have
    // an infinitye wave appears every 5 second to debag the wave

    [Header("Test wave!")]

    public bool is_Test_Wave;

    private FollowthePatch follow_Component;
    private Enemy enemy_Component_Script;

    private void Start()
    {
        //Start function CrateEnemyWave as a coroutine
        StartCoroutine(CreateEnemyWave());
    }

    IEnumerator CreateEnemyWave()
    {
        for(int i = 0; i < count_in_Wave; i++)
        {
            //Create an instance of the prefab obj_Enemy in the obj_Enemy position ant without rotation

            GameObject new_enemy =Instantiate(obj_Enemy,obj_Enemy.transform.position,Quaternion.identity);

            //Try and find an FollowThePath sqcript on the gamejbject new _enemy
            follow_Component = new_enemy.GetComponent<FollowthePatch>();
            //Specify the path that will move the new_enemy
            follow_Component.path_points = path_Points;
            //Specify the speed with whitch the new enemy will move 
            follow_Component.speed_Enemy= speed_Enemy;
            //Destroy the survining enemies at the end of the path or send them to the beginign of the path

            follow_Component.is_return = is_return;

            //Try and find an Enemy scripts ob the gameobject new_enemy
            enemy_Component_Script = new_enemy.GetComponent<Enemy>();
            //Specify shot chance a new enemy
            enemy_Component_Script.shot_Chance = shootingSettings.shot_Chance;
            enemy_Component_Script.shot_time_Min = shootingSettings.shot_Time_Min;
            enemy_Component_Script.shot_time_Max = shootingSettings.shot_Time_max;
            new_enemy.SetActive(true);
            //Every time_Spavn seconds
            yield return new WaitForSeconds(time_Spawn);

        }

        if (is_Test_Wave)
        {
            //Infinitely generate the current wave every 5 seconds
            yield return new WaitForSeconds(5f);

            StartCoroutine(CreateEnemyWave());
        }

        //If is_return =false destroy the enemy ay the and of the path


        if (!is_return)
        {
            Destroy(gameObject);
        }
    }


    //To make it easier to set up enemy waypoints,connect them whith a line
    private void OnDrawGizmos()
    {
        NewPositionByPath(path_Points);

    }
    void NewPositionByPath(Transform[] path)
    {
        Vector3[] path_Positons=new Vector3[path.Length];

        for(int i = 0; i < path.Length; i++)
        {
            path_Positons[i] = path[i].position;
        }
        path_Positons = Smoothing(path_Positons);
        path_Positons = Smoothing(path_Positons);
        path_Positons = Smoothing(path_Positons);
        for (int i=0;i< path_Positons.Length-1; i++)
        {
            Gizmos.DrawLine(path_Positons[i], path_Positons[i+1]);
        }
    }
    Vector3[] Smoothing(Vector3[] path_Positons)
    {
        Vector3[] new_Path_Position = new Vector3[(path_Positons.Length - 2) * 2 + 2];
        new_Path_Position[0] = path_Positons[0];
        new_Path_Position[new_Path_Position.Length - 1] = path_Positons[path_Positons.Length - 1];
        int j = 1;
        for (int i = 0; i < path_Positons.Length - 2; i++)
        {
            new_Path_Position[j] = path_Positons[i] + (path_Positons[i + 1] - path_Positons[i]) * 0.75f;
            new_Path_Position[j + 1] = path_Positons[i + 1] + (path_Positons[i + 2] - path_Positons[i+1])*0.25f;
            j += 2;

        }
        return new_Path_Position;
    }



}
