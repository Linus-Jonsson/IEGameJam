using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MouseLook : MonoBehaviour
{
    private float sensitivity;
    [SerializeField] private float startSensitivity;
    private float xRotation = 0f;

    private float endFoV = 30f;
    private float currentFoV;
    private float defaultFoV = 60f;
    private float zoomedAmmount;

    private Transform plrTransform;
    private Camera cam;
    private PlayerController plrController;
    private Shoot shootScript;

    [SerializeField] private Image crosshair;

    void Start()
    {
        //Cursor.lockState = CursorLockMode.Locked; - Init in StartGame() in GameLoopController

        plrTransform = transform.parent.transform;
        plrController = FindObjectOfType<PlayerController>();
        cam = GetComponent<Camera>();
        shootScript = FindObjectOfType<Shoot>();
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

        bool mouse1 = Input.GetKey(KeyCode.Mouse1);

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        plrTransform.Rotate(Vector3.up * mouseX);

        if (mouse1)
        {
            if (plrController.GetState() != PlayerState.dead && plrController.GetState() != PlayerState.won)
            {
                if (shootScript.isShooting != true)
                {
                    sensitivity = startSensitivity * 0.3f;
                    zoomedAmmount += -Time.deltaTime * 10;

                    crosshair.enabled = false;
                    plrController.SetState(PlayerState.aiming);
                }
            }
        }
        else
        {
            zoomedAmmount += Time.deltaTime * 10;
            crosshair.enabled = true;

            if (currentFoV == defaultFoV)
            {
                sensitivity = startSensitivity;
                plrController.SetState(PlayerState.notAiming);
            }
        }

        
        zoomedAmmount = Mathf.Clamp(zoomedAmmount, -1.2f, 0f);
        currentFoV = defaultFoV + endFoV * zoomedAmmount;

        cam.fieldOfView = currentFoV;
    }
}
