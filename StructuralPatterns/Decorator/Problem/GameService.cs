using Decorator.Problem.Models;
using System;
using System.Collections.Generic;
using System.Text;
using static DesignPatterns.ConsoleUtils;

namespace Decorator.Problem
{
    public static class GameService
    {
        public static async Task RunGame()
        {
            WriteColored("Iniciando jogo...", 2);
            WriteSeparator();

            Enemy enemy = new(100);
            WriteColored(new("   ", ConsoleColor.Green, ConsoleColor.Green), new(" Inimigo padrão criado. Vida: "), new($"{enemy.HealthPoints}", ConsoleColor.White, 1));
            await TestEnemy(enemy);

            EnemyImmuneToFire enemyImmuneToFire = new(100);
            WriteColored(new("   ", ConsoleColor.DarkRed, ConsoleColor.DarkRed), new(" Inimigo imune a fogo criado. Vida: "), new($"{enemyImmuneToFire.HealthPoints} ", ConsoleColor.White, 1));
            await TestEnemy(enemyImmuneToFire);

            EnemyWithDeathExplosion enemyWithDeathExplosion = new(100, 20);
            WriteColored(new("   ", ConsoleColor.Magenta, ConsoleColor.Magenta), new(" Inimigo com explosão de morte criado. Vida: "), new($"{enemyWithDeathExplosion.HealthPoints} ", ConsoleColor.White, 1));
            await TestEnemy(enemyWithDeathExplosion);

            EnemyWithArmor enemyWithArmor = new(100, 2);
            WriteColored(new("   ", ConsoleColor.Blue, ConsoleColor.Blue), new(" Inimigo com armadura criado. Vida: "), new($"{enemyWithArmor.HealthPoints} ", ConsoleColor.White, 1));
            await TestEnemy(enemyWithArmor);

            EnemyWithDefeatReward enemyWithReward = new(100, 5);
            WriteColored(new("   ", ConsoleColor.Yellow, ConsoleColor.Yellow), new(" Inimigo com recompensa criado. Vida: "), new($"{enemyWithReward.HealthPoints} ", ConsoleColor.White, 1));
            await TestEnemy(enemyWithReward);

            EnemyWithDefeatRewardAndArmor enemyWithRewardAndArmor = new(50, 5, 2);
            WriteColored(new("   ", ConsoleColor.Red, ConsoleColor.Red), new(" Inimigo com recompensa e armadura criado. Vida: "), new($"{enemyWithRewardAndArmor.HealthPoints} ", ConsoleColor.White, 1));
            await TestEnemy(enemyWithRewardAndArmor);
        }

        private static async Task TestEnemy(Enemy enemy)
        {
            await Task.Delay(1000);

            WriteColored(new TextItem("Atacando inimigo... Dano: "), new TextItem("10", ConsoleColor.White, 1));
            await enemy.TakeDamage(DamageType.Default, 10);

            await Task.Delay(1000);
            WriteColored("", 1);
            WriteSeparator();

            WriteColored(new TextItem("Atacando inimigo com dano de fogo... Dano: "), new TextItem("10", ConsoleColor.White, 1));
            await enemy.TakeDamage(DamageType.Fire, 10);

            await Task.Delay(3000);
            WriteColored("", 1);
            WriteSeparator();

            WriteColored(new TextItem("Atacando inimigo com dano perfurante... Dano: "), new TextItem("80", ConsoleColor.White, 1));
            await enemy.TakeDamage(DamageType.Pierce, 80);

            await Task.Delay(2000);
            WriteColored("", 1);
            WriteSeparator();
        }
    }
}
