using UnityEngine;

namespace DesignPatterns.Command
{
    public class EnemyUnit : MonoBehaviour
    {
        [SerializeField] private int maxHp = 50;
        [SerializeField] private int currentHp = 50;

        public int CurrentHp => currentHp;
        public void TakeDamage(int damage)
        {
            currentHp -= damage;

            currentHp = Mathf.Clamp(currentHp, 0, maxHp);

            Debug.Log("EnemyHp : " + currentHp);

            if (currentHp <= 0)
            {
                Debug.Log("Enemy Die");
            }
        }
        public void RestoreHp(int amount)
        {
            currentHp += amount;
            currentHp = Mathf.Clamp(currentHp, 0, maxHp);
            Debug.Log("EnemyHp : " + currentHp);
        }
    }
}
