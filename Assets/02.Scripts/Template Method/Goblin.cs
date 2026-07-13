using System.Collections;
using UnityEngine;

namespace DesignPatterns.TemplateMethod
{
    public class Goblin : MonsterBase
    {
        protected override IEnumerator AttackCo()
        {
            if (attackEffect != null)
            {
                attackEffect.Play();
            }
            transform.localScale = Vector3.one * 1.2f;
            yield return new WaitForSeconds(0.2f);

            transform.localScale = Vector3.one;
        }
    }

}
