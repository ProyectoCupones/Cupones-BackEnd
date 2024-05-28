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
  public class companiesCreateController : ControllerBase
    {
        public readonly IEmpresasService _empresasService;

        public companiesCreateController(IEmpresasService empresasService)
        {
            _empresasService = empresasService;
          }
[HttpPost]
        [Route("api/empresas")]
        public IActionResult Create([FromBody] Empresa empresa)
        {
            _empresasService.add(empresa);
            return Ok();
        }
    
    }
}