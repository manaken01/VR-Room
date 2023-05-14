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

    private List<AnswerData> PickedAnswers = new List<AnswerData>();
    private List<int> FinishedQuestions = new List<int>();
    private int currentQuestion = 0;
    
    void Start (){ //inicio
        LoadQuestions();

        foreach (var question in Questions){
                Debug.Log(question.Info);
        }

        //Display();
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

    void LoadQuestions() //Cargar preguntas
    {
        Object[] objs = Resources.LoadAll("Preguntas", typeof(Question));
        _questions = new Question[objs.Length];
        for (int i = 0; i < objs.Length; i++)
        {
            _questions[i] = (Question)objs[i];
        }
    }
}