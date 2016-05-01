using System;
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
        List<CreatureAttack> Attacks { get; }
        int AttackAbility { get; }
        int DodgeAbility { get; }
        int BlockAbility { get; }
        List<AttackTypes> Armour { get; }
        int Regeneration { get; }
        int MovementValue { get; }
        int? Fatigue { get; }
        bool Tireless { get; }

        void DamageCreature(int damageTaken);
        void DamageCreature(int damageTaken, List<AttackTypes> damageTypes);

    }
}