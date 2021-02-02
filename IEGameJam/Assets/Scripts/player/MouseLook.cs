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

    private Transform plr;
    private Camera cam;
    [SerializeField] private Image crosshair;

    void Start()
    {
        plr = transform.parent.transform;
        Cursor.lockState = CursorLockMode.Locked;
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

        plr.Rotate(Vector3.up * mouseX);

        if (mouse1)
        {
            zoomedAmmount += -Time.deltaTime * 10;
            sensitivity = 150;
            crosshair.enabled = false;
        }
        else
        {
            zoomedAmmount += Time.deltaTime * 10;
            sensitivity = 300f;
            crosshair.enabled = true;
        }

        zoomedAmmount = Mathf.Clamp(zoomedAmmount, -1.4f, 0f);
        currentFoV = defaultFoV + endFoV * zoomedAmmount;

        cam.fieldOfView = currentFoV;
    }
}
