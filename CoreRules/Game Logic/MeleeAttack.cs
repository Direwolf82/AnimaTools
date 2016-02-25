using CoreRules.Enums;
using System;

namespace CoreRules.Game_Logic {
    public static class MeleeAttack {

        /// <summary>
        /// Calculate the result of a melee attack.
        /// </summary>
        /// <param name="AttackResult">The result of attacker's final attack less defender's final defense</param>
        /// <param name="DefenderArmour">The armour value the defender has against the attacker's attack type</param>
        /// <returns>A tuple that describes if the attack hit for damage and the damage percentage, hit for no damage or triggered a counteracttack with or without a bonus to the counterattack.</returns>
        public static Tuple<AttackResults, int> ResolveAttack(int AttackResult, int DefenderArmour) {
            if (DefenderArmour < 0) {
                throw new ArgumentOutOfRangeException("DefenderArmour", "Armour value canot be less than 0");
            }
            else if (DefenderArmour > 10) {
                throw new ArgumentOutOfRangeException("DefenderArmour", "Armour value cannot be greater than 10");
            }
            int resultValue;
            if (AttackResult < -301) {
                AttackResult = -301;
            }
            else if (AttackResult > 400) {
                AttackResult = 400;
            }
            if (AttackResult < 0) {
                resultValue = (((Math.Abs(AttackResult) - 1) - ((Math.Abs(AttackResult) - 1) % 10))) / 2;
                return new Tuple<AttackResults, int>(AttackResults.CounterAttack, resultValue);
            }
            else if (AttackResult >= 0 && AttackResult < 30) {
                return new Tuple<AttackResults, int>(AttackResults.HitNoDamage, 0);
            }
            else if (AttackResult >= 30 && AttackResult < 40) {
                if (DefenderArmour < 3) {
                    return new Tuple<AttackResults, int>(AttackResults.HitWithDamage, 10);
                }
                else {
                    return new Tuple<AttackResults, int>(AttackResults.HitNoDamage, 0);
                }
            }
            else if (AttackResult >= 40 && AttackResult < 50) {
                if (DefenderArmour == 0) {
                    return new Tuple<AttackResults, int>(AttackResults.HitWithDamage, 30);
                }
                else if (DefenderArmour == 1 || DefenderArmour == 2) {
                    return new Tuple<AttackResults, int>(AttackResults.HitWithDamage, 20);
                }
                else if (DefenderArmour == 3) {
                    return new Tuple<AttackResults, int>(AttackResults.HitWithDamage, 10);
                }
                else {
                    return new Tuple<AttackResults, int>(AttackResults.HitNoDamage, 0);
                }
            }
            else {
                resultValue = AttackResult - (AttackResult % 10) - (DefenderArmour * 10);
                if (resultValue <= 0) {
                    return new Tuple<AttackResults, int>(AttackResults.HitNoDamage, 0);
                }
                else {
                    return new Tuple<AttackResults, int>(AttackResults.HitWithDamage, resultValue);
                }
            }
        }
    }
}