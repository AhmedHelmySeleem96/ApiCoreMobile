namespace ApiCoreMobile.Data
{
    public class Category
    {
        public int Id{ get; set; }
        public string Name{ get; set; }
       public IList<Mobiles> mobile { get; set; }
    }
}
