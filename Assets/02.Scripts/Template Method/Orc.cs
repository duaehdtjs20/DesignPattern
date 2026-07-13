using System.Collections;
using UnityEngine;

namespace DesignPatterns.TemplateMethod
{
    public class Orc : MonsterBase
    {
        protected override IEnumerator AttackCo()
        {
            transform.position += Vector3.up * 0.3f;
            yield return new WaitForSeconds(0.3f);

            if(attackEffect != null )
            {
                attackEffect.Play();
            }
            transform.position -= Vector3.up * 0.3f;
            yield return new WaitForSeconds(0.5f);
        }
    }
}
