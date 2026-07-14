using UnityEngine;

// Presenter
// model과 view연결함.
// model이 변경되면 View를 갱신
namespace DesignPatterns.MVP
{
    public class MonsterHealthPresenter : MonoBehaviour
    {
        [SerializeField] private MonsterHealthModel model;
        [SerializeField] private MonsterHealthView view;
        private void Awake()
        {
            if (model == null)
            {
                model = GetComponent<MonsterHealthModel>();
            }
        }
        private void Start()
        {
            model.OnHealthChanged += HealthChanged;
            view.Initialize(model.MaxHealth);
            view.UpdateHealth(model.CurrentHealth, model.MaxHealth);
        }
        private void OnDestroy()
        {
            if (model != null) model.OnHealthChanged -= HealthChanged;
        }
        public void Damage(int damage)
        {
            model.Takedamage(damage);
        }
        public void Heal(int amount)
        {
            model.Heal(amount); // 실제 체력회복은 모델에게 요청
        }
        public void ResetHealth()
        {
            model.ResetHealth();
        }
        // model의 체력이 변경되었을때 호출
        private void HealthChanged()
        {
            // 모델의 현재 데이터를 view에 반영
            view.UpdateHealth(model.CurrentHealth, model.MaxHealth);
            if (model.IsDead)
            {
                view.ShowDead(); // view에 사망상태를 표시
            }
        }
    }
}
// 디자인 패턴
// 프로그래밍을 만들때 반복해서 발생하는 문제를 해결하기 위한 설계 방법
// 완성된 코드를 그대로 쓰는게 아니라 이런 문제가 생겼을 때 이런 구조로 해결할 수 있다.

// 어떤 문제가 발생했는지, 현재 코드가 왜 불편한지, 어떤 부분이 자주 변경이 일어나는지
// 객체들간의 책임을 어덯게 나눌껀지, 이 패턴을 사용하면 무엇이 좋아지는지를 먼저 알아야된다.

// 역할을 나눌 수 있음. 변경에 유연해짐. 코드 중복을 줄일 수 있음. 객체간의 결합도 낮출 수 있음
// 테스트 하기 쉬워짐.
