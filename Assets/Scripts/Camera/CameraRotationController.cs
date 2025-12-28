using Unity.Cinemachine;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraRotationController : MonoBehaviour
{
    [SerializeField] InputActionReference look;
    [SerializeField] InputActionReference rotate;
    [SerializeField] CinemachineSplineDolly dolly;
    private float sensitivity = .1f;

    void OnEnable()
    {
        look.action.Enable();
        rotate.action.Enable();
    }

    void OnDisable()
    {
        look.action.Disable();
        rotate.action.Disable();
    }

    // Update is called once per frame
    void Update()
    {
        if (!rotate.action.IsPressed())
            return;

        Vector2 lookVector = look.action.ReadValue<Vector2>();

        dolly.CameraPosition += lookVector.x * sensitivity * Time.deltaTime;

    }
}
