using UnityEngine;
using KardasTag;

public class TitleController : MonoBehaviour
{
    private Transform cameraTransform;



    private void Start()
    {
        GetComponentValues();
    }



    private void Update()
    {
        SetTitleTextRotation();
    }



    private void SetTitleTextRotation()
    {
        transform.rotation = Quaternion.LookRotation(-(transform.position - cameraTransform.position));
    }



    private void GetComponentValues()
    {
        cameraTransform = GameObject.FindGameObjectWithTag(Tag.CAMERA).transform;
    }
}