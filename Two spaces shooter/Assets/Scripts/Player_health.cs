using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_health : MonoBehaviour
{

    // Static reference to the Player (can be used in other scripts).
    public static Player_health instance = null;
    // Player health.
    public int player_Health = 1;

    private void Awake()
    {
        // Setting up the references.
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    // Method of taking damage by the player
    public void GetDamage(int damage)
    {
        // Reduce the health by the damage amount.
        player_Health -= damage;

        // If the player does not have a health...
        if (player_Health <= 0)
        {
            // Call the player destruction method
            Destruction();
        }
    }
    // Method destruction player.
    void Destruction()
    {
        // Destroy the current player object.
        Destroy(gameObject);
    }

}
