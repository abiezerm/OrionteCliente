using DataLayer.DBModels;
using DataLayer.DBModels.Core;
using System.ComponentModel.DataAnnotations.Schema;

[Table("Cli_Client_Address")]
public class ClientAddress : CoreModel
{
    public Client Client { get; set; } = null!;
    public int ClientId { get; set; }
    public string Address { get; set; } = null!;
    public string AddressComplemnt { get; set; } = null!;
    public string PostalCode { get; set; } = null!;
    public string City { get; set; } = null!;
    public string State { get; set; } = null!;

}