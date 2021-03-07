using UnityEngine;

public class gameManager : MonoBehaviour
{
    private bool key1;
    [SerializeField] private AudioClip keyClip;

    [SerializeField] private AudioSource source;

    void Update()
    {
        if (PlayerController.NumberCandlesEnabled == 0 && !key1)
        {
            Instantiate(Resources.Load("key1"), new Vector3(-0.71f, 0.62f, 3.17f), Quaternion.identity).name="key1";
            key1 = true; //Permet de n'instancier qu'une seule fois la clé (d'où la condition)
            source.PlayOneShot(keyClip);
        }
        
    }
}
