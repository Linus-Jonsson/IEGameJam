using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunAnimator : MonoBehaviour
{
    private Animator anm;
    private bool PlrisAiming;

    void Start()
    {
        anm = GetComponent<Animator>();
    }

    void Update()
    {
        anm.SetBool("isAiming", PlrisAiming);
    }
    public void isAiming(bool tf)
    {
        PlrisAiming = tf;
    }
}
