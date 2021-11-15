using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private WeaponManager weapon_Manager;

    public float fireRate = 15f;
    private float nextTimeToFire;

    private Camera mainCam;


    public float damage = 20f;



    private void Awake()
    {
        weapon_Manager = GetComponent<WeaponManager>();
        mainCam = Camera.main;

    }

    // Start is called before the first frame update
    void Start()
    {

    }

    void Update()
    {
        WeaponShoot();
    }


    void WeaponShoot()
    {

        // if we have assault riffle
        if (weapon_Manager.GetCurrentSelectedWeapon().fireType == WeaponFireType.MULTIPLE)
        {

            // if we press and hold left mouse click AND
            // if Time is greater than the nextTimeToFire
            if (Input.GetMouseButton(0) && Time.time > nextTimeToFire)
            {

                nextTimeToFire = Time.time + 1f / fireRate;

                weapon_Manager.GetCurrentSelectedWeapon().ShootAnimation();

                 BulletFired();
            }
        }
        else
        {

            if (Input.GetMouseButtonDown(0))
            {

                // handle axe
                if (weapon_Manager.GetCurrentSelectedWeapon().tag == Tags.AXE_TAG)
                {
                    weapon_Manager.GetCurrentSelectedWeapon().ShootAnimation();
                }

                // handle shoot
                if (weapon_Manager.GetCurrentSelectedWeapon().bulletType == WeaponBulletType.BULLET)
                {

                    weapon_Manager.GetCurrentSelectedWeapon().ShootAnimation();

                     BulletFired();
                }
            }
        }

    }

    void BulletFired()
    {

        RaycastHit hit;

        if (Physics.Raycast(mainCam.transform.position, mainCam.transform.forward, out hit))
        {
            print("WE HIT : " + hit.transform.gameObject.name);
            if (hit.transform.tag == Tags.ENEMY_TAG)
            {
               // hit.transform.GetComponent<HealthScript>().ApplyDamage(damage);
            }

        }
    }
}
