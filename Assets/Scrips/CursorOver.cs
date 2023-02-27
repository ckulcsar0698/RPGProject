using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CursorOver : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public void OnPointerEnter(PointerEventData eventData)
    {
        CharacterMove.CanMove = false;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        CharacterMove.CanMove = true;
    }
}
