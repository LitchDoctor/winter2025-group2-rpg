using UnityEngine;
using UnityEngine.UIElements;

[CreateAssetMenu(fileName = "SceneInfo", menuName = "Scriptable Objects/SceneInfo")]
public class SceneInfo : ScriptableObject
{
    public bool returnedFromBattle = false;

    public Vector3 returnPosition = new Vector3(0,0,0);
}
