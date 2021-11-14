using Croisant_Crawler.Core;

namespace Croisant_Crawler.Drawing
{
    public class Enemy_View
    {
        public readonly Stats Enemy;

        // public Enemy_View(Stats enemy)
        // {
        //     Enemy = enemy;
        // }
        public void SubscribeToStatChanges(Stats enemy)
        {
            enemy.HP_OnChange  += this.UpdateHP;
        }

        public void UpdateHP(Stats enemy)
        {
            
        }
    }
}