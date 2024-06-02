using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class EndLevel : MonoBehaviour
{
    public Text timerText;
    public GameObject gameOverPanel;
    public GameObject playAgainButton;
    public GameObject quitButton;

    private float startTime;
    private bool gameEnded = false;

    public float rotationSpeed = 100f;


    private void Start()
    {
        startTime = Time.time;
    }
    


    private void Update()
    {
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime, Space.World);

        if (!gameEnded)
        {
            // Update timer
            float elapsedTime = Time.time - startTime;
            UpdateTimerText(elapsedTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Player"))
        {
            Debug.Log("Plauyer");
            EndGame();
        }
    }


    private void EndGame()
    {
        // Set game as ended

        Time.timeScale = 0f;
        gameEnded = true;

        // Disable player controls or any other relevant gameplay elements

        // Show game over panel
        gameOverPanel.SetActive(true);

        // Calculate total game time
        float elapsedTime = Time.time - startTime;

        // Display total game time
        UpdateTimerText(elapsedTime);

        // Enable play again and quit buttons
        playAgainButton.SetActive(true);
        quitButton.SetActive(true);
    }

    private void UpdateTimerText(float time)
    {
        int minutes = Mathf.FloorToInt(time / 60f);
        int seconds = Mathf.FloorToInt(time % 60f);
        string timerString = string.Format("{0:00}:{1:00}", minutes, seconds);
        timerText.text = "Time: " + timerString;
    }

    public void PlayAgain()
    {
        Time.timeScale = 1f;
        // Reset the game or reload the scene
        // Example: SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void QuitGame()
    {
        // Quit the application
        // Example: Application.Quit();
        Application.Quit();
    }
}
