using UnityEngine;

namespace DesignPatterns.Decorator
{
    public class WeaponVisualView : MonoBehaviour
    {
        [SerializeField] private GameObject fireEffect;
        [SerializeField] private GameObject poisonEffect;
        [SerializeField] private GameObject criticalEffect;

        public void SetFire(bool value)
        {
            if (fireEffect != null)
            {
                fireEffect.SetActive(value);
            }
        }
        public void SetPoison(bool value)
        {
            if (poisonEffect != null)
            {
                poisonEffect.SetActive(value);
            }
        }
        public void SetCritical(bool value)
        {
            if (criticalEffect != null)
            {
                criticalEffect.SetActive(value);
            }
        }
        public void ResetEffects()
        {
            SetFire(false);
            SetPoison(false);
            SetCritical(false);
        }
    }
}
