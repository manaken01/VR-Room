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
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("Escena Diego", LoadSceneMode.Single);
    }
}
