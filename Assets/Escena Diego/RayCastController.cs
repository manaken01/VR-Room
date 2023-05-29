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

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity))
        {
          var selectedObject = hit.transform;
          if (selectedObject != null)
          {
            if (Input.GetKey(KeyCode.X))
            {
              gameObject.transform.Rotate(new Vector3(0f, 0f, _rotatespeed) * Time.deltaTime, Space.World);
            }
            if (Input.GetKey(KeyCode.Y))
            {
              gameObject.transform.Rotate(new Vector3(0f, _rotatespeed, 0f) * Time.deltaTime, Space.World);
            }
            if (Input.GetKey(KeyCode.Z))
            {
              gameObject.transform.Rotate(new Vector3(_rotatespeed, 0f, 0f) * Time.deltaTime, Space.World);
            }
          }
        }
    }
}
