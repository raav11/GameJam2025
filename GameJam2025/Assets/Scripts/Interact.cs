using UnityEngine;
using UnityEngine.UI;
using UnityEngine.WSA;

public class Interact : MonoBehaviour
{

    private bool inReach;

    private InteractableGateWay interactableGateWay;


    void Awake()
    {

        //interactableGateWay = GetComponent<InteractableGateWay>();


    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            inReach = true;
            
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            inReach = false;
            
        }
    }

    void Update()
    {
        if (inReach && Input.GetKeyDown(KeyCode.E))
        {

            //TestingPurposes();            
        }

    }
}