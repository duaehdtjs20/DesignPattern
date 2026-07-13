using UnityEngine;

namespace DesignPatterns.Decorator
{
    public class PoisonWeaponDecorator : WeaponDecorator
    {
        public PoisonWeaponDecorator(IWeapon weapon) : base(weapon) { }
        public override string GetName()
        {
            return base.GetName() + " + Poison";
        }
        public override int GetDamage()
        {
            return base.GetDamage() + 3;
        }
    }
}
