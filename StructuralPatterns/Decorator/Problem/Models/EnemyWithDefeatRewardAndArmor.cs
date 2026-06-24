using static DesignPatterns.ConsoleUtils;

namespace Decorator.Problem.Models
{
    public class EnemyWithDefeatRewardAndArmor : Enemy
    {
        public int CoinCount { get; private set; }
        public float ArmorProtection { get; private set; }
        public EnemyWithDefeatRewardAndArmor(int healthPoints, int coinCount, float armorProtection) : base(healthPoints)
        {
            CoinCount = coinCount;
            ArmorProtection = armorProtection;
        }
        public override async Task TakeDamage(DamageType type, int damage)
        {
            int _damage = damage;

            if (type != DamageType.Pierce)
                _damage = (int)Math.Round(damage / ArmorProtection);

            WriteColored(new TextItem($"Dano absorvido por armadura: {damage - _damage}", ConsoleColor.Blue, 1));

            int oldHealth = base.HealthPoints;
            await base.TakeDamage(type, _damage);

            if (HealthPoints == 0 && oldHealth > 0)
                WriteColored(new TextItem($"Moedas derrubadas: {CoinCount}", ConsoleColor.Yellow, 1));
        }
    }
}
