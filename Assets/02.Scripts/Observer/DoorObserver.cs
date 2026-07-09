using DesignPatterns.Observer;
using Unity.VisualScripting;
using UnityEngine;

public class DoorObserver : MonoBehaviour
{
    [SerializeField] private ButtonSubject subjectToObserver;
    [SerializeField] private Vector3 openOffset = new Vector3(0.0f, 3.0f, 0.0f);
    [SerializeField] private float moveSpeed = 3.0f;

    private Vector3 closedPosition;
    private Vector3 openedPosition;
    private Vector3 targetPosition;

    private bool isOpen;

    private void Awake()
    {
        closedPosition = transform.position;
        openedPosition = closedPosition + openOffset;
        targetPosition = closedPosition;
        if(subjectToObserver != null)
        {
            subjectToObserver.Clicked += OnButtonClicked;
        }
    }
    private void Update()
    {
        MoveDoor();
    }
    private void OnButtonClicked()
    {
        isOpen = !isOpen;
        if(isOpen)
        {
            targetPosition = openedPosition;
        }
        else
        {
            targetPosition = closedPosition;
        }
    }
    private void MoveDoor()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
    }
    private void OnDestroy()
    {
        if (subjectToObserver != null)
        {
            subjectToObserver.Clicked -= OnButtonClicked;
        }
    }
}
