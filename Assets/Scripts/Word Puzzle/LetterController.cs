using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class LetterController : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    private CanvasGroup canvasGroup;
    private RectTransform rectTransform;
    [SerializeField] public Canvas Canvas;
    public GameObject LetterContainer;
    public bool DroppedOnSlot = false;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
    }

    public void OnPointerDown(PointerEventData eventData) { 
        SoundFXManager.Instance.PlayPickLetterSound();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = .6f;
        canvasGroup.blocksRaycasts = false;

        DroppedOnSlot = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / Canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;

        StartCoroutine(CheckIfDroppedOnSlot());
    }

    /// Coroutine to check if the letter is dropped on a slot.
    private IEnumerator CheckIfDroppedOnSlot()
    {
        yield return new WaitForEndOfFrame();

        if (!DroppedOnSlot)
        {
            // If the letter is not dropped on a slot, return it to the letter container.
            transform.SetParent(LetterContainer.transform.parent);
            transform.SetParent(LetterContainer.transform);
        }
    }

    /// Sets the letter of the letter controller.
    public void SetLetter(string letter)
    {
        GetComponentInChildren<TextMeshProUGUI>().text = letter;
    }
}
