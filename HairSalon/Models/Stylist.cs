using System.Collections.Generic;

namespace HairSalon.Models
{
  public class Stylist
  {
    public Stylist()
    {
      this.Clients = new HashSet<Client>();
      this.Appointments = new HashSet<Appointment>();
    }

    public int StylistId { get; set; }
    public string Name { get; set; }
    public string Specialty { get; set; }
    public virtual ICollection<Client> Clients { get; set; }
    public virtual ICollection<Appointment> Appointments { get; set; }
  }
}