using System;
using Croisant_Crawler.Data;

namespace Croisant_Crawler.Core
{
    public class Stats
    {
        public int Level { get; set; }

        public string Name { get; protected set; }

        protected ValueInRangeInt _HP;
        public ValueInRangeInt HP => _HP;
        public Action<Stats> HP_OnChange;
        // public int HP { get; set; }
        // public int MaxHP { get; set; }

        public virtual int Vit { get; set; } // R
        public virtual int Str { get; set; } // Y
        public virtual int Agi { get; set; } // G

        // Flat damage reduction.
        public virtual int Def { get; set; }
        // AV / (AV + 100)
        public virtual int Arm { get; set; }
        public float DamageReduction => Arm / (Arm + 100f);

        public Stats(string name, int vit, int str, int agi, int def = 0, int arm = 0)
        {
            (Name, Vit, Str, Agi, Def, Arm) = (name, vit, str, agi, def, arm);

            RecalculateHP(true);
        }

        public virtual void TakeDamage(int damage)
        {
            _HP.value -= CalculateDamage(damage);
            if(_HP.IsMin)
                Die();
            HP_OnChange(this);
        }

        private void Die()
        {
            throw new NotImplementedException("Props are not meant to die for now...");
        }

        protected virtual void RecalculateHP(bool firstCalculation = false)
        {
            float hpPercent = _HP.Percent;
            _HP.range.max = Vit * 20;
            _HP.value = (int)_HP.range.Evaluate(hpPercent);

            if(firstCalculation)
                _HP.value = _HP.range.max;
            HP_OnChange(this);
        }

        public int CalculateDamage(int baseDamage)
        {
            return (int)Math.Max(baseDamage * (1-DamageReduction) - Def, 1);
        }
    }
}