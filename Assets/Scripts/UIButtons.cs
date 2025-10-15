using UnityEngine;
using UnityEngine.SceneManagement;

public class UIButtons : MonoBehaviour
{
    public bool SettingsMenuActivity = false;
    public GameObject SettingsMenuObj;
    public GameObject MainUI;

    public void StartGame()
    {
        SceneManager.LoadScene("Hospital_Level", LoadSceneMode.Single);
    }

    public void SettingsMenu()
    {
        if(!SettingsMenuActivity)
        {
            SettingsMenuObj.SetActive(true);
            MainUI.SetActive(false);
            SettingsMenuActivity = true;
        }
        else
        {
            SettingsMenuObj.SetActive(false);
            MainUI.SetActive(true);
            SettingsMenuActivity = false;
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
