using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCastController : MonoBehaviour
{
  public GameObject currentHitObject;
    

    // Update is called once per frame
    void FixedUpdate()
    {
        float _rotatespeed = 100f;
        RaycastHit hit;
        var leftHandDevices = new List<UnityEngine.XR.InputDevice>();
        UnityEngine.XR.InputDevice device = leftHandDevices[0];

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity))
        {
          var selectedObject = hit.transform;
          if (selectedObject != null)
          {
            bool triggerValue;
            if (device.TryGetFeatureValue(UnityEngine.XR.CommonUsages.primaryButton, out triggerValue) && triggerValue)
            {
              gameObject.transform.Rotate(new Vector3(0f, 0f, _rotatespeed) * Time.deltaTime, Space.World);
            }
          }
        }
    }
}
