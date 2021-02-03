using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int health;

    public void UpdateHealth(int ModifyValue ) {
        health += ModifyValue;
        if (health <= 0) {
            gameObject.SetActive(false);
        }
    }
}
