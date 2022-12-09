using Swashbuckle.AspNetCore.SwaggerGen;

namespace ScannerAPI.Entities
{
	public class History
	{
		public int Id { get; set; }
		public DateTime Data { get; set; }
		public virtual List<Scanner> Scanners { get; set; }
	}
}
