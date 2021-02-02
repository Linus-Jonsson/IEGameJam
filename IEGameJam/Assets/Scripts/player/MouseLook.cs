using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MouseLook : MonoBehaviour
{
    private float sensitivity = 300f;
    private float xRotation = 0f;

    private float endFoV = 30f;
    private float currentFoV;
    private float defaultFoV = 60f;
    private float zoomedAmmount;

    private Transform plrTransform;
    private Camera cam;
    private PlayerController plrController;

    [SerializeField] private Image crosshair;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;

        plrTransform = transform.parent.transform;
        plrController = FindObjectOfType<PlayerController>();
        cam = GetComponent<Camera>();
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
                zoomedAmmount += -Time.deltaTime * 10;
                sensitivity = 150;
                crosshair.enabled = false;
                plrController.SetState(PlayerState.aiming);
            }
        }
        else
        {
            zoomedAmmount += Time.deltaTime * 10;
            sensitivity = 300f;
            crosshair.enabled = true;

            if (currentFoV == defaultFoV)
            {
                plrController.SetState(PlayerState.notAiming);
            }
        }

        zoomedAmmount = Mathf.Clamp(zoomedAmmount, -1.4f, 0f);
        currentFoV = defaultFoV + endFoV * zoomedAmmount;

        cam.fieldOfView = currentFoV;
    }
}
