using UnityEngine;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public List<SumoCollisionController> sumoCollisionControllers = new List<SumoCollisionController>();
    [SerializeField] private UIManager uIManager;

    private int aliveCount;
    public bool isStart;
    public int score;



    public void SetBestScore()
    {
        if (score >= PlayerPrefs.GetInt("BestScore"))
        {
            PlayerPrefs.SetInt("BestScore", score);
        }
    }



    public void CheckGameEnd(bool _time)
    {
        aliveCount = 0;

        for (int i = 0; i < sumoCollisionControllers.Count; i++)
        {
            if (sumoCollisionControllers[i].isGround)
            {
                aliveCount++;
            }
        }

        if (aliveCount is 1 || _time)
        {
            if (!_time)
            {
                if (sumoCollisionControllers[0].isGround)
                {
                    uIManager.SetWinPanel();
                }

                else
                {
                    uIManager.SetLosePanel();
                }
            }

            else
            {
                uIManager.SetLosePanel();
            }
        }
    }
}
