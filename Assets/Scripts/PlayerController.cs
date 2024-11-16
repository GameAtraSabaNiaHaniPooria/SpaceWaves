using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 3f; 
    public float boostedSpeed = 6f; 
    private float currentSpeed; 

    public float rotationAngle = 25f; 
    private Rigidbody2D rb;
    private bool movingUp = true;
    public bool isGameOver = false; 

    public GameObject gameOverCanvas;

    
    private float score = 0f; 
    private float highScore = 0f; 

    public Text scoreText1;
    public Text scoreText2;
    public Text highScoreText;   

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        if (gameOverCanvas != null)
        {
            gameOverCanvas.SetActive(false); 
        }

        
        highScore = PlayerPrefs.GetFloat("HighScore", 0f);
        currentSpeed = moveSpeed; 
        UpdateUI();
    }

    void Update()
    {
        if (isGameOver) return; 

       
        score += Time.deltaTime;

       
        UpdateUI();

        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            movingUp = !movingUp;  
            UpdateRotation(); 
        }

       
        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
        {
            currentSpeed = boostedSpeed; 
        }
        else
        {
            currentSpeed = moveSpeed; 
        }
    }

    void FixedUpdate()
    {
        if (isGameOver) return;

        float verticalMovement = movingUp ? currentSpeed : -currentSpeed;
        rb.linearVelocity = new Vector2(0, verticalMovement); 

        float angle = movingUp ? rotationAngle : -rotationAngle;
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Obstacle") && !isGameOver)
        {
            GameOver();
        }
    }

    void GameOver()
    {
        isGameOver = true;

      
        rb.linearVelocity = Vector2.zero;

        
        if (score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetFloat("HighScore", highScore);
            PlayerPrefs.Save();
        }

        
        if (gameOverCanvas != null)
        {
            gameOverCanvas.SetActive(true);
        }
    }

    void UpdateRotation()
    {
        float angle = movingUp ? 30f : -30f;
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    void UpdateUI()
    {
        if (scoreText1 != null)
            scoreText1.text = $"Score: {score:F2}";

        if (scoreText2 != null)
            scoreText2.text = $"Score: {score:F2}";

        if (highScoreText != null)
            highScoreText.text = $"High Score: {highScore:F2}";
    }
}
