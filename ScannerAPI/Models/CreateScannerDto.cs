using System.ComponentModel.DataAnnotations;
using ScannerAPI.Entities;

namespace ScannerAPI.Models
{
	public class CreateScannerDto
	{	
		public int Id { get; set; }
		[Required]
		public string Budynek { get; set; }
		public string Skaner { get; set; }
	}
}
