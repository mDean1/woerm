using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

//CODE FROM "How to Drag UI Windows and Send to Top in Unity" by Code Monkey (https://www.youtube.com/watch?v=Mb2oua3FjZg)

public class dragUI : MonoBehaviour, IDragHandler
{
    [SerializeField] private RectTransform dragRectTransform;
    [SerializeField] private RectTransform canvasReactTransform;

    public void OnDrag(PointerEventData eventData){
        Vector2 anchoredPosition = eventData.delta / canvasReactTransform.localScale.x;

        if ((anchoredPosition.x + dragRectTransform.rect.width) > canvasReactTransform.rect.width){
            anchoredPosition.x = canvasReactTransform.rect.width - dragRectTransform.rect.width;
        }

        if ((anchoredPosition.y + dragRectTransform.rect.height) > canvasReactTransform.rect.height){
            anchoredPosition.y = canvasReactTransform.rect.height - dragRectTransform.rect.height;
        }
        

        dragRectTransform.anchoredPosition += anchoredPosition;
        
    }
}
