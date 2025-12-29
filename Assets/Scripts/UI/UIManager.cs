using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] Transform engine;

    private Vector3 rot = Vector3.zero;

    public void OnScaleSliderValueChanged(float value) {
        // scale engine to value
        engine.localScale = Vector3.one * value;
    }

    public void OnRotateXSliderValueChanged(float value) {
        rot.x = value;
        engine.eulerAngles = rot;
    }

    public void OnRotateYSliderValueChanged(float value)
    {
        rot.y = value;
        engine.eulerAngles= rot;
    }
    public void OnRotateZSliderValueChanged(float value)
    {
        rot.z = value;
        engine.eulerAngles = rot;
    }

}
