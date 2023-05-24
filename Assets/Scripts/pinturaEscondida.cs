using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pinturaEscondida : MonoBehaviour
{
    public GameObject pintura;
    private Rigidbody rb;

    public void pinturaGrab() {
        rb = pintura.GetComponent<Rigidbody>();
        rb.isKinematic = false;
        rb.useGravity  = true;
        
    }

   
   
}
