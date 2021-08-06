using System;
using Xunit;

namespace GameEngine.Tests
{
    public class PlayerCharacterShould
    {
        [Fact]
        public void BeInexprincedWhenNew()
        {
            PlayerCharacter sut = new PlayerCharacter();
            Assert.True(sut.IsNoob);// Boolean
        }

        // String
        [Fact]
        public void CalculateFullName()
        {
            PlayerCharacter sut = new() { FirstName = "FName", LastName = "LName" };
            Assert.Equal("FName LName", sut.FullName, ignoreCase: true);

        }

        [Fact]
        public void CalculateFullName_StartsWithFName()
        {
            PlayerCharacter sut = new() { FirstName = "FName", LastName = "LName" };
            Assert.StartsWith("FName", sut.FullName, StringComparison.OrdinalIgnoreCase);

        }
        [Fact]
        public void CalculateFullName_WithTitleCase()
        {
            PlayerCharacter sut = new() { FirstName = "Fname", LastName = "Lname" };
            Assert.Matches("[A-Z]{1}[a-z]+ [A-Z]{1}[a-z]+", sut.FullName);
        }
        [Fact]
        public void CalculateFullName_WithNonTitleCaseFail()
        {
            PlayerCharacter sut = new() { FirstName = "FName", LastName = "LName" };
            Assert.DoesNotMatch("[A-Z]{1}[a-z]+ [A-Z]{1}[a-z]+", sut.FullName);
        }
        //Numeric
        [Fact]
        public void StartWithDefaultHealth()
        {
            PlayerCharacter sut = new();
            Assert.Equal(100, sut.Health);
        }
        [Fact]
        public void StartWithDefaultHealth_NotZero()
        {
            PlayerCharacter sut = new();
            Assert.NotEqual(0, sut.Health);
        }
        [Fact]
        public void IncreaseHealthAfterSleeping()
        {
            PlayerCharacter sut = new();
            sut.Sleep();
            //101-200
            //Assert.True(sut.Health >= 101 && sut.Health <= 200);
            Assert.InRange<int>(sut.Health, 101, 200);
        }
        //Null
        [Fact]
        public void NotHavedefaultNickNameByDefault()
        {
            PlayerCharacter sut = new();
            Assert.Null(sut.Nickname);
        }
        //Collection
        [Fact]
        public void HaveLongBow()
        {
            PlayerCharacter sut = new();
            Assert.Contains("Long Bow", sut.Weapons);
        }

        [Fact(Skip = "Only for verifying purpose")]
        public void HaveLongBow1()
        {
            PlayerCharacter sut = new();
            Assert.Contains("Long Bow1", sut.Weapons);
        }
        //Looking for Predicate
        [Fact]
        public void HaveAtLeastOneKindOfSword()
        {
            PlayerCharacter sut = new();
            //Weapons = new List<string>
            //{
            //    "Long Bow",
            //    "Short Bow",
            //    "Short Sword",
            //};
            Assert.Contains(sut.Weapons, weapon => weapon.Contains("Sword"));
        }

        [Fact]
        public void HaveAllExpectedweapons()
        {
            PlayerCharacter sut = new PlayerCharacter();
            var expectedWeapos = new[]
            {
                "Long Bow",// Change to Bow-x
                "Short Bow",
                "Short Sword",
            };
            Assert.Equal(expectedWeapos, sut.Weapons);
        }

        [Fact]
        public void NotHaveAStaffOfWonder()
        {
            PlayerCharacter sut = new();
            Assert.DoesNotContain("staff of wonder", sut.Weapons);
        }
        //Checking null-able and whiteSpace
        [Fact]
        public void NotHaveNoEmptyDefaultWeapons()
        {
            PlayerCharacter sut = new PlayerCharacter();
            Assert.All(sut.Weapons, weapon => Assert.False(string.IsNullOrWhiteSpace(weapon)));
        }
        //Event Test
        [Fact]
        public void RaiseSleptEvent()
        {
            PlayerCharacter sut = new();
            Assert.Raises<EventArgs>(
                handler => sut.PlayerSlept += handler,
                handler => sut.PlayerSlept -= handler,
                () => sut.Sleep());
        }
        //INotify Based event
        [Fact]
        public void RaisePropertyChanedEvent()
        {
            PlayerCharacter sut = new();
            Assert.PropertyChanged(sut, "Health", () => sut.TakeDamage(10));
        }
    }
}
