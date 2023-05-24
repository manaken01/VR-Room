using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PuzzleController : MonoBehaviour
{
    [SerializeField] private int numberOfTasksToComplete;
    private int currentlyCompletedTasks = 0;

    [Header("Completition events")]
    public UnityEvent onPuzzleCompletition;

    public void completedPuzzleTask()
    {
        currentlyCompletedTasks++;
        checkForPuzzleCompletition();
    }

    private void checkForPuzzleCompletition()
    {
        if (currentlyCompletedTasks >= numberOfTasksToComplete)
        {
            onPuzzleCompletition.Invoke();
        }
    }

    public void puzzlePieceRemove()
    {
        currentlyCompletedTasks--;
    }
}
