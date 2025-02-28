using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerInteraction : MonoBehaviour
{
    //creates an object and sets it to null
    public GameObject currentInterObj = null;
    public InteractionObject currentInterObjScript = null;
    public Inventory inventory;
    public GameObject interactionUI;




    void Start()
    {
        if(interactionUI != null)
        {
            interactionUI.SetActive(false);
        }
    }

    public static GameBehaviour Instance;


    //function that allows user to use whatever item is being interacted with
    void Update()
    {
        if(Input.GetButtonDown ("Interact") && currentInterObj)
        {
            //check if object can be stored in inventory
            if(currentInterObjScript.inventory)
            {
                inventory.AddItem(currentInterObj);
            }
            currentInterObj.SendMessage("DoInteraction");
            interactionUI.SetActive(false);
        }


            if(Input.GetKeyDown(KeyCode.I))
            {
                inventory.ToggleInventory();
            }
        }








    //when player comes in contact with an object
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("interObject"))
        {
            Debug.Log(other.name);
            currentInterObj = other.gameObject;
            currentInterObjScript = currentInterObj.GetComponent <InteractionObject> ();




            if(interactionUI != null)
            {
                interactionUI.SetActive(true);
            }
        }


        if(other.CompareTag("encounter"))
        {
            GetComponent<PlayerMovement>().LockMovement();
            GameBehaviour.Instance.ShowEncounterPanel();
            //GameBehaviour.Instance.SetNextEncounter(other.GetComponent<Encounter>().encounterSceneName);
        }
    }








    //when players leaves the range of object's collider
    void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag ("interObject"))
        {
            if(other.gameObject == currentInterObj)
            {
                currentInterObj = null;
                if(interactionUI != null)
                {
                    interactionUI.SetActive(false);
                }
            }
        }
        if(other.gameObject.tag == "encounter")
        {
            GameBehaviour.Instance.HideEncounterPanel();
        }
    }
}
