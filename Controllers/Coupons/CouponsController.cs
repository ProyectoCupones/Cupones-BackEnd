using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Cupones.Models;
using Cupones.Services;

namespace Cupones.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CouponsController : ControllerBase
    {
        private readonly ICouponsService _couponsService;


        public CouponsController(ICouponsService couponsService)
        {
            _couponsService = couponsService;
        }


        [HttpGet]
        public ActionResult<IEnumerable<Cupon>> GetCoupons()
        {
            try
            {
                var cupones = _couponsService.GetAll(); // Obtiene todos los cupones del servicio
                return Ok(cupones); // Devuelve un resultado Ok con los cupones recuperados
            }
            catch (Exception ex)
            {
                // Captura cualquier excepción y devuelve un estado de error interno del servidor (código 500) con un mensaje descriptivo
                return StatusCode(500, $"Error al recuperar los cupones: {ex.Message}");
            }
        }
        // Método de acción HTTP GET que devuelve un cupón específico según su ID
        [HttpGet("{id}")]
        public IActionResult GetCoupon(int id)
        {
            try
            {
                var cupon = _couponsService.GetById(id); // Obtiene el cupón con el ID especificado del servicio
                if (cupon == null)
                {
                    // Si el cupón no existe, devuelve un NotFound con un mensaje indicando que no se encontró el cupón
                    return NotFound($"Cupon with id {id} not found");
                }
                return Ok(cupon); // Devuelve un resultado Ok con el cupón recuperado
            }
            catch (Exception ex)
            {
                // Captura cualquier excepción y devuelve un estado de error interno del servidor (código 500) con un mensaje descriptivo
                return StatusCode(500, $"Error retrieving cupon with id {id}: {ex.Message}");
            }
        }
    }
}
