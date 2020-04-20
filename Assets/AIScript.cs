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
    [SerializeField] private int movementSpeed = 5;
    private state currentState = state.Wander;
    private bool destinationSelected = false;
    private GameObject destination;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(currentState == state.Wander){
            if (destinationSelected){
                if(destination.transform == GetComponent<Transform>()){
                    //idle
                }
                else{
                    //go to destination
                }
            }
            else{
                destination = wanderList[random.Next(wanderList.Count)];
                destinationSelected = true;
            }
        }
        else if (currentState == state.Drink){
            if (destinationSelected){
                if(destination.transform == GetComponent<Transform>()){
                    //await beer
                }
                else{
                    //go to destination
                }
            }
            else{
                destination = wanderList[random.Next(drinkList.Count)];
                destinationSelected = true;
            }
        }
        else if (currentState == state.Dance){
            if (destinationSelected){
                if(destination.transform == GetComponent<Transform>()){
                    //dance
                }
                else{
                    //go to destination
                }
            }
            else{
                destination = wanderList[random.Next(danceList.Count)];
                destinationSelected = true;
            }
        }
        else if (currentState == state.Exit){
            if (destinationSelected){
                if(destination.transform == GetComponent<Transform>()){
                    //dissapear
                }
                else{
                    //go to destination
                }
            }
            else{
                destination = exitSpot;
                destinationSelected = true;
            }
        }
    }
}
