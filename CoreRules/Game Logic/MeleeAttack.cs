using CoreRules.Enums;
using System;

namespace CoreRules.Game_Logic {
    public static class MeleeAttack {

        /// <summary>
        /// Calculate the result of a melee attack.
        /// </summary>
        /// <param name="attackResult">The result of attacker's final attack less defender's final defense</param>
        /// <param name="defenderArmour">The armour value the defender has against the attacker's attack type</param>
        /// <returns>A tuple that describes if the attack hit for damage and the damage percentage, hit for no damage or triggered a counteracttack with or without a bonus to the counterattack.</returns>
        public static Tuple<AttackResults, int> ResolveAttack(int attackResult, int defenderArmour) {
            if (defenderArmour < 0) {
                throw new ArgumentOutOfRangeException(nameof(defenderArmour), "Armour value canot be less than 0");
            } else if (defenderArmour > 10) {
                throw new ArgumentOutOfRangeException(nameof(defenderArmour), "Armour value cannot be greater than 10");
            }
            int resultValue;
            if (attackResult < -301) {
                attackResult = -301;
            } else if (attackResult > 400) {
                attackResult = 400;
            }
            if (attackResult < 0) {
                resultValue = (((Math.Abs(attackResult) - 1) - ((Math.Abs(attackResult) - 1) % 10))) / 2;
                return new Tuple<AttackResults, int>(AttackResults.CounterAttack, resultValue);
            } else if (attackResult >= 0 && attackResult < 30) {
                return new Tuple<AttackResults, int>(AttackResults.HitNoDamage, 0);
            } else if (attackResult >= 30 && attackResult < 40) {
                if (defenderArmour < 3) {
                    return new Tuple<AttackResults, int>(AttackResults.HitWithDamage, 10);
                } else {
                    return new Tuple<AttackResults, int>(AttackResults.HitNoDamage, 0);
                }
            } else if (attackResult >= 40 && attackResult < 50) {
                if (defenderArmour == 0) {
                    return new Tuple<AttackResults, int>(AttackResults.HitWithDamage, 30);
                } else if (defenderArmour == 1 || defenderArmour == 2) {
                    return new Tuple<AttackResults, int>(AttackResults.HitWithDamage, 20);
                } else if (defenderArmour == 3) {
                    return new Tuple<AttackResults, int>(AttackResults.HitWithDamage, 10);
                } else {
                    return new Tuple<AttackResults, int>(AttackResults.HitNoDamage, 0);
                }
            } else {
                resultValue = attackResult - (attackResult % 10) - (defenderArmour * 10);
                if (resultValue <= 0) {
                    return new Tuple<AttackResults, int>(AttackResults.HitNoDamage, 0);
                } else {
                    return new Tuple<AttackResults, int>(AttackResults.HitWithDamage, resultValue);
                }
            }
        }
    }
}