namespace Xarajat_API.Models;

public class CalculateRoomOutlays
{
    public int UsersCount { get; set; }
    public int TotalCost { get; set; }
    public int CostPerUser => TotalCost / UsersCount;
}