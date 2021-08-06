using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace GameEngine.Tests
{
    /// <summary>
    /// For checking the Inheritance Hierarchy
    /// </summary>
    public class EnemyFactoryShould
    {
        [Fact]
        [Trait("Category", "Enemy")]
        public void CreateNormalEnemyByDefault()
        {
            EnemyFactory sut = new EnemyFactory();
            Enemy enemy = sut.Create("Zombie");

            Assert.IsType<NormalEnemy>(enemy);
        }
        [Fact]
        public void CreateNormalEnemyByDefault_NotTypeEg()
        {
            EnemyFactory sut = new EnemyFactory();
            Enemy enemy = sut.Create("Zombie");

            Assert.IsNotType<DateTime>(enemy);
        }
        [Fact]
        public void CreateBossEnemy()
        {
            EnemyFactory sut = new EnemyFactory();
            Enemy enemy = sut.Create("Zombie King", isBoss: true);

            Assert.IsType<BossEnemy>(enemy);
        }
        //Base class checking
        [Fact]
        public void CreateBossEnemy_CreateAssignableType()
        {
            EnemyFactory sut = new EnemyFactory();
            Enemy enemy = sut.Create("Zombie King", isBoss: true);

            Assert.IsAssignableFrom<Enemy>(enemy);
        }
        //Check two instances not same
        [Fact]
        public void CreateSeparateInstanc()
        {
            EnemyFactory sut = new EnemyFactory();
            var enemy1 = sut.Create("Zombie");
            var enemy2 = sut.Create("Zombie");

            Assert.NotSame(enemy2, enemy1);
        }
        [Fact]
        public void NotAllowNullName()
        {
            EnemyFactory sut = new EnemyFactory();

            Assert.Throws<ArgumentNullException>(()=> sut.Create(null));
        }

        [Fact]
        public void NotAllowNullName_specific()
        {
            EnemyFactory sut = new EnemyFactory();

            Assert.Throws<ArgumentNullException>("name",() => sut.Create(null));
        }
        //Boss Name check is a private method

        [Fact]
        public void OnlyAllowKingOrQueenBossName()
        {
            EnemyFactory sut = new EnemyFactory();

            EnemyCreationException ex = Assert.Throws<EnemyCreationException>(() => sut.Create("Zombie",true));

            Assert.Equal("Zombie", ex.RequestedEnemyName);
        }
    }
}
