using UnityEngine;
using TMPro;

public class BotTitleController : MonoBehaviour
{

    [SerializeField] private CountryController countryData;
    [SerializeField] private NameController nameData;

    [SerializeField] private SpriteRenderer[] botCountryIcons;
    [SerializeField] private TMP_Text[] botNameTexts;



    private void Start()
    {
        SetRandomBotPlayers();
    }



    public void SetRandomBotPlayers()
    {
        for (int i = 0; i < botNameTexts.Length; i++)
        {
            int index = Random.Range(0, botNameTexts.Length);

            botNameTexts[i].text = nameData.nameDatas[index].name;
            botCountryIcons[i].sprite = countryData.countryDatas[index].countryFlag;
        }
    }
}

