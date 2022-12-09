using Microsoft.AspNetCore.Mvc;
using ScannerAPI.Entities;
using ScannerAPI.Models;
using AutoMapper;
using ScannerAPI.Services;


namespace ScannerAPI.Controllers
{
	[Route("api/scanner")]
	public class ScannerController : ControllerBase
	{
		private readonly IScannerService _scannerService;
		public ScannerController(IScannerService scannerService)
		{
			_scannerService = scannerService;
		}
		[HttpPost]
		// wysłanie danych przez klijenta 
		public ActionResult CreateScanner([FromBody]CreateScannerDto dto)
		{
			//sprawdzenie właściwości 
			/*if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}*/

			var id = _scannerService.Create(dto);
			return Created("/api/scanner/{id}", null);
		}
		/*public ActionResult CreateEmployee([FromBody]AddEmployeeDto dto)
		{
			/*if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}


			var id = _scannerService.Create(dto);

			return Created("/api/scanner/{id}", null);
		}
	    */
		[HttpGet]
		public ActionResult<IEnumerable<ScannerDto>> GetAll()
		{
			var scannerDto = _scannerService.GetAll();
			return Ok(scannerDto);
		}
		[HttpGet("{id}")]
		public ActionResult<ScannerDto> Get([FromRoute] int id)
		{
			var scanner = _scannerService.GetById(id);

			if (scanner is null)
			{
				return NotFound();
			}
			return Ok(scanner);
		}

	}

}
