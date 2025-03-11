using UnityEngine;

public class returnFromBattle : MonoBehaviour
{
    public SceneInfo SceneInfo;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (SceneInfo.returnPosition.x != 0 && SceneInfo.returnPosition.y != 0) {
            transform.position = SceneInfo.returnPosition;
            SceneInfo.returnPosition.Set(0, 0, 0);
        }
    }
}
