using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStamina : MonoBehaviour
{
    private float maxStamina= 100f;

    private float currentStamina;
    
    public StatManager staminaBar;

    private WaitForSeconds regenTime = new WaitForSeconds(0.1f);

    private Coroutine regenStamina;
    
    void Start()
    {
        currentStamina = maxStamina;
        staminaBar.SetMaxBar(maxStamina);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            decresaseStamina();
        }


    }

    public void decresaseStamina()
    {
        if (currentStamina > 0)
        {
            currentStamina -= Time.deltaTime*20;
            staminaBar.SetBar(currentStamina);
        
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
            staminaBar.SetBar(currentStamina);
            currentStamina += 1;
           
            yield return regenTime;
        }
        
        regenStamina = null;
    }
}
