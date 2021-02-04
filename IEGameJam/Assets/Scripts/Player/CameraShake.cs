using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    [Header("only place this component on one game object")]
    public Animator camAnim;

    #region singleton
    public static CameraShake instance;
    private void Awake() => instance = this;
    #endregion

    public void GotHitCamShake()
    {
        camAnim.SetTrigger("Got hit shake");
    }
    public void ShootingCamShake()
    {
        camAnim.SetTrigger("Shooting shake");
    }

}
