using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class L4PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    bool isJumping = true;
    public float JumpPower = 5.0f;


    public GameObject text;

    bool isGameOver = false;
    SpriteRenderer sr;
    Color a;
    int count = 1;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        isJumping = true;
        Debug.Log("Player : isJumping = true");
        text.SetActive(false);
        a = sr.color;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            Debug.Log("Player : Floor 충돌");
            if (count < 1)
            {
                text.SetActive(true);
                sr.color = Color.red;
                isGameOver = true;
            }
            else
            {
                count--;
            }
        }

        if (collision.gameObject.CompareTag("Enemy"))
        {
             text.SetActive(true);
             sr.color = Color.red;
            isGameOver = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!isGameOver)
        {
            if (Keyboard.current.spaceKey.wasPressedThisFrame)
            {
                Debug.Log("Player : 점프(Space Bar Pressed)");
                rb.linearVelocity = new Vector2(0.0f, JumpPower);
                sr.color = Color.blue;
                isJumping = true;
            }
            else
            {
                sr.color = a;
            }
        }
    }
}
