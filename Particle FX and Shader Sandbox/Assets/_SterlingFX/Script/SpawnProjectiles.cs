﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnProjectiles : MonoBehaviour
{
    public GameObject firePoint;
    public List<GameObject> vfx = new List<GameObject>();
    public RotateToMouse RotateToMouse;

    private GameObject effectToSpawn;
    private float timeToFire = 0;

    void Start()
    {
        effectToSpawn = vfx [0];
    }

    void Update()
    {
        if (Input.GetMouseButton (0) && Time.time >= timeToFire)
        {
            timeToFire = Time.time + 1 / effectToSpawn.GetComponent<ProjectileMove>().fireRate;
            SpawnVFX();
        }
    }

    void SpawnVFX()
    {
        GameObject vfx;

        if (firePoint != null)
        {
            vfx = Instantiate(effectToSpawn, firePoint.transform.position, Quaternion.identity);
            if (RotateToMouse != null)
            {
                vfx.transform.localRotation = RotateToMouse.GetRotation();
            }
        } else
        {
            Debug.Log("No Fire Point");
        }
    }
}
