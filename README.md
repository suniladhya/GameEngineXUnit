# GameEngineXUnit
Testing illustration C#

Traits: categorizing th unit tst cases
for categorising the test cases to a particular functionality, [Trait("Category", "Enemy")] can be used.
they can be used at the class level or in the funtion level.

Tests can be executed from the test explorer and command line
### Command line Execution
dotnet Test
dotnet Test --filter "category=Enemy"

dotnet Test --filter "category=Enemy|Category=Boss"

### Skip a Test
[Fact(Skip="Reason")]

*It is advisable to delete the out dated test*

### Custom Test Output
```C#
using Xunit.Abstractions;
```
```C#
private readonly ITestOutputHelper _output;
        public EnemyFactoryShould(ITestOutputHelper output)
        {
            _output = output;
        }
```

dotnet Test --filter "category=Enemy|Category=Boss" --logger:trx
https://github.com/Microsoft/vstest-docs/blob/master/docs/report.md

### Sharing the context

