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

    public void AttemptToRun(float success_percentage){
        float rand = Random.value;
        // Debug.Log(rand + " : " + success_percentage/100);
        if(success_percentage/100 < rand){
            GoEncounter();
        }else{
            HideEncounterPanel();
        }
    }

        public void ShowEncounterPanel(){
        encounterPanel.gameObject.SetActive(true);
    }
}
