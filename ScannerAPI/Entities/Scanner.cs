using System.Net;

namespace ScannerAPI.Entities
{
	public class Scanner
	{
		public int Id { get; set; }
		public string Budynek { get; set; }
		public string Skaner { get; set; }
		public virtual List<Employee> Employees { get; set; }
	}
}
