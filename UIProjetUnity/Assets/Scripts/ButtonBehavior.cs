using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonBehavior : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene("SampleScene");
    }
    
    public void Exit()
    {
        Application.Quit();
    }
    
    public void ExitToHome()
    {
        SceneManager.LoadScene("Menu");
    }
}
