using static DesignPatterns.ConsoleUtils;

namespace Decorator.Solution.Models
{
    public class EnemyWithDeathExplosionDecorator : BaseEnemyDecorator
    {
        public int ExplosionDamage { get; private set; }
        public EnemyWithDeathExplosionDecorator(IEnemy enemy, int explosionDamage) : base(enemy)
        {
            ExplosionDamage = explosionDamage;
        }

        public override async Task TakeDamage(DamageType type, int damage)
        {
            int oldHealth = base.HealthPoints;
            await base.TakeDamage(type, damage);

            if (base.HealthPoints == 0 && oldHealth > 0)
                WriteColored(new TextItem($"Explosão após morte. Dano: {ExplosionDamage}", ConsoleColor.Magenta, 1));
        }
    }
}
