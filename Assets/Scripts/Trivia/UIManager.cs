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

    [SerializeField] Color finalBGColor;
    public Color FinalBGColor { get { return finalBGColor; } }
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

    [SerializeField] TextMeshProUGUI resolutionStateInfoText;
    public TextMeshProUGUI ResolutionStateInfoText { get { return resolutionStateInfoText; } }

    [SerializeField] TextMeshProUGUI imageScoreText; 
    public TextMeshProUGUI ImageScoreText {get{return imageScoreText;}}


    [Space]

    //[SerializeField] TextMeshProUGUI highscoreText;//no se usa
    //public TextMeshProUGUI HighScoreText {get{return highscoreText;}}

    [SerializeField] CanvasGroup mainCanvasGroup;
    public CanvasGroup MainCanvasGroup {get{return mainCanvasGroup;}}

    [SerializeField] RectTransform finishUiElements; //no se usa
    public RectTransform FinishUIElements {get{return finishUiElements;}}

}

public class UIManager : MonoBehaviour
{
    //public GameManager Manager;

    public enum ResolutionScreenType {Correct, Incorrect, Final} //no hay final display

    [Header("References")]
    [SerializeField] GameEvents events;

    [Header("UI Elements (Prefabs)")]
    [SerializeField] AnswerData answerPrefab;

    [SerializeField] UIElements uIElements;

    [Space]

    [SerializeField] UIMAnagerParameters parameters;

    List<AnswerData> currentAnswers = new List<AnswerData>(); 
    private int resStateParaHash = 0;

    private IEnumerator  IE_DisplayTimedResolution    = null;


    void OnEnable (){
        events.UpdateQuestionUI         += UpdateQuestionUI;
        events.DisplayScreen            += DisplayResolution;
        events.ScoreUpdated             += UpdateScoreUI;
    }

    void OnDisable (){
        events.UpdateQuestionUI         -= UpdateQuestionUI;
        events.DisplayScreen            -= DisplayResolution;
        events.ScoreUpdated             -= UpdateScoreUI;
    }
    
    void Start(){
        UpdateScoreUI();
        resStateParaHash = Animator.StringToHash("ScreenState");
    }
    void UpdateQuestionUI(Question question){
        uIElements.QuestioninfoTextObject.text = question.Info;
        CreateAnswers(question);
    }

    void DisplayResolution(ResolutionScreenType type, int score){
        UpdateSUI(type, score);
        uIElements.ResolutionScreenAnim.SetInteger(resStateParaHash, 2);
        uIElements.MainCanvasGroup.blocksRaycasts = false;

        if (type != ResolutionScreenType.Final)
        {
            if (IE_DisplayTimedResolution != null)
            {
                StopCoroutine(IE_DisplayTimedResolution);
            }
            IE_DisplayTimedResolution = DisplayTimedResolution();
            StartCoroutine(IE_DisplayTimedResolution);
        }
    }

    IEnumerator DisplayTimedResolution()
    {
        yield return new WaitForSeconds(GameUtility.ResolutionDelayTime);
        uIElements.ResolutionScreenAnim.SetInteger(resStateParaHash, 1);
        uIElements.MainCanvasGroup.blocksRaycasts = true;
    }

    void UpdateSUI(ResolutionScreenType type, int score){
        switch (type)
        {
            case ResolutionScreenType.Correct:
                
                uIElements.ResolutionBG.color = parameters.CorrectBGC;
                uIElements.ResolutionStateInfoText.text = "¡Correcto!";
                uIElements.ImageScoreText.text = "+"+ score;
                break;
            case ResolutionScreenType.Incorrect:
                uIElements.ResolutionBG.color = parameters.IncorrectBGC;
                uIElements.ResolutionStateInfoText.text = "¡Incorrecto!";
                uIElements.ImageScoreText.text = "-"+ score;
                break;  //26
            case ResolutionScreenType.Final:
                uIElements.ResolutionBG.color = parameters.FinalBGColor;
                uIElements.ResolutionStateInfoText.text = "Perdiste";
                uIElements.ImageScoreText.text = "";
                uIElements.FinishUIElements.gameObject.SetActive(true);
                break;
        }   
    }
  
    void CreateAnswers(Question question){
        EraseAnswers();

        float offset = 0 - parameters.Margins;

        
        
        
        
        for (int i = 0; i < question.Answers.Length; i++){
            
            AnswerData newAnswer = (AnswerData)Instantiate(answerPrefab, uIElements.AnswerContentArea); 

            
            

            newAnswer.UpdateData(question.Answers[i].Info, i);

            newAnswer.Rect.anchoredPosition = new Vector2(0, offset);

            offset -= (newAnswer.Rect.sizeDelta.y + parameters.Margins);

           
            
            uIElements.AnswerContentArea.sizeDelta = new Vector2(uIElements.AnswerContentArea.sizeDelta.x, offset * - 1);

            currentAnswers.Add(newAnswer);

            
            
            //newAnswer.ButtonAnswer.onClick.AddListener(() => Manager.Accept());

        }

    }   


    void EraseAnswers(){
        foreach(var answer in currentAnswers){
            Destroy(answer.gameObject);
        }
        currentAnswers.Clear();
    }
    
    
    void UpdateScoreUI()
    {
        uIElements.ScoreText.text = "Puntos: " + events.CurrentFinalScore;
    }
}
