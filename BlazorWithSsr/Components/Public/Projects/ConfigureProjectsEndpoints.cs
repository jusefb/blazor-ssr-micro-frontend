using Microsoft.AspNetCore.Http.HttpResults;

namespace BlazorWithSsr.Components.Public.Projects;

public static class ConfigureProjectsComponents
{
    // Method to configure the endpoints for the projects API using minimal APIs
    public static void ConfigureProjectsEndpoints(this WebApplication app)
    {
        app.MapGet("/api/projects", () => new RazorComponentResult(typeof(ProjectSummaryTable)));

        app.MapPost("/api/projects/mark-done/{id}", (int id, IProjectService projectService) =>
        {
            projectService.MarkDone(id);
            return new RazorComponentResult(typeof(ProjectSummaryTable));
        });
        
        app.MapPost("/api/projects/mark-active/{id}", (int id, IProjectService projectService) =>
        {
            projectService.MarkActive(id);
            return new RazorComponentResult(typeof(ProjectSummaryTable));
        });
    }
}