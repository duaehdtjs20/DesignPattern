using UnityEngine;

namespace DesignPatterns.Command
{
    public class AttackCommand : ICommand
    {
        private PlayerUnit attacker;
        private EnemyUnit target;
        private int damage;

        public AttackCommand(PlayerUnit attacker, EnemyUnit target)
        {
            this.attacker = attacker;
            this.target = target;
            damage = attacker.AttackDamage;
        }

        public void Execute()
        {
            if (target == null) return;
            target.TakeDamage(damage);
            Debug.Log("Attack Execute : " + damage);
        }

        public void Undo()
        {
            if (target == null) return;
            target.RestoreHp(damage);
            Debug.Log("Attack Undo : " + damage);
        }
    }
}
