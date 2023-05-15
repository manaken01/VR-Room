using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;

[Serializable()]
public struct UIMAnagerParameters{
    [Header("Answers options")]

    [SerializeField] float margins; //no se ocupa
    public float Margins {get{return margins;}}

    [Header("Screen Options")]
    [SerializeField] Color correctBGC;
    public Color CorrectBGC {get{return correctBGC;}}

    [SerializeField] Color incorrectBGC;
    public Color IncorrectBGC {get{return incorrectBGC;}}
}

[Serializable()]
public struct UIElements
{
    [SerializeField] RectTransform answerContentArea; 
    public RectTransform AnswerContentArea {get{return answerContentArea;}}

    [SerializeField] TextMeshProUGUI questioninfoTextObject;
    public TextMeshProUGUI QuestioninfoTextObject {get{return questioninfoTextObject;}}

    [SerializeField] TextMeshProUGUI scoreText;
    public TextMeshProUGUI ScoreText {get{return scoreText;}}

    [Space]

    [SerializeField] Animator resolutionScreenAnim;
    public Animator ResolutionScreenAnim {get{return resolutionScreenAnim;}}


    [SerializeField] Image resolutionBG;
    public Image ResolutionBG {get{return resolutionBG;}}

    [SerializeField] TextMeshProUGUI screenText; 
    public TextMeshProUGUI ScreenText {get{return screenText;}}

    [SerializeField] TextMeshProUGUI imageScoreText; 
    public TextMeshProUGUI ImageScoreText {get{return imageScoreText;}}


    [Space]

    //[SerializeField] TextMeshProUGUI highscoreText;//no se usa
    //public TextMeshProUGUI HighScoreText {get{return highscoreText;}}

    [SerializeField] CanvasGroup mainCanvasGroup;
    public CanvasGroup MainCanvasGroup {get{return mainCanvasGroup;}}

    // [SerializeField] RectTransform finishUiElements; //no se usa
    // public RectTransform FinishUiElements {get{return finishUiElements;}}

}

public class UIManager : MonoBehaviour
{
    public enum ResolutionScreenType {Correct, Incorrect} //no hay final display

    [Header("References")]
    [SerializeField] GameEvents events;

    [Header("UI Elements (Prefabs)")]
    [SerializeField] AnswerData answerPrefab;

    [SerializeField] UIElements uiElements;

    [Space]

    [SerializeField] UIMAnagerParameters parameters;

    List<AnswerData> currentAnswers = new List<AnswerData>(); 
    private int resStateParaHash = 0;


    void OnEnable (){
        events.UpdateQuestionUI += UpdateQuestionUI;
    }

    void OnDisable (){
        events.UpdateQuestionUI -= UpdateQuestionUI;
    }
    
    void Start(){
        resStateParaHash = Animator.StringToHash("ScreenState");
    }
    void UpdateQuestionUI(Question question){
        uiElements.QuestioninfoTextObject.text = question.Info;
        CreateAnswers(question);
    }

    void DisplayResolution(ResolutionScreenType type, int score){
        
    }

    void UpdateSUI(ResolutionScreenType type, int score){
        switch (type)
        {
            case ResolutionScreenType.Correct:
                uiElements.ResolutionBG.color = parameters.CorrectBGC;
                uiElements.ScreenText.text = "¡Correcto!";
                uiElements.ImageScoreText.text = "+"+ score;
                break;
            case ResolutionScreenType.Incorrect:
                uiElements.ResolutionBG.color = parameters.IncorrectBGC;
                uiElements.ScreenText.text = "¡Incorrecto!";
                uiElements.ImageScoreText.text = "-"+ score;
                break;  //26
        }
    }

    void CreateAnswers(Question question){
        EraseAnswers();

        float offset = 0 - parameters.Margins;

        for (int i = 0; i < question.Answers.Length; i++){
            AnswerData newAnswer = (AnswerData)Instantiate(answerPrefab, uiElements.AnswerContentArea); 
            newAnswer.UpdateData(question.Answers[i].Info, i);

            newAnswer.Rect.anchoredPosition = new Vector2(0, offset);

            offset -= (newAnswer.Rect.sizeDelta.y + parameters.Margins);

            uiElements.AnswerContentArea.sizeDelta = new Vector2(uiElements.AnswerContentArea.sizeDelta.x, offset * - 1);

            currentAnswers.Add(newAnswer);
        }
    }

    void EraseAnswers(){
        foreach(var answer in currentAnswers){
            Destroy(answer.gameObject);
        }
        currentAnswers.Clear();
    }
    
}
