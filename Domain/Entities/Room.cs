namespace Chilite.Domain.Entities;

public class Room
{
    public string RoomId { get; set; }

    public virtual List<Interview> Interviews { get; set; }
}
