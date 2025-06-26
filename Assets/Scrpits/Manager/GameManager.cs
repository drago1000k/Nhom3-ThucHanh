using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public int score = 0;
    private bool isGameOver = false;

    [SerializeField] private Text scoreText;
    [SerializeField] private GameObject scoreUI;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        UpdateScoreUI();
    }

    public void AddScore(int value)
    {
        if (!isGameOver)
        {
            score += value;
            UpdateScoreUI();
        }
    }

    public void TriggerGameOver()
    {
        if (!isGameOver)
        {
            isGameOver = true;
            SceneManager.LoadScene("GameOverScene");
        }
    }

    private void UpdateScoreUI()
    {
        if (scoreText != null)
        {
            scoreText.text = $"Score: {score}";
        }
    }

    public void ResetGame()
    {
        isGameOver = false;
        score = 0;
        SceneManager.LoadScene("SampleScene");
        Time.timeScale = 1f;
    }
}