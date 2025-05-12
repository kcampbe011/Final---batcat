using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatSwing : MonoBehaviour
{
    public float swingAngle = 45f;
    public float swingDuration = 0.2f;

    private bool isSwinging = false;
    private float swingTimer = 0f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isSwinging = true;
            swingTimer = swingDuration;
            transform.rotation = Quaternion.Euler(0f, 0f, swingAngle);
        }

        if (isSwinging)
        {
            swingTimer -= Time.deltaTime;

            if (swingTimer <= 0f)
            {
                transform.rotation = Quaternion.Euler(0f, 0f, 0f);
                isSwinging = false;
            }
        }
    }

    // This method handles the bat's collision with the monster
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Monster"))
        {
            Destroy(other.gameObject); // Destroy the monster when hit by the bat
        }
    }
}
