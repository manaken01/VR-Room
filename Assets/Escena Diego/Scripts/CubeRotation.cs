using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeRotation : MonoBehaviour
{
    public float RoatitionSpeed = 100f;

    private static int SnapRot;

    private static Vector3 NearestWorldAxis(Vector3 v)
    {
        if (Mathf.Abs(v.x) < Mathf.Abs(v.y))
        {
            v.x = 0;
            if (Mathf.Abs(v.y) < Mathf.Abs(v.z))
                v.y = 0;
            else
                v.z = 0;
        }
        else
        {
            v.y = 0;
            if (Mathf.Abs(v.x) < Mathf.Abs(v.z))
                v.x = 0;
            else
                v.z = 0;
        }
        return v;
    }

    private void Update()
    {
        // thunbstick rotation....
        if (Input.GetKey(KeyCode.X))
        {
            transform.Rotate(Vector3.up * -RoatitionSpeed * Time.deltaTime, Space.World);
        }

        if (Input.GetKey(KeyCode.Y))
        {
            transform.Rotate(Vector3.right * RoatitionSpeed * Time.deltaTime, Space.World);
        }
        
        if (Input.GetKey(KeyCode.Z))
        {
            transform.Rotate(Vector3.forward * -RoatitionSpeed * Time.deltaTime, Space.World);
        }

        
    }

    public void res()
    {
        gameObject.transform.rotation = Quaternion.identity;
    }
}
