using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Microsoft.Extensions.Configuration;
using PizzaBox.Storing;

namespace PizzaBox.Client.Models
{
  public class OrderViewModel
  {
    public List<string> Stores { get; set; }
    public List<string> Users { get; set; }

    [Required]
    public string Store { get; set; }

    [Required]
    public string User { get; set; }
  }
}