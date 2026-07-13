using System.Collections;
using UnityEngine;

namespace DesignPatterns.TemplateMethod
{
    public abstract class MonsterBase : MonoBehaviour
    {
        [SerializeField] protected Transform target;
        [SerializeField] protected ParticleSystem attackEffect;
        [SerializeField] protected float moveSpeed = 3.0f;
        [SerializeField] protected float attackDistance = 1.5f;

        protected Vector3 startPosition; // 몬스터 시작 위치
        private bool isExecuting; // 현재 행동중인지 확인용도

        protected virtual void Awake()
        {
            startPosition = transform.position;
            if (attackEffect != null)
            {
                attackEffect.Stop();
            }
        }
        public void ExecuteTurn()
        {
            if (isExecuting) return;
            StartCoroutine(ExecuteTurnCo()); // 정해진 행동 순서를 코루틴으로 실행
        }
        // 템플릿 메서드 역할을 하는 함수
        // 전체 행동 순서를 부모가 고정
        private IEnumerator ExecuteTurnCo()
        {
            isExecuting = true;
            OnTurnStart();
            yield return MoveToTargetCo();
            yield return AttackCo();
            yield return ReturnToStartCo();
            OnTurnEnd();
            isExecuting = false;
        }
        // 타겟 근처까지 이동하는 코루틴
        // 기본 이동 방식은 부모가 제공함.
        protected virtual IEnumerator MoveToTargetCo()
        {
            while (Vector3.Distance(transform.position, target.position) > attackDistance)
            {
                transform.position = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
                yield return null;
            }
        }
        // 공격
        protected virtual IEnumerator AttackCo()
        {
            if(attackEffect != null)
            {
                attackEffect.Play(true);
            }
            yield return new WaitForSeconds(0.5f);

        }
        // 시작 위치로
        protected virtual IEnumerator ReturnToStartCo()
        {
            while (Vector3.Distance(transform.position, startPosition) > 0.05f)
            {
                transform.position = Vector3.MoveTowards(transform.position, startPosition, moveSpeed * Time.deltaTime);
                yield return null;
            }
            transform.position = startPosition;
        }
        // 행동 시작시 실행되는 함수
        // 자식이 필요하면 오버라이드 할 수 있음
        protected virtual void OnTurnStart()
        {

        }
        // 행동이 끝날 시 실행되는 함수
        protected virtual void OnTurnEnd()
        {

        }
    }
}

