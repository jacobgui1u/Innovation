using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
* HexCell est une class qui appartient a l'objet prefab HexCell
* Cette classe permet de connaitre les coordonnées de la cellules
*/
public class HexCell : MonoBehaviour
{

	//coordonnées de la cellule par rapport a un point 0
	public HexCoordinates coordinates;
	public Color color;

	/**
	* methode qui permet de retourner une distance par rapport à une autre cellule
	*/
  public static HexCoordinates FromOffsetCoordinates (int x, int z) {
		return new HexCoordinates(x - z / 2, z);
	}
}
