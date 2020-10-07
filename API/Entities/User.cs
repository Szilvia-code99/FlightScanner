using System;

namespace API.Entities
{
    // Entity Framework features : querying, saving, transactions, migrations etc.
    // Entitas/model amit minden egyes adatbazissal kapcsolatos muvelet kereten belul hasznalhatunk ami a felhasznalo reszet erinti 
    public class User
    {
        // jovo heten ha implementalasra kerul sor, inkabb nevezzed Id-nak
        public int Id { get; set; }

        // jovo heten ha implementalasra kerul sor, inkabb nevezzed UserName-nek
        public string UserName { get; set; }

        // jovo heten ha implementalasra kerul sor, inkabb nevezzed PasswordHash-nek
        public byte[] PasswordHash { get; set;}

        // jovo heten ha implementalasra kerul sor, inkabb nevezzed PasswordSalt-nak
        public byte[] PasswordSalt { get; set; }       

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime DateOfBirth { get; set; }

        public int IdNumber { get; set; }
 


    }
}