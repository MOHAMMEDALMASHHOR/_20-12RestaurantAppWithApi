using System.Text.Json;

namespace Entities;
public class ErrorDetails
{
    public int SatusCode { get; set; }
    public string? Message { get; set; }
    public override string ToString()
    {
        return JsonSerializer.Serialize(this);
    }
}