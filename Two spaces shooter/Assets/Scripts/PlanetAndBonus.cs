using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetAndBonus : MonoBehaviour
{
    //An array the planets prefab to be spawned
    public GameObject[] obj_Planets;
    //How long bettwen each planets spawn
    public float time_palnets_spawn;
    //The speed at whitch the planets moves;
    public float speed_planets;

    //Planets list 
    //We will use this list so that the palnets do not repeat

    List<GameObject> planetsList=new List<GameObject>();

    private void Start()
    {
        //Start function PlanetsCreation as a coroutime.
        StartCoroutine(PlanetsCreation());
    }

    IEnumerator PlanetsCreation()
    {
        //Fill the list with planets 
        for(int i = 0; i < obj_Planets.Length; i++)
        {
            planetsList.Add(obj_Planets[i]);
        }
        //wait 7 seconds after the game started...

        yield return new WaitForSeconds(7);

        //Create planets 

        while (true)
        {
            //Select a random planet for the list 
            int randomIndex=Random.Range(0,planetsList.Count);
            //Create an instance of the planet ,taking into account the limits of the player,s movement width
            //The planet will be created above the camera`s visibility
            //The planets will move at an angle in the range of -25 to 25
            GameObject new_Planet = Instantiate(planetsList[randomIndex],



                new Vector2(Random.Range(Player.instance.borders.minY, Player.instance.borders.maxX),
                Player.instance.borders.maxY * 1.5f),
                Quaternion.Euler(0, 0, Random.Range(-25, 25)));

            //Remove the selected planet from the list
            planetsList.RemoveAt(randomIndex);
            //if the list empty ,fill at again 

            if(planetsList.Count == 0)
            {
                for(int i=0;i< obj_Planets.Length; i++)
                {
                    planetsList.Add(obj_Planets[i]);
                }
            }
            //On yhe created planet we find the component MovingObjects and set speed of movement
            new_Planet.GetComponent<ObjectMoving>().speed = speed_planets;
            yield return new WaitForSeconds(time_palnets_spawn);


        }
    }



}
