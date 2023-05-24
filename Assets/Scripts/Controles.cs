using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Controles : MonoBehaviour  
{   
    public XRRayInteractor rayInteractor;
    // Start is called before the first frame update
    public GameObject player;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void test() {
        RaycastHit hit;
        rayInteractor.TryGetCurrent3DRaycastHit(out hit);
        Vector3 localHit = transform.InverseTransformPoint(hit.point);
        Debug.Log(localHit);
        localHit.x = localHit.x * -2;
        localHit.z = localHit.z * -2;
        localHit.y = player.transform.position.y;
        player.transform.position = localHit;
        Debug.Log(localHit);
        //TeleportPlayer(new Vector3((localHit.x * 25),localHit.y, (localHit.z * 25)));

    }
}
