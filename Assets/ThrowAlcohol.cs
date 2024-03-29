﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ThrowAlcohol : MonoBehaviour
{
    [SerializeField] private Transform projectileSpawn;
    [SerializeField] private GameObject projectile;
    [SerializeField] private float speedMultiplierx;
    [SerializeField] private float speedMultipliery;
    [SerializeField] private int FRAMES_AGO_THROW_VELOCITY = 2;
    private Queue<Vector3> OLD_VELOCITY = new Queue<Vector3>();
    // Update is called once per frame
    void Update()
    {   
        /*
        if (Input.GetButtonUp("Fire1"))
        {
            GameObject p = Instantiate(projectile, projectileSpawn.position, projectileSpawn.rotation);
            Rigidbody r = p.GetComponent<Rigidbody>();
            Destroy(p,2);
            if (OLD_VELOCITY.Count > 0){
                Vector3 displace = Input.mousePosition - OLD_VELOCITY.Dequeue();

                r.AddForce(projectileSpawn.forward * displace[1] * speedMultiplierx + projectileSpawn.right * displace[0] * speedMultipliery, ForceMode.Impulse);
                //r.AddForce(Input.mousePosition, ForceMode.Force)
            }
        }
        */
        if (Input.GetButton("Fire1")){
            OLD_VELOCITY.Enqueue(Input.mousePosition);
            if (OLD_VELOCITY.Count > FRAMES_AGO_THROW_VELOCITY){
                OLD_VELOCITY.Dequeue();
            } 
        }
        else{
            OLD_VELOCITY.Clear();
        }
    }

    public void Throw(GameObject alcohol)
    {
        GameObject p = Instantiate(alcohol, projectileSpawn.position, projectileSpawn.rotation);
        Rigidbody r = p.GetComponent<Rigidbody>();
        Destroy(p, 2);
        if (OLD_VELOCITY.Count > 0)
        {
            Vector3 displace = Input.mousePosition - OLD_VELOCITY.Dequeue();

            r.AddForce(
                projectileSpawn.forward * displace[1] * speedMultiplierx +
                projectileSpawn.right * displace[0] * speedMultipliery, ForceMode.Impulse);
            //r.AddForce(Input.mousePosition, ForceMode.Force)
        }
    }
    
    void FixedUpdate(){
        
    }
}
