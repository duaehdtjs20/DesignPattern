using UnityEngine;

namespace DesignPatterns.Observer
{
    public class ParticleObserver : MonoBehaviour
    {
        [SerializeField] private ButtonSubject subjectToObserver;
        [SerializeField] private ParticleSystem particle;
        private void Awake()
        {
            if (particle == null)
            {
                particle = GetComponent<ParticleSystem>();
            }
            if (subjectToObserver != null)
            {
                subjectToObserver.Clicked += OnButtonClicked;
            }
        }
        private void OnDestroy()
        {
            if (subjectToObserver != null)
            {
                subjectToObserver.Clicked -= OnButtonClicked;
            }
        }
        private void OnButtonClicked()
        {
            if (particle == null) return;

            particle.Stop();
            particle.Play();
        }
    }
}
