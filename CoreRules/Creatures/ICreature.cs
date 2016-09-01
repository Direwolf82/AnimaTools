using System.Collections.Generic;
using System.ComponentModel;
using CoreRules.Enums;

namespace CoreRules.Creatures {
    public interface ICreature : INotifyPropertyChanged{
        int Level { get; }
        CreatureCategory Category { get; }
        bool IsElemental { get; }
        bool IsUndead { get; }
        int Gnosis { get; }
        int LifePoints { get; }
        AnimaClass Class { get; }
        int Strength { get; }
        int Dexterity { get; }
        int Agility { get; }
        int Constitution { get; }
        int Power { get; }
        int Intelligence { get; }
        int Willpower { get; }
        int Perception { get; }
        int Initiative { get; }
        int PhysicalResistance { get; }
        int MagicResistance { get; }
        int PsychicResistance { get; }
        int VenomResistance { get; }
        int DiseaseResistance { get; }
        IEnumerable<ICreatureAttack> Attacks { get; }
        int AttackAbility { get; }
        int DodgeAbility { get; }
        int BlockAbility { get; }
        IEnumerable<AttackTypes> Armour { get; }
        int Regeneration { get; }
        int MovementValue { get; }
        int? Fatigue { get; }
        bool Tireless { get; }

        /// <summary>
        /// Adjusts creature's life points by the damage taken. Use when Armour types will be irrelevant.
        /// </summary>
        /// <param name="damageTaken">Amount of damage dealt by attack</param>
        void DamageCreature(int damageTaken);

        void DamageCreature(int damageTaken, IEnumerable<AttackTypes> damageTypes);

    }
}