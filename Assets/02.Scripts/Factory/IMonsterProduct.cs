using UnityEngine;

namespace DesignPatterns.FactoryPattern
{
    public interface IMonsterProduct
    {
        string MonsterName { get; }
        // 몬스터 데이터를 받아서 초기화하는 메서드
        void Initialize(MonsterData data);
    }
}
