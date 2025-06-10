namespace HangFire.Dtos;

public class EmailDto
{
    public string For { get; set; } = null!;
    public string Subject { get; set; } = null!;
    public string Body { get; set; } = null!;
}
 
