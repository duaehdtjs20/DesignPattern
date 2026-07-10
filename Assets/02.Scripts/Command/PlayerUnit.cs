using UnityEngine;

namespace DesignPatterns.Command
{
    public class PlayerUnit : MonoBehaviour
    {
        [SerializeField] private float moveDistance = 1.0f; // 한변 입력할때 이동할거리

        [SerializeField] private LayerMask obstacleLayer;

        [SerializeField] private int attackDamage = 10;
        [Header("체력 설정")]
        [SerializeField] private int maxHp = 100;
        [SerializeField] private int currentHp = 50;

        [Header("포션 설정")]
        [SerializeField] private int potionHealAmount = 20;
        [SerializeField] private int potionCount = 3;

        public float MoveDistance => moveDistance;
        public int AttackDamage => attackDamage;
        public int CurrentHp => currentHp;
        public int PotionCount => potionCount;
        void Start()
        {

        }

        void Update()
        {

        }
        public void Move(Vector3 direction)
        {
            if (!IsValidMove(direction)) return;
            transform.position += direction * moveDistance;
        }
        public bool IsValidMove(Vector3 direction)
        {
            Vector3 startPosition = transform.position;
            bool isBlocked = Physics.Raycast(startPosition, direction, MoveDistance, obstacleLayer);

            return !isBlocked;
        }
        public void UsePotion()
        {
            if (!CanUsePotion()) return;

            potionCount--;
            AddHp(potionHealAmount);

            Debug.Log("포션 사용 / 남은 포션 : " + potionCount);
        }
        public bool CanUsePotion()
        {
            return potionCount > 0 && currentHp < maxHp;
        }
        public void RestorePotion()
        {
            potionCount--;
            RemoveHp(potionHealAmount);
            Debug.Log("Potion Undo / 남은 포션 : " + potionCount);
        }
        public void AddHp(int amount)
        {
            currentHp += amount;
            currentHp = Mathf.Clamp(currentHp, 0, maxHp);
            Debug.Log("PlayerHp : " + currentHp);
        }
        public void RemoveHp(int amount)
        {
            currentHp -= amount;
            currentHp = Mathf.Clamp(currentHp, 0, maxHp);
            Debug.Log("PlayerHp : " + currentHp);
        }
    }
}
