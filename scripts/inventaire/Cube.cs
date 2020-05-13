using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Cube : MonoBehaviour, InvPrefab{

  public Cube(Sprite i){
    this._Image=i;
  }

  public string Name{
    get{
      return "Cube";
    }
  }

  public Sprite _Image = null;

  public Sprite Image{
    get{
      return _Image;
    }
  }

  public void OnPickup(){
    gameObject.SetActive(false);
  }

  public void OnDrop(){
    RaycastHit hit = new RaycastHit();
    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
    print("llll");
    if(Physics.Raycast(ray,out hit,1000)){
      gameObject.SetActive(true);
      gameObject.transform.position=hit.point;
    }
  }
}
