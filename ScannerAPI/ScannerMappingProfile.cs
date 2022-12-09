using ScannerAPI.Entities;
using ScannerAPI.Models;
using AutoMapper;

namespace ScannerAPI
{
	public class ScannerMappingProfile : Profile
	{
		public ScannerMappingProfile()
		{
			CreateMap<Scanner, ScannerDto>()
			.ReverseMap(); //w obie strony

		    CreateMap<Employee, EmployeeDto>();
			CreateMap<History, HistoryDto>();



			CreateMap<CreateScannerDto, Scanner>();

		}

	}
}
