using UnityEngine;
using UnityEngine.EventSystems;
using LitMotion;
using LitMotion.Extensions;
using UnityEngine.UI; // Added for Button component reference

public class UIButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler
{
    // [Header("FMOD Events")]
    // public EventReference hoverSound;
    // public EventReference pressSound;
    // public EventReference releaseSound;

    [Header("Litmotion Effects")]
    public Transform targetTransform; // The transform to animate

    private void Awake()
    {
        if (targetTransform == null)
            targetTransform = transform;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (!GetComponent<Button>().interactable)
            return;

        LitMotion.LMotion.Create(targetTransform.localScale, Vector3.one * 1.1f, 0.2f)
            .BindToLocalScale(targetTransform);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        LitMotion.LMotion.Create(targetTransform.localScale, Vector3.one, 0.2f)
            .BindToLocalScale(targetTransform);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        // Press sound (FMOD removed)
        // if (!pressSound.IsNull)
        // {
        //     AudioManager.PlaySFX(pressSound);
        // }

        LitMotion.LMotion.Create(targetTransform.localScale, Vector3.one * 0.9f, 0.1f)
            .BindToLocalScale(targetTransform);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        // Release sound (FMOD removed)
        // if (!releaseSound.IsNull)
        // {
        //     AudioManager.PlaySFX(releaseSound);
        // }

        if (eventData.pointerCurrentRaycast.gameObject == gameObject)
        {
            LitMotion.LMotion.Create(targetTransform.localScale, Vector3.one * 1.1f, 0.2f)
                .BindToLocalScale(targetTransform);
        }
        else
        {
            LitMotion.LMotion.Create(targetTransform.localScale, Vector3.one, 0.2f)
                .BindToLocalScale(targetTransform);
        }
    }
}
