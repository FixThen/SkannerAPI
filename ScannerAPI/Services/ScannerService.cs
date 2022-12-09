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
		}

		public class ScannerService : IScannerService
		{
			private readonly ScannerDbContext _dbContext;
			private readonly IMapper _mapper;
			//referencja 
			public ScannerService(ScannerDbContext dbContext,IMapper mapper)
			{
				_dbContext = dbContext;
				_mapper = mapper;
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
