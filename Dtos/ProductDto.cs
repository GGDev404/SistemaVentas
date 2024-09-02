public class ProductDTO
{
    public int ProductId { get; set; }
    public bool IsJewel { get; set; }
    public int SubFamilyId { get; set; }
    public DateTime CreationDate { get; set; }
    public required string Name { get; set; }
    public required string Description { get; set; }
    public required string Status { get; set; }
    public bool IsActive { get; set; }
    public decimal Price { get; set; } 
    public string? ImageUrl { get; set; }// Añadido para el precio
}

    public class ProductCreateDTO
{
    public bool IsJewel { get; set; }
    public int SubFamilyId { get; set; }
    public DateTime CreationDate { get; set; }
    public required string Name { get; set; }
    public required string Description { get; set; }
    public required string Status { get; set; }
    public bool IsActive { get; set; }
    public string? ImageUrl { get; set; }
    public required InventoryDTO Inventory { get; set; }  // Datos del inventario
}
