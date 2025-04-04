﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BrinquedoAPIv2.Data;
using BrinquedoAPIv2.Models;

namespace BrinquedoAPIv2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrinquedoesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public BrinquedoesController(AppDbContext context)
        {
            _context = context;
        }

    
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Brinquedo>>> GetBrinquedos()
        {
            return await _context.Brinquedos.ToListAsync();
        }

    
        [HttpGet("{id}")]
        public async Task<ActionResult<Brinquedo>> GetBrinquedo(int id)
        {
            var brinquedo = await _context.Brinquedos.FindAsync(id);

            if (brinquedo == null)
            {
                return NotFound();
            }

            return brinquedo;
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> PutBrinquedo(int id, Brinquedo brinquedo)
        {
            if (id != brinquedo.Id)
            {
                return BadRequest();
            }

            _context.Entry(brinquedo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BrinquedoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

    
        [HttpPost]
        public async Task<ActionResult<Brinquedo>> PostBrinquedo(Brinquedo brinquedo)
        {
            _context.Brinquedos.Add(brinquedo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBrinquedo", new { id = brinquedo.Id }, brinquedo);
        }

     
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBrinquedo(int id)
        {
            var brinquedo = await _context.Brinquedos.FindAsync(id);
            if (brinquedo == null)
            {
                return NotFound();
            }

            _context.Brinquedos.Remove(brinquedo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BrinquedoExists(int id)
        {
            return _context.Brinquedos.Any(e => e.Id == id);
        }
    }
}
