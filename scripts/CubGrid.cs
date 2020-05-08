using UnityEngine;
using UnityEngine.UI;

/**
* Classe qui modelise une grille de cellules cubique
* la grille a une taille (largeur et hauteur)
* la grille a deux argument, un label et une cellule tout deux prefabriqué
* la grille possède un tableau de cellules et un canvas
*/
public class CubGrid : MonoBehaviour {
  public int width = 6;
	public int height = 6;


  public Text cellLabelPrefab;
	public CubCell cellPrefab;


  CubCell[] cells;
	Canvas gridCanvas;


  /**
  * la methode awake permet d'initialiser les variable avant que le jeu ne démarre
  * ici on initialise le canvas a partir de l'argument dans unity
  * on initialise le tableau de cellule a la taille choisit et on créer les cellules du tableau
  */
  void Awake(){
    gridCanvas = GetComponentInChildren<Canvas>();
    cells = new CubCell[height * width];

		for (int z = 0, i = 0; z < height; z++) {
			for (int x = 0; x < width; x++) {
				CreateCell(x, z, i++);
			}
		}
  }

  /**
  * methode qui permet de créer une cellules a partir d'une position et d'un numero
  */
  void CreateCell (int x, int z, int i) {
    //création de la postion a partir d'une position * le numero de case
		Vector3 position;
		position.x = x * 10f;
		position.y = 0f;
		position.z = z * 10f;

    //tableau de cellules qui instancie  la cellule dans le tableau a partir de l'argument dans unity et lui donne la position
		CubCell cell = cells[i] = Instantiate<CubCell>(cellPrefab);
		cell.transform.SetParent(transform, false);
		cell.transform.localPosition = position;
		cell.coordinates = CubCoordinates.FromOffsetCoordinates(x, z);

    //instanciation du label 
    Text label = Instantiate<Text>(cellLabelPrefab);
		label.rectTransform.SetParent(gridCanvas.transform, false);
		label.rectTransform.anchoredPosition =
		new Vector2(position.x, position.z);
	  label.text = cell.coordinates.ToStringOnSeparateLines();
	}

}
