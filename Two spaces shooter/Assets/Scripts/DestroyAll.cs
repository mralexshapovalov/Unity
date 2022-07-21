using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAll : MonoBehaviour
{

    //Referance to the BoxCllider 2d component 
    private BoxCollider2D _bonder_Collider;
    //Vector for storing sizes Cmaera
    private Vector2 _viewport_Size;

    private void Awake()
    {
        //Setting up the refereces.
        //In the current objects,find the BoxCliider2D component.

        _bonder_Collider = GetComponent<BoxCollider2D>();

    }
    private void Start()
    {
        //Call the ResizeCollider method
        ResizeCollider();

    }
    //Methoud Resize Collider
    //The size of the collider is adjusted th the size of the camera

    void ResizeCollider()
    {
        //Get the size of the upper right corner and multyoly it by 2.
        _viewport_Size = Camera.main.ViewportToWorldPoint(new Vector2(1, 1)) * 2;
        //Increase the width by 1.5
        _viewport_Size.x *= 1.5f;
        //Increase the height by 1.5
        _viewport_Size.y *= 1.5f;
        //Change the size.
        _bonder_Collider.size = _viewport_Size;
    }
    public void OnTriggerExit2D(Collider2D coll)
    {
        switch (coll.tag)
        {
            case "Planet":
                Destroy(coll.gameObject);
                break;
        }
    }



}
