using Microsoft.EntityFrameworkCore;

public class RoomDbService : IRoomService
{
    private readonly HotelDbContext _context;

    public RoomDbService(HotelDbContext context)
    {
        _context = context;
    }
    public Room Create(RoomDTO l)
    {
        var nuevoRoom = new Room
        {
            Titulo = l.Titulo,
            AutorId = l.AutorId,
            Paginas = l.Paginas,
            Ano = l.Ano,
            Url_Portada = l.Url_Portada,
            Temas = new List<Tema>()
        };

        foreach(int idTema in l.TemasIds)
        {
            nuevoRoom.Temas.Add(_context.Temas.Find(idTema));
        }
        _context.Add(nuevoRoom);
        _context.SaveChanges();
        return nuevoRoom;
    }

    public bool Delete(int id)
    {
        Room? l = _context.Rooms.Find(id);
        if (l is null) return false;

        _context.Rooms.Remove(l);
        _context.SaveChanges();
        return true;
    }

    public IEnumerable<Room> GetAll()
    {
        return _context.Rooms.Include(el => el.Autor).Include(l => l.Temas);
    }

    public Room? GetById(int id)
    {
        return _context.Rooms.Find(id);
    }

    public Room Update(int id, RoomDTO l)
    {
        var RoomUpdate = _context.Rooms.Include(l => l.Temas).FirstOrDefault(l => l.Id == id);
        Console.WriteLine(RoomUpdate.Id);
        RoomUpdate.Titulo = l.Titulo;
        RoomUpdate.Ano = l.Ano;
        RoomUpdate.Paginas = l.Paginas;
        RoomUpdate.AutorId = l.AutorId;
        RoomUpdate.Url_Portada = l.Url_Portada;
        RoomUpdate.Temas.Clear();

        
        foreach(int idTema in l.TemasIds)
        {
            RoomUpdate.Temas.Add(_context.Temas.Find(idTema));
        }

        _context.Entry(RoomUpdate).State = EntityState.Modified;
        _context.SaveChanges();
        return RoomUpdate;

    }
}