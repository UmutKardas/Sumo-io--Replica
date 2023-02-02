using UnityEngine;

public class SumoStatsController : MonoBehaviour
{
    public void ChangeSumoStats(GameObject _sumo, float _score)
    {
        if (_score < 1000 && _score >= 500)
        {
            _sumo.transform.localScale = new Vector3(1.3f, 1.3f, 1.3f);
            _sumo.GetComponent<Rigidbody>().mass = 2;
            _sumo.GetComponent<SumoDamageController>().forceValue = 70;
            _sumo.GetComponent<SumoDamageController>().radius = 0.3f;
            _sumo.GetComponent<SumoDamageController>().maxDistance = 0.7f;

        }

        else if (_score >= 1000)
        {
            _sumo.transform.localScale = new Vector3(1.6f, 1.6f, 1.6f);
            _sumo.GetComponent<Rigidbody>().mass = 3;
            _sumo.GetComponent<SumoDamageController>().forceValue = 80;
            _sumo.GetComponent<SumoDamageController>().radius = 0.4f;
            _sumo.GetComponent<SumoDamageController>().maxDistance = 0.9f;
        }
    }



}
