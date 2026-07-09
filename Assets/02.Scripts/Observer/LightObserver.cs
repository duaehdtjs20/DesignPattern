using DesignPatterns.Observer;
using UnityEngine;

public class LightObserver : MonoBehaviour
{
    [SerializeField] private ButtonSubject subjectToObserver;
    [SerializeField] private Light targetLight;

    private bool isLightOn;

    private void Awake()
    {
        if(targetLight == null)
        {
            targetLight = GetComponent<Light>();
        }
        if(targetLight != null)
        {
            isLightOn = targetLight.enabled;
        }
        if(subjectToObserver != null)
        {
            subjectToObserver.Clicked += OnButtonClicked;
        }
    }
    private void OnDestroy()
    {
        if(subjectToObserver != null)
        {
            subjectToObserver.Clicked -= OnButtonClicked;
        }
    }
    private void OnButtonClicked()
    {
        if (targetLight == null) return;
        isLightOn = !isLightOn;
        targetLight.enabled = isLightOn;

    }
}
