using UnityEngine;
using System;



[CreateAssetMenu(fileName = "New Country Data", menuName = "Country Data")]
public class CountryController : ScriptableObject
{
    public CountryData[] countryDatas;
}



[Serializable]
public class CountryData
{
    public Sprite countryFlag;
    public string countryName;
}