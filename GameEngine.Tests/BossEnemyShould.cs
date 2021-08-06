using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace GameEngine.Tests
{
    public class BossEnemyShould
    {
        private readonly BossEnemy _sut;
        public BossEnemyShould()
        {
            _sut = new();
        }
        [Fact]
        [Trait("Category", "Enemy")]
        public void HaveCorrectPower()
        {
            //BossEnemy sut = new();
            Assert.Equal(166.667, _sut.TotalSpecialAttackPower, 3);
        }

        
    }
}
