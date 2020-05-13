using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour{

  private const int SLOTS = 9;

  private List<InvPrefab> lItems = new List<InvPrefab>();

  public event EventHandler<InvEventArgs> ItemRemoved;

  //ici on ajoute en donnée l'item
  public InvPrefab AddItem(InvPrefab item){
    if(lItems.Count < SLOTS){
      lItems.Add(item);

      item.OnPickup();
      return item;
    }else{
      return null;
    }

  }


  public void RemoveItem(InvPrefab item){

    if(lItems.Contains(item)){

      lItems.Remove(item);

      item.OnDrop();
      /////////////////////////////

      Collider collider = (item as MonoBehaviour).GetComponent<Collider>();
      if(collider!=null){
        collider.enabled = true;
      }
      print(ItemRemoved);
      if(ItemRemoved !=null){
        ItemRemoved(this, new InvEventArgs(item));
      }
    }
  }
}
