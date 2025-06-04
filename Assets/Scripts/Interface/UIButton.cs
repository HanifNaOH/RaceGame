using UnityEngine;
using UnityEngine.EventSystems;
using FMODUnity;
using LitMotion;
using LitMotion.Extensions;
using UnityEngine.UI; // Added for Button component reference

public class UIButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler
{
    [Header("FMOD Events")]
    public EventReference hoverSound;
    public EventReference pressSound;
    public EventReference releaseSound;

    [Header("Litmotion Effects")]
    public Transform targetTransform; // The transform to animate
    
    // Default to self if no target transform is set
    private void Awake()
    {
        if (targetTransform == null)
            targetTransform = transform;
    }

    // Called when pointer enters the button (hover)
    public void OnPointerEnter(PointerEventData eventData)
    {
        // Added a check to skip LitMotion animations if the button is not interactable
        if (!GetComponent<Button>().interactable)
            return;

        // Hover effect: scale up
        LitMotion.LMotion.Create(targetTransform.localScale, Vector3.one * 1.1f, 0.2f)
            .BindToLocalScale(targetTransform);
    }

    // Called when pointer exits the button
    public void OnPointerExit(PointerEventData eventData)
    {
        // Return to original scale if not pressed
        LitMotion.LMotion.Create(targetTransform.localScale, Vector3.one, 0.2f)
            .BindToLocalScale(targetTransform);
    }

    // Called when button is pressed
    public void OnPointerDown(PointerEventData eventData)
    {
        // Press sound
        if (!pressSound.IsNull)
        {
            AudioManager.PlaySFX(pressSound);
        }

        // Press effect: scale down
        LitMotion.LMotion.Create(targetTransform.localScale, Vector3.one * 0.9f, 0.1f)
            .BindToLocalScale(targetTransform);
    }

    // Called when button is released
    public void OnPointerUp(PointerEventData eventData)
    {
        // Release sound
        if (!releaseSound.IsNull)
        {
            AudioManager.PlaySFX(releaseSound);
        }

        // If pointer is still over the button after release, show hover state
        // otherwise return to original scale
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
