namespace TNSBackend.Models;
using System.Text.Json.Serialization;

public class User
{
    public int Id { get; set; }
    public string FullName { get; set; } = string.Empty;
    public int DepartmentId { get; set; }
    public string DepartmentName { get; set; } = string.Empty;

    [JsonIgnore] // Detect JSON Cycle
    public Department? Department { get; set; }
}