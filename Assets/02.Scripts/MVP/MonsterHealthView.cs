using TMPro;
using UnityEngine;
using UnityEngine.UI;

// View
// 화면에 보여주는 역할만함.
// Slider, Text, Image 같은 UI를 갱신
// 실제 체력 계산은 하지 않는다.
public class MonsterHealthView : MonoBehaviour
{
    [SerializeField] private Slider healthSlider;
    [SerializeField] private TMP_Text healthText;
    [SerializeField] private TMP_Text deadText;

    public void Initialize(int maxHealth)
    {
        healthSlider.maxValue = maxHealth;
        healthSlider.value = maxHealth;
        if(deadText != null)
        {
            deadText.gameObject.SetActive(false);
        }
    }
    public void UpdateHealth(int currentHealth, int maxHealth)
    {
        healthSlider.value = currentHealth;
        if(healthText != null)
        {
            healthText.text = currentHealth + " / " + maxHealth;
        }
    }
    public void ShowDead()
    {
        deadText.gameObject.SetActive(true);
    }
}
