using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float speed;
    Rigidbody2D rigibody;
    public Text collectedText;
    public static int collectedAmount = 0;
    public GameObject slashPrefab;
    public float slashSpeed;
    public float slashScale = 1.0f;
    private float lastSlash;
    public float slashDelay;

    void Start()
    {
        rigibody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {

        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        float slashHor = Input.GetAxisRaw("SlashHorizontal");
        float slashVer = Input.GetAxisRaw("SlashVertical");


        if ((slashHor != 0 || slashVer != 0) && Time.time > lastSlash + slashDelay)
        {
            Slash(slashHor, slashVer);
            lastSlash = Time.time;
        }


        if (!Mathf.Approximately(horizontal, 0) || !Mathf.Approximately(vertical, 0))
        {
            rigibody.linearVelocity = new Vector2(horizontal * speed, vertical * speed);
        }
        else
        {
            rigibody.linearVelocity = Vector2.zero;
        }


        collectedText.text = "Coins: " + collectedAmount;
    }

    void Slash(float x, float y)
    {
        GameObject slash = Instantiate(slashPrefab, transform.position, transform.rotation);
        Rigidbody2D slashRigidbody = slash.AddComponent<Rigidbody2D>();
        slashRigidbody.gravityScale = 0;


        slash.transform.localScale *= slashScale;

        Vector2 slashVelocity = new Vector2(
            (x < 0) ? Mathf.Floor(x) * slashSpeed : Mathf.Ceil(x) * slashSpeed,
            (y < 0) ? Mathf.Floor(y) * slashSpeed : Mathf.Ceil(y) * slashSpeed
        );
        slashRigidbody.linearVelocity = slashVelocity;

        if (slashVelocity != Vector2.zero)
        {
            float angle = Mathf.Atan2(slashVelocity.y, slashVelocity.x) * Mathf.Rad2Deg;
            slash.transform.rotation = Quaternion.Euler(0, 0, angle);
        }
    }

    public void IncreaseSlashSize(float amount)
    {
        slashScale += amount; 
    }
}