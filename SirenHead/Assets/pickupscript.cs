using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickupscript : MonoBehaviour
{
    public Transform tempTrans;
    public Transform player;
    public Transform Object;
    public Rigidbody self;
    public bool beingCarried;
    public bool hasPlayer;
    public bool touched;
    public bool onoroff = false;
    public float throwForce = 3f;
    public float wheel;
    public bool mouseon;
    public Camera pre;
    public bool falling;
    public bool inob;
    // Update is called once per frame
    void FixedUpdate()
    {
        // Bit shift the index of the layer (8) to get a bit mask
        RaycastHit hit;
        Ray ray = pre.ScreenPointToRay(Input.mousePosition);


        int layerMask = 0 << 9;

        // This would cast rays only against colliders in layer 8.
        // But instead we want to collide against everything except layer 8. The ~ operator does this, it inverts a bitmask.
        layerMask = ~layerMask;


        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask))
        {
            if (hit.collider.gameObject.tag == "object")
            {
                mouseon = true;
            }
            else
            {

                mouseon = false;
            }
        }
        else
        {

            mouseon = false;
        }
    }
    void Update()
    {
        //check distance of gameObject and player

        



        float dist = Vector3.Distance(gameObject.transform.position, player.position);
        if (dist <= 4.5f)
        {
            //can be picked up
            hasPlayer = true;
        }
        else
        {
            hasPlayer = false;
        }



        if (hasPlayer && Input.GetKeyDown("e") && mouseon)
        {
            GetComponent<Rigidbody>().isKinematic = true;
            Vector3 Breh = new Vector3(Object.position.x, Object.position.y + Input.GetAxis("Mouse ScrollWheel"), Object.position.z);
            transform.parent = player.transform;

            beingCarried = true;
        }
        if (beingCarried)


        {

            GetComponent<Rigidbody>().useGravity = true;
            Object.transform.position = new Vector3(Object.position.x, Object.position.y + Input.GetAxis("Mouse ScrollWheel") * 1f, Object.position.z);
            Object.transform.eulerAngles = new Vector3(0, 0, 0);
            GetComponent<Rigidbody>().useGravity = false;
            
            
            if (touched)
            {
                GetComponent<Rigidbody>().isKinematic = false;
                GetComponent<Rigidbody>().useGravity = true;

                transform.parent = null;
                beingCarried = false;
                touched = false;
            }

            else if (Input.GetMouseButtonDown(0) && mouseon)
            {
                GetComponent<Rigidbody>().isKinematic = false;
                GetComponent<Rigidbody>().useGravity = true;

                transform.parent = null;
                beingCarried = false;
                self.AddForce(transform.forward *10);
            }
        }
   
    }


    void OnTriggerEnter()
    {
        if (beingCarried)
        {
            touched = true;

        }
    }

  

    
    
   



}
