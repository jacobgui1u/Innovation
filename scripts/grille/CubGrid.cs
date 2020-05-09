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
  CubMesh cubMesh;

  // couleur de la cellule touché ou non
  public Color defaultColor = Color.white;
	public Color touchedColor = Color.magenta;

  /**
  * au debut du programme on utilise le mesh pour afficher les mesh
  */
  void Start () {
    cubMesh.Cubisme(cells);
  }

  /**
  * la methode awake permet d'initialiser les variable avant que le jeu ne démarre
  * ici on initialise le canvas a partir de l'argument dans unity
  * on Initialise aussi le mesh qui permet de rendre la carte
  * on initialise le tableau de cellule a la taille choisit et on créer les cellules du tableau
  */
  void Awake(){
    gridCanvas = GetComponentInChildren<Canvas>();
		cubMesh = GetComponentInChildren<CubMesh>();
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
    cell.color = defaultColor;

    //instanciation du label
    Text label = Instantiate<Text>(cellLabelPrefab);
		label.rectTransform.SetParent(gridCanvas.transform, false);
		label.rectTransform.anchoredPosition =
		new Vector2(position.x, position.z);
	  label.text = cell.coordinates.ToStringOnSeparateLines();
	}



  /*
  * on gère ici les inputs notamment si on clique sur une cellule
  */
  void Update () {
		if (Input.GetMouseButton(0)) {
			HandleInput();
		}
	}

  /*
  *cette methode qere le clique et recherche la celulle cliqué par rapport au rayon d'input
  */
  void HandleInput () {
		Ray inputRay = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;
		if (Physics.Raycast(inputRay, out hit)) {
			TouchCell(hit.point);
		}
	}

  /*
  * cette methode affiche la postion touché et la celulle
  */
	void TouchCell (Vector3 position) {
    position = transform.InverseTransformPoint(position);
		CubCoordinates coordinates = CubCoordinates.FromPosition(position);
		// Debug.Log("touched at " + coordinates.ToString());

    //on color la cellule
    int index = coordinates.X + coordinates.Z * width ;
  	CubCell cell = cells[index];

		cell.color = touchedColor;
		cubMesh.Cubisme(cells);
	}


}
