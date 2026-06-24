using static DesignPatterns.ConsoleUtils;

namespace Decorator.Problem.Models
{
    public class EnemyWithDefeatReward : Enemy
    {
        public int CoinCount { get; private set; }
        public EnemyWithDefeatReward(int healthPoints, int coinCount) : base(healthPoints)
        {
            CoinCount = coinCount;
        }
        public override async Task TakeDamage(DamageType type, int damage)
        {
            int oldHealth = base.HealthPoints;
            await base.TakeDamage(type, damage);

            if (HealthPoints == 0 && oldHealth > 0)
                WriteColored(new TextItem($"Moedas derrubadas: {CoinCount}", ConsoleColor.Yellow, 1));
        }
    }
}
