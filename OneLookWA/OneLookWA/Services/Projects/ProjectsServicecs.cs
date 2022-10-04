using OneLookWA.Models;
using System.Net.Http.Json;

namespace OneLookWA.Services.Projects
{
    public class ProjectsServicecs : IProjectsService
    {
        string test = string.Empty;
        List<Project> projects = new List<Project>();

        HttpClient _httpClient;
        public ProjectsServicecs(HttpClient httpclient)
        {
            _httpClient = httpclient;
        }
        public async Task<List<Project>> GetProjects(int id)
        {
            var result = await _httpClient.GetFromJsonAsync<List<Project>>($"https://localhost:7193/api/Projects/{id}");

            projects = result;

            if(projects == null)
            {
                test = "el valor es null";
                return new List<Project>();
            }
            else
            {
                return projects;
            }            
        }
    }
}
