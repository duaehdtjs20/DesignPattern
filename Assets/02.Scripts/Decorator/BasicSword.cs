using UnityEngine;

// 가장 기본이 되는 클래스
// 데코레이터 들이 이 기본 무기를 감싸면서 기능을 추가
namespace DesignPatterns.Decorator
{
    public class BasicSword : IWeapon
    {
        public string GetName()
        {
            return "Basic Sword";
        }
        public int GetDamage()
        {
            return 10;
        }
    }
}
