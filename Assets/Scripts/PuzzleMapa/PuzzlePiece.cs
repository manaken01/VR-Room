using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class PuzzlePiece : MonoBehaviour
{
    [SerializeField] private PuzzleController linkedPuzzleManager;
    [SerializeField] private Transform CorrectPuzzlePiece;
    private XRSocketInteractor socket;

    private void Awake()
    {
        socket = GetComponent<XRSocketInteractor>();
    }

    private void OnEnable()
    {
        socket.selectEntered.AddListener(ObjectSnapped);
        socket.selectExited.AddListener(ObjectRemoved);
    }
    private void OnDisabled()
    {
        socket.selectEntered.RemoveListener(ObjectSnapped);
        socket.selectExited.RemoveListener(ObjectRemoved);
    }
    private void ObjectSnapped(SelectEnterEventArgs arg0)
    {
        var snappedObjectName = arg0.interactableObject;
        if (snappedObjectName.transform.name == CorrectPuzzlePiece.name)
        {
            linkedPuzzleManager.completedPuzzleTask();
        }
    }
    private void ObjectRemoved(SelectExitEventArgs arg0)
    {
        var removedObjectName = arg0.interactableObject;
        if (removedObjectName.transform.name == CorrectPuzzlePiece.name)
        {
            linkedPuzzleManager.puzzlePieceRemove();
        }
    }
}
