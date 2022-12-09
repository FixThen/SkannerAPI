using ScannerAPI.Entities;

namespace ScannerAPI.Models
{
	public class ScannerDto
	{
		public int Id { get; set; }
		public string Budynek { get; set; }
		public string Skaner { get; set; }
		public virtual List<Employee> Employees { get; set; }
	}
}
