﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProductAppMvc.Data;
using ProductAppMvc.Models;


namespace ProductAppMvc.Controllers
{
    public class ProductController : Controller
    {
        private readonly ProductAppMvcContext _context;

        public ProductController(ProductAppMvcContext context)
        {
            _context = context;
        }

        // Vista para ingresar el producto
        public IActionResult Create()
        {
            return View();
        }

        // Método para guardar el producto en la base de datos
        [HttpPost]
        [Route("api/product")]
        public async Task<IActionResult> CreateProduct([FromBody] Product product)
        {
            if (ModelState.IsValid)
            {
                // Guardar el producto en la base de datos
                _context.Products.Add(product);
                await _context.SaveChangesAsync();
                return Ok("Producto guardado exitosamente");
            }
            return BadRequest("Error al guardar el producto.");
        }



        // Vista para mostrar los productos guardados
        public async Task<IActionResult> Index()
        {
            return View(await _context.Products.ToListAsync());
        }
    }
}

