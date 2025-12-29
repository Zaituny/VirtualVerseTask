using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] Transform engine;

    public void OnScaleSliderValueChanged(float value) {
        // scale engine to value
        engine.localScale = Vector3.one * value;
    }

    public void OnRotateXSliderValueChanged(float value) {
        Vector3 rot = engine.eulerAngles;
        rot.x = value;
        Debug.Log(value);
        Debug.Log(rot);
        engine.eulerAngles = rot;
    }

    public void OnRotateYSliderValueChanged(float value)
    {
        Vector3 rot = engine.eulerAngles;
        rot.y = value;
        engine.eulerAngles= rot;
    }
    public void OnRotateZSliderValueChanged(float value)
    {
        Vector3 rot = engine.eulerAngles;
        rot.z = value;
        engine.eulerAngles = rot;
    }

}
