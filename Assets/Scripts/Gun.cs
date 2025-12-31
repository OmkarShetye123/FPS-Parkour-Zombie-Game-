using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public ParticleSystem muzzleFlash;

    public Camera cam;

    public AudioSource audioSource;

    public AudioClip clip;

    public int maxAmmo;
    public int currentAmmo;

    public float nextTimetoFire;
    public float fireRate;

    public bool handgun;

    private void Start()
    {
        cam = Camera.main;

        audioSource = GetComponent<AudioSource>();

        audioSource.clip = clip;
    }

    private void Update()
    {
        if (!GameManager.instance.player) return;
        GameManager.instance.ammoText.text = $"Ammo : {currentAmmo}/{maxAmmo}";

        if (handgun) return;

        if (Input.GetMouseButtonDown(0) && currentAmmo > 0)
        {
            muzzleFlash.Play();
            audioSource.Play();
        }
        else if (Input.GetMouseButtonUp(0))
        {
            muzzleFlash.Stop();
            audioSource.Stop();
        }

    }

    public void Shoot()
    {
        if(Time.time >= nextTimetoFire && currentAmmo>0)
        {
            if (handgun)
            {
                muzzleFlash.Play();
                audioSource.Play();
            }
            nextTimetoFire = Time.time + 1 / fireRate;
            RaycastHit hit;

            if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit))
            {
                Zombie zombie = hit.collider.GetComponent<Zombie>();
                if (zombie != null)
                {
                    zombie.health -= 10;
                    Instantiate(GameManager.instance.blood, hit.point, Quaternion.LookRotation(hit.normal), zombie.transform); 
                }
            }
            currentAmmo--;
        }
    }
}
