using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMenu : MonoBehaviour
{
    [SerializeField] private Canvas gameMenu;
    private bool isShowing;
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isShowing = !isShowing;
            gameMenu.gameObject.SetActive(isShowing);
        }
    }
}
