using static DesignPatterns.ConsoleUtils;

namespace Decorator.Problem.Models
{
    public class EnemyWithArmor : Enemy
    {
        public float ArmorProtection { get; private set; }
        public EnemyWithArmor(int healthPoints, float armorProtection) : base(healthPoints)
        {
            ArmorProtection = armorProtection;
        }

        public override async Task TakeDamage(DamageType type, int damage)
        {
            int _damage = damage;

            if(type != DamageType.Pierce)
                _damage = (int)Math.Round(damage / ArmorProtection);

            WriteColored(new TextItem($"Dano absorvido por armadura: {damage - _damage}", ConsoleColor.Blue, 1));
            
            await base.TakeDamage(type, _damage);
        }
    }
}
