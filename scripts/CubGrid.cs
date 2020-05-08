using UnityEngine;
using UnityEngine.UI;

public class CubGrid : MonoBehaviour {
  public int width = 6;
	public int height = 6;


  public Text cellLabelPrefab;
	public CubCell cellPrefab;


  CubCell[] cells;
	Canvas gridCanvas;



  void Awake(){
    gridCanvas = GetComponentInChildren<Canvas>();
    cells = new CubCell[height * width];

		for (int z = 0, i = 0; z < height; z++) {
			for (int x = 0; x < width; x++) {
				CreateCell(x, z, i++);
			}
		}
  }


  void CreateCell (int x, int z, int i) {
		Vector3 position;
		position.x = x * 10f;
		position.y = 0f;
		position.z = z * 10f;

		CubCell cell = cells[i] = Instantiate<CubCell>(cellPrefab);
		cell.transform.SetParent(transform, false);
		cell.transform.localPosition = position;
		cell.coordinates = CubCoordinates.FromOffsetCoordinates(x, z);

    Text label = Instantiate<Text>(cellLabelPrefab);
		label.rectTransform.SetParent(gridCanvas.transform, false);
		label.rectTransform.anchoredPosition =
		new Vector2(position.x, position.z);
	  label.text = cell.coordinates.ToStringOnSeparateLines();
	}

}
