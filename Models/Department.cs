namespace TNSBackend.Models;
using System.Text.Json.Serialization;

public class Department
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;

    [JsonIgnore] // Detect JSON Cycle
    public List<User> Users { get; set; } = new();
}