namespace API.Entities
{
    public class User
    {
        public int userId { get; set; }
        public string userName { get; set; }
      
        public byte[] hash{get;set;}
        public byte[] salt { get; set; }

        //public string password { get; set; }

        
    }
}