using api.dal;
using api.models.dbEntities;
using Microsoft.EntityFrameworkCore;
namespace api.repositories;


class ProjectRepository : IProjectRepository
{
    private readonly RailwayContext _context;
    public ProjectRepository()
    {
        _context = new RailwayContext();
    }

    public Task<bool> CreateProjectAsync(Project project)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteProjectAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Project>> GetOverdueProjectsByUserIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }
    // I gotta do a join :<
    public async Task<IEnumerable<Project>> GetProjectsByUserIdAsync(Guid id)
    {
        var _values = from project in _context.Projects.Where(project => project.UserId == id)
                      from todos in _context.Todos.Where(todos => project.ProjectId == todos.ProjectId)
                      from notes in _context.Notes.Where(note => project.ProjectId == note.ProjectId)
                      from repositories in _context.Repositories.Where(repositories => project.ProjectId == repositories.ProjectId)
                      select project;
        return _values;
        // I gotta do joins and I dont know how tooooo
    }

    public Task<bool> UpdateProjectAsync(Project project)
    {
        throw new NotImplementedException();
    }
}