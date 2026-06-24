using System;
using System.Collections.Generic;
using System.Text;

namespace Decorator.Solution.Models
{
    public abstract class BaseEnemyDecorator : IEnemy
    {
        private readonly IEnemy WrappedEnemy;
        public int HealthPoints => WrappedEnemy.HealthPoints;

        protected BaseEnemyDecorator(IEnemy enemy)
        {
            WrappedEnemy = enemy;
        }

        public virtual async Task TakeDamage(DamageType type, int damage)
        {
            await WrappedEnemy.TakeDamage(type, damage);
        }
    }
}
