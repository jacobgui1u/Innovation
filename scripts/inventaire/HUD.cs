using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class HUD : MonoBehaviour{

  //inventaire du Joueur
  public Inventory inventaire;

  public void Start(){
    inventaire.ItemRemoved += Inventory_ItemRemoved;
  }

  //Initialisation avec des prefab qui seront choisit pour completer la quête
  public void Awake(){
    InvPrefab obj = Instantiate(Resources.Load("Cube", typeof(Cube))) as InvPrefab;
    // GameObject obj = GameObject.Instantiate((GameObject)Resources.Load("Cube.prefab"));

    // si l'instanciation a réussi on ajoute
    if(obj!=null)
      ItemAdded(inventaire.AddItem(obj));
  }

  //ici on ajoute en UI
  public void ItemAdded(InvPrefab item){
    Transform inventoryPanel = transform.Find("Inventory pannel");

    foreach(Transform slot in inventoryPanel){

      Transform comp = slot.GetChild(0).GetChild(0);
      Image image = comp.GetComponent<Image>();
      ItemDragHandler itemDragHandler = comp.GetComponent<ItemDragHandler>();
      if(!image.enabled){
        image.enabled = true;
        image.sprite = item.Image;

        itemDragHandler.Item=item;

        break;
      }
    }
  }

  private void Inventory_ItemRemoved(object sender,InvEventArgs e){
    Transform inventoryPanel = transform.Find("Inventory pannel");


    foreach(Transform slot in inventoryPanel){

      Transform comp = slot.GetChild(0).GetChild(0);
      Image image = comp.GetComponent<Image>();
      ItemDragHandler itemDragHandler = comp.GetComponent<ItemDragHandler>();

      print(itemDragHandler);
      if(itemDragHandler.Item.Equals(e.Item)){
        image.enabled = false;
        image.sprite = null;
        itemDragHandler.Item = null;
        break;
      }

    }
  }




}
