using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed = 2f; 
    public float changeDirectionTime = 2f; 
    public float patrolRange = 5f; 

    private Vector2 startPoint; 
    private Vector2 direction; 
    private float timer; 
    private Rigidbody2D rb;

    void Start()
    {
        startPoint = transform.position; 
        ChangeDirection(); 
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        timer += Time.deltaTime;


        transform.Translate(direction * speed * Time.deltaTime);


        if (Vector2.Distance(transform.position, startPoint) > patrolRange)
        {
            direction = -direction; 
            timer = 0; 
        }


        if (timer >= changeDirectionTime)
        {
            ChangeDirection();
        }
    }

    void ChangeDirection()
    {

        float randomX = Random.Range(-1f, 1f);
        float randomY = Random.Range(-1f, 1f);

        direction = new Vector2(randomX, randomY).normalized; 
        timer = 0; 
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Slash")
        {
            Destroy(gameObject);

        }

    }
}