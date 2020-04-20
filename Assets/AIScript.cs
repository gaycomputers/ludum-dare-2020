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
    public GameObject exitSpot;
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
    private float timeout = 30.0f;
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
            waiting = 0;
            currentState = state.Wander;
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
                    waiting += Time.deltaTime;
                    if (waiting > timeout){
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
                }
                else{
                    //go to destination
                    goto2();
                }
            }
            else{
                destination = wanderList[random.Next(danceList.Count)];
                destinationSelected = true;
            }
        }
        else if (currentState == state.Exit){
            if (destinationSelected){
                if(destination.transform.position == GetComponent<Transform>().position){
                    //dissapear
                }
                else{
                    //go to destination
                    goto2();
                }
            }
            else{
                destination = exitSpot;
                destinationSelected = true;
            }
        }
    }
}
