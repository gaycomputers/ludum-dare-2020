using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class AIScript : MonoBehaviour
{
    public GameObject reach; //circle
    public List<GameObject> wanderList;
    public List<GameObject> drinkList;
    public List<GameObject> danceList;
    public GameObject ExitSpot;
    enum state {
        Wander,
        Drink,
        Dance,
        Exit
        
    }
    System.Random random = new System.Random();
    [SerializeField] private float movementSpeed = 0.05f;
    private state currentState = state.Drink;
    private bool destinationSelected = false;
    private GameObject destination;
    private float waiting = 0.0f;
    private float timeout = 10.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void goto2()
    {
        // Moves towards destination
        Vector3 movement = movementSpeed * Vector3.Normalize(destination.transform.position - GetComponent<Transform>().position);
        
        // GetComponent<RigidBody>().AddForce(movement);
        transform.position = transform.position + movement;

        if ((destination.transform.position - GetComponent<Transform>().position).magnitude < movementSpeed)
        {
            transform.position = destination.transform.position;
        }
    }

    void OnCollisionEnter(Collision other)
    {
        
        if (other.gameObject.CompareTag("Drink")){
            destinationSelected = false;
            Destroy(other.gameObject);
            waiting = Time.time;
            currentState = state.Dance;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(currentState == state.Wander){
            if (destinationSelected){
                if(destination.transform.position == GetComponent<Transform>().position){
                    //idle
                }
                else{
                    //go to destination
                    goto2();
                }
            }
            else{
                destination = wanderList[random.Next(wanderList.Count)];
                destinationSelected = true;
            }
        }
        else if (currentState == state.Drink){
            if (destinationSelected){
                if(destination.transform.position == GetComponent<Transform>().position){
                    //await beer
                    
                    //Debug.Log(Time.time - waiting);
                    if (Time.time - waiting > timeout){
                        destinationSelected = false;
                        currentState = state.Exit;
                    }
                }
                else{
                    //go to destination
                    goto2();
                    
                }
            }
            else{
                destination = drinkList[random.Next(drinkList.Count)];
                destinationSelected = true;
            }
        }
        else if (currentState == state.Dance){
            if (destinationSelected){
                if(destination.transform.position == GetComponent<Transform>().position){
                    //dance
                    destinationSelected = false;
                    //Debug.Log(waiting);
                    
                    if (Time.time - waiting > timeout){
                        currentState = state.Drink;
                        waiting = Time.time;
                    }
                }
                else{
                    //go to destination
                    goto2();
                    
                }
            }
            else{
                destination = wanderList[random.Next(wanderList.Count)];
                destinationSelected = true;
            }
        }
        else if (currentState == state.Exit){
            if (destinationSelected){
                if(destination.transform.position == GetComponent<Transform>().position){
                    //dissapear
                    currentState = state.Dance;
                    waiting = Time.time;
                }
                else{
                    //go to destination
                    goto2();
                }
            }
            else{
                destination = ExitSpot;
                destinationSelected = true;
            }
        }
    }
}
