using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class cambiarScena : MonoBehaviour
{

    public void cambiarScenaV()
    {
        StartCoroutine(cargarScena());
    }

     IEnumerator cargarScena() {
        yield return new WaitForSeconds(4);
        SceneManager.LoadScene("Escena 1", LoadSceneMode.Single);
    }
}
