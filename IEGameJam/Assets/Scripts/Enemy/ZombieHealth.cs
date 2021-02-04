using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieHealth : MonoBehaviour
{
    public int health;

    public void UpdateHealth(int ModifyValue ) {
        health += ModifyValue;
        if (health <= 0) {
            Destroy(gameObject);
        }
    }
}
