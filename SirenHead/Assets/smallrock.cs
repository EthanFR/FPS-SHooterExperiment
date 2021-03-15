using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Timers;

public class smallrock : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public Camera pre;
    public GameObject self;
    public GameObject player;
    public Rigidbody selfr;
    public float distance = 0;
    public bool touching = false;
    public bool carrying = false;

    // Update is called once per frame
    void Update()
    {
        Debug.Log("start" + carrying);
        RaycastHit hit;
       

        Ray ray = pre.ScreenPointToRay(Input.mousePosition);
        int layerMask = 8;
        float height;
        layerMask = ~layerMask;
        if (carrying == true)
        {
            this.transform.position = ray.GetPoint(distance);
            if (Input.GetMouseButtonDown(1))
            {  
                selfr.velocity = new Vector3(0,0,0);
                carrying = false;
                
            }

            if (Input.GetMouseButtonDown(0))
            {
                selfr.velocity = new Vector3(0, 0, 0);
                carrying = false;
                
                //transform.parent = player.transform;
                self.transform.rotation = player.transform.rotation;
                selfr.AddForce(transform.forward * 1000);
                //transform.parent = this.transform;


            }

        }
        Debug.Log("middle" + carrying);
        if (Physics.Raycast(ray, out hit, 4, layerMask) && Input.GetKeyDown("r")&&!carrying && hit.collider.tag == "ground")
        {
            height = self.transform.position.z + 10;
            //float timer = 2000;
            self.transform.position = hit.point;
            distance = hit.distance;
            carrying = true;
           










        }

        Debug.Log("end" + carrying);

        // This would cast rays only against colliders in layer 8.
        // But instead we want to collide against everything except layer 8. The ~ operator does this, it inverts a bitmask.

    }
    


}
