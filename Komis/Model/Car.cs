namespace Komis.Model
{
	public class Car
	{
		public int Id { get; set; }
		public string Mark { get; set; }
		public string Model { get; set; }
		public int ProductionYear { get; set; }
		public string Mileage { get; set; }
		public string TankSize { get; set; }
		public string FuelType { get; set; }
		public string Power { get; set; }
		public string Description { get; set; }
		public decimal Price { get; set; }
		public string PhotoURL { get; set; }
		public string ThumbnailURL { get; set; }
		public bool IsCarOfTheWeek { get; set; }

	}
}
