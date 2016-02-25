using System;
using NUnit.Framework;
using CoreRules.Enums;
using CoreRules.Game_Logic;
using AnimaTools_UnitTests.TestData;

namespace AnimaTools_UnitTests {
    /// <summary>
    /// Summary description for MeleeAttack_UnitTests
    /// </summary>
    [TestFixture]
    public class MeleeAttack_UnitTests {

        public MeleeAttack_UnitTests() {

        }

        [Test, TestCaseSource(typeof(FailedAttackValues), "TestCases")]
        public int FinalAttackHigherThanDefense(int AttackValue) {
            Assert.AreEqual(AttackResults.CounterAttack, MeleeAttack.ResolveAttack(AttackValue, 0).Item1);
            return MeleeAttack.ResolveAttack(AttackValue, 0).Item2;
        }

        [Test, TestCaseSource(typeof(SuccessfulAttacks), "TestCases")]
        public Tuple<AttackResults, int> AttackEqualToOrHigherThanDefense(int AttackResult, int Armour) {
            return MeleeAttack.ResolveAttack(AttackResult, Armour);
        }

        [Test, ExpectedException("System.ArgumentOutOfRangeException")]
        public void ArmourLessThan0_ThrowException() {
            MeleeAttack.ResolveAttack(1, -1);
        }

        [Test, ExpectedException("System.ArgumentOutOfRangeException")]
        public void ArmourGreterThan10_ThrowException() {
            MeleeAttack.ResolveAttack(1, 11);
        }
    }
}
