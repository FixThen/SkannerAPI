using ScannerAPI.Entities;

namespace ScannerAPI.Models
{
	public class CreateScannerDto
	{	
		public int Id { get; set; }
		public string ?Budynek { get; set; }
		public string ?Skaner { get; set; }
	}
}
