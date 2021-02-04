using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int health;
    private AudioManager am;

    private void Start()
    {
        am = FindObjectOfType<AudioManager>();
    }
    public void UpdateHealth(int ModifyValue ) {
        health += ModifyValue;
        if (health <= 0) {
            am.Play("deathZombie");
            Destroy(gameObject);
        }
    }
}
