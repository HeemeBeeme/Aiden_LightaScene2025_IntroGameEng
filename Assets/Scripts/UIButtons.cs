using UnityEngine;
using UnityEngine.SceneManagement;

public class UIButtons : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("Hospital_Level", LoadSceneMode.Single);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
