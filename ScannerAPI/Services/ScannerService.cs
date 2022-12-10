using ScannerAPI.Entities;
using ScannerAPI.Models;
using ScannerAPI;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace ScannerAPI.Services
{
	
		public interface IScannerService
		{
			int Create(CreateScannerDto dto);
			IEnumerable<ScannerDto> GetAll();
			ScannerDto GetById(int id);
			bool Delete(int id);
			bool Update(int it, UpdateScannerDto dto);
		}

		public class ScannerService : IScannerService
		{
			private readonly ScannerDbContext _dbContext;
			private readonly IMapper _mapper;
			private readonly ILogger<ScannerService> _logger;

			//referencja 
			public ScannerService(ScannerDbContext dbContext,IMapper mapper, ILogger<ScannerService> logger)
			{
				// baza danych
				_dbContext = dbContext;
				// mappowanie/przenoszenie do bazy
				_mapper = mapper;
				//zapisywanie loginów/błędów
				_logger = logger;
			}
			public bool Update(int id, UpdateScannerDto dto)
			{
				var scanner = _dbContext
					.Scanners
					.FirstOrDefault(r => r.Id == id);
				if (scanner is null) return false;
				scanner.Budynek = dto.Budynek;
				scanner.Skaner = dto.Skaner;
				_dbContext.SaveChanges();
				return true;
			}
			
			public bool Delete(int id)
			{
				_logger.LogError($"Scanner with id: {id} DELETE action invoked");
				var scanner = _dbContext
					.Scanners
					.FirstOrDefault(r => r.Id == id);
				if (scanner is null) return false;
				_dbContext.Scanners.Remove(scanner);
				_dbContext.SaveChanges();
				return true;
			}

			public ScannerDto GetById(int id)
			{
				var scanner = _dbContext
					.Scanners
					//.Include(s => s.Osoby)
					.FirstOrDefault(r => r.Id == id);
				if (scanner is null) return null;
				var result = _mapper.Map<ScannerDto>(scanner);
				return result;
			}
			public IEnumerable<ScannerDto> GetAll()
			{
				var scanners = _dbContext
					.Scanners
					.Include(s => s.Employees)
					.ToList();

				var scannersDtos = _mapper.Map<List<ScannerDto>>(scanners);

				return scannersDtos;
			}
		public int Create(CreateScannerDto dto)
		{
			var scanner = _mapper.Map<Scanner>(dto);
			_dbContext.Scanners.Add(scanner);
			_dbContext.SaveChanges();
			return scanner.Id;
		}

		/*public int Create(AddEmployeeDto dto)
			{
				var employee = _mapper.Map<Employee>(dto);
				_dbContext.Employees.Add(employee);
				_dbContext.SaveChanges();
				return employee.Id;
			}*/
	}
	
}
