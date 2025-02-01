using UnityEngine;
using UnityEngine.SceneManagement;


public class Jumpscareswitch : MonoBehaviour
{
    [SerializeField] private AudioClip sound;
    private AudioSource audioSource;
    private float switchCounter;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>(); // Add an AudioSource component
        audioSource.clip = sound;
        audioSource.Play();
        
        
    }

    // Update is called once per frame
    void Update()
    {
        switchCounter += Time.deltaTime;
        Debug.Log("First");

        
        if (switchCounter >= 2.2) 
        {
            Debug.Log("Second");
            switchCounter = 0;
            SceneManager.LoadScene("DeathScreen");
        }
        
    }
}
