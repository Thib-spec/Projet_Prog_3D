using System;
using System.Collections;
using System.Collections.Generic;
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
    [SerializeField] private GameObject wallLastScene;
    private BatteryController battery;
    private int interactableLayerMask;

    private bool open;
    public static int NumberCandlesEnabled;

    void Awake()
    {
        interactableLayerMask = LayerMask.GetMask("Interactable");
    }
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        interac.text = "";
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
        
        if (Input.GetKey(KeyCode.LeftShift) && Math.Abs(Input.GetAxis("Vertical") - 1) <= 0 && staminaBar.value > 0)
        if (Input.GetKey(KeyCode.LeftShift) && Input.GetAxis("Vertical") == 1 && staminaBar.value > 0) // Si notre stamina est supérieure à 0 et que l'on se déplace vers l'avant
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

    private void raycastColl()
    {
        RaycastHit raycastHit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out raycastHit,3f,interactableLayerMask))
        {
            interac.text = "Appuyez sur E pour interagir";
            if (Input.GetKeyDown(KeyCode.E))
                    {

                        {
                            if (raycastHit.collider.name == "candle")
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

                            if (raycastHit.collider.name == "Door") //&& stats.OwnKey1)
                            {
                                raycastHit.collider.GetComponent<Animator>().SetBool("open", !open);
                                open = !open;
                            }

                            if (raycastHit.collider.name == "key1")
                            {
                                stats.OwnKey1 = true;
                                Destroy(raycastHit.collider.gameObject);
                            }

                            if (raycastHit.collider.name == "key2")
                            {
                                stats.OwnKey2 = true;
                                Destroy(raycastHit.collider.gameObject);
                                Destroy(wallLastScene);
                            }

                            if (raycastHit.collider.name == "key3")
                            {
                                stats.OwnKey3 = true;
                                Destroy(raycastHit.collider.gameObject);
                                SceneManager.LoadScene("Victory Scene");
                            }

                            if (raycastHit.collider.name == "battery")
                            {
                                battery = raycastHit.collider.gameObject.GetComponent<BatteryController>();
                                battery.BatteryCharge();
                                Destroy(raycastHit.collider.gameObject);
                            }
                        }
                    }
        }
        else
        {
            interac.text = "";
        }

    }
}
