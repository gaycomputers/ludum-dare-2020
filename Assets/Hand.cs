﻿using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class Hand : MonoBehaviour
{
    private Canvas _canvas;
    private GraphicRaycaster _graphicRaycaster;
    private Transform _heldObject;
    private ThrowAlcohol _throwAlcohol;
    
    
    // Start is called before the first frame update
    void Start()
    {
        _throwAlcohol = FindObjectOfType<ThrowAlcohol>();
        _canvas = GetComponentInParent<Canvas>();
        _graphicRaycaster = GetComponentInParent<GraphicRaycaster>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Input.mousePosition;

        if (Input.GetButtonDown("Fire1"))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.CompareTag("AlcoholSource"))
                {
                    _heldObject = Instantiate(hit.transform.GetComponent<AlcoholSource>().alcoholPrefab, transform.parent).transform;
                }
                if (hit.transform.CompareTag("Gun")) 
                {
                    _heldObject = Instantiate(hit.transform.GetComponent<GunSource>().gunPrefab, transform.parent).transform;
                }
                if (hit.transform.CompareTag("JukeboxRemote")) 
                {
                    hit.transform.GetComponent<Radio>().NextSong();
                }
            }
        }
        
        if (_heldObject != null)
        {
            _heldObject.position = transform.position;
            
            if (Input.GetButtonUp("Fire1"))
            {
                if (_heldObject.CompareTag("Alcohol"))
                {   
                    _throwAlcohol.Throw(_heldObject.GetComponent<Alcohol>().Throwable);
                    Destroy(_heldObject.gameObject);
                    _heldObject = null;
                }
                else if (_heldObject.CompareTag("Gun"))
                {
                    //shoot gun
                    Destroy(_heldObject.gameObject);
                    _heldObject = null;
                }
            }
        }
    }
}
