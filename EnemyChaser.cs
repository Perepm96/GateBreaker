using UnityEngine;

public class EnemyChaser : MonoBehaviour
{
    public Transform player; 
    public float speed = 3f; 
    public float stopDistance = 1f; 

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); 
    }

    void Update()
    {
        ChasePlayer();
    }

    void ChasePlayer()
    {

        if (player == null)
        {
            Debug.LogWarning("Player not assigned!");
            return;
        }


        Vector2 direction = (player.position - transform.position).normalized;


        if (Vector2.Distance(transform.position, player.position) > stopDistance)
        {
            rb.linearVelocity = direction * speed;
        }
        else
        {
            rb.linearVelocity = Vector2.zero; 
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Slash")
        {
            Destroy(gameObject);

        }

    }

}