namespace GuzellikMerkeziYonetimSistemi.Models
{
	public class Islem
	{
		public int Id { get; set; }
		public string IslemAdi { get; set; } = "";
		public int IslemKategoriId { get; set; }
		public  IslemKategori IslemKategori { get; set; }

		public int Sure { get; set; } 
		public decimal Fiyat { get; set; }
		public string Aciklama { get; set; } = "";



	}
}
