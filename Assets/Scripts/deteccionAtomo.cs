using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deteccionAtomo : MonoBehaviour
{
    public AudioSource source;
    public AudioClip clip;
    void OnTriggerEnter(Collider objeto) 
    {   
        // When target is hit
        if(objeto.gameObject.name == "atomo")
        {
            source.PlayOneShot(clip);
            Debug.Log("Target was Hit!");
            Destroy(objeto);
        }
    }
}
