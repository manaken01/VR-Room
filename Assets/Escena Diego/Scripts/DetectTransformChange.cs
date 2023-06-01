using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DetectTransformChange : MonoBehaviour
{
    public AudioSource source;
    public AudioClip clip;
    // Atributos encargados de la pieza A.
    public GameObject piezaA;
    public GameObject baseA;
    private Vector3 posicionObjetivoA;
    private Quaternion rotacionObjetivoA;

    // Atributos encargados de la pieza B.
    public GameObject piezaB;
    public GameObject baseB;
    private Vector3 posicionObjetivoB;
    private Quaternion rotacionObjetivoB;

    // Atributos encargados de la pieza C.
    public GameObject piezaC;
    public GameObject baseC;
    private Vector3 posicionObjetivoC;
    private Quaternion rotacionObjetivoC;

    // Atributos encargados de la pieza D.
    public GameObject piezaD;
    public GameObject baseD;
    private Vector3 posicionObjetivoD;
    private Quaternion rotacionObjetivoD;

    // Atributos encargados de la pieza E.
    public GameObject piezaE;
    public GameObject baseE;
    private Vector3 posicionObjetivoE;
    private Quaternion rotacionObjetivoE;

    // Atributos encargados de la pieza F.
    public GameObject piezaF;
    public GameObject baseF;
    private Vector3 posicionObjetivoF;
    private Quaternion rotacionObjetivoF;

    // Atributos encargados de la pieza G.
    public GameObject piezaG;
    public GameObject baseG;
    private Vector3 posicionObjetivoG;
    private Quaternion rotacionObjetivoG;

    // Atributos encargados de la pieza H.
    public GameObject piezaH;
    public GameObject baseH;
    private Vector3 posicionObjetivoH;
    private Quaternion rotacionObjetivoH;

    // Atributos encargados de la pieza I.
    public GameObject piezaI;
    public GameObject baseI;
    private Vector3 posicionObjetivoI;
    private Quaternion rotacionObjetivoI;


    // Start is called before the first frame update
    void Start()
    {
        posicionObjetivoA = baseA.transform.position;
        rotacionObjetivoA = baseA.transform.rotation;

        posicionObjetivoB = baseB.transform.position;
        rotacionObjetivoB = baseB.transform.rotation;

        posicionObjetivoC = baseC.transform.position;
        rotacionObjetivoC = baseC.transform.rotation;

        posicionObjetivoD = baseD.transform.position;
        rotacionObjetivoD = baseD.transform.rotation;

        posicionObjetivoE = baseE.transform.position;
        rotacionObjetivoE = baseE.transform.rotation;

        posicionObjetivoF = baseF.transform.position;
        rotacionObjetivoF = baseF.transform.rotation;

        posicionObjetivoG = baseG.transform.position;
        rotacionObjetivoG = baseG.transform.rotation;

        posicionObjetivoH = baseH.transform.position;
        rotacionObjetivoH = baseH.transform.rotation;

        posicionObjetivoI = baseI.transform.position;
        rotacionObjetivoI = baseI.transform.rotation;

        //Vector3 posicionP = posicionObjetivoA;
        //Debug.Log(posicionP.x.ToString("F4"));
    }

    // Update is called once per frame
    void Update()
    {
      Vector3 posicionPA = piezaA.transform.position;
      Quaternion rotacionPA = piezaA.transform.rotation;

      Vector3 posicionPB = piezaB.transform.position;
      Quaternion rotacionPB = piezaB.transform.rotation;

      Vector3 posicionPC = piezaC.transform.position;
      Quaternion rotacionPC = piezaC.transform.rotation;

      Vector3 posicionPD = piezaD.transform.position;
      Quaternion rotacionPD = piezaD.transform.rotation;

      Vector3 posicionPE = piezaE.transform.position;
      Quaternion rotacionPE = piezaE.transform.rotation;

      Vector3 posicionPF = piezaF.transform.position;
      Quaternion rotacionPF = piezaF.transform.rotation;
      
      Vector3 posicionPG = piezaG.transform.position;
      Quaternion rotacionPG = piezaG.transform.rotation;

      Vector3 posicionPH = piezaH.transform.position;
      Quaternion rotacionPH = piezaH.transform.rotation;

      Vector3 posicionPI = piezaI.transform.position;
      Quaternion rotacionPI = piezaI.transform.rotation;
        if (
          posicionPA == posicionObjetivoA && rotacionPA == rotacionObjetivoA &&
          posicionPB == posicionObjetivoB && rotacionPB == rotacionObjetivoB &&
          posicionPC == posicionObjetivoC && rotacionPC == rotacionObjetivoC &&
          posicionPD == posicionObjetivoD && rotacionPD == rotacionObjetivoD &&
          posicionPE == posicionObjetivoE && rotacionPE == rotacionObjetivoE &&
          posicionPF == posicionObjetivoF && rotacionPF == rotacionObjetivoF &&
          posicionPG == posicionObjetivoG && rotacionPG == rotacionObjetivoG &&
          posicionPH == posicionObjetivoH && rotacionPH == rotacionObjetivoH &&
          posicionPI == posicionObjetivoI && rotacionPI == rotacionObjetivoI
          )
        {
          source.PlayOneShot(clip);
          StartCoroutine(cargarScena());
          Debug.Log("Exito!");
          this.enabled = false;
        }
    }

    IEnumerator cargarScena() {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("Escena final", LoadSceneMode.Single);
    }
}
