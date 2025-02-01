using UnityEngine;
using UnityEngine.SceneManagement;

public class DIE : MonoBehaviour
{
    void OnCollisionEnter(Collision collision) 
    {
        if (collision.gameObject.CompareTag("Player"))
        {

             SceneManager.LoadScene("Jumpscares");
        }

    }


}
