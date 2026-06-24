using static DesignPatterns.ConsoleUtils;

namespace Decorator.Problem.Models
{
    public class EnemyImmuneToFire : Enemy
    {
        public EnemyImmuneToFire(int healthPoints) : base(healthPoints)
        {
        }

        public override async Task TakeDamage(DamageType type, int damage)
        {
            if (type != DamageType.Fire)
                await base.TakeDamage(type, damage);
            else
                WriteColored(new TextItem($"Inimigo imune a fogo. Dano ignorado: {damage}", ConsoleColor.DarkRed, 1));
        }
    }
}
