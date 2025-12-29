using Unity.Cinemachine;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class CameraRotationController : MonoBehaviour
{
    [SerializeField] InputActionReference look;
    [SerializeField] InputActionReference rotate;
    [SerializeField] InputActionReference zoom;
    [SerializeField] CinemachineSplineDolly dolly;
    [SerializeField] CinemachineCamera cam;
    private float sensitivity = 1f;

    void OnEnable()
    {
        look.action.Enable();
        rotate.action.Enable();
        zoom.action.Enable();
    }

    void OnDisable()
    {
        look.action.Disable();
        rotate.action.Disable();
        zoom.action.Disable();
    }

    // Update is called once per frame
    void Update()
    {
        // check if we are on UI overlay or not
        if (EventSystem.current != null &&
            EventSystem.current.IsPointerOverGameObject())
            return;

        // zoom
        Vector2 zoomValue = zoom.action.ReadValue<Vector2>();
        cam.Lens.FieldOfView -= zoomValue.y;
        cam.Lens.FieldOfView = Mathf.Clamp(cam.Lens.FieldOfView, 10, 80);

        // check if left mouse button is clicked (or whatever is the action button for rotate)
        if (!rotate.action.IsPressed())
            return;

        Vector2 lookVector = look.action.ReadValue<Vector2>();

        dolly.CameraPosition += lookVector.x * sensitivity * Time.deltaTime;

    }
}
