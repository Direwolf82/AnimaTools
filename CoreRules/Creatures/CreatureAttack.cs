using System.Collections.Generic;
using CoreRules.Enums;

namespace CoreRules.Creatures {
    public class CreatureAttack : ICreatureAttack {
        public string AttackName { get; internal set; }
        public List<AttackTypes> AttackType { get; internal set; }
        public int Damage { get; internal set; }
        public string Description { get; internal set; }

        public CreatureAttack(string name, List<AttackTypes> attackTypes, int damage, string description) {
            AttackName = name;
            AttackType = attackTypes;
            Damage = damage;
            Description = description;
        }

        public CreatureAttack(string name, List<AttackTypes> attackTypes, int damage) {
            AttackName = name;
            AttackType = attackTypes;
            Damage = damage;
        }
    }
}