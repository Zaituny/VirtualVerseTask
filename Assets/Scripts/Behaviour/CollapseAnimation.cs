using UnityEngine;

public class CollapseAnimation : MonoBehaviour
{
    private const float AnimationDuration = 0.3f;
    public void Collapse()
    {
        LeanTween.value(gameObject, 1, 0, AnimationDuration)
            .setOnUpdate(scale =>
            {
                var currentScale = transform.localScale;
                currentScale.y = scale;
                transform.localScale = currentScale;

                if (Mathf.Approximately(scale, 0f)) gameObject.SetActive(false);
            })
            .setEase(LeanTweenType.easeInBack);
    }
}
