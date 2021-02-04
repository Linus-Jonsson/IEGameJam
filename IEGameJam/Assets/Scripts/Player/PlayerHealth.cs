using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int health;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            UpdateHealth(1);
        }
    }

    public void UpdateHealth(int ModifyValue)
    {
        CameraShake.instance.GotHitCamShake();
        health += ModifyValue;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
