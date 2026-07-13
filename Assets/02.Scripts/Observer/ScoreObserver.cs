using TMPro;
using UnityEngine;

namespace DesignPatterns.Observer
{
    public class ScoreObserver : MonoBehaviour
    {
        [SerializeField] private ButtonSubject subjectToObserver;
        [SerializeField] private TMP_Text scoreText;
        [SerializeField] private int addScore = 10;

        private int score;
        private void Awake()
        {
            score = 0;
            UpdateScoreText();

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
        private void UpdateScoreText()
        {
            if (scoreText == null) return;
            scoreText.text = "Score : " + score;
        }
        private void OnButtonClicked()
        {
            score += addScore;
            UpdateScoreText();
        }
    }
}
