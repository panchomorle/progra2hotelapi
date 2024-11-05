public class Reservation
{
    public int Id { get; set; }                      // Identificador único de la reserva
    public int RoomId { get; set; }                  // Id de la habitación reservada
    public Room Room { get; set; }                   // Relación con el modelo Room
    public string UserId { get; set; }               // Id del usuario que realizó la reserva
    public ApplicationUser User { get; set; }        // Relación con el modelo ApplicationUser

    public DateTime StartDate { get; set; }          // Fecha de inicio de la reserva
    public DateTime EndDate { get; set; }            // Fecha de fin de la reserva
}