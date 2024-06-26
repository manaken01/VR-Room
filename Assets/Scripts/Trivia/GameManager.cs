using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    Question[] _questions = null;
    public Question[] Questions {get { return _questions;}}


    [SerializeField] GameEvents events = null;

    //[SerializeField]    Animator            timerAnimtor            = null;
    [SerializeField]    TextMeshProUGUI     timerText               = null;
    [SerializeField]    Color               timerHalfWayOutColor    = Color.yellow;
    [SerializeField]    Color               timerAlmostOutColor     = Color.red;
    private             Color               timerDefaultColor       = Color.white;


    private List<AnswerData> PickedAnswers = new List<AnswerData>();
    private List<int> FinishedQuestions = new List<int>();
    private int currentQuestion = 0;

    private             IEnumerator         IE_WaitTillNextRound    = null;
    private             IEnumerator         IE_StartTimer           = null;

    private             bool                IsFinished
    {
        get
        {
            return (FinishedQuestions.Count < Questions.Length) ? false : true;
        }
    }

    void OnEnable()
    {
        events.UpdateQuestionAnswer += UpdateAnswers;
    }

    void OnDisable()
    {
        events.UpdateQuestionAnswer -= UpdateAnswers;
    }
    void Awake()
    {
        events.CurrentFinalScore = 0;
    }
    void Start (){ //inicio
        LoadQuestions();

        
        var seed = UnityEngine.Random.Range(int.MinValue, int.MaxValue); 
        UnityEngine.Random.InitState(seed);

        foreach (var question in Questions){
                Debug.Log(question.Info);
        }

        Display();
    }

    public void UpdateAnswers(AnswerData newAnswer)
    {
         if (Questions[currentQuestion].GetAnswerType == Question.AnswerType.Single)
        {
            foreach (var answer in PickedAnswers)
            {
                if (answer != newAnswer)
                {
                    answer.Reset();
                }
            }
            PickedAnswers.Clear();
            PickedAnswers.Add(newAnswer);
        }
        else
        {
            bool alreadyPicked = PickedAnswers.Exists(x => x == newAnswer);
            if (alreadyPicked)
            {
                PickedAnswers.Remove(newAnswer);
            }
            else
            {
                PickedAnswers.Add(newAnswer);
            }
        }
    }

    public void EraseAnswers(){ //Borrar pregunta
        PickedAnswers = new List<AnswerData>();
    }

    void Display() //Pantalla
    {
        EraseAnswers();
        var question = GetRandomQuestion();

        if (events.UpdateQuestionUI != null)
        {
            events.UpdateQuestionUI(question);
        }else{
            Debug.LogWarning("Ups error");
        }
        if (question.UseTimer)
        {
            UpdateTimer(question.UseTimer);
        }

    }

    public void Accept(){
        UpdateTimer(false);
        bool isCorrect = CheckAnswers();
        FinishedQuestions.Add(currentQuestion);
        

        //Agregar si cuando el score es mayor a 500  cambiar de escena

        UpdateScore((isCorrect) ? Questions[currentQuestion].AddScore : -Questions[currentQuestion].AddScore);

        if (events.CurrentFinalScore >= 500)
        {
            AudioManager.Instance.StopSound("Fondo");
            SceneManager.LoadScene("Escena 2", LoadSceneMode.Single);
        }else{
            var type = (IsFinished) ? UIManager.ResolutionScreenType.Final
            : (isCorrect) ? UIManager.ResolutionScreenType.Correct 
            : UIManager.ResolutionScreenType.Incorrect;

            if (events.CurrentFinalScore < 0)
            {
                type = UIManager.ResolutionScreenType.Final;
            }
            
            if (events.DisplayScreen != null)
            {
                events.DisplayScreen(type, Questions[currentQuestion].AddScore);
            }
            AudioManager.Instance.PlaySound((isCorrect) ? "Correcto" : "Incorrecto");
            if (type != UIManager.ResolutionScreenType.Final)
            {
                if (IE_WaitTillNextRound != null)
                {
                    StopCoroutine(IE_WaitTillNextRound);
                }
                IE_WaitTillNextRound = WaitTillNextRound();
                StartCoroutine(IE_WaitTillNextRound);
        }
        }
        
        

    }
        
    void UpdateTimer(bool state)
    {
        switch (state)
        {
            case true:
                IE_StartTimer = StartTimer();
                StartCoroutine(IE_StartTimer);

                //timerAnimtor.SetInteger(timerStateParaHash, 2);
                break;
            case false:
                if (IE_StartTimer != null)
                {
                    StopCoroutine(IE_StartTimer);
                }

                //timerAnimtor.SetInteger(timerStateParaHash, 1);
                break;
        }
    }
    IEnumerator StartTimer()
    {
        var totalTime = Questions[currentQuestion].Timer;
        var timeLeft = totalTime;

        timerText.color = timerDefaultColor;
        while (timeLeft > 0)
        {
            timeLeft--;

            //AudioManager.Instance.PlaySound("CountdownSFX");

            if (timeLeft < totalTime / 2 && timeLeft > totalTime / 4)
            {
                timerText.color = timerHalfWayOutColor;
            }
            if (timeLeft < totalTime / 4)
            {
                timerText.color = timerAlmostOutColor;
            }

            timerText.text = timeLeft.ToString();
            yield return new WaitForSeconds(1.0f);
        }
        Accept();
    }

    IEnumerator WaitTillNextRound(){
        yield return new WaitForSeconds(GameUtility.ResolutionDelayTime);
        Display();
    }

    Question GetRandomQuestion (){ //Sacar pregunta Random
        var randomIndex = GetRandomQuestionIndex();
        currentQuestion = randomIndex;

        return Questions[currentQuestion];
    }

    int GetRandomQuestionIndex() { //Sacar numero Random
        var random = 0;
        if(FinishedQuestions.Count < Questions.Length){
            do{
                random = UnityEngine.Random.Range(0, Questions.Length);
            }while(FinishedQuestions.Contains(random) || random == currentQuestion);
        }
        return random;
    }

    bool CheckAnswers()
    {
        if (!CompareAnswers())
        {
            return false;
        }
        return true;
    }
    
    bool CompareAnswers()
    {
        if (PickedAnswers.Count > 0)
        {
            List<int> c = Questions[currentQuestion].GetCorrectAnswers();
            List<int> p = PickedAnswers.Select(x => x.AnswerIndex).ToList();

            var f = c.Except(p).ToList();
            var s = p.Except(c).ToList();

            return !f.Any() && !s.Any();
        }
        return false;
    }
    
    void LoadQuestions() //Cargar preguntas
    {
        Object[] objs = Resources.LoadAll("Preguntas", typeof(Question));
        _questions = new Question[objs.Length];
        for (int i = 0; i < objs.Length; i++)
        {
            _questions[i] = (Question)objs[i];
        }
    }

    private void UpdateScore (int add){
        events.CurrentFinalScore += add;
        if (events.ScoreUpdated != null){

            events.ScoreUpdated();
        }
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}