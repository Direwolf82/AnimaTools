using CoreRules.Enums;
using System.Collections.Generic;

namespace CoreRules.Dictionaries {
    public static class SpecialCombatSituationModifiers {

        public static int? TotalAttackModifier(List<SpecialCombatSituations> combatSituations) {
            if (combatSituations.Count == 0) {
                return 0;
            }
            int? totalModifier = 0;
            foreach (var situation in combatSituations) {
                int? value;
                AttackModifiers.TryGetValue(situation, out value);
                if (value == null) {
                    totalModifier = null;
                    break;
                }
                else {
                    totalModifier += value;
                }
            }
            return totalModifier;
        }

        public static int? TotalPhysicalActionModifier(List<SpecialCombatSituations> combatSituations) {
            if (combatSituations.Count == 0) {
                return 0;
            }
            int? totalModifier = 0;
            foreach (var situation in combatSituations) {
                int? value;
                PhysicalActionModifiers.TryGetValue(situation, out value);
                if (value == null) {
                    totalModifier = null;
                    break;
                }
                else {
                    totalModifier += value;
                }
            }
            return totalModifier;

        }

        public static int? TotalInitiativeModifier(List<SpecialCombatSituations> combatSituations) {
            if (combatSituations.Count == 0) {
                return 0;
            }
            int? totalModifier = 0;
            foreach (var situation in combatSituations) {
                int? value;
                InitiativeModifiers.TryGetValue(situation, out value);
                if (value == null) {
                    totalModifier = null;
                    break;
                }
                else {
                    totalModifier += value;
                }
            }
            return totalModifier;

        }

        public static int? TotalDodgeModifier(List<SpecialCombatSituations> combatSituations) {
            if (combatSituations.Count == 0) {
                return 0;
            }
            int? totalModifier = 0;
            foreach (var situation in combatSituations) {
                int? value;
                DodgekModifiers.TryGetValue(situation, out value);
                if (value == null) {
                    totalModifier = null;
                    break;
                }
                else {
                    totalModifier += value;
                }
            }
            return totalModifier;

        }

        public static int? TotalBlockModifier(List<SpecialCombatSituations> combatSituations) {
            if (combatSituations.Count == 0) {
                return 0;
            }
            int? totalModifier = 0;
            foreach (var situation in combatSituations) {
                int? value;
                BlockModifiers.TryGetValue(situation, out value);
                if (value == null) {
                    totalModifier = null;
                    break;
                }
                else {
                    totalModifier += value;
                }
            }
            return totalModifier;
        }

        #region Attack Modifiers
        static Dictionary<SpecialCombatSituations, int?> AttackModifiers = new Dictionary<SpecialCombatSituations, int?>() {
            {SpecialCombatSituations.Flanked, -10 },
            {SpecialCombatSituations.FromBehind, -30 },
            {SpecialCombatSituations.Surprised, null },
            {SpecialCombatSituations.VisionPartiallyObscured, -30 },
            {SpecialCombatSituations.VisionTotallyObscured, -100 },
            {SpecialCombatSituations.HigherGround, 20 },
            {SpecialCombatSituations.FromGround, -30 },
            {SpecialCombatSituations.PartiallyImmobilized, -20 },
            {SpecialCombatSituations.MostlyImmobilized, -80 },
            {SpecialCombatSituations.FullyImmobilized, -200 },
            {SpecialCombatSituations.PutAtWeaponPoint, -20 },
            {SpecialCombatSituations.Levitating, -20 },
            {SpecialCombatSituations.FlightType10To14, 10 },
            {SpecialCombatSituations.FlightType15Plus, 15 },
            {SpecialCombatSituations.Charging, 10 },
            {SpecialCombatSituations.DrawingWeapon, -25 },
            {SpecialCombatSituations.CrowededSpace, -40 },
            {SpecialCombatSituations.SmallAdversary, -10 },
            {SpecialCombatSituations.TinyAdversary, -20 }
        };
        #endregion

        #region Block Modifiers
        static Dictionary<SpecialCombatSituations, int?> BlockModifiers = new Dictionary<SpecialCombatSituations, int?>() {
            {SpecialCombatSituations.Flanked, -30 },
            {SpecialCombatSituations.FromBehind, -80 },
            {SpecialCombatSituations.Surprised, -90 },
            {SpecialCombatSituations.VisionPartiallyObscured, -30 },
            {SpecialCombatSituations.VisionTotallyObscured, -80},
            {SpecialCombatSituations.HigherGround, 0 },
            {SpecialCombatSituations.FromGround, -30 },
            {SpecialCombatSituations.PartiallyImmobilized, -20 },
            {SpecialCombatSituations.MostlyImmobilized, -80 },
            {SpecialCombatSituations.FullyImmobilized, -200 },
            {SpecialCombatSituations.PutAtWeaponPoint, -120 },
            {SpecialCombatSituations.Levitating, -20 },
            {SpecialCombatSituations.FlightType10To14, 10 },
            {SpecialCombatSituations.FlightType15Plus, 10 },
            {SpecialCombatSituations.Charging, -10 },
            {SpecialCombatSituations.DrawingWeapon, -25 },
            {SpecialCombatSituations.CrowededSpace, -40 },
            {SpecialCombatSituations.SmallAdversary, 0 },
            {SpecialCombatSituations.TinyAdversary, -10 }
        };
        #endregion

        #region Dodge Modifiers
        static Dictionary<SpecialCombatSituations, int?> DodgekModifiers = new Dictionary<SpecialCombatSituations, int?>() {
            {SpecialCombatSituations.Flanked, -30 },
            {SpecialCombatSituations.FromBehind, -80 },
            {SpecialCombatSituations.Surprised, -90 },
            {SpecialCombatSituations.VisionPartiallyObscured, -15 },
            {SpecialCombatSituations.VisionTotallyObscured, -80},
            {SpecialCombatSituations.HigherGround, 0 },
            {SpecialCombatSituations.FromGround, -30 },
            {SpecialCombatSituations.PartiallyImmobilized, -40 },
            {SpecialCombatSituations.MostlyImmobilized, -80 },
            {SpecialCombatSituations.FullyImmobilized, -200 },
            {SpecialCombatSituations.PutAtWeaponPoint, -120 },
            {SpecialCombatSituations.Levitating, -40 },
            {SpecialCombatSituations.FlightType10To14, 10 },
            {SpecialCombatSituations.FlightType15Plus, 20 },
            {SpecialCombatSituations.Charging, -20 },
            {SpecialCombatSituations.DrawingWeapon, 0 },
            {SpecialCombatSituations.CrowededSpace, -40 },
            {SpecialCombatSituations.SmallAdversary, 0 },
            {SpecialCombatSituations.TinyAdversary, 0 }
        };

        #endregion

        #region Initiative Modifiers
        static Dictionary<SpecialCombatSituations, int?> InitiativeModifiers = new Dictionary<SpecialCombatSituations, int?>() {
            {SpecialCombatSituations.Flanked, 0 },
            {SpecialCombatSituations.FromBehind, 0 },
            {SpecialCombatSituations.Surprised, null },
            {SpecialCombatSituations.VisionPartiallyObscured, 0 },
            {SpecialCombatSituations.VisionTotallyObscured, 0},
            {SpecialCombatSituations.HigherGround, 0 },
            {SpecialCombatSituations.FromGround, -10 },
            {SpecialCombatSituations.PartiallyImmobilized, -20 },
            {SpecialCombatSituations.MostlyImmobilized, -30 },
            {SpecialCombatSituations.FullyImmobilized, -100 },
            {SpecialCombatSituations.PutAtWeaponPoint, -50 },
            {SpecialCombatSituations.Levitating, 0 },
            {SpecialCombatSituations.FlightType10To14, 10 },
            {SpecialCombatSituations.FlightType15Plus, 10 },
            {SpecialCombatSituations.Charging, 0 },
            {SpecialCombatSituations.DrawingWeapon, 0 },
            {SpecialCombatSituations.CrowededSpace, 0 },
            {SpecialCombatSituations.SmallAdversary, 0 },
            {SpecialCombatSituations.TinyAdversary, 0 }
        };

        #endregion

        #region Physical Action Modifiers
        static Dictionary<SpecialCombatSituations, int?> PhysicalActionModifiers = new Dictionary<SpecialCombatSituations, int?>() {
            {SpecialCombatSituations.Flanked, 0 },
            {SpecialCombatSituations.FromBehind, 0 },
            {SpecialCombatSituations.Surprised, -90 },
            {SpecialCombatSituations.VisionPartiallyObscured, -30 },
            {SpecialCombatSituations.VisionTotallyObscured, -90},
            {SpecialCombatSituations.HigherGround, 0 },
            {SpecialCombatSituations.FromGround, -30 },
            {SpecialCombatSituations.PartiallyImmobilized, -40 },
            {SpecialCombatSituations.MostlyImmobilized, -60 },
            {SpecialCombatSituations.FullyImmobilized, -200 },
            {SpecialCombatSituations.PutAtWeaponPoint, -100 },
            {SpecialCombatSituations.Levitating, -60 },
            {SpecialCombatSituations.FlightType10To14, 0 },
            {SpecialCombatSituations.FlightType15Plus, 0 },
            {SpecialCombatSituations.Charging, 0 },
            {SpecialCombatSituations.DrawingWeapon, -25 },
            {SpecialCombatSituations.CrowededSpace, -20 },
            {SpecialCombatSituations.SmallAdversary, 0 },
            {SpecialCombatSituations.TinyAdversary, 0 }
        };
        #endregion

    }
}
