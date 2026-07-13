using System.Collections;
using UnityEngine;

namespace DesignPatterns.TemplateMethod
{
    public class Boss : MonsterBase
    {
        protected override IEnumerator MoveToTargetCo()
        {
            yield return new WaitForSeconds(0.3f);
            Vector3 targetPosition = target.position + Vector3.back * attackDistance;

            transform.position = targetPosition;
            yield return new WaitForSeconds(0.3f);
        }
        protected override IEnumerator AttackCo()
        {
            if(attackEffect != null)
            {
                attackEffect.Play();
            }
            transform.localScale = Vector3.one * 1.5f;
            yield return new WaitForSeconds(0.8f);
            transform.localScale = Vector3.one;
        }
    }
}
