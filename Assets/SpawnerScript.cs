using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour
{
    public GameObject objeto;

    public void InstantiateNewObject() {
        //GameObject taza = new GameObject("taza");
        Instantiate(objeto, new Vector3(0.746f, 0.883f, 1.222f), Quaternion.identity);

    }


}
