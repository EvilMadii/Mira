using api.models.dbEntities;
namespace api.services;
interface IProjectService
{
    public Task<IEnumerable<Project>> GetAllUserProjectsAsync();
    public Task<IEnumerable<Project>> GetProjectsByStatus();
    public Task<Project> GetProjectByIdAsync();
    public Task<bool> DeleteProjectAsync(Project project);
    public Task<bool> UpdateProjectAsync(Project project);
    public Task<bool> CreateProjectAsync(Project project);

}