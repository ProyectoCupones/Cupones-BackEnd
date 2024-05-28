using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Cupones.Models;
using Cupones.Services;

namespace Cupones.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CompaniesSearchController : ControllerBase
    {
        public readonly ICompaniesService _companiesService;

        public CompaniesSearchController(ICompaniesService companiesService)
        {
            _companiesService = companiesService;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Empresa>> Search(string consulta)
        {
            try
            {
                // Verifica si la consulta recibida es nula o vacía
                if (string.IsNullOrEmpty(consulta))
                {
                    // Devuelve un BadRequest si la consulta es nula o vacía
                    return BadRequest("Consulta is null or empty");
                }

                // Realiza la búsqueda de cupones utilizando la consulta
                var result = _companiesService.Search(consulta);

                // Devuelve un resultado Ok con el resultado de la búsqueda
                return Ok(result);
            }
            catch (Exception ex)
            {
                // Devuelve un estado de error interno del servidor (500) con un mensaje descriptivo
                return StatusCode(500, $"Error searching coupons: {ex.Message}");
            }
        }

        public IEnumerable<Empresa> SearchCompany(string consulta)
        {
            return _companiesService.Search(consulta);
        }
    }
}
