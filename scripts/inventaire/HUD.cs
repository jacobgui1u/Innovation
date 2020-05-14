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
    inventaire.ItemRemplace += Inventory_ItemRemplace;
    inventaire.ItemAdded += Inventory_ItemAdded;

    Transform parent=transform.Find("Inventory pannel");
    for(int i=0;i<9;i++){
      GameObject ob = Instantiate(Resources.Load("slot", typeof(object))) as GameObject;
      ob.transform.SetParent(parent);
    }


    for(int i=0;i<3;i++){
      InvPrefab obj = Instantiate(Resources.Load("Cube", typeof(Cube))) as InvPrefab;
      if(obj!=null)
        inventaire.AddItem(obj);

    }

    // GameObject obj = GameObject.Instantiate((GameObject)Resources.Load("Cube.prefab"));
    // si l'instanciation a réussi on ajoute

  }

  //ici on ajoute en UI
  private void Inventory_ItemAdded(object sender,InvEventArgs e){

    InvPrefab item=e.Item;
    Transform inventoryPanel = transform.Find("Inventory pannel");

    foreach(Transform slot in inventoryPanel){

      Transform comp = slot.GetChild(0).GetChild(0);
      Image image = comp.GetComponent<Image>();
      ItemDragHandler itemDragHandler = comp.GetComponent<ItemDragHandler>();
      Text label = comp.GetChild(0).GetComponent<Text>();


      if(!image.enabled){
        image.enabled = true;
        image.sprite = item.Image;

        int txt = inventaire.nombreItem(e.Item);
        label.text= txt.ToString();

        itemDragHandler.Item=item;

        break;
      }
    }
  }



  private void Inventory_ItemRemoved(object sender,InvEventArgs e){
    Transform inventoryPanel = transform.Find("Inventory pannel");


    foreach(Transform slot in inventoryPanel){
      // if(slot)
      Transform comp = slot.GetChild(0).GetChild(0);
      Image image = comp.GetComponent<Image>();
      ItemDragHandler itemDragHandler = comp.GetComponent<ItemDragHandler>();
      Text label = comp.GetChild(0).GetComponent<Text>();

      // print(itemDragHandler);
      if(itemDragHandler.Item.Name.Equals(e.Item.Name)){
        image.enabled = false;
        image.sprite = null;
        itemDragHandler.Item = null;

        int txt = inventaire.nombreItem(e.Item);
        print(txt);
        if(txt==0){
          label.text="";
        }else{
          label.text= txt.ToString();
        }

        break;
      }

    }
  }


  private void Inventory_ItemRemplace(object sender,InvEventArgs e){
    Transform inventoryPanel = transform.Find("Inventory pannel");


    foreach(Transform slot in inventoryPanel){
      // if(slot)
      Transform comp = slot.GetChild(0).GetChild(0);
      Image image = comp.GetComponent<Image>();
      ItemDragHandler itemDragHandler = comp.GetComponent<ItemDragHandler>();
      Text label = comp.GetChild(0).GetComponent<Text>();

      // print(itemDragHandler);
      if(itemDragHandler.Item.Name.Equals(e.Item.Name)){
        image.sprite = e.Item.Image;;
        itemDragHandler.Item = e.Item;

        int txt = inventaire.nombreItem(e.Item);
        label.text= txt.ToString();
        break;
      }

    }
  }



}
