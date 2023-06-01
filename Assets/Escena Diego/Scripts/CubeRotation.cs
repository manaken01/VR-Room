using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeRotation : MonoBehaviour
{
    public float RoatitionSpeed = 20f;

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
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(Vector3.up * -RoatitionSpeed * Time.deltaTime, Space.World);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(Vector3.up * RoatitionSpeed * Time.deltaTime, Space.World);
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Rotate(Vector3.right * RoatitionSpeed * Time.deltaTime, Space.World);
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Rotate(Vector3.right * -RoatitionSpeed * Time.deltaTime, Space.World);
        }

        // snap rotation
        SnapRot = 1; // Cambia esto según tus necesidades o elimínalo si no lo necesitas

        if (SnapRot == 1)
        {
            Vector3 alignedForward = NearestWorldAxis(transform.forward);
            Vector3 alignedUp = NearestWorldAxis(transform.up);
            transform.rotation = Quaternion.LookRotation(alignedForward, alignedUp);
        }
    }

    public void res()
    {
        gameObject.transform.rotation = Quaternion.identity;
    }
}