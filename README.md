# yahtzee - New headline

TDD project for our course [2dv610](https://coursepress.lnu.se/kurs/mjukvarutestning/labs/assignment-2-xunit-testing/) at [Linnæus university](https://coursepress.lnu.se/kurs/mjukvarutestning/)

## The assignment

The assignment is to create a project using TDD in a OO way. We chose to make Yahtzee using C#.

### Language of implementation

C#

### Framework for unit-testing

[xUnit](https://xunit.github.io/)

### Framework for Mocking
[Moq](https://github.com/moq/moq4)

### Code coverage tool
[Coverlet](https://github.com/tonerdo/coverlet/?WT.mc_id=-blog-scottha)

## Scripts
### The application
Within the `Yahtzee` folder run `dotnet run`.

### Tests
Within the `YahtzeeTests` folder run `dotnet test`

### Code coverage
Within the `YahtzeeTests` folder run either command.
#### All files
`dotnet test /p:CollectCoverage=true`
#### All files except Main(Program.cs)
`dotnet test /p:CollectCoverage=true /p:ExcludeByFile="../Yahtzee/Program.cs"`


## Current coverage
#### Number of tests
![number-of-tests](https://github.com/AntonStrand/yahtzee/blob/master/coverage-screenshots/num-of-tests.png)

#### Coverage with main included
![coverage-w-main](https://github.com/AntonStrand/yahtzee/blob/master/coverage-screenshots/coverage-w-main.png)

#### Coverage with main excluded
![coverage-wo-main](https://github.com/AntonStrand/yahtzee/blob/master/coverage-screenshots/coverage-wo-main.png)
