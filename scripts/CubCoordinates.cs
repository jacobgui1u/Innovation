using UnityEngine;

/**
* Classe qui modelise les coordonnées d'une cellules
* les coordonnées on une position x et y
* la methode y permet d'obtenir la distance depuis la case 0:0
* les autres methodes sont des methodes d'affichage 
*/
[System.Serializable]
public struct CubCoordinates {

	public int X { get; private set; }

	public int Z { get; private set; }

	public CubCoordinates (int x, int z) {
		X = x;
		Z = z;
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
}
