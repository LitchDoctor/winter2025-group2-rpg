using UnityEngine;

public class Defeated : MonoBehaviour
{
    public SceneInfo sceneInfo;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (sceneInfo.returnedFromBattle == true)
        {
            sceneInfo.returnedFromBattle = false;
            Destroy(gameObject);
        }
    }
}
