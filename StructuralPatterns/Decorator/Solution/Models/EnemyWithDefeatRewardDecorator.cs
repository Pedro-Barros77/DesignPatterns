using static DesignPatterns.ConsoleUtils;

namespace Decorator.Solution.Models
{
    public class EnemyWithDefeatRewardDecorator : BaseEnemyDecorator
    {
        public int CoinCount { get; private set; }
        public EnemyWithDefeatRewardDecorator(IEnemy enemy, int coinCount) : base(enemy)
        {
            CoinCount = coinCount;
        }

        public override async Task TakeDamage(DamageType type, int damage)
        {
            int oldHealth = base.HealthPoints;
            await base.TakeDamage(type, damage);

            if (base.HealthPoints == 0 && oldHealth > 0)
                WriteColored(new TextItem($"Moedas derrubadas: {CoinCount}", ConsoleColor.Yellow, 1));
        }
    }
}
