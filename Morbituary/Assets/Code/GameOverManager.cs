using Assets.Code.Actors;
using UnityEngine;

public class GameOverManager : MonoBehaviour
{
    public Player playerHealth;       // Reference to the player's health.
    public float delay = 5f;         // Time to wait before restarting the level


    Animator anim;                          // Reference to the animator component.
    float delayTimer;                     // Timer to count up to restarting the level


    void Awake()
    {
        // Set up the reference.
        anim = GetComponent<Animator>();
    }


    void Update()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        Debug.Log("Enemies left: " + enemies.Length);
        if (enemies.Length == 0)
        {
            anim.SetTrigger("Win");

            delayTimer += Time.deltaTime;
            
            if (delayTimer >= delay)
            {
                Application.LoadLevel("MainMenu");
            }
        }

        // If the player has run out of health...
        if (playerHealth.Health <= 0)
        {
            // ... tell the animator the game is over.
            anim.SetTrigger("GameOver");


            delayTimer += Time.deltaTime;


            if (delayTimer >= delay)
            {
                // .. then reload the main menu.
                Application.LoadLevel("MainMenu");
            }
        }
    }
}