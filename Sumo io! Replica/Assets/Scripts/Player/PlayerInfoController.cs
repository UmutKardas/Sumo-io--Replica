using UnityEngine;
using TMPro;


public class PlayerInfoController : MonoBehaviour
{

    [SerializeField] private CountryController countryController;
    [SerializeField] private SpriteRenderer playerFlagIcon;
    [SerializeField] private TMP_Text playerTitleText;
    [SerializeField] private TMP_InputField playerTitleInput;



    private void Start()
    {
        SetRandomPlayerCountry();
    }



    public void SetPlayerName()
    {
        playerTitleText.text = playerTitleInput.text;
    }



    private void SetRandomPlayerCountry()
    {
        playerFlagIcon.sprite = countryController.countryDatas[Random.Range(0, countryController.countryDatas.Length)].countryFlag;
    }
}
