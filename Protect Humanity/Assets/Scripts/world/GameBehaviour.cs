using UnityEngine;
using UnityEngine.SceneManagement;

public class GameBehaviour : MonoBehaviour
{
    private string nextEncounter;
    public static GameBehaviour Instance;

    public GameObject encounterPanel;
    private void Awake()
    {
        if (Instance == null){
            Instance = this;
        }else if(Instance != this){
            Destroy(gameObject);
        }
    }


    public void GoToScene(string sceneName){
        SceneManager.LoadScene(sceneName);
    }

    public void SetNextEncounter(string encounterName){
        nextEncounter = encounterName;
    }

    public void GoEncounter(){
        SceneManager.LoadScene(nextEncounter);
    }

    public void HideEncounterPanel(){
        encounterPanel.gameObject.SetActive(false);
    }

        public void ShowEncounterPanel(){
        encounterPanel.gameObject.SetActive(true);
    }
}
