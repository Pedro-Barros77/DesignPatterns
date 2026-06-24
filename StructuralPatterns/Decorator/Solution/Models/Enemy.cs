using static DesignPatterns.ConsoleUtils;

namespace Decorator.Solution.Models
{
    public enum DamageType
    {
        Default,
        Explosion,
        Fire,
        Frost,
        Poison,
        Pierce
    }

    public class Enemy : IEnemy
    {
        public int HealthPoints { get; protected set; }

        public Enemy(int healthPoints)
        {
            HealthPoints = healthPoints;
        }

        public async Task TakeDamage(DamageType type, int damage)
        {
            SetHealthPoints(HealthPoints - damage);

            if (type == DamageType.Fire || type == DamageType.Poison)
            {
                //Simulação de dano durante um tempo em ticks
                _ = Task.Run(async () =>
                {
                    int fireTickDamage = damage / 10;
                    await Task.Delay(500);
                    SetHealthPoints(HealthPoints - fireTickDamage);
                    await Task.Delay(500);
                    SetHealthPoints(HealthPoints - fireTickDamage);
                    await Task.Delay(500);
                    SetHealthPoints(HealthPoints - fireTickDamage);
                });
            }
        }

        private void SetHealthPoints(int value)
        {
            int oldHealth = HealthPoints;
            HealthPoints = Math.Clamp(value, 0, 100);
            WriteColored(new TextItem($"Dano recebido ({oldHealth - HealthPoints}). Vida: {oldHealth} => {HealthPoints}", ConsoleColor.White, 1));

            if (HealthPoints == 0)
                WriteColored(new TextItem("Inimigo morto", ConsoleColor.White, 1));
        }
    }
}
