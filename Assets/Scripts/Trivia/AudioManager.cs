using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct SoundParameters
{
    public float Volume;
    public float Pitch;
    public bool Loop;



}

public class Sound{

    [SerializeField] string name;
    public string Name {get{return name;}}

    [SerializeField] AudioClip clip;
    public AudioClip Clip {get{return clip;}}

    [SerializeField] SoundParameters parameters;
    public SoundParameters Parameters {get{return parameters;}}
    [HiddenInInspector]
    public AudioSource source;

    public void Play(){
        Source.clip = Clip;
        
    }

    public void Stop(){

    }
}

public class AudioManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
