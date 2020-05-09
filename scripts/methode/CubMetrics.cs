using UnityEngine;

public static class CubMetrics{

  public const float tailleCube = 10;


  public static Vector3[] corners = {
    new Vector3(0f, 0f, tailleCube),
    new Vector3(tailleCube, 0f, 0f),
    new Vector3(0f, 0f, tailleCube),
    new Vector3(tailleCube, 0f, tailleCube),
    new Vector3(tailleCube, 0f, 0f),
  };
}
