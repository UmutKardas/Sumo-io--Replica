using UnityEngine;
using KardasTag;

public class SumoCollisionController : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    public bool isGround = true;



    private void OnCollisionEnter(Collision other)
    {

        if (other.gameObject.CompareTag(Tag.GROUND))
        {
            isGround = true;
        }

        if (other.gameObject.CompareTag(Tag.SUSHI))
        {
            other.gameObject.GetComponent<SushiSpawnController>().SetNewSushi();
            this.gameObject.GetComponent<SumoScoreController>().SetScoreIncrease(100);
        }
    }



    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag(Tag.GROUND))
        {
            isGround = false;

            if (this.gameObject.GetComponent<SumoDamageController>().lastSumo != null)
            {
                this.gameObject.GetComponent<SumoDamageController>().lastSumo.GetComponent<SumoScoreController>().SetScoreIncrease(500);
            }

            this.gameObject.GetComponent<SumoDeathController>().SetSumoDeath();
            gameManager.CheckGameEnd(false);
        }
    }
}
