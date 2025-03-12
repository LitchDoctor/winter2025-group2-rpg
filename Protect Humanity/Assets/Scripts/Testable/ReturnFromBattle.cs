using UnityEngine;

public class returnFromBattle : MonoBehaviour
{
    public SceneInfo SceneInfo;
    
    void Awake()
    {
        if (SceneInfo.returnedFromBattle == true) 
        {
            Debug.Log("returning from battle");
            transform.position = SceneInfo.returnPosition;

            SceneInfo.returnPosition.Set(0, 0, 0);
        }
        else
        {
            transform.position.Set(0, 0, 0);
        }
    }
}
