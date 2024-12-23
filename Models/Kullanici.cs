namespace GuzellikMerkeziYonetimSistemi.Models
{
	public class Kullanici
	{
		public int Id { get; set; }
		public string Adi { get; set; }
		public string Soyadi { get; set; }
		public string GSM { get; set; }
		public string EmailAdres { get; set; }

		public DateTime DogumTarihi { get; set; }
		public string Adres { get; set; }	
	}
}
