using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.SceneManagement;

public class TutorialManager : MonoBehaviour
{
    public TextMeshProUGUI tutorialText;
    private GameManager gameManager;
    private int tutorialStep = 0;
    public GameObject spawner;

    private void Start()
    {
        ShowNextStep();
        gameManager = FindObjectOfType<GameManager>();
        gameManager.TutoMode();
    }

    public void ShowNextStep()
    {
        switch (tutorialStep)
        {
            case 0:
                tutorialText.text = "Welcome\n to Pumpkin Invaders\n Press N when you're ready !";
                PauseForOneSecond(2f);
                break;
            case 1:
                tutorialText.text = "First lesson : use right and left arrow keys to move on your line.\n Try it !";
                PauseForOneSecond(1f);
                break;
            case 2:
                tutorialText.text = "Second lesson : Press space to shoot.";
                PauseForOneSecond(1f);
                break;
            case 3:
                spawner.SetActive(true);
                tutorialText.text = "Tip : Destroy the mean upcoming pumpkins to earn points (top left).";
                PauseForOneSecond(2f);
                break;
            case 4:
                tutorialText.text = "Be careful to the time (top right), when it gets down to zero the game is over";
                PauseForOneSecond(3f);
                break;
            case 5:
                tutorialText.text = "Every 100 points you level up (top center) and get some bonus time but the game is getting harder";
                PauseForOneSecond(3f);
                break;
            case 6:
                Spawner MazeSpawner = FindObjectOfType<Spawner>();
                MazeSpawner.spawnMaze();
                tutorialText.text = "Every 3 levels a maze will get down the screen and you'll have to solve it !";
                PauseForOneSecond(2f);
                break;
            case 7:
                tutorialText.text = "At every moment you can press P to Pause the game and take a breath";
                PauseForOneSecond(1f);
                break;
            case 8:
                tutorialText.text = "Oh and last thing : if you let a pumpkin reach the end of the screen it will cost you some time so don't let that happen !";
                PauseForOneSecond(4f);
                break;
            case 9:
                spawner.SetActive(false);
                tutorialText.text = "I think you’re ready now! Good luck!";
                TutoEnd();
                break;
        }

        tutorialStep++;
    }

    private void Update()
    {
        if (gameManager != null)
        {
            if (Input.GetKeyDown(KeyCode.N) && tutorialStep == 1)
            {
                ShowNextStep();
            }
            if (gameManager.GetScore() >= 30 && tutorialStep == 3)
            {
                ShowNextStep();
            }
            if (gameManager.GetScore() >= 60 && tutorialStep == 4)
            {
                ShowNextStep();
            }
            if (gameManager.GetScore() >= 90 && tutorialStep == 5)
            {
                ShowNextStep();
            }
            if (gameManager.GetScore() >= 120 && tutorialStep == 6)
            {
                ShowNextStep();
            }
            if (gameManager.GetScore() >= 150 && tutorialStep == 7)
            {
                ShowNextStep();
            }
            if (gameManager.GetScore() >= 180 && tutorialStep == 8)
            {
                ShowNextStep();
            }
            if (gameManager.GetScore() >= 210 && tutorialStep == 9)
            {
                ShowNextStep();
            }
        }
    }

    public void PauseForOneSecond(float seconds)
    {
        StartCoroutine(PauseCoroutine(seconds));
    }

    private IEnumerator PauseCoroutine(float seconds)
    {
        Time.timeScale = 0f; 
        yield return new WaitForSecondsRealtime(seconds);
        Time.timeScale = 1f;
    }

    private void TutoEnd()
    {
        StartCoroutine(WaitAndExit());
    }

    private IEnumerator WaitAndExit()
    {
        yield return new WaitForSeconds(3f);

        SceneManager.LoadScene("MainMenu");
    }
}

