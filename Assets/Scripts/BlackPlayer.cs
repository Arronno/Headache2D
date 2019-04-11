using UnityEngine;

public class BlackPlayer : MonoBehaviour
{
    Rigidbody2D rb;
    int coinstate = 0;

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
            //Debug.Log("Hit");
            coinstate = 1;
            other.gameObject.SetActive(false);
        }

        if (coinstate == 1 && other.CompareTag("LeftBound"))
        {
            FindObjectOfType<GameManager>().WinGame();
        }

        if (other.CompareTag("RightBound") || other.CompareTag("UpperBound"))
        {
            FindObjectOfType<GameManager>().EndGame();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("RedBall"))
        {
            FindObjectOfType<GameManager>().EndGame();
        }
    }
}