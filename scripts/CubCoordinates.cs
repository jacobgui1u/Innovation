using UnityEngine;

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
