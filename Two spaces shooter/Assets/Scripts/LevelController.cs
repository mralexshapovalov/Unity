using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EnemyWaves
{
    public float timeToStart;

    public GameObject wave;

    public bool is_Last_Wave;



}


public class LevelController : MonoBehaviour
{
    public static LevelController instance;

    public GameObject[] playerShip;

    public EnemyWaves[] enemyWaves;


    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        for(int i = 0; i < enemyWaves.Length; i++)
        {
            StartCoroutine(CreateEnemyWaves(enemyWaves[i].timeToStart, enemyWaves[i].wave));
        }
    }

    IEnumerator CreateEnemyWaves (float delay,GameObject Wave)
    {
        if(delay !=0)
            yield return new WaitForSeconds(delay);

        if (Player.instance != null)
            Instantiate(Wave);
    }

}
