using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStamina : MonoBehaviour
{
    private int maxStamina= 100;

    private float currentStamina;
    
    public staminaBar staminaBar;

    private WaitForSeconds regenTime = new WaitForSeconds(0.1f);

    private Coroutine regenStamina;
    
    void Start()
    {
        currentStamina = maxStamina;
        staminaBar.SetMaxStamina(maxStamina);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            decresaseStamina();
            Debug.Log(currentStamina);
            
        }
        
        
    }

    public void decresaseStamina()
    {
        if (currentStamina > 0)
        {
            currentStamina -= 0.1f;
            staminaBar.SetStaminaBar(currentStamina);
        
            if (regenStamina != null)
            {
                StopCoroutine(regenStamina);
            }
        
            
            regenStamina = StartCoroutine(increaseStamina());
        }
    }

    private IEnumerator increaseStamina()
    {
        yield return new WaitForSeconds(2);
    
        while (currentStamina < maxStamina)
        { 
            staminaBar.SetStaminaBar(currentStamina);
            currentStamina += 1;
           
            yield return regenTime;
            Debug.Log(currentStamina);
        }
        
        regenTime = null;
    }
}
