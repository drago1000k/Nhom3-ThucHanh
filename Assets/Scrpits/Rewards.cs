using UnityEngine;

public class Rewards : MonoBehaviour
{
    public int score = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameManager.Instance.AddScore(score);
            gameObject.SetActive(false);
        }
    }

}
