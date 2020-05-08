using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HexGrid : MonoBehaviour {

	public int width = 6;
	public int height = 6;

	public HexCell cellPrefab;

	HexCell[] cells;
	HexMesh hexMesh;

	public Text cellLabelPrefab;

	Canvas gridCanvas;

	public Color defaultColor = Color.white;
	public Color touchedColor = Color.magenta;


	void Start () {
		hexMesh.Triangulate(cells);
	}

	void Awake () {
		gridCanvas = GetComponentInChildren<Canvas>();
		hexMesh = GetComponentInChildren<HexMesh>();

		cells = new HexCell[height * width];

		for (int z = 0, i = 0; z < height; z++) {
			for (int x = 0; x < width; x++) {
				CreateCell(x, z, i++);
			}
		}
	}



	/**
	* methode qui créer des cellules dans la grille (grid)
	*/
	void CreateCell (int x, int z, int i) {
		//création d'un vecteur qui sera la position
		Vector3 position;
		position.x = (x + z * 0.5f - z / 2) * (HexMetrics.innerRadius * 2f);
		// position.x = x * (HexMetrics.innerRadius * 2f);
		position.y = 0f;
		position.z = z * (HexMetrics.outerRadius * 1.5f);

		//Creation de la cellule par instanciation d'un prefab HexCell
		HexCell cell = cells[i] = Instantiate<HexCell>(cellPrefab);
		cell.transform.SetParent(transform, false);
		cell.transform.localPosition = position;
		cell.coordinates = HexCoordinates.FromOffsetCoordinates(x, z);
		cell.color = defaultColor;

		//Creation d'un texte affichant le coordonnées par instanciation d'un preab Text
		Text label = Instantiate<Text>(cellLabelPrefab);
		label.rectTransform.SetParent(gridCanvas.transform, false);
		//on donne au label sa position anchrée a partir d'un vecteur
		label.rectTransform.anchoredPosition = new Vector2(position.x, position.z);
		// label.text = x.ToString() + "\n" + z.ToString();
		label.text = cell.coordinates.ToStringOnSeparateLines();
	}





	void Update () {
		if (Input.GetMouseButton(0)) {
			HandleInput();
		}
	}

	void HandleInput () {
		Ray inputRay = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;
		if (Physics.Raycast(inputRay, out hit)) {
			TouchCell(hit.point);
		}
	}

	void TouchCell (Vector3 position) {
		position = transform.InverseTransformPoint(position);
		// Debug.Log("touched at " + position);
		HexCoordinates coordinates = HexCoordinates.FromPosition(position);

		int index = coordinates.X + coordinates.Z * width + coordinates.Z / 2;
		HexCell cell = cells[index];
		cell.color = touchedColor;
		hexMesh.Triangulate(cells);
		Debug.Log("touched at " + coordinates.ToString());
	}


}
