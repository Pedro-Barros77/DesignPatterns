using static DesignPatterns.ConsoleUtils;

namespace Decorator.Solution.Models
{
    public class EnemyImmuneToFireDecorator : BaseEnemyDecorator
    {
        public EnemyImmuneToFireDecorator(IEnemy enemy) : base(enemy)
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
