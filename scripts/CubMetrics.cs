using UnityEngine;

public static class CubMetrics{
  public const float outerRadius = 10f;
  public const float innerRadius = outerRadius * 0.866025404f;

  //pas utiles, permet de calculer les coins d'un hexagone
  public static Vector3[] corners = {
    new Vector3(0f, 0f, outerRadius),
    new Vector3(innerRadius, 0f, 0.5f * outerRadius),
    new Vector3(innerRadius, 0f, -0.5f * outerRadius),
    new Vector3(0f, 0f, -outerRadius),
    new Vector3(-innerRadius, 0f, -0.5f * outerRadius),
    new Vector3(-innerRadius, 0f, 0.5f * outerRadius)
  };
}
