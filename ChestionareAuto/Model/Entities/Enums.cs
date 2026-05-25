/**************************************************************************
 * *
 * File:        Enums.cs                                                 *
 * Copyright:   (c) 2026, Luca Monica, Macovei Paul, Talmaciu Theodor    *              
 * Description: Aici sunt definite rolurile posibile ale unui utilizator,* 
 *              starea unui test, cât și tipul sesiunii.                 *
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
