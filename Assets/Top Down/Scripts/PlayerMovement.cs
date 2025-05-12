using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public static PlayerMovement Player;

    public Rigidbody2D RB;
    public float Speed = 5;
    public ProjectileController BulletPrefab;

    private void Awake()
    {
        // Record the player to a static variable for easy access
        Player = this;
    }

    void Update()
    {
        // Movement code
        Vector2 vel = Vector2.zero;
        if (Input.GetKey(KeyCode.D)) vel.x = Speed;
        else if (Input.GetKey(KeyCode.A)) vel.x = -Speed;
        if (Input.GetKey(KeyCode.W)) vel.y = Speed;
        else if (Input.GetKey(KeyCode.S)) vel.y = -Speed;
        RB.linearVelocity = vel;

        // If I click, shoot!
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            float angle = Mathf.Atan2(pos.y - transform.position.y, pos.x - transform.position.x) * Mathf.Rad2Deg;
            Instantiate(BulletPrefab, transform.position, Quaternion.Euler(0, 0, angle));
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // If I walk into the exit...
        if (other.gameObject.CompareTag("Exit"))
        {
            SceneManager.LoadScene("You Win");
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        // If the player collides with a monster, the game ends
        if (other.gameObject.CompareTag("Monster"))
        {
            SceneManager.LoadScene("You Lose");
        }

        // If the player collides with a hazard, the game ends
        if (other.gameObject.CompareTag("Hazard"))
        {
            SceneManager.LoadScene("You Lose");
        }
    }
}
