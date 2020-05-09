using UnityEngine;

/**
* Classe qui modelise les coordonnées d'une cellules
* les coordonnées on une position x et y
* la methode y permet d'obtenir la distance depuis la case 0:0
* les autres methodes sont des methodes d'affichage
*/
[System.Serializable]
public struct CubCoordinates {

  [SerializeField]
	private int x, z;



	public CubCoordinates (int x, int z) {
		this.x = x;
		this.z = z;
	}

  public int X {
    get {
      return x;
    }
  }

  public int Z {
    get {
      return z;
    }
  }

  public int Y {
    get {
      return -X - Z;
    }
  }


  public static CubCoordinates FromOffsetCoordinates (int x, int z) {
    return new CubCoordinates(x, z);
  }

  public override string ToString () {
		return "(" + X.ToString() + ", " + Y.ToString() + ", " + Z.ToString() + ")";
	}

	public string ToStringOnSeparateLines () {
		return X.ToString() + "\n" + Y.ToString() + "\n" + Z.ToString();
	}

  /**
  * methode qui calcule la postion de notre cellule par rapport au totale de celulle / mesh
  */
  public static CubCoordinates FromPosition (Vector3 position) {
    //ici on recupere la position qu'on divise par la taille du cube (cellule, 10)
    float x = position.x/CubMetrics.tailleCube;
    float z = position.z/CubMetrics.tailleCube;

    //on la transforme en entier, enlevant les virgules
    int iX = Mathf.RoundToInt(x);
		int iZ = Mathf.RoundToInt(z);

    //on retourne
		return new CubCoordinates(iX, iZ);
  }

  public Vector3 getPosition(){
    return new Vector3((this.x*CubMetrics.tailleCube)-CubMetrics.tailleCube/2,0,(this.z*CubMetrics.tailleCube)-CubMetrics.tailleCube/2);
  }

}
