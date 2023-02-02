using System.Collections;
using UnityEngine;
using KardasTag;

public class SumoDeathController : MonoBehaviour
{
    private GameObject groundGameobject;
    [SerializeField] private CinemaMachineController cinemaMachineController;
    [SerializeField] private SumoScoreController sumoScoreController;


    private void Start()
    {
        GetComponentValues();
    }



    private void GetComponentValues()
    {
        groundGameobject = GameObject.FindGameObjectWithTag(Tag.GROUND);
    }



    public void SetSumoDeath()
    {
        StartCoroutine(nameof(SumoDeath));
    }



    IEnumerator SumoDeath()
    {
        yield return new WaitForSeconds(1);

        if (this.gameObject.name == cinemaMachineController.sumoGameobject.name)
        {
            transform.localPosition = new Vector3(100, 100, 100);
            cinemaMachineController.SetNewCameraPosition();
            if (this.gameObject.name == "Player")
            {
                PlayerPrefs.SetFloat("Score", sumoScoreController.score);
            }

            else
            {
                this.gameObject.GetComponent<BotMovementController>().inMotion = false;
            }
        }

        this.gameObject.SetActive(false);
    }




}
