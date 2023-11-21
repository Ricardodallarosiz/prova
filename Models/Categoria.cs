namespace API.Models;

public class Categoria
{
    public int CateId { get; set; }
    public string? Name { get; set; }
    public DateTime Create { get; set; } = DateTime.Now;
}
