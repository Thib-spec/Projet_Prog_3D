using System.Collections;
using UnityEngine;

public class PlayerStamina : MonoBehaviour
{
    private static float maxStamina= 100f;

    private float currentStamina;
    
    public StatManager staminaBar;

    private WaitForSeconds regenTime = new WaitForSeconds(0.1f); // On évite de recréer un WaitForSeconds à chaque appel de la coroutine

    private Coroutine regenStamina;
    
    void Start()
    {
        currentStamina = maxStamina;            // le joueur commence avec sa stamina au max
        staminaBar.SetMaxBar(maxStamina);
    }
    
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
            currentStamina -= Time.deltaTime*20;        // On diminue la stamina progressivement
            staminaBar.SetBar(currentStamina);          // On actualise l'UI
        
            if (regenStamina != null)                   // On stoppe la coroutine une fois la barre chargée
            {
                StopCoroutine(regenStamina);
            }
            
            regenStamina = StartCoroutine(increaseStamina()); 
        }
    }

    private IEnumerator increaseStamina()
    {
        yield return new WaitForSeconds(2);     // On attend deux secondes
    
        while (currentStamina < maxStamina)
        {
            staminaBar.SetBar(currentStamina);  // On actualise l'UI (barre bleue)
            currentStamina += 1;                // On regen progressivement la stamina
           
            yield return regenTime;
        }
        
        regenStamina = null;
    }
}
