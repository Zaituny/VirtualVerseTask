using UnityEngine;

public class ExpandAnimation : MonoBehaviour
{

    private const float AnimationDuration = 0.3f;

    public void Expand()
    {
        gameObject.SetActive(true);
        LeanTween.value(gameObject, 0, 1, AnimationDuration)
            .setOnUpdate(scale =>
            {
                var currentScale = transform.localScale;
                currentScale.y = scale;
                transform.localScale = currentScale;
            })
            .setEase(LeanTweenType.easeOutBack);
    }

}
