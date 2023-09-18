namespace PokemonReviewApp.Dto
{
    public class PokemonDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }

        /*Dto - Api isteği atıldığında model'e yazdığımız her şeyi dönmek yerine
        sadece istediğimiz belli bi kısmın dönmesini sağlar
        aynı şekilde apiye gelecek veriler de sınırlandırılabilir dto ile*/
    }
}
