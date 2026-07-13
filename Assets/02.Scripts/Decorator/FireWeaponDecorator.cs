using UnityEngine;

// 기존 무기에 화염옵션을 추가하는 데코레이터
// 기존 무기를 수정하지 않고 바깥에서 감싸서 기능을 추가
namespace DesignPatterns.Decorator
{
    public class FireWeaponDecorator : WeaponDecorator
    {
        // 기존 무기를 부모 생성자에게 전달
        public FireWeaponDecorator(IWeapon weapon) : base(weapon) { }
        public override string GetName()
        {
            return base.GetName() + " + Fire";
        }
        public override int GetDamage()
        {
            return base.GetDamage() + 5;
        }
    }
}
