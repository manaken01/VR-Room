using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class detectarBueno : MonoBehaviour
{
    public bool obj1;
    public bool obj2;
    public bool obj3;
    public AudioSource audioSource;

    // Update is called once per frame
    void Update()
    {
        if (obj1 && obj2 && obj3) {
            Debug.Log("Nivel pasado");
            StartCoroutine(cargarScena());
        }
    }

    IEnumerator cargarScena() {
        yield return new WaitForSeconds(4);
        audioSource.mute = true;
        SceneManager.LoadScene("Escena 3", LoadSceneMode.Single);
    }
}
