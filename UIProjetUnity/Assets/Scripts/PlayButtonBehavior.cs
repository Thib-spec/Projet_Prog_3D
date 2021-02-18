using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButtonBehavior : MonoBehaviour
{
   
    public void Play()
    {
        SceneManager.LoadScene("SampleScene");
    }
    
}
