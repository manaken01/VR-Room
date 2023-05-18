using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class AnswerData : MonoBehaviour //Claserespuesta que solo contiene el index
{
    //public GameObject Manager;
    [Header("UI Elements")]
    [SerializeField] TextMeshProUGUI infoTextObject;
    //[SerializeField] Button ButtonAnswer;
    [SerializeField] Image toggle;

    [Header("Textures")]
    [SerializeField] Sprite uncheckedToggle;
    [SerializeField] Sprite checkedToggle;

    [Header("References")]
    [SerializeField] GameEvents events;
    
    private RectTransform _rect;
    public RectTransform Rect{
        get{
            if (_rect == null){
                _rect = GetComponent<RectTransform>() ?? gameObject.AddComponent<RectTransform>();
            }            return _rect;
        }
    }

    private int _answerIndex = -1;
    public int AnswerIndex{get { return _answerIndex;}}
    private bool Checked = false;


    public void UpdateData(string info, int index){
        infoTextObject.text = info;
        _answerIndex = index;

    }

    public void Reset ()
    {
        Checked = false;
        UpdateUI();
    }
    public void SwitchState ()
    {
        Checked = !Checked;
        UpdateUI();

        if (events.UpdateQuestionAnswer != null)
        {
            events.UpdateQuestionAnswer(this);
        }
    }
    void UpdateUI ()
    {
        if (toggle == null) return;

        toggle.sprite = (Checked) ? checkedToggle : uncheckedToggle;
    }
}
