using System.Threading;
using UnityEngine;

public class FlickeringLight : MonoBehaviour
{

    [SerializeField] Light spotLight;

    private float timer;
    void Start()
    {

        
    }


    void Update()
    {

        timer += Time.deltaTime;

        if (timer >= 10)
        {
            //spotLight.enabled = false;
        }
        
    }
}
