namespace BlazorWithSsr.Components.Public.Projects;

public class ProjectSummaryDto
{
    public long ProjectId { get; set; }
    public string ProjectName { get; set; }
    public string ProjectDescription { get; set; }
    public string ProjectStatus { get; set; }
}

public class CreateProjectDto
{
    public string ProjectName { get; set; }
    public string ProjectDescription { get; set; }
}
public interface IProjectService
{
    Task<List<ProjectSummaryDto>> GetProjectSummaries();
    void MarkDone(int id);
    void MarkActive(int id);
}

public class ProjectService: IProjectService
{
    private List<ProjectSummaryDto> _projectSummaries = new List<ProjectSummaryDto>
    {
        new ProjectSummaryDto
        {
            ProjectId = 1,
            ProjectName = "Project 1",
            ProjectDescription = "Project 1 Description",
            ProjectStatus = "Active"
        },
        new ProjectSummaryDto
        {
            ProjectId = 2,
            ProjectName = "Project 2",
            ProjectDescription = "Project 2 Description",
            ProjectStatus = "Active"
        },
    };
    
    public async Task<List<ProjectSummaryDto>> GetProjectSummaries()
    {
        return await Task.FromResult(_projectSummaries);
    }

    public void MarkDone(int id)
    {
        var project = _projectSummaries.FirstOrDefault(x => x.ProjectId == id);
        if (project != null)
        {
            project.ProjectStatus = "Done";
        }
    }

    public void MarkActive(int id)
    {
        var project = _projectSummaries.FirstOrDefault(x => x.ProjectId == id);
        if (project != null)
        {
            project.ProjectStatus = "Active";
        }
    }

    public Task CreateProject(CreateProjectDto createProjectDto)
    {
        // Create project
        _projectSummaries.Add(new ProjectSummaryDto
        {
            ProjectId = _projectSummaries.Max(x => x.ProjectId) + 1,
            ProjectName = createProjectDto.ProjectName,
            ProjectDescription = createProjectDto.ProjectDescription,
            ProjectStatus = "Active"
        });
        
        return Task.CompletedTask;
    }
}