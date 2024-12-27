namespace GuzellikMerkeziYonetimSistemi.Models
{
	public class Personel
	{
		public int Id { get; set; }
		public string Adi { get; set; }
		public string Soyadi { get; set; }
		public string GSM { get; set; }
		public string EmailAdres { get; set; }

		public int? UzmanlikId { get; set; }
		public Uzmanlik Uzmanlik { get; set; }

		public int SalonId { get; set; }
		public Salon Salon { get; set; }

		public DateTime DogumTarihi { get; set; }
		public string Adres { get; set; }


	}
}
