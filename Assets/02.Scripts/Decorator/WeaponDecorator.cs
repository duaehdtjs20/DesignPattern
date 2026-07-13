using UnityEngine;

// 모든 무기 데코레이터의 부모 클래스.
// 데코레이터도 IWeapon을 구현함.
// 그래야 BasicSword와 똑같이 사용할 수 있음.
namespace DesignPatterns.Decorator
{
    public abstract class WeaponDecorator : IWeapon
    {
        protected IWeapon weapon;
        // 내가 감쌀 무기를 부모 클래스인 WeaponDecorator에게 넘긴다.
        public WeaponDecorator(IWeapon weapon)
        {
            this.weapon = weapon; // w전달받은 무기를 내부에 저장
        }
        public virtual string GetName()
        {
            return weapon.GetName(); // 기본적으로는 감싸고 있는 무기 이름을 그대로 반환
        }
        public virtual int GetDamage()
        {
            return weapon.GetDamage(); // 기본적으로는 감싸고 있는 무기 데미지를 그대로 반환
        }
    }
}
