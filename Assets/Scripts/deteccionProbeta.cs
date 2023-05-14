using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deteccionProbeta: MonoBehaviour
{
    public AudioSource source;
    public AudioClip clip;
    void OnTriggerEnter(Collider objeto) 
    {   
        // When target is hit
        if(objeto.gameObject.name == "probeta")
        {
            source.PlayOneShot(clip);
            Debug.Log("Target was Hit!");
            Destroy(objeto);
        }
    }
}
