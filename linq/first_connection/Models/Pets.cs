#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace first_connection.Models;

public class Pet
{
    [Key]
    public int PetId {get;set;}
    public string Name {get;set;}
    public string Type {get;set;}
    public int Age {get;set;}
    public bool hasFur {get;set;}
    public DateTime CreatedAt {get;set;}
    public DateTime UpdatedAt {get;set;}
}