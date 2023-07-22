using api.models.dbEntities;

namespace api.repositories;


interface IProjectRepository
{
    public Task<bool> CreateProjectAsync(Project project);
    public Task<bool> UpdateProjectAsync(Project project);
    public Task<bool> DeleteProjectAsync(Guid id);
    // how tf do I do a join? I am keen on writing and using an sql query
    public Task<IEnumerable<Project>> GetProjectsByUserIdAsync(Guid id);
    // I have to do a lot of cheeky shit to make these two methods work
    public Task<IEnumerable<Project>> GetOverdueProjectsByUserIdAsync(Guid id);
}