using UnityEngine;
using UnityEditor;


/**
* Classe qui permet d'afficher dans le gui des chsoses
* notamment ici les coordonnées d'une case
*/
[CustomPropertyDrawer(typeof(CubCoordinates))]
public class CubCoordinatesDrawer : PropertyDrawer {

  /**
  * Methode qui affiche les coordonnée dans le gui
  */
  public override void OnGUI (Rect position, SerializedProperty property, GUIContent label) {
    CubCoordinates coordinates = new CubCoordinates(
			property.FindPropertyRelative("x").intValue,
			property.FindPropertyRelative("z").intValue
		);

    //permet d'obtenir le label a afficher avant la postion
    position = EditorGUI.PrefixLabel(position, label);
    //affichage
		GUI.Label(position, coordinates.ToString());
  }
}
