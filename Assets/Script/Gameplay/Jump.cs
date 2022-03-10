using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Jump : MonoBehaviour
{
    public GameController gameManager;
    public float velocity = 1;
    private Rigidbody2D rb ;
    
    public Collider2D headCollider;
    public Collider2D bodyCollider;

    public GameObject bird;
    public GameObject shield;

    private GameObject scoreText;

    private Score score;
    private int coins;

    public Text coinsText;
    public Shield shieldTimer;
    public BonusStar scoreTimer;

    public int scoreMultiplier = 1;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
        
    }
     private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Score"))
        {
            Score.scoreText += scoreMultiplier;
        }
            if (other.CompareTag("Shield"))
        {
            headCollider.enabled = false;
            bodyCollider.enabled = true;
            shield.SetActive(true);
            shieldTimer.gameObject.SetActive(true);
            shieldTimer.isCooldown = true;
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("BonusStar"))
        {
            StartCoroutine(StarBonus());
            scoreTimer.gameObject.SetActive(true);
            scoreTimer.isCooldown = true;
            Destroy(other.gameObject);

        }
        if (other.CompareTag("Ground"))
        {
            gameManager.GameOver();
        }
        
        if (other.CompareTag("HardModeOn"))
        {
            StartCoroutine(HardModeOn());
            Destroy(other.gameObject);
        } 
        
        if (other.CompareTag("HardModeOff"))
        {
            StartCoroutine(HardModeOff());
            Destroy(other.gameObject);
        }

        if (other.CompareTag("Coin"))
        {
            coins++;
            coinsText.text = coins.ToString();
            Destroy(other.gameObject);
        }
        
    }
    
    void Update()
    {
        rb.gravityScale *= 1;
        if (Input.GetMouseButtonDown(0))
        {
            rb.velocity = Vector2.up * velocity;
        }
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        gameManager.GameOver();
    }
    private IEnumerator StarBonus()
    {
        scoreMultiplier = 3;
        yield return new WaitForSeconds(5);
        scoreMultiplier = 1;
    }
    private IEnumerator HardModeOn() 
    {
        rb.gravityScale *= -1;
        velocity *= -1;
        yield return new WaitForSeconds(5);
       
    }
    
    private IEnumerator HardModeOff() 
    {
        rb.gravityScale *= 1;
        velocity *= 1;
        yield return new WaitForSeconds(5);
    }
}
