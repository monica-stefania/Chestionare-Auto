using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    /// <summary>
    /// Definește rolurile posibile ale unui utilizator în aplicație.
    /// </summary>
    public enum UserRole
    {
        Admin,
        Utilizator
    }

    /// <summary>
    /// Definește starea unui test susținut de utilizator.
    /// </summary>
    public enum StareTest
    {
        Admis,
        Respins,
        Nefinalizat
    }

    /// <summary>
    /// Definește tipul sesiunii de chestionar.
    /// </summary>
    public enum TipSesiune
    {
        Examen,
        Invatare
    }
}
