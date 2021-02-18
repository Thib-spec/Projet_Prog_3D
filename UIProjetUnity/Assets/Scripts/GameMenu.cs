using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMenu : MonoBehaviour
{
    [SerializeField] private Canvas gameMenu;
    private bool isShowing;
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) /*Lors de l'appui sur espace, on active ou désactive le canvas (menu pause)
        selon son état précédent (si le menu était déjà affiché, on ne l'affiche plus et inversement)*/
        {
            isShowing = !isShowing;
            gameMenu.gameObject.SetActive(isShowing);
        }

        if (isShowing)
        {
            Time.timeScale = 0f; /*On définit l'échelle de temps (vitesse à laquelle le temps passe)
            Sur 0 pour que le jeu s'arrête dans le temps (jeu ne défile plus)*/
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.Confined; //Indique que le curseur est bloqué dans la fenêtre du jeu
        }
        else
        {
            Time.timeScale = 1f; //On relance le jeu
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked; //On bloque le curseur (il n'est plus mobile) qui n'est plus visible

        }
    }
    
}
