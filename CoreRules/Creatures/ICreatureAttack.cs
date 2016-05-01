using System.Collections.Generic;
using CoreRules.Enums;

namespace CoreRules.Creatures {
    public interface ICreatureAttack {
        string AttackName { get; }
        List<AttackTypes> AttackType { get; }
        int Damage { get; }
        string Description { get; }
    }
}