using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField] private float shootRange;
    [SerializeField] private float shootSpeed;
    private float timer;

    private Vector3 midScreen;

    private void Update() {

        

        timer += Time.deltaTime * shootSpeed;
        if (Input.GetMouseButton(0) && timer >= 1f) {
            midScreen = Camera.main.ViewportToWorldPoint(new Vector3(0.5f,0.5f,0));
            if (Physics.Raycast(midScreen, Camera.main.transform.forward, out RaycastHit hit, shootRange)) {

            }
            
        }
    }

}
