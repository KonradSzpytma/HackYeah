using FluentAssertions;
using HackYeah.Domain.ExampleFeature;
using JetBrains.Annotations;

namespace HackHeah.UnitTest.Domain.ExampleFeature;

[TestSubject(typeof(ExampleAggregate))]
public class ExampleAggregateTest
{

    [Fact]
    public void AddUser_ShouldAddUser()
    {
        var sut = new ExampleAggregate("HackYeah");
        
        sut.AddName("Hello");
        
        sut.GetNames().Should().Contain("Hello");
    }
}