using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [Header("Rect Transform")]
    [SerializeField] private RectTransform startPanel;
    [SerializeField] private RectTransform gameStartPanel;
    [SerializeField] private RectTransform gamePanel;
    [SerializeField] private RectTransform winPanel;
    [SerializeField] private RectTransform losePanel;


    [Header("DOTween")]
    [SerializeField] private Ease ease;
    [SerializeField] private float endYPosition;
    [SerializeField] private float duration;



    [Header("Start Current Time")]
    private int startCurrentTime = 3;
    private bool isActive;
    [SerializeField] private TMP_Text countTimeText;


    [Header("Time")]
    [SerializeField] private float time;
    private float currentTime;


    [Header("Resume Button")]
    [SerializeField] private Button resumeButton;
    [SerializeField] private Sprite playSprite;
    [SerializeField] private Sprite resumeSprite;
    private bool resumeButtonBool;


    [Header("Other")]
    [SerializeField] private GameObject touchObject;
    [SerializeField] private GameManager gameManager;
    [SerializeField] private TimeController timeController;
    [SerializeField] private PlayerMovementController playerMovementController;
    [SerializeField] private PlayerAnimationController playerAnimationController;
    [SerializeField] private CinemaMachineController cinemaMachineController;



    [Header("Score")]
    [SerializeField] private float highScore;
    [SerializeField] private float losePanelHighScore;
    [SerializeField] private TMP_Text highScoreText;
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private TMP_Text losePanelScoreText;
    [SerializeField] private TMP_Text losePanelHighScoreText;


    private void Awake()
    {
        Time.timeScale = 1;
        SetHighScore();
    }



    private void SetHighScore()
    {
        highScore = PlayerPrefs.GetInt("BestScore");
        highScoreText.text = highScore.ToString();
    }



    public void SetStartPanelMove()
    {
        startPanel.DOMoveY(endYPosition, duration).SetEase(ease);
        gameStartPanel.DOMoveY(960, duration).SetEase(ease).OnComplete(() => isActive = true);
    }



    private void Update()
    {
        if (isActive)
            CountTime();
    }



    public void CountTime()
    {
        if (currentTime <= 0)
        {
            currentTime = time;

            if (startCurrentTime >= 0)
                countTimeText.DOFade(0, 1).OnComplete(() => OnComplete());
        }

        else
        {
            currentTime -= Time.deltaTime;
        }

    }



    public void SetWinPanel()
    {
        touchObject.SetActive(false);
        gamePanel.gameObject.SetActive(false);
        winPanel.gameObject.SetActive(true);
        playerAnimationController.SetPlayerDance();
        cinemaMachineController.ChangeCamera();
        playerMovementController.enabled = false;
        winPanel.DOMoveY(-460, duration).SetEase(ease);
    }



    public void SetLosePanel()
    {
        losePanelScoreText.text = gameManager.score.ToString();
        losePanelHighScore = PlayerPrefs.GetInt("BestScore");
        losePanelHighScoreText.text = losePanelHighScore.ToString();
        touchObject.SetActive(false);
        gamePanel.gameObject.SetActive(false);
        losePanel.gameObject.SetActive(true);
        losePanel.DOMoveY(-540, duration).SetEase(ease).OnComplete(() => Time.timeScale = 0);
    }



    public void SetScoreTextValue()
    {
        scoreText.text = gameManager.score.ToString();
    }



    private void OnComplete()
    {
        startCurrentTime--;
        countTimeText.text = startCurrentTime.ToString();
        countTimeText.DOFade(1, 0);

        if (startCurrentTime is 0)
        {
            isActive = false;
            gameStartPanel.DOMoveY(2960, duration).SetEase(ease).OnComplete(() =>
             gamePanel.DOMoveY(1960, duration).SetEase(ease).OnComplete(() => touchObject.SetActive(true)));
            gameManager.isStart = true;
            StartCoroutine(timeController.SetTime());
        }
    }



    public void SetRestartButton()
    {
        SceneManager.LoadScene(0);
    }



    public void SetResumeButton()
    {
        if (!resumeButtonBool)
        {
            Time.timeScale = 0;
            resumeButton.GetComponent<Image>().sprite = playSprite;
            resumeButtonBool = true;
        }

        else
        {
            Time.timeScale = 1;
            resumeButton.GetComponent<Image>().sprite = resumeSprite;
            resumeButtonBool = false;
        }
    }
}
