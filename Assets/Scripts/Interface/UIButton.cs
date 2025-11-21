using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI; // Added for Button component reference
using FMODUnity; // Added for FMOD EventReference
public class UIButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler
{
    [Header("FMOD Events")]
    public EventReference hoverSound;
    public EventReference pressSound;
    public EventReference releaseSound;

    [Header("UIButton Settings")]
    public Transform targetTransform;
    [Range(1f, 1.5f)]
    public float hoverScale = 1.1f;
    [Range(0.5f, 1f)]
    public float pressedScale = 0.9f;

    private Vector3 originalScale;
    private Button button;

    private void Awake()
    {
        if (targetTransform == null)
            targetTransform = transform;

        originalScale = targetTransform.localScale;
        button = GetComponent<Button>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (button != null && !button.interactable)
            return;

        SetScale(hoverScale);
        PlaySound(hoverSound);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        SetScale(1f);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (button != null && !button.interactable)
            return;

        SetScale(pressedScale);
        PlaySound(pressSound);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (button != null && !button.interactable)
            return;

        bool pointerStillOver = eventData.pointerCurrentRaycast.gameObject == gameObject;
        SetScale(pointerStillOver ? hoverScale : 1f);
        PlaySound(releaseSound);
    }

    private void SetScale(float multiplier)
    {
        targetTransform.localScale = originalScale * multiplier;
    }

    private void PlaySound(EventReference eventReference)
    {
        if (!eventReference.IsNull)
        {
            RuntimeManager.PlayOneShot(eventReference);
        }
    }
}
