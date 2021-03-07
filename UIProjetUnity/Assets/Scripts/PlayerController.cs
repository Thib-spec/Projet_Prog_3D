using System;
using DefaultNamespace;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    [SerializeField] private Transform selfTransform;
    [SerializeField] private float movementSpeed=4f;
    [SerializeField] private float movementSpeedOnShift=8f;
    [SerializeField] private float cameraSensibility = 0.1f;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private Slider staminaBar;
    [SerializeField] private Stats stats;
    [SerializeField] private TextMeshProUGUI interac;
    [SerializeField] private GameObject wallLastScene; //Correspond au game object du mur qui va être
    //retiré lors de la récupération de la 2ème clé (pour accéder à la dernière salle)
    private BatteryController battery;
    private int interactableLayerMask;

    private bool open;
    public static int NumberCandlesEnabled; //Contient le nombre de bougies allumées, permet de faire apparaître
    //la clé si cette variable est à 0

    void Awake()
    {
        interactableLayerMask = LayerMask.GetMask("Interactable"); //On récupère le layerMask 
        //correspondant aux objets avec lesquels on peut interagir
    }
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        interac.text = ""; //Correspond au texte affiché lorsque l'utilisateur pointe son curseur sur un objet
        //avec lequel on peut interagir
        NumberCandlesEnabled = 9; 
    }

    
    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        RotateCamera();
        raycastColl();
        if (stats.Health <= 0)
        {
            SceneManager.LoadScene("DeathScene");
        }
    }

    public void MovePlayer()
    {

        Vector3 cameraRight = selfTransform.right;
        Vector3 cameraforward = selfTransform.forward;
        Vector3 deltaposition = new Vector3(cameraRight.x, 0f, cameraRight.z) * Input.GetAxis("Horizontal") +
                                new Vector3(cameraforward.x, 0f, cameraforward.z) * Input.GetAxis("Vertical");
        
        if (Input.GetKey(KeyCode.LeftShift) && Math.Abs(Input.GetAxis("Vertical") - 1) <= 0 && staminaBar.value > 0) // Si notre stamina est supérieure à 0 et que l'on se déplace vers l'avant
        {
            movementSpeed = movementSpeedOnShift;  // On modifie la vitesse de déplacement pour sprinter
        }
        else
        {
            movementSpeed = 4f;
        }
        rb.MovePosition(rb.position + deltaposition * (movementSpeed * Time.deltaTime));
    }

    public void RotateCamera()
    {
        float pitch = -Input.GetAxis("Mouse Y");
        pitch = Mathf.Clamp(pitch, -90f, 90f);


        selfTransform.eulerAngles += new Vector3(pitch, Input.GetAxis("Mouse X"), 0f) * cameraSensibility;
    }

    private void raycastColl() //Fonction qui va gérer tout le système de raycast (pour les objets avec lesquels
    //on va interagir)
    {
        RaycastHit raycastHit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); //Le rayon part de la caméra, dans la direction
        //pointée par notre curseur
        if (Physics.Raycast(ray, out raycastHit,3f,interactableLayerMask)) //Si le raycast rencontre
        //un objet de type "interactable" (avec lequel on peut interagir)
        {
            if (interac.text == "") //Permet de gérer l'affichage du texte selon qu'il soit vide
            //(si on ne pointe pas vers un objet avec lequel on peut interagir), ou qu'il contienne le texte
            //indiquant que le joueur ne possède pas la clé
            {
                interac.text = "Appuyez sur E pour interagir"; //On modifie le texte affiché au centre de l'écran
            }
            if (Input.GetKeyDown(KeyCode.E))
            {
                {
                    if (raycastHit.collider.name == "candle") //Si l'objet pointé est une bougie,
                    //on l'éteint (en désactivant les game objects correspondant à la flamme et à la
                    //lumière) ou on la rallume selon l'état de la bougie actuelle
                    //puis on modifie la variable contenant le nombre de bougies allumées
                    {
                        if (raycastHit.collider.transform.GetChild(0).gameObject.activeSelf)
                        {
                            raycastHit.collider.transform.GetChild(0).gameObject.SetActive(false);
                            raycastHit.collider.transform.GetChild(2).gameObject.SetActive(false);
                            NumberCandlesEnabled--;
                        }
                        else
                        {
                            raycastHit.collider.transform.GetChild(0).gameObject.SetActive(true);
                            raycastHit.collider.transform.GetChild(2).gameObject.SetActive(true);
                            NumberCandlesEnabled++;
                        }
                    }

                    if (raycastHit.collider.name == "Door" && stats.OwnKey1) //Si l'objet pointé est la porte,
                    //et que l'utilisateur possède la clé, on l'ouvre ou la referme selon son état
                    {
                        raycastHit.collider.GetComponent<Animator>().SetBool("open", !open);
                        open = !open;
                    }

                    if (raycastHit.collider.name == "Door" && !stats.OwnKey1) //Si par contre il ne possède pas la
                    //clé, on modifie le message
                    {
                        interac.text = "Vous n'avez pas la clé";
                    }

                    if (raycastHit.collider.name == "key1") //Si l'objet pointé est une clé, on modifie
                    //les stats du joueur pour garder en mémoire qu'il a la clé et on détruit la clé
                    {
                        stats.OwnKey1 = true;
                        Destroy(raycastHit.collider.gameObject);
                    }

                    if (raycastHit.collider.name == "key2")
                    {
                        stats.OwnKey2 = true;
                        Destroy(raycastHit.collider.gameObject);
                        Destroy(wallLastScene); //Pour la 2ème clé, on détruit le mur qui mène à la dernière salle
                    }

                    if (raycastHit.collider.name == "key3")
                    {
                        stats.OwnKey3 = true;
                        Destroy(raycastHit.collider.gameObject);
                        SceneManager.LoadScene("Victory Scene"); //Pour la dernière clé, elle donne la victoire
                    }

                    if (raycastHit.collider.name == "battery") //Si l'objet pointé est une batterie,
                    //on utilise la méthode BatteryCharge pour recharger la batterie de la lampe torche
                    //et on détruit la batterie
                    {
                        battery = raycastHit.collider.gameObject.GetComponent<BatteryController>();
                        battery.BatteryCharge();
                        Destroy(raycastHit.collider.gameObject);
                    }
                }
            }
        }
        else //Si l'objet pointé n'est pas de type "interactable", on n'affiche aucun texte
        {
            interac.text = "";
        }

    }
}
