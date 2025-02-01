using UnityEngine;

public class KeepingTrackOfParts : MonoBehaviour
{
    public float counter = 0f;
    public bool holding = false;

    [SerializeField] private AudioClip ambience;
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>(); // Add an AudioSource component
        audioSource.clip = ambience;
        audioSource.loop = true; // Enable looping
        audioSource.playOnAwake = true;
        audioSource.Play(); // Play the ambience sound
    }
}

