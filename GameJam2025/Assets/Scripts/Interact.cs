using System;
using UnityEngine;
using UnityEngine.InputSystem.Android;
using UnityEngine.UI;
using UnityEngine.WSA;

public class Interact : MonoBehaviour
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
        if (inReach && Input.GetKeyDown(KeyCode.E) && !keepingTrackOfParts.holding)
        {

            Debug.Log("DESTROY THYSELF!");

            keepingTrackOfParts.holding = true;

            Destroy(gameObject);
        }

    }
}