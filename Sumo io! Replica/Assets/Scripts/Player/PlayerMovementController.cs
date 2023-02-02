using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{

    [SerializeField] private PlayerDataTransmitter playerDataTransmitter;
    [SerializeField] private float playerMovementSpeed;
    [SerializeField] private float playerRotationSpeed;
    [SerializeField] private GameManager gameManager;

    private Rigidbody playerRigidbody;



    private void Start()
    {
        GetComponentValues();
    }



    private void GetComponentValues()
    {
        playerRigidbody = this.gameObject.GetComponent<Rigidbody>();
    }



    private void FixedUpdate()
    {
        SetPlayerMovement();
        SetPlayerRotation();
    }



    private void SetPlayerMovement()
    {
        if (gameManager.isStart)
        {
            transform.Translate(Vector3.forward * playerMovementSpeed * Time.fixedDeltaTime);
        }
    }



    private void SetPlayerRotation()
    {
        if (playerDataTransmitter.GetDirectionValue() != Vector3.zero)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(playerDataTransmitter.GetDirectionValue()), playerRotationSpeed * Time.fixedDeltaTime);
        }

    }
}