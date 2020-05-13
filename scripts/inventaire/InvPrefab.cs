using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public interface InvPrefab{

  string Name {get;}
  Sprite Image {get;}
  void OnPickup();
  void OnDrop();

}



public class InvEventArgs : EventArgs{
  public InvEventArgs(InvPrefab item){
    Item = item;
  }
  public InvPrefab Item;
}
