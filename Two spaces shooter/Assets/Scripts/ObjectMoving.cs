using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMoving : MonoBehaviour
{
    //The speed at which the objects moves

    public float speed;

    private void Update()
    {
        //Move the object verticale with a given speed

        transform.Translate(Vector3.up * speed * Time.deltaTime);

    }
}
