using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PartitionLabels.WebAPI.Models; 

public class RequestModel {
    [Required]
    [DisplayName("input")]
    public string Input { get; set; }
}