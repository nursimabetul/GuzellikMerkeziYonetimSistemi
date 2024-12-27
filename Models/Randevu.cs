namespace GuzellikMerkeziYonetimSistemi.Models
{
	public class Randevu
	{
		public int Id { get; set; }
		public DateTime RandevuTarihi { get; set; }


		public int PersonelId { get; set; }
		public Personel Personel { get; set; }

		// İşlem Türü
		public int IslemId { get; set; }
		public Islem Islem    { get; set; }



		// İşlem Süresi

		// Ücret

		public int SalonId { get; set; }
		public Salon Salon { get; set; }

		// Randevu alan kullanıcı bilgileri

		public Durum durum { get; set; }
		public string Aciklama { get; set; }

	}
}
