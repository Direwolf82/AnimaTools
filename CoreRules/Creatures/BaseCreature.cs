using System;
using System.Collections.Generic;
using System.ComponentModel;
using CoreRules.Enums;

namespace CoreRules.Creatures {
    public class BaseCreature : ICreature {
        private bool isElemental;
        private bool isUndead;
        private int lifePoints;
        private int maxLifePoints;

        public int Level { get; internal set; }
        public CreatureCategory Category { get; internal set; }

        public virtual bool IsElemental {
            get { return isElemental; }
            internal set {
                isElemental = value;
                if (value) {
                    IsUndead = false;
                }
            }
        }
        public virtual bool IsUndead {
            get { return isUndead; }
            internal set {
                isUndead = value;
                if (value) {
                    IsElemental = false;
                }
            }
        }

        public int Gnosis { get; internal set; }

        public int LifePoints {
            get {
                return lifePoints;
            }
            internal set {
                lifePoints = value;
                NotifyPropertyChanged(nameof(LifePoints));
            }
        }

        public AnimaClass Class { get; internal set; }
        #region base stats
        public int Strength { get; internal set; }
        public int Dexterity { get; internal set; }
        public int Agility { get; internal set; }
        public int Constitution { get; internal set; }
        public int Power { get; internal set; }
        public int Intelligence { get; internal set; }
        public int Willpower { get; internal set; }
        public int Perception { get; internal set; }
        #endregion 
        public int Initiative { get; internal set; }
        #region resistances
        public int PhysicalResistance { get; internal set; }
        public int MagicResistance { get; internal set; }
        public int PsychicResistance { get; internal set; }
        public int VenomResistance { get; internal set; }
        public int DiseaseResistance { get; internal set; }
        #endregion
        public IEnumerable<ICreatureAttack> Attacks { get; internal set; }
        public int AttackAbility { get; internal set; }
        public int Regeneration { get; internal set; }
        public int MovementValue { get; internal set; }
        public int? Fatigue { get; internal set; }
        public bool Tireless { get; internal set; }
        public int DodgeAbility { get; internal set; }
        public int BlockAbility { get; internal set; }
        public IEnumerable<AttackTypes> Armour {
            get {
                throw new NotImplementedException();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(string propertyName) {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public virtual void DamageCreature(int damageTaken) {
            if (damageTaken > LifePoints) {
                LifePoints = 0;
            } else {
                LifePoints -= damageTaken;
            }
        }

        public virtual void DamageCreature(int damageTaken, IEnumerable<AttackTypes> damageTypes) {
            throw new NotImplementedException();
        }

        public BaseCreature(int lifePoints, int initiative, int attackAbility, int dodgeAbility, int blockAbility) {
            LifePoints = lifePoints;
            Initiative = initiative;
            AttackAbility = attackAbility;
            DodgeAbility = dodgeAbility;
            BlockAbility = blockAbility;
        }
    }
}