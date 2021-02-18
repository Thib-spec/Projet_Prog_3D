using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonBehavior : MonoBehaviour
{
    [SerializeField] private Canvas gameMenu;
    public void Play()
    {
        SceneManager.LoadScene("SampleScene");
    }
    
    public void Exit()
    {
        Application.Quit();
    }

    public void Resume()
    {
        gameMenu.gameObject.SetActive(false); //On désactive le canvas pour revenir en jeu
        Time.timeScale = 1f; /*On redéfinit l'échelle de temps (vitesse à laquelle le temps passe)
        Sur 1 pour que le jeu reprenne normalement, car dans le script gameMenu, lors de l'affichage du Canvas,
        on a arrêté le défilement du jeu*/
    }

    public void ExitToHome()
    {
        SceneManager.LoadScene("Menu");
    }
}
