using UnityEngine;

namespace DesignPatterns.Decorator
{
    public class CriticalWeaponDecorator : WeaponDecorator
    {
        public CriticalWeaponDecorator(IWeapon weapon) : base(weapon) { }
        public override string GetName()
        {
            return base.GetName() + " + Critical";
        }
        public override int GetDamage()
        {
            return base.GetDamage() * 2;
        }
    }
}
