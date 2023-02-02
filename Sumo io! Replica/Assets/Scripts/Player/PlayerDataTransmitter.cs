using UnityEngine;

public class PlayerDataTransmitter : MonoBehaviour
{
    [SerializeField] private PlayerInputController playerInputController;

    public float GetJoystickHorizontalValue()
    {
        return playerInputController.joystickHorizontalValue;
    }



    public float GetJoystickVerticalValue()
    {
        return playerInputController.joystickVerticalValue;
    }



    public Vector3 GetDirectionValue()
    {
        return playerInputController.directionValue;
    }
}
