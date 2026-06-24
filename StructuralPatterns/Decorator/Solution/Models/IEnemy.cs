using System;
using System.Collections.Generic;
using System.Text;

namespace Decorator.Solution.Models
{
    public interface IEnemy
    {
        public int HealthPoints { get; }
        Task TakeDamage(DamageType type, int damage);
    }
}
