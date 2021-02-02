using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingRay : MonoBehaviour
{
    void Update()
    {
        Vector3 lineOrgin = Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0));
        Debug.DrawRay(lineOrgin, Camera.main.transform.forward * 50.0f, Color.green);
    }
}
