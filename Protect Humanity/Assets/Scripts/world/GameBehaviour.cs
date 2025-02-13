using UnityEngine;
using UnityEngine.SceneManagement;

public class GameBehaviour : MonoBehaviour
{

    public static GameBehaviour Instance;

    private void Awake()
    {
        if (Instance == null){
            Instance = this;
        }else if(Instance != this){
            Destroy(gameObject);
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void sceneToMoveTo(string scene){
        SceneManager.LoadScene(scene);
    }
}
