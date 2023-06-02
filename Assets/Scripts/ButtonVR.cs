using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class ButtonVR : MonoBehaviour
{
    public GameObject button;
    public UnityEvent onClick;
    GameObject presser;
    bool isPressed;
    
    public void TaskOnClick(){
		action();
	}


    public void action()
    {
        StartCoroutine(cargarScena());
    }
    IEnumerator cargarScena() {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("Escena 1", LoadSceneMode.Single);
    }
}
