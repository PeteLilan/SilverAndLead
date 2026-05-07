using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public void restartGame()
    {
        SceneManager.LoadScene("Scene1"); // Load Level_01
    }
}