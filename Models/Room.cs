public class Room
{
    public int Id { get; set; }
    public string Number { get; set; }  // Número de habitación
    public string Type { get; set; }  // Tipo (Sencilla, Doble, Suite)
    public decimal PricePerNight { get; set; }  // Precio por noche
    public bool IsAvailable { get; set; } = true;  // Estado de disponibilidad
}
