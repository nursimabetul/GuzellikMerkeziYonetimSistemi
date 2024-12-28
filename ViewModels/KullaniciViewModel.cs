using System.ComponentModel.DataAnnotations;

namespace GuzellikMerkeziYonetimSistemi.ViewModels
{
	public class KullaniciViewModel
	{
		public int Id { get; set; }
		public string Ad { get; set; }
		public string Soyad { get; set; }
		public string Email { get; set; }
		public string KullaniciAdi { get; set; }
		[Required]
		[StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
		[DataType(DataType.Password)]
		[Display(Name = "Password")]		



		public string Password { get; set; }
		public string Telefon { get; set; }
		public string Adres { get; set; }
		public string Cinsiyet { get; set; }
		public string DogumTarihi { get; set; }
		public string Rol { get; set; }
		public string Durum { get; set; }
		public string OlusturulmaTarihi { get; set; }
		public string GuncellemeTarihi { get; set; }
		public string SilinmeTarihi { get; set; }
		public string SilinmeDurumu { get; set; }



	}
}
