using UnityEngine;
using UnityEngine.SceneManagement;

public class LogoScript : MonoBehaviour
{
    public void LoadGame()
    {
        SceneManager.LoadScene("Game");
    }
}