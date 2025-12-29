using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PartInfoPanelManager : MonoBehaviour
{

    [SerializeField] Camera mainCamera;


    [SerializeField] ExpandAnimation ea;
    [SerializeField] CollapseAnimation ca;

    [SerializeField] TextMeshProUGUI partName;
    [SerializeField] TextMeshProUGUI partDescription;

    public void show(EnginePartData data) {
        Debug.Log("showing panel");
        partName.text = data.partName;
        partDescription.text = data.description;
        ea.Expand();
    }

    public void hide() {
        ca.Collapse();
    }

    void LateUpdate()
    {
        // Always face the camera
        transform.LookAt(
            transform.position + mainCamera.transform.forward
        );
    }
}
