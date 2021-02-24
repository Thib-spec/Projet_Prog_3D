using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using TMPro;
using UnityEngine;
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
    private int interactableLayerMask;
    
    private bool open;
    private bool candleEnabled;

    void Awake()
    {
        interactableLayerMask = LayerMask.NameToLayer("Interactable");
    }
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        interac.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        RotateCamera();
        raycastColl();
    }

    public void MovePlayer()
    {

        Vector3 cameraRight = selfTransform.right;
        Vector3 cameraforward = selfTransform.forward;
        Vector3 deltaposition = new Vector3(cameraRight.x, 0f, cameraRight.z) * Input.GetAxis("Horizontal") +
                                new Vector3(cameraforward.x, 0f, cameraforward.z) * Input.GetAxis("Vertical");
        
        if (Input.GetKey(KeyCode.LeftShift) && Input.GetAxis("Vertical") == 1 && staminaBar.value > 0)
        {
            movementSpeed = movementSpeedOnShift;
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
        if (Physics.Raycast(ray, out raycastHit,2f,~interactableLayerMask))
        {
            interac.text = "Appuyez sur E pour interagir";
            if (Input.GetKeyDown(KeyCode.E))
                    {
                        
                        {
                            if (raycastHit.collider.name == "candle")
                            {
                                raycastHit.collider.transform.GetChild(0).gameObject.SetActive(candleEnabled);
                                candleEnabled = !candleEnabled;
                            }
                            
                            if (raycastHit.collider.name =="Door")
                            {
                                raycastHit.collider.GetComponent<Animator>().SetBool("open",!open);
                                open = !open;
                            }
                            if (raycastHit.collider.name =="key1" || 
                                raycastHit.collider.name =="key2" ||
                                raycastHit.collider.name =="key3")
                            {
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
