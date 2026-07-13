using UnityEngine;

/*
[TemplateMethod Pattern]
- 알고리즘의 전체 흐름은 부모클래스가 정하고 세부동작만 자식이 클래스 구현
- 순서는 부모가 정하고 행동은 자식이 결정함.

몬스터가 여러종류가 있으면
- 플레이어를 찾음 -> 이동 -> 공격 -> 원래위치로 되돌아감.

- 슬라임은 천천히 이동
- 오크는 도끼로 공격함.
- 법사는 마법공격
*/

namespace DesignPatterns.TemplateMethod
{
    public class TemplateMethod : MonoBehaviour
    {
        [SerializeField] private MonsterBase goblin;
        [SerializeField] private MonsterBase orc;
        [SerializeField] private MonsterBase boss;

        private MonsterBase currentMonster;
        void Start()
        {
            currentMonster = goblin;
        }

        void Update()
        {
            if(Input.GetKeyDown(KeyCode.Alpha1))
            {
                currentMonster = goblin;
            }
            if(Input.GetKeyDown(KeyCode.Alpha2))
            {
                currentMonster = orc;
            }
            if(Input.GetKeyDown(KeyCode.Alpha3))
            {
                currentMonster = boss;
            }
            if(Input.GetKeyDown(KeyCode.Space))
            {
                currentMonster.ExecuteTurn();
            }
        }
    }
}
