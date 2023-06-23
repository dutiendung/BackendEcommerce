public partial class Notification
{
    public long Id { get; set; }
    public string Type { get; set; } = null!;
    public string NotifiableType { get; set; } = null!;
    public long NotifiableId { get; set; }
    public string Data { get; set; } = null!;
    public DateTime? ReadAt { get; set; }
    public DateTime? CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}
