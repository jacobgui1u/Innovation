using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemDropHandler : MonoBehaviour, IDropHandler
{
  public Inventory inventaire;
  public void OnDrop(PointerEventData eventData){
    RectTransform invPanel = transform as RectTransform;

    if(!RectTransformUtility.RectangleContainsScreenPoint(invPanel,Input.mousePosition)){
      InvPrefab item = eventData.pointerDrag.gameObject.GetComponent<ItemDragHandler>().Item;
      inventaire.RemoveItem(item);
    }
  }
}
