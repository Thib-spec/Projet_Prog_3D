using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    [SerializeField] private Transform selfTransform;    
    [SerializeField] private Transform cameraTransform;
    [SerializeField] private float movementSpeed = 0.2f;
    [SerializeField] private float movementSpeedOnShift = 0.5f;
    [SerializeField] private float cameraSensibility = 0.1f;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private Slider staminaBar;
    [SerializeField] private Stats stats;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        RotateCamera();
        if (stats.OwnKey1)
        {
            Debug.Log("Picked Key 1");
        }

        if (stats.OwnKey2)
        {
            Debug.Log("Picked Key 2");
        }
    }

    public void MovePlayer()
    {

        Vector3 cameraRight = cameraTransform.right;
        Vector3 cameraforward = cameraTransform.forward;
        Vector3 deltaposition = new Vector3(cameraRight.x, 0f, cameraRight.z) * Input.GetAxis("Horizontal") +
                                new Vector3(cameraforward.x, 0f, cameraforward.z) * Input.GetAxis("Vertical");
        
        if (Input.GetKey(KeyCode.LeftShift) && Input.GetAxis("Vertical") == 1 && staminaBar.value > 0)
        {
            movementSpeed = movementSpeedOnShift;
        }
        else
        {
            movementSpeed = 0.02f;
        }
        rb.MovePosition(rb.position + deltaposition * movementSpeed);
    }

    public void RotateCamera()
    {
        float pitch = -Input.GetAxis("Mouse Y");
        pitch = Mathf.Clamp(pitch, -90f, 90f);


        cameraTransform.eulerAngles += new Vector3(pitch, Input.GetAxis("Mouse X"), 0f) * cameraSensibility;
    }
}
