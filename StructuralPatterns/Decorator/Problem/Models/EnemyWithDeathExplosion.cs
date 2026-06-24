using static DesignPatterns.ConsoleUtils;

namespace Decorator.Problem.Models
{
    public class EnemyWithDeathExplosion : Enemy
    {
        public int ExplosionDamage { get; private set; }
        public EnemyWithDeathExplosion(int healthPoints, int explosionDamage) : base(healthPoints)
        {
            ExplosionDamage = explosionDamage;
        }
        public override async Task TakeDamage(DamageType type, int damage)
        {
            int oldHealth = base.HealthPoints;
            await base.TakeDamage(type, damage);

            if (HealthPoints == 0 && oldHealth > 0)
                WriteColored(new TextItem($"Explosão após morte. Dano: {ExplosionDamage}", ConsoleColor.Magenta, 1));
        }
    }
}
