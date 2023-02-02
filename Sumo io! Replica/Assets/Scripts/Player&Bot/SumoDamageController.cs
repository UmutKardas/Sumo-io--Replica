using System.Collections;
using UnityEngine;

public class SumoDamageController : MonoBehaviour
{
    [Header("Raycast")]
    [SerializeField] private Transform stomachTransform;
    [SerializeField] private LayerMask layer;
    public float maxDistance = 0.5f;
    public float radius;
    RaycastHit hit;


    [Header("Force")]
    private GameObject targetSumo;
    public GameObject lastSumo;
    public float forceValue;
    private bool isTouch;


    [Header("Other")]
    [SerializeField] private CinemaMachineController cinemaMachineController;


    void Update()
    {
        if (Physics.SphereCast(stomachTransform.position, radius, stomachTransform.forward, out hit, maxDistance, layer))
        {
            targetSumo = hit.collider.gameObject;
            isTouch = true;
        }


        if (isTouch)
        {
            if (this.gameObject.name == "Player")
            {
                cinemaMachineController.SetCameraShake();
            }

            targetSumo.GetComponent<Rigidbody>().AddForce(-(transform.position - targetSumo.transform.position) * forceValue * Time.deltaTime, ForceMode.Impulse);
            targetSumo.GetComponent<SumoDamageController>().lastSumo = this.gameObject;
            StartCoroutine(DamageTimeValue());
        }
    }



    IEnumerator DamageTimeValue()
    {
        yield return new WaitForSeconds(0.2f);
        isTouch = false;
    }
}
