using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;


public class LetterSlotController : MonoBehaviour, IDropHandler
{
    public string Letter;
    public LetterPuzzleController PuzzleController;

    public void OnDrop(PointerEventData eventData)
    {
        // Initiate pointer drag
        if (eventData.pointerDrag != null && transform.childCount == 0)
        {
            SoundFXManager.Instance.PlayDropLetterSound();

            // Get the LetterController from the dragged object
            LetterController letterController = eventData.pointerDrag.GetComponent<LetterController>();
            
            letterController.DroppedOnSlot = true;

            // Change the parent of the dragged object to this slot
            letterController.transform.SetParent(transform);

            // Reset the local position of the dragged object to align it perfectly with the slot
            letterController.transform.localPosition = Vector3.zero;
        }

        // Check if the puzzle is complete
        PuzzleController.CheckPuzzleComplete();
    }
}