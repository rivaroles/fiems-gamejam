using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class EventClick : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{

    public void OnPointerDown(PointerEventData eventData) 
    {
        //Vazio
    }

    public void OnPointerUp(PointerEventData eventData) 
    {
        //Vazio
    }

    public void OnPointerClick(PointerEventData eventData) 
    {
        Debug.Log("Você clicou em " + gameObject.name);
    }

    public void OnPointerEnter(PointerEventData eventData) 
    {
        //Vazio
    }

    public void OnPointerExit(PointerEventData eventData) 
    {
        // Vazio
    }
}
