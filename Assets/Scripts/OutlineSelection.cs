using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class OutlineSelection : MonoBehaviour
{
    [SerializeField] private InputActionReference select;
    [SerializeField] private PartInfoPanelManager partInfoPanelManager;

    private Transform highlighted;
    private Transform selected;

    private Camera cam;

    void OnEnable()
    {
        select.action.Enable();
    }

    void OnDisable()
    {
        select.action.Disable();
    }

    void Awake()
    {
        cam = Camera.main;
    }

    void Update()
    {
        HandleHover();
        HandleSelection();
    }

    // ---------------- HOVER ----------------
    void HandleHover()
    {
        ClearHighlight();

        if (EventSystem.current.IsPointerOverGameObject())
            return;

        Ray ray = cam.ScreenPointToRay(Mouse.current.position.ReadValue());
        if (!Physics.Raycast(ray, out RaycastHit hit))
            return;

        if (!hit.transform.CompareTag("Selectable"))
            return;

        if (hit.transform == selected)
            return;

        highlighted = hit.transform;
        EnableOutline(highlighted, Color.blue);
    }

    // ---------------- SELECTION ----------------
    void HandleSelection()
    {
        if (!select.action.WasPressedThisFrame())
            return;

        // Clicked on something selectable
        if (highlighted != null)
        {
            Select(highlighted);
        }
        else
        {
            Deselect();
        }
    }

    void Select(Transform target)
    {
        if (selected != null)
            DisableOutline(selected);

        selected = target;
        EnableOutline(selected, Color.blue);

        EnginePart part = selected.GetComponent<EnginePart>();
        if (part != null)
            partInfoPanelManager.show(part.data);
    }

    void Deselect()
    {
        if (selected != null)
            DisableOutline(selected);

        selected = null;
        partInfoPanelManager.hide();
    }

    // ---------------- OUTLINE HELPERS ----------------
    void EnableOutline(Transform t, Color color)
    {
        Outline outline = t.GetComponent<Outline>();
        if (outline == null)
            outline = t.gameObject.AddComponent<Outline>();

        outline.enabled = true;
        outline.OutlineColor = color;
        outline.OutlineWidth = 7f;
    }

    void DisableOutline(Transform t)
    {
        Outline outline = t.GetComponent<Outline>();
        if (outline != null)
            outline.enabled = false;
    }

    void ClearHighlight()
    {
        if (highlighted == null)
            return;

        // Do NOT disable outline if it's the selected object
        if (highlighted != selected)
            DisableOutline(highlighted);

        highlighted = null;
    }
}
