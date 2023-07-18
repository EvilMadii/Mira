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
    public Task<IEnumerable<Project>> GetProjectsByUserIdAsync(Guid id)
    {
        // I gotta do joins and I dont know how tooooo
    }

    public Task<bool> UpdateProjectAsync(Project project)
    {
        throw new NotImplementedException();
    }
}