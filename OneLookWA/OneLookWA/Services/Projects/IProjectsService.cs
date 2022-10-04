using OneLookWA.Models;

namespace OneLookWA.Services.Projects
{
    public interface IProjectsService
    {
        public Task<List<Project>> GetProjects(int id);
    }
}
