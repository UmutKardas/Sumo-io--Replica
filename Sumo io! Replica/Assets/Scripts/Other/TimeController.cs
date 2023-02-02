using System.Collections;
using UnityEngine;
using TMPro;

public class TimeController : MonoBehaviour
{

    [SerializeField] private GameManager gameManager;
    [SerializeField] private TMP_Text timerText;
    [SerializeField] private float timeStep;


    private int second = 60;
    private int minute = 2;



    private void Start()
    {
        StartCoroutine(nameof(SetTime));
    }



    public IEnumerator SetTime()
    {
        while (gameManager.isStart)
        {
            DescreaSecond();
            SetTimeTextValues();
            yield return new WaitForSeconds(timeStep);
        }
    }



    private void DescreaSecond()
    {
        second--;

        if (second <= 0)
        {
            second = 60;
            DecreaseMinute();
        }
    }


    private void DecreaseMinute()
    {
        minute--;

        if (minute < 0)
        {
            gameManager.CheckGameEnd(true);
        }
    }


    private void SetTimeTextValues()
    {
        timerText.text = minute.ToString("00") + " : " + second.ToString("00");
    }
}
