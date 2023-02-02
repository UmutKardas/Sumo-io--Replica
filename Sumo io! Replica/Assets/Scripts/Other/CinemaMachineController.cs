using System.Collections;
using UnityEngine;
using Cinemachine;

public class CinemaMachineController : MonoBehaviour
{

    [SerializeField] private CinemachineVirtualCamera cinemachineVirtualCamera;
    public GameObject sumoGameobject;



    public void SetCameraShake()
    {
        cinemachineVirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain = 1f;
        StartCoroutine(nameof(CameraShake));
    }



    IEnumerator CameraShake()
    {
        yield return new WaitForSeconds(0.3f);
        cinemachineVirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain = 0f;
    }



    public void SetNewCameraPosition()
    {

        cinemachineVirtualCamera.Follow = null;
        cinemachineVirtualCamera.transform.localPosition = new Vector3(0.52f, 13.4f, -9.26f);
        cinemachineVirtualCamera.GetCinemachineComponent<CinemachineTransposer>().m_FollowOffset = new Vector3(0f, 8.4f, 4f);

    }



    public void ChangeCamera()
    {
        cinemachineVirtualCamera.transform.parent.gameObject.GetComponent<CinemachineMixingCamera>().m_Weight1 = 2;
    }
}