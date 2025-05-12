using UnityEngine;

public class KillMonster : MonoBehaviour
{
    public void OnCollisionEnter2D_Custom(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Monster"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
