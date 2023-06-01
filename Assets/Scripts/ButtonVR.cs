using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class ButtonVR : MonoBehaviour
{
    public GameObject button;
    public UnityEvent onPress;
    public UnityEvent onReleased;
    GameObject presser;
    bool isPressed;
    
    void Start()
    {
        isPressed = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(!isPressed)
        {
            button.transform.localPosition = new Vector3(0, 0.003f,0);
            presser = other.gameObject;
            onPress.Invoke();
            isPressed = true;

        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other == presser)
        {
            button.transform.localPosition = new Vector3(0, 0.015f,0);
            onReleased.Invoke();
            isPressed = false;
        }
        
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
