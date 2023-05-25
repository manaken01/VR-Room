using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deteccionLibro: MonoBehaviour
{
    public AudioSource source;
    public AudioClip clip;
    public AudioClip clip2;
    public detectarBueno lib;
    void OnTriggerEnter(Collider objeto) 
    {   
        Vector3 localPos;
        // When target is hit
        if(objeto.gameObject.name == "libro")
        {
            source.PlayOneShot(clip);
            Debug.Log("Target was Hit!");
            Destroy(objeto);
            lib.obj3 = true;
        }
        else if(objeto.gameObject.name == "atomo" || objeto.gameObject.name == "probeta")
        {
            source.PlayOneShot(clip2);
            Debug.Log("Mal");
            localPos.x = 0.561f;
            localPos.y = 1.143f;
            localPos.z = -0.578f;
            Debug.Log(localPos);
            objeto.transform.position = localPos;
        }
        else {
            source.PlayOneShot(clip2);
            Debug.Log("Mu mal");
            Destroy(objeto);
        }
    }
}