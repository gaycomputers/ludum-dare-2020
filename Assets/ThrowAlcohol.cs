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
    [SerializeField] private int FRAMES_AGO_THROW_VELOCITY = 2;
    private Queue<Vector3> OLD_VELOCITY = new Queue<Vector3>();
    // Update is called once per frame
    void Update()
    {   
        if (Input.GetButtonUp("Fire1"))
        {
            GameObject p = Instantiate(projectile, projectileSpawn.position, projectileSpawn.rotation);
            Rigidbody r = p.GetComponent<Rigidbody>();
            if (OLD_VELOCITY.Count > 0){
                r.AddForce(OLD_VELOCITY.Dequeue(), ForceMode.Impulse);
                //r.AddForce(Input.mousePosition, ForceMode.Force)
            }
        }
    }
    void FixedUpdate(){
        if (Input.GetButton("Fire1")){
            OLD_VELOCITY.Enqueue((projectileSpawn.right * Input.GetAxis("Mouse X") * speedMultiplierx) + (projectileSpawn.forward * Input.GetAxis("Mouse Y") * speedMultipliery));
            if (OLD_VELOCITY.Count > FRAMES_AGO_THROW_VELOCITY){
                OLD_VELOCITY.Dequeue();
            } 
        }
        else{
            OLD_VELOCITY.Clear();
        }
    }
}
