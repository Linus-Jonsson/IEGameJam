using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    [Header("Put the damage in positive numbers")]
    [SerializeField] private GameObject[] bulletHolePrefabs;
    [SerializeField] private int damage;
    [SerializeField] private float shootRange;
    [Range(.5f, 20f)]
    [SerializeField] private float shootSpeed;
    [SerializeField] private LayerMask hitMask;
    [SerializeField] private ParticleSystem muzzleFlash;
    [SerializeField] private ParticleSystem smoke;
    [SerializeField] private GameObject bloodSplatter;
    [SerializeField] private Animator uziAnimator;
    public bool isShooting;
    private float timer;

    private Vector3 midScreen;
    private GameObject BulletHoleHolder;

    private void Start()
    {
        BulletHoleHolder = new GameObject("Bullet Hole Holder");
    }

    private void Update()
    {

        timer += Time.deltaTime * shootSpeed;
        if (Input.GetMouseButton(0) && timer >= 1f)
        {
            CameraShake.instance.ShootingCamShake();
            AudioManager.instance.Play("shoot");
            midScreen = Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0));
            isShooting = true;
            muzzleFlash.Play();
            smoke.Play();
            uziAnimator.SetBool("shooting", true);
            if (Physics.Raycast(midScreen, Camera.main.transform.forward, out RaycastHit hit, shootRange, hitMask))
            {
                if (hit.collider != null)
                {
                    if (hit.collider.tag == "Wall")
                    {
                        GameObject bulletHole = Instantiate(GetRandomBulletHole(bulletHolePrefabs), hit.point + hit.normal * 0.001f, Quaternion.identity) as GameObject;
                        bulletHole.transform.LookAt(hit.point + hit.normal);
                        bulletHole.transform.SetParent(BulletHoleHolder.transform);
                        Destroy(bulletHole, 7.5f);
                    }
                    if (hit.collider.tag == "Enemy")
                    {
                        hit.collider.GetComponent<Health>().UpdateHealth(-damage);
                        float dir = (hit.point - transform.position).magnitude; 
                        var rot = Quaternion.LookRotation(hit.normal, transform.position - hit.point);
                        
                        Instantiate(bloodSplatter, hit.point, rot);
                    }
                }
            }
            Debug.DrawRay(hit.point,transform.position - hit.point, Color.white);
            timer = 0;
        }
        if (Input.GetMouseButton(0) != true)
        {
            uziAnimator.SetBool("shooting", false);
            isShooting = false;
        }
    }
    private GameObject GetRandomBulletHole(GameObject[] gameObjects) => gameObjects[Random.Range(0, bulletHolePrefabs.Length)]; 

}


