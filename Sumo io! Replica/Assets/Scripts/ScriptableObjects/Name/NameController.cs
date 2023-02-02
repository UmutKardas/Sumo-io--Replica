using UnityEngine;
using System;


[CreateAssetMenu(fileName = "New Name Data", menuName = "Name Data")]
public class NameController : ScriptableObject
{
    public NameData[] nameDatas;
}



[Serializable]
public class NameData
{
    public string name;
}