using System.Threading;
using UnityEngine;

public class FlickeringLight : MonoBehaviour
{

    [SerializeField] Light spotLight;

    public float timer;
    void Start()
    {

        
    }


    void Update()
    {

        timer += Time.deltaTime;

        if (timer >= 10)
        {
            spotLight.enabled = false;

            if (timer >= 10.2) 
            {

                timer = 0;

            }

            return;
        }


        spotLight.enabled = true;
        
        
    }
}
