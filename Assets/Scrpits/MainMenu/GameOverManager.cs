using UnityEngine;
using UnityEngine.UI;

public class GameOverManager : MonoBehaviour
{
    [SerializeField] private Text finalScoreText;

    private void Start()
    {
        if (GameManager.Instance != null)   
        {
            finalScoreText.text = $"SCORE: {GameManager.Instance.score}";
        }
    }

    public void RestartGame()
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.ResetGame();
        }
    }

    public void ExitGame()
    {
        Application.Quit();
        
    }
}