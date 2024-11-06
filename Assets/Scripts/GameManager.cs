using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.IO;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI levelText;
    private int score;
    private float timeLeft = 120f;
    public int currentLevel = 1;
    public GameObject pauseMenu;
    public GameObject gameOverMenu;
    public GameObject gameEndedMenu;
    public bool Tuto = false;

    public GameObject maze1;
    private bool spawned = false;

    private void Start()
    {
        score = 0;
        UpdateScoreText();
        UpdateTimerText();
        UpdateLevelText();
    }

    private void Update()
    {
        UpdateTimer();

        if (score >= currentLevel * 100)
        {
            LevelUp();
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            TogglePause();
        }

        if (!Tuto && currentLevel == 3 && !spawned)
        {
            Spawner enemySpawner = FindObjectOfType<Spawner>();
            enemySpawner.spawnMaze();
            spawned = true;
        }
    }

    public int GetScore() {  return score; }

    public void TutoMode()
    {
        timeLeft = 500f;
        Tuto = true;
    }

    public void TogglePause()
    {
        if (Time.timeScale == 1)
        {
            Time.timeScale = 0;
            pauseMenu.SetActive(true); 
        }
        else
        {
            Time.timeScale = 1; 
            pauseMenu.SetActive(false);
        }
    }

    private void LevelUp()
    {
        currentLevel++;
        timeLeft += Random.Range(5,15);

        Spawner enemySpawner = FindObjectOfType<Spawner>();
        if (enemySpawner != null)
        {
            enemySpawner.AdjustSpawnRate(currentLevel);
        }

        UpdateLevelText();
    }

    public void AddScore(int points)
    {
        score += points;
        UpdateScoreText();
    }

    void UpdateScoreText()
    {
        scoreText.text = "Score: " + score;
    }

    void UpdateTimer()
    {
        timeLeft -= Time.deltaTime;

        if (timeLeft <= 0)
        {
            timeLeft = 0;
            GameOver();
        }

        UpdateTimerText();
    }

    void GameOver()
    {
        Time.timeScale = 0;
        gameOverMenu.SetActive(true);
    }

    void EndGame()
    {
        Time.timeScale = 0;
        gameEndedMenu.SetActive(true);
    }

    void UpdateTimerText()
    {
        timerText.text = "Time: " + Mathf.FloorToInt(timeLeft).ToString();
    }

    void UpdateLevelText()
    {
        levelText.text = "Level: " + currentLevel;
        StartCoroutine(AnimateLevelText());
    }

    IEnumerator AnimateLevelText()
    {
        levelText.color = Color.yellow;
        yield return new WaitForSeconds(1f);
        levelText.color = Color.white;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void PumpkinAttack()
    {
        timeLeft -= 5f;
    }

    public void MazeTouch()
    {
        GameOver();
    }
}
