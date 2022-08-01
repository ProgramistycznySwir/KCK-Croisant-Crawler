using System;
using System.Collections.Generic;
using System.Linq;
using Croisant_Crawler.Core;
using Croisant_Crawler.Data;
using Croisant_Crawler.Drawing;

using static Croisant_Crawler.Helpers.ConsoleHelper;

namespace Croisant_Crawler;

public enum FightResult { Victory, TPK }
public static class Fight_Game
{
    public static FightResult StartFight(in PlayerStats player, in Room room)
    {
        Console.Clear();


        Fight fight = new Fight(room.distanceFromStart);

        Fight_View view = new(player, fight);
        view.DisplayPrompt("Fight has started press [enter] key if you're ready.");
        Wait();

        // Fight loop:
        ConsoleKey key = ConsoleKey.X;
        for(int turn = 1; true; turn++)
        {
            view.DelimitTurn(turn);

            // view.DisplayPrompt("Choose action, accept with [D]");
            // view.DisplayActions(player);
            view.DisplayPrompt("For now you can only attack, proceed with [enter] key.");

            view.DisplayPrompt("Choose target, accept with [D], back off action with [A].");
            goto_ChooseTargetAgain:
            view.EnemySelector.SetActive(true);
            int selectedTargetIndex;
            Stats selectedTarget;
            do
            {
                view.EnemySelector.UpdateCursor(key);
                selectedTargetIndex = view.EnemySelector.CursorIndex;
                selectedTarget = fight.enemies[selectedTargetIndex];
                Stats_View.DrawStats(selectedTarget);
            } while((key = TakeInput()) is not ConsoleKey.D or ConsoleKey.A);
            if(selectedTarget.IsDead)
                goto goto_ChooseTargetAgain;
            view.EnemySelector.SetActive(false);

            // Deal damage to enemy:
            int damage = player.GetDamage();
            int receivedDamage = selectedTarget.TakeDamage(damage);
            view.Log(DamageMessage(player.Name, $"[{selectedTargetIndex + 1}]{selectedTarget.Name}", receivedDamage.ToString()));
            // Give player exp.
            if(selectedTarget.IsDead)
            {
                view.Log(DeathMessage($"[{selectedTargetIndex + 1}]{selectedTarget.Name}"));
                player.ReceiveExp(PlayerStats.ExpGainFormula(player, selectedTarget));
            }
            if (fight.enemies.All(enemy => enemy.IsDead))
                return Victory(view, player);

            foreach(Stats enemy in fight.enemies)
            {
                damage = enemy.GetDamage();
                receivedDamage = player.TakeDamage(damage);
                view.Log(DamageMessage($"[{selectedTargetIndex + 1}]{selectedTarget.Name}", player.Name, receivedDamage.ToString()));
                if(player.IsDead)
                    return GameOver(view);
            }
        }
    }

    static FightResult Victory(Fight_View view, PlayerStats player)
    {
        view.PlayerView.UnsubscribeToStatChanges(player);

        view.DelimitTurn(0);
        view.Log("Hero has defeated all enemies.");
        view.DisplayPrompt("You've won, press [enter] to continue adventure.");
        Wait();
        return FightResult.Victory;
    }

    static FightResult GameOver(Fight_View view)
    {
        view.DelimitTurn(0);
        view.Log("Hero has fallen...");
        view.DisplayPrompt("You've lost, game is over, press [enter] to continue...");
        Wait();
        return FightResult.TPK;
    }

    static string DamageMessage(string attacker, string receiver, string damage)
        => $"{attacker} have dealt {damage} damage to {receiver}";
    static string DeathMessage(string subject)
        => $"{subject} has been eliminated.";
    static string ExperienceMessage(string amount)
        => $"Hero was rewarded {amount} experience";
    static string LevelUpMessage(string amount)
        => $"Hero has leveled up.";
}