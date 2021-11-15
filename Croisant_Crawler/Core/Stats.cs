using System;
using Croisant_Crawler.Data;

namespace Croisant_Crawler.Core
{
    public class Stats
    {
        public virtual int Lvl { get; protected set; }

        public string Name { get; protected set; }

        protected ValueInRangeInt _HP;
        public ValueInRangeInt HP => _HP;
        // I'm leaving this as Action<Stats> soo if I need it later.
        public Action<Stats> HP_OnChange;

        public virtual int Vit { get; set; } // R
        public virtual int Str { get; set; } // Y
        public virtual int Agi { get; set; } // G

        // Flat damage reduction.
        public virtual int Def { get; set; }
        // AV / (AV + 100)
        public virtual int Arm { get; set; }
        public float DamageReduction => Arm / (Arm + 100f);

        public bool IsDead { get; protected set; }
        public Action<Stats> IsDead_OnChange;

        public RangeInt DamageRange { get; protected set; }
        public Action<Stats> Dmg_OnChange;
        public int GetDamage()
            => DamageRange.RandomInt;

        public Stats(string name, int vit, int str, int agi, int def = 0, int arm = 0, int? lvl = null)
        {
            (Name, Vit, Str, Agi, Def, Arm) = (name, vit, str, agi, def, arm);
            if(lvl.HasValue)
                Lvl = lvl.Value;

            RecalculateHP(true);
            RecalculateDamageRange();
        }

        public virtual int TakeDamage(int damage)
        {
            int receivedDamage = CalculateDamageReceived(damage);
            _HP.value -= receivedDamage;
            if(_HP.IsMin)
                Die();
            if(HP_OnChange is not null)
                HP_OnChange(this);

            return receivedDamage;
        }

        protected virtual void Die()
        {
            IsDead = true;
            RunSummary.IncKilledEnemies();
            if(IsDead_OnChange is not null)
                IsDead_OnChange(this);
        }

        protected virtual void RecalculateHP(bool firstCalculation = false)
        {
            float hpPercent = _HP.Percent;
            _HP.range.max = Vit * 20;
            _HP.value = (int)_HP.range.Evaluate(hpPercent);

            if(firstCalculation)
                _HP.value = _HP.range.max;
            if(HP_OnChange is not null)
                HP_OnChange(this);
        }

        protected virtual void RecalculateDamageRange()
        {
            DamageRange = new RangeInt(Str * 2, Str * 3);

            if(Dmg_OnChange is not null)
                Dmg_OnChange(this);
        }

        public int CalculateDamageReceived(int baseDamage)
        {
            return (int)Math.Max(baseDamage * (1-DamageReduction) - Def, 1);
        }
    }
}