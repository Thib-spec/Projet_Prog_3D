using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{

    private const float delay = 5f;
    private float timer = 0f; //temps qui va être comparé au delay, dès qu'il va l'atteindre : changement de scène
    
    
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > delay)
        {
            SceneManager.LoadScene("Menu");
        }
    }
}
