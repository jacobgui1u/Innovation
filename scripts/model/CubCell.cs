using UnityEngine;

/**
* Classe qui permet d'implementer une Cellule
* Une cellule possède des coordonnée
*/
public class CubCell : MonoBehaviour{
  public CubCoordinates coordinates;

  public Color color;

  public int getX(){
    return coordinates.X;
  }

  public int getY(){
    return coordinates.Y;
  }
}
