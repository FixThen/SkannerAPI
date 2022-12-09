using ScannerAPI.Entities;

namespace ScannerAPI.Models
{
	public class HistoryDto
	{
		public int Id { get; set; }
		public DateTime Data { get; set; }
		public virtual List<Scanner> Scanners { get; set; }
	}
}
