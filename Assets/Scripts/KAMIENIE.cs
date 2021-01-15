using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KAMIENIE : MonoBehaviour
{
    public Transform movePoint;
    public Transform kamor2;
    public LayerMask whatStopsMov;
    public float kamyczki;
    public float kamyczki2;

    private void FixedUpdate()
    {
        if (Input.GetAxisRaw("Horizontal") == 1 || Input.GetAxisRaw("Horizontal") == -1)
        { 
        kamyczki = Input.GetAxisRaw("Horizontal");
        }
        if (Input.GetAxisRaw("Vertical") == 1 || Input.GetAxisRaw("Vertical") == -1)
        {
        kamyczki2 = Input.GetAxisRaw("Vertical");
        }

    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {



            kamor2.position += new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f);

            kamor2.position += new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f);

           // kamor2.position += kamor2.position - other.transform.position;
                
           
            

        }
    }


}
