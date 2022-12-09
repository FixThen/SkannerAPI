using ScannerAPI.Entities;
using System.Net;
using Microsoft.IdentityModel.Tokens;
using System.IO;


namespace ScannerAPI
{
	public class ScannerSeeder
	{
		private readonly ScannerDbContext _dbContext;

		public ScannerSeeder(ScannerDbContext dbContext)
		{
			_dbContext = dbContext;

		}
		public void Seed()
		{
			if (_dbContext.Database.CanConnect())
			{
				if (!_dbContext.Scanners.Any())
				{
					var scanners = GetScanners();
					_dbContext.Scanners.AddRange(scanners);
					_dbContext.SaveChanges();
				}
			}
		}
		private IEnumerable<Scanner> GetScanners()
		{
			var scanners = new List<Scanner>()
			{
					new Scanner()
					{
						Budynek="Lakiernia",
						Skaner= "2",
						Employees= new List<Employee>()
						{
							new Employee ()
							{
								Karta= "1234",
								Imie=  "Jan",
								Nazwisko= "Kowal",
								ContactNumber ="123432",

							},
							new Employee()
							{
								Karta= "5555",
								Imie=  "Sebastian",
								Nazwisko= "Walczak",
								ContactNumber ="432423",
							}
						}
					}
			};
				
			return scanners;
		}


	}
}
