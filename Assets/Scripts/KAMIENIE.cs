using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KAMIENIE : MonoBehaviour
{
    public Transform movePoint;
    public Transform kamor2;
    public LayerMask whatStopsMov;
    public Vector3 kamyczki;
    public int kamyczki2;


    private void Update()
    {
        if(Input.GetAxisRaw("Horizontal") == 1 || Input.GetAxisRaw("Horizontal") == -1 )
        {
            kamyczki = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0f);
        }

        if(Input.GetAxisRaw("Vertical") == 1 || Input.GetAxisRaw("Vertical") == -1)
        {
            kamyczki = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0f);
        }
        

    }



    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {


            kamor2.position += kamyczki;

           // kamor2.position += kamor2.position - other.transform.position;
                
           
            

        }
    }


}
