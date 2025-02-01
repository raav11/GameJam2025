using UnityEngine;

public class OxygenRefill : MonoBehaviour
{
    private Healthbar Oxygen;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Oxygen = other.gameObject.GetComponent<Healthbar>();
            Oxygen.RestoreHealth(20);
            
        }
    }
}
