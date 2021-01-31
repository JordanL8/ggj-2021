using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler, IDropHandler{

    [SerializeField] private Canvas canvas;
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;

    public RectTransform boundary;
    public bool moved = false; 

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("OnBeginDrag");
        canvasGroup.alpha = .6f;
        canvasGroup.blocksRaycasts = false;
        //throw new System.NotImplementedException();
    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("OnDrag");
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("OnPointerDown");
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("OnEndDrag");
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;

        if (rectTransform.position.x < boundary.position.x + boundary.rect.width &&
           rectTransform.position.x + rectTransform.rect.width > boundary.position.x &&
           rectTransform.position.y < boundary.position.y + boundary.rect.height &&
           rectTransform.position.y + rectTransform.rect.height > boundary.position.y)
        {
            moved = true;
            Debug.Log("inside");
            // collision detected!
        }
        //throw new System.NotImplementedException();
    }
    
    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("OnDrop1");
        //throw new System.NotImplementedException();
    }
}
