using UnityEngine;

public class PreRoar : MonoBehaviour
{
    [SerializeField] private AudioClip sound;
    private AudioSource audioSource;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerEnter(Collider other) 
    {
        if (other.CompareTag("Player"))
        {
            audioSource = gameObject.AddComponent<AudioSource>(); // Add an AudioSource component
            audioSource.clip = sound;
            Debug.Log("SOUND WORKS YDEEHEHEHEHEH");
            
           
            audioSource.Play(); // Play the ambience sound
    
        }

    }
}
