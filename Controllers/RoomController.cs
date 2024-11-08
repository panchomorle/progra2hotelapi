using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;           // Para el uso de [Authorize]
using Microsoft.AspNetCore.Mvc;                     // Para el uso de controladores y atributos de ruta
using Microsoft.EntityFrameworkCore;                // Para el uso de Entity Framework Core
             






[Authorize]
[ApiController]
[Route("api/[controller]")]
public class RoomController : ControllerBase
{
    private readonly HotelDbContext _context;

    public RoomController(HotelDbContext context)
    {
        _context = context;
    }

    // GET: api/rooms - Ver habitaciones disponibles (abierto a todos los usuarios)
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Room>>> GetRooms()
    {
        return await _context.Rooms.ToListAsync();
    }

    // POST: api/rooms - Añadir una habitación (solo administradores)
    [Authorize(Roles = "Admin")]
    [HttpPost]
    public async Task<IActionResult> AddRoom(Room room)
    {
        _context.Rooms.Add(room);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetRooms), new { id = room.Id }, room);
    }

    // PUT: api/rooms/{id} - Editar una habitación (solo administradores)
    [Authorize(Roles = "Admin")]
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateRoom(int id, Room room)
    {
        if (id != room.Id)
            return BadRequest();

        _context.Entry(room).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return NoContent();
    }

    // DELETE: api/rooms/{id} - Eliminar una habitación (solo administradores)
    [Authorize(Roles = "Admin")]
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteRoom(int id)
    {
        var room = await _context.Rooms.FindAsync(id);
        if (room == null)
            return NotFound();

        _context.Rooms.Remove(room);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}
