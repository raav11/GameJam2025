using Unity.VisualScripting;
using UnityEngine;

public class BaseTracking : MonoBehaviour
{

    private bool inReach;

    private KeepingTrackOfParts keepingTrackOfParts;


    void Awake()
    {

        keepingTrackOfParts = GameObject.Find("Player").GetComponent<KeepingTrackOfParts>();


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

            if (inReach && Input.GetKeyDown(KeyCode.E) && keepingTrackOfParts.holding)
            {

            keepingTrackOfParts.counter++;
            keepingTrackOfParts.holding = false;

            Debug.Log("look!" + keepingTrackOfParts.counter + "The amount of parts you have!");


        }

            if (keepingTrackOfParts.counter >= 5)
        {
            Debug.Log("Thou has woneth!");
        }

    }
}
