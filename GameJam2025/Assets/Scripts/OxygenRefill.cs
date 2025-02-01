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
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Oxygen = collision.gameObject.GetComponent<Healthbar>();
        }
    }
}
