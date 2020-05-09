using UnityEngine;
using System.Collections.Generic;
using System.Collections;

/**
* classe qui modelise un mesh pour les cubes,
* cela permet d'obtenir un affichage unifié des mesh et non independant
* pour optimiser l'affichage
*/
[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class CubMesh : MonoBehaviour {

  //le mesh a afficher
	Mesh cubMesh;

  //vertice et triangle pour le mesh general du terrain
  List<Vector3> vertices;
  List<int> triangles;

  MeshCollider meshCollider;
  List<Color> colors;

  /*
  * initilisation des attributs, on ajout un composant mesh
  * il contient le game objet mesh dans cubGrid
  */
	void Awake () {
		GetComponent<MeshFilter>().mesh = cubMesh = new Mesh();
    meshCollider = gameObject.AddComponent<MeshCollider>();
		cubMesh.name = "Cub Mesh";
    vertices = new List<Vector3>();
    triangles = new List<int>();

    colors = new List<Color>();

	}





  /*
  * cubisme permet de recalculer les mesh
  */
	public void Cubisme (CubCell[] cells) {

    cubMesh.Clear();
		vertices.Clear();
		triangles.Clear();
		colors.Clear();

    for (int i=0; i<cells.Length;i++){
      // vertices = new Vector3[(xSize + 1) * (zSize + 1)];
      Triangulate(cells[i]);
    }

    cubMesh.vertices = vertices.ToArray();
		cubMesh.triangles = triangles.ToArray();
		cubMesh.RecalculateNormals();
    cubMesh.colors = colors.ToArray();

    meshCollider.sharedMesh = cubMesh;
	}


  void Triangulate (CubCell cell) {
		Vector3 center = cell.coordinates.getPosition();
    for (int i = 0; i < 3; i++) {
		    AddTriangle(
  			   center ,
           center + CubMetrics.corners[i+1],
    		   center + CubMetrics.corners[i+2]
		   );
       AddTriangleColor(cell.color);
    }
	}

  void AddTriangle (Vector3 v1, Vector3 v2, Vector3 v3) {
  		int vertexIndex = vertices.Count;
  		vertices.Add(v1);
  		vertices.Add(v2);
  		vertices.Add(v3);
  		triangles.Add(vertexIndex);
  		triangles.Add(vertexIndex + 1);
  		triangles.Add(vertexIndex + 2);
  	}

    void AddTriangleColor (Color color) {
  		colors.Add(color);
  		colors.Add(color);
  		colors.Add(color);
  	}



}
