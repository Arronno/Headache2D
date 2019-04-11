using UnityEngine;

public class RedPlayer : MonoBehaviour
{
    Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.zero;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.AddForce(new Vector2(0.2f, 0f), ForceMode2D.Impulse);
        }
   
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.AddForce(new Vector2(-0.2f, 0f), ForceMode2D.Impulse);
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            rb.AddForce(new Vector2(0f, 0.5f), ForceMode2D.Impulse);
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            rb.AddForce(new Vector2(0f, -0.2f), ForceMode2D.Impulse);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Coin"))
        {
            other.gameObject.SetActive(false);

            FindObjectOfType<GameManager>().EndGame();
        }

        if (other.CompareTag("LeftBound") || other.CompareTag("RightBound") || other.CompareTag("UpperBound"))
        {
            FindObjectOfType<GameManager>().EndGame();
        }
    }
}
