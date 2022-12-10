using ScannerAPI.Entities;
using System.ComponentModel.DataAnnotations;
namespace ScannerAPI.Models;

public class UpdateScannerDto
{
    [Required]
    public string Budynek { get; set; }
    public string Skaner { get; set; }
}