using DesignPatterns.Observer;
using System.Collections;
using UnityEngine;

public class AudioObserver : MonoBehaviour
{
    [SerializeField] private ButtonSubject subjectToObserver;
    [SerializeField] private float delay = 0.0f;
    private AudioSource audioSource;
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();

        if(subjectToObserver != null)
        {
            subjectToObserver.Clicked += OnButtonClicked;
        }
    }

    private void OnButtonClicked()
    {
        StartCoroutine(PlayWithDelay());
    }
    private IEnumerator PlayWithDelay()
    {
        yield return new WaitForSeconds(delay);
        audioSource.Stop();
        audioSource.Play();
    }
    private void OnDestroy()
    {
        if(subjectToObserver != null)
        {
            subjectToObserver.Clicked -= OnButtonClicked;
        }
    }
}
