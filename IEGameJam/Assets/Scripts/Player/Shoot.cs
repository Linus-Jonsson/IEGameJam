using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField] private float shootSpeed;
    private float timer;

    private void Update() {
        timer += Time.deltaTime * shootSpeed;
        if (Input.GetMouseButton(0) && timer >= 1f) {

        }
    }
}
