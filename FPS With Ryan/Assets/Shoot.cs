using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public GameObject bullet;
    public GameObject gun;
    public GameObject player;


    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Click");
            GameObject faker;
            faker = Instantiate(bullet, gun.transform.position + player.transform.forward, player.transform.rotation) as GameObject;
            faker.AddComponent<SphereCollider>();
            Rigidbody Rb = faker.AddComponent<Rigidbody>();
            Rb.AddForce(faker.transform.forward * 5000);
        }
    }
}
