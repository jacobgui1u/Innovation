using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour{

  private const int SLOTS = 9;

  private List<List<InvPrefab>> lItems = new List<List<InvPrefab>>();

  public event EventHandler<InvEventArgs> ItemRemoved;
  public event EventHandler<InvEventArgs> ItemAdded;
  public event EventHandler<InvEventArgs> ItemRemplace;

  //ici on ajoute en donnée l'item
  public void AddItem(InvPrefab item){
    Boolean exist=false;
    //on verifie qu'il n'existe pas déja un tableau de l'item
    foreach(List<InvPrefab> l in lItems){
      if(l[0].Name.Equals(item.Name)){
        l.Add(item);
        ItemRemplace(this, new InvEventArgs(item));
        item.OnPickup();
        exist=true;
        break;
      }

    }

    //sinon on l'ajoute a un slot libre
    if(lItems.Count < SLOTS && !exist){
      List<InvPrefab> nouveau = new List<InvPrefab>();
      nouveau.Add(item);
      lItems.Add(nouveau);

      item.OnPickup();
      if(ItemAdded !=null){
        ItemAdded(this, new InvEventArgs(item));
      }
    }

  }


  public void RemoveItem(InvPrefab item){
    foreach(List<InvPrefab> l in lItems){
      if(l[0].Name.Equals(item.Name)){
        print(l.Count);
        if(l.Count>1){
          l.RemoveAt(l.Count-1);
          if(ItemRemoved !=null){
            ItemRemplace(this, new InvEventArgs(l[l.Count-1]));
            print("remplace");
          }
          break;
        }else{
          lItems.Remove(l);
          if(ItemRemoved !=null){
          print("suppr");
            ItemRemoved(this, new InvEventArgs(item));
          }

          break;
        }


      }
    }
    item.OnDrop();
    /////////////////////////////

    Collider collider = (item as MonoBehaviour).GetComponent<Collider>();
    if(collider!=null){
      collider.enabled = true;
    }
  }

  public int nombreItem(InvPrefab item){
    foreach(List<InvPrefab> l in lItems){
      if(l[0].Name.Equals(item.Name)){
        return l.Count;
      }
    }
    return 0;
  }
}
