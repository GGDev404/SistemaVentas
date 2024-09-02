using Sales_System_Api.Dtos;
using Sales_System_Api.Models;
public class TransferDTO
{
    public int SourceBranchId { get; set; }
    public int DestinationBranchId { get; set; }
    public IEnumerable<TransferProductDTO> TransferProducts { get; set; }
}
