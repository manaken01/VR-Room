using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class AnswerData : MonoBehaviour //Claserespuesta que solo contiene el index
{
    [Header("UI Elements")]
    [SerializeField] TextMeshProUGUI infoTextObject;

    private int _answerIndex = -1;
    public int AnswerIndex{get { return _answerIndex;}}
     //no existen los toggles es con bnutton click
}
