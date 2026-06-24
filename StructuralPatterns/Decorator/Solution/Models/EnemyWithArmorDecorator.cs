using static DesignPatterns.ConsoleUtils;

namespace Decorator.Solution.Models
{
    public class EnemyWithArmorDecorator : BaseEnemyDecorator
    {
        public float ArmorProtection { get; private set; }
        public EnemyWithArmorDecorator(IEnemy enemy, float armorProtection) : base(enemy)
        {
            ArmorProtection = armorProtection;
        }

        public override async Task TakeDamage(DamageType type, int damage)
        {
            int _damage = damage;

            if (type != DamageType.Pierce)
                _damage = (int)Math.Round(damage / ArmorProtection);

            WriteColored(new TextItem($"Dano absorvido por armadura: {damage - _damage}", ConsoleColor.Blue, 1));

            await base.TakeDamage(type, _damage);
        }
    }
}
