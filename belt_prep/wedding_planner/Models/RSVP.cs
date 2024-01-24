#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Components.RenderTree;
using Microsoft.Extensions.Configuration.UserSecrets;
namespace wedding_planner.Models;
public class RSVP
{
    [Key]
    public int RSVPID { get; set; }
    
    // Foreign keys.
    public int UserId { get; set; }
    public int WeddingId { get; set; }

    // Nav Props
    public User? Responder { get; set; }
    public Wedding? WeddingRespondedTo {get; set; }

    public DateTime CreatedAt {get;set;} = DateTime.Now;
    public DateTime UpdatedAt {get;set;} = DateTime.Now;

}