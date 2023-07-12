using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WatchStore.Domain
{
    public class User
    {
        // Identyfikator użytkownika
        public int Id { get; set; }

        // Nazwa użytkownika
        public string Username { get; set; }

        // Hasło użytkownika
        public string Password { get; set; }

        // Rola użytkownika (np. "User", "Admin")
        public string Role { get; set; }

        // Imię użytkownika
        public string FirstName { get; set; }

        // Nazwisko użytkownika
        public string LastName { get; set; }

        // Adres e-mail użytkownika
        public string Email { get; set; }

        // Adres użytkownika
        public string Address { get; set; }

        public DateTime DateOfBirth { get; set; }
        public string PhoneNumber { get; set; }


        // Kolekcja zamówień złożonych przez użytkownika
        public ICollection<Order> Orders { get; set; }
    }
}
