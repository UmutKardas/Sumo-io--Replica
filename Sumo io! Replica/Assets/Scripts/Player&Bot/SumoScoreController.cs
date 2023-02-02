using UnityEngine;

public class SumoScoreController : MonoBehaviour
{
    [SerializeField] private SumoStatsController sumoStatsController;
    [SerializeField] private GameManager gameManager;
    [SerializeField] private UIManager uIManager;
    public float score;


    public void SetScoreIncrease(int _value)
    {
        score += _value;
        if (this.gameObject.name == "Player")
        {
            SetScoreText(_value);
        }

        else
        {
            sumoStatsController.ChangeSumoStats(this.gameObject, score);
        }
    }



    public void SetScoreText(int _value)
    {
        gameManager.score += _value;
        sumoStatsController.ChangeSumoStats(this.gameObject, gameManager.score);
        gameManager.SetBestScore();
        uIManager.SetScoreTextValue();
    }
}
