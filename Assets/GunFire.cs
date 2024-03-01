using System.Collections;
using UnityEngine;

public class GunFire : MonoBehaviour
{
    [SerializeField] private Transform barrelLoc;
    [SerializeField] private GameObject muzzleFire;
    [SerializeField] private GameObject bulletPref;
    [SerializeField] private float fireRate = 0.5f;

    private bool shooting = false;

    private void Start()
    {
        muzzleFire.SetActive(false);
    }
    private void Update()
    {

        // Toggle shooting state based on mouse button
        if (Input.GetMouseButtonDown(0))
        {
            StartShooting();
        }
        else if (Input.GetMouseButtonUp(0))
        {
            StopShooting();
        }
    }

    private void StartShooting()
    {
        if (!shooting)
        {
            muzzleFire.SetActive(true);
            shooting = true;
            StartCoroutine(ShootingRoutine());
        }
    }

    private void StopShooting()
    {
        if (shooting)
        {
            muzzleFire.SetActive(false);
            shooting = false;
            StopAllCoroutines(); // Stop any ongoing shooting coroutine
        }
    }

    private IEnumerator ShootingRoutine()
    {
        while (shooting)
        {
            // Instantiate Bullet
            Instantiate(bulletPref, barrelLoc.position, barrelLoc.transform.rotation);
            yield return new WaitForSeconds(fireRate);
        }
    }
}
