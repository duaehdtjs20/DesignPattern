using UnityEngine;
/*
[팩토리 패턴]
- 팩토리 패턴은 객체 생성을 전담하는 클래스를 따로 두는 디자인 패턴

- 일반적인 생성 방식
ㄴ Instantiate(monsterPrefab);
ㄴ 이렇게 직접 생성하면 생성하는 쪽 코드가 어떤 프리팹을 만들지 어떻게 초기화를 할지 모두 알아야 한다.

[팩토리 패턴 사용시]
예) monsterFactory.createMonster(position);
    ㄴ 생성하는 쪽은 Factory한테 요청만 함.
    ㄴ 실제로 어떤 몬스터를 만들지, 어떤 데이터를 넣을지, 어떤 초기화를 할지는 Factory가 담당

1. 객체 생성 코드를 한곳에서 관리할 수 있음
2. 생성 방식이 바뀌어도 사용하는 쪽 코드는 덜 바뀜
3. 몬스터, 아이템, 무기, 스킬처럼 종류가 많은 객체를 만들 때 유용
4. 스크립터블오브젝트와 조합하면 데이터 기반 생성구조를 만들기 좋음.
5. 생성 후 초기화 로직을 Factory 안에 모아둘 수 있음
*/

namespace DesignPatterns.FactoryPattern
{
    public class MonsterFactory : MonoBehaviour
    {
        [SerializeField] private MonsterBase monsterPrefab;
        [SerializeField] private MonsterData[] monsterDatas;

        public IMonsterProduct CreateRandomMonster(Vector3 position)
        {
            if (monsterPrefab == null) return null;
            if (monsterDatas == null ||  monsterDatas.Length == 0 ) return null;

            int randomIndex = Random.Range(0, monsterDatas.Length);

            MonsterData selectedData = monsterDatas[randomIndex];

            if(selectedData == null ) return null;

            MonsterBase newMonster = Instantiate(monsterPrefab, position, Quaternion.identity);

            newMonster.Initialize(selectedData);

            Debug.Log(GetLog(newMonster));
            return newMonster;
        }
        private string GetLog(IMonsterProduct monster)
        {
            return "MonsterFactory: create monster" + monster.MonsterName;
        }
    }
}
