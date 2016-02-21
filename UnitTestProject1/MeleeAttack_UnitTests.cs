using System;
using System.Text;
using System.Collections.Generic;
using NUnit;
using NUnit.Framework;
using AnimaTools.Game_Logic;
using AnimaTools.Enums;
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
    }
}
