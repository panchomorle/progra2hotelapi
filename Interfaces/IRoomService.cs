using System.Collections.Generic;

public interface IRoomService
{
    Room Create(RoomDTO roomDto);
    bool Delete(int id);
    IEnumerable<Room> GetAll();
    Room? GetById(int id);
    Room Update(int id, RoomDTO roomDto);
}