using UnityEngine;
using UnityEngine.SceneManagement;

public class Utilities : MonoBehaviour
{
    public void GameTime() 
    {
        GoToGame();

    }
    public void GoToGame()
    {
        SceneManager.LoadScene("MainGame");
    }
}
