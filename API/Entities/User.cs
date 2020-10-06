namespace API.Entities
{
    // Entity Framework features : querying, saving, transactions, migrations etc.
    // Entitas/model amit minden egyes adatbazissal kapcsolatos muvelet kereten belul hasznalhatunk ami a felhasznalo reszet erinti 
    public class User
    {
        // jovo heten ha implementalasra kerul sor, inkabb nevezzed Id-nak
        public int userId { get; set; }

        // jovo heten ha implementalasra kerul sor, inkabb nevezzed UserName-nek
        public string userName { get; set; }

        // jovo heten ha implementalasra kerul sor, inkabb nevezzed PasswordHash-nek
        public byte[] hash { get; set;}

        // jovo heten ha implementalasra kerul sor, inkabb nevezzed PasswordSalt-nak
        public byte[] salt { get; set; }       
    }
}