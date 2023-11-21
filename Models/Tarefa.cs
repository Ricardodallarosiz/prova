namespace API.Models;

public class Tarefa
{
    public int TaskId { get; set; }
    public string? Ttl { get; set; }
    public string? Dc { get; set; }
    public DateTime Create { get; set; } = DateTime.Now;
    public Categoria? Cate { get; set; }
    public int CateId { get; set; }

    public Status? Stts { get; set; }
    public int SttsId { get; set; }
}
