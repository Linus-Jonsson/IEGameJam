using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    [Header("Put the damage in positive numbers")]
    [SerializeField] private int damage;
    [SerializeField] private float shootRange;
    [SerializeField] private float shootSpeed;
    [SerializeField] private LayerMask hitMask;
    [SerializeField] private ParticleSystem muzzleFlash;
    [SerializeField] private ParticleSystem smoke;
    [SerializeField] private Animator uziAnimator;
    public bool isShooting;
    private float timer;

    private Vector3 midScreen;

    private void Update()
    {

        timer += Time.deltaTime * shootSpeed;
        if (Input.GetMouseButton(0) && timer >= 1f)
        {
            midScreen = Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0));
            isShooting = true;
            muzzleFlash.Play();
            smoke.Play();
            uziAnimator.SetBool("shooting", true);
            if (Physics.Raycast(midScreen, Camera.main.transform.forward, out RaycastHit hit, shootRange, hitMask))
            {
                if (hit.collider != null)
                {
                    hit.collider.GetComponent<Health>().UpdateHealth(-damage);
                }
            }
            timer = 0;
        }
        if (Input.GetMouseButton(0) != true)
        {
            uziAnimator.SetBool("shooting", false);
            isShooting = false;
        }
    }
}


