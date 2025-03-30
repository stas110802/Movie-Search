using System.Reflection;
using NetArchTest.Rules;

namespace MovieSearch.Architecture.Test;

public class ArchitectureTests
{
    private const string ApplicationNamespace = "MovieSearch.Application";
    private const string InfrastructureNamespace = "MovieSearch.Infrastructure";
    private const string PersistenceNamespace = "MovieSearch.Persistence";
    private const string WebApiNamespace = "MovieSearch.WebApi";
    
    [Test]
    public void DomainShouldNotHaveDependencyOnOtherProjects()
    {
        var assembly = Assembly.GetAssembly(typeof(Domain.IRestMovieClient));

        var otherProjects = new[]
        {
            ApplicationNamespace,
            InfrastructureNamespace,
            PersistenceNamespace,
            WebApiNamespace
        };

        var testResult = Types.InAssembly(assembly)
            .ShouldNot()
            .HaveDependencyOnAny(otherProjects)
            .GetResult();

        Assert.IsTrue(testResult.IsSuccessful);
    }

    [Test]
    public void ApplicationShouldNotHaveDependencyOnOtherProjects()
    {
        var assembly = Assembly.GetAssembly(typeof(Application.Profiles.ActorProfile));

        var otherProjects = new[]
        {
            InfrastructureNamespace,
            PersistenceNamespace,
            WebApiNamespace
        };

        var testResult = Types
            .InAssembly(assembly)
            .ShouldNot()
            .HaveDependencyOnAny(otherProjects)
            .GetResult();

        Assert.IsTrue(testResult.IsSuccessful);
    }
    
    [Test]
    public void InfrastructureShouldNotHaveDependencyOnOtherProjects()
    {
        var assembly = Assembly.GetAssembly(typeof(Infrastructure.Common.BaseEndpoint));

        var otherProjects = new[]
        {
            WebApiNamespace
        };

        var testResult = Types
            .InAssembly(assembly)
            .ShouldNot()
            .HaveDependencyOnAny(otherProjects)
            .GetResult();

        Assert.IsTrue(testResult.IsSuccessful);
    }
    
    [Test]
    public void PersistenceShouldNotHaveDependencyOnOtherProjects()
    {
        var assembly = Assembly.GetAssembly(typeof(Persistence.Repositories.MovieRepository));

        var otherProjects = new[]
        {
            WebApiNamespace
        };

        var testResult = Types
            .InAssembly(assembly)
            .ShouldNot()
            .HaveDependencyOnAny(otherProjects)
            .GetResult();

        Assert.IsTrue(testResult.IsSuccessful);
    }
}