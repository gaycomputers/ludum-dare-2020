using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ThrowAlcohol : MonoBehaviour
{
    [SerializeField] private Transform projectileSpawn;
    [SerializeField] private GameObject projectile;
    [SerializeField] private float speedMultiplierx;
    [SerializeField] private float speedMultipliery;
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonUp("Fire1"))
        {
            GameObject p = Instantiate(projectile, projectileSpawn.position, projectileSpawn.rotation);
            Rigidbody r = p.GetComponent<Rigidbody>();
            r.AddForce(projectileSpawn.right * Input.GetAxis("Mouse X") * speedMultiplierx, ForceMode.VelocityChange);
            r.AddForce(projectileSpawn.forward * Input.GetAxis("Mouse Y") * speedMultipliery, ForceMode.VelocityChange);
        }
    }
}
