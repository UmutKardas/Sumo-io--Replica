using UnityEngine;

public class PlayerInputController : MonoBehaviour
{

    [SerializeField] private DynamicJoystick dynamicJoystick;
    [HideInInspector] public float joystickHorizontalValue;
    [HideInInspector] public float joystickVerticalValue;
    [HideInInspector] public Vector3 directionValue;



    void Update()
    {
        SetPlayerMouseInput();
    }



    private void SetPlayerMouseInput()
    {
        if (Input.GetMouseButton(0))
        {
            joystickHorizontalValue = dynamicJoystick.Horizontal;
            joystickVerticalValue = dynamicJoystick.Vertical;
            directionValue = Vector3.forward * joystickVerticalValue + Vector3.right * joystickHorizontalValue;
        }
    }
}
