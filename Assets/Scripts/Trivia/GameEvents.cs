using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameEvents", menuName = "Quiz/new GameEvents")]

public class GameEvents : ScriptableObject
{
    public delegate void UpdateQuestionUICallback(Question question);
    public UpdateQuestionUICallback UpdateQuestionUI;

    public delegate void UpdateQuestionAnswerCallback(AnswerData pickedAnswer); //Creop que no se ocupa porque no se actualiza la respueta
    public UpdateQuestionAnswerCallback UpdateQuestionAnswer;

    public delegate void DisplayScreenCallback(UIManager.ResolutionScreenType type, int score); 
    public DisplayScreenCallback DisplayScreen;

    public delegate void ScoreUpdatedCallBack();
    public ScoreUpdatedCallBack ScoreUpdated;

    [HideInInspector]
    public int CurrentFinalScore;

    // [HideInInspector]
    // public int StartupHighscore = 0;
}
