using UnityEngine;

public class Menu : MonoBehaviour //Script pour le menu de lancement du jeu
{
    
    void Start()
    {
        Cursor.visible = true; //Déjà expliqué ailleurs
        Cursor.lockState = CursorLockMode.Confined;
    }
}
