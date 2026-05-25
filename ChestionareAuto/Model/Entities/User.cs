/**************************************************************************
 * *
 * File:        User.cs                                                  *
 * Copyright:   (c) 2026, Luca Monica, Macovei Paul, Talmaciu Theodor    *              
 * Description: Această clasă reprezintă un utilizator al aplicației     *
 *              Chestionare Auto.                                        *
 * Author:      Talmaciu Theodor                                         *
 * Proiect:     Chestionare Auto                                         *
                                         
 *                                                                       *
 * Acest software a fost dezvoltat de 3 studenți ca proiect educațional  *
 * și a fost conceput pentru a fi utilizat în mod gratuit de către       *
 * oricine dorește să învețe sau să se testeze pentru examenul auto.     *
 
 * Sunteți liberi să utilizați și să modificați acest cod sursă în       *
 * aplicațiile voastre, cu condiția să păstrați această notă de          *
 * copyright și autorii originali.                                       *
 *                                                                       *
 **************************************************************************/

using Entities;
using System.Data;

namespace Entities
{
    /// <summary>
    /// Reprezintă un utilizator al aplicației Chestionare Auto.
    /// Un utilizator poate avea rolul de Admin sau Utilizator normal.
    /// </summary>
    public class User
    {
        /// <summary>
        /// Identificatorul unic al utilizatorului.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Numele complet al utilizatorului.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Numele de utilizator folosit la autentificare.
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// Adresa de email a utilizatorului.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Parola utilizatorului folosită la autentificare.
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Rolul utilizatorului în aplicație: Admin sau Utilizator.
        /// Adminul poate gestiona întrebările și utilizatorii.
        /// </summary>
        public UserRole Role { get; set; }

        /// <summary>
        /// Inițializează un nou utilizator cu toate proprietățile necesare.
        /// </summary>
        public User(int id, string name, string username, string email, string password, UserRole role)
        {
            Id = id;
            Name = name;
            Username = username;
            Email = email;
            Password = password;
            Role = role;
        }

    }
}