/**************************************************************************
 * *
 * File:        IRepository.cs                                           *
 * Copyright:   (c) 2026, Luca Monica, Macovei Paul, Talmaciu Theodor    *              
 * Description: Aceasta este interfața pentru clasele QuestionRepository,*
 *              UserRepository și ResultRepository.                      * 
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

namespace Repositories
{
    /// <summary>
    /// Interfața generică pentru repository-urile din aplicație, care definesc operațiile de bază pentru 
    /// gestionarea datelor entităților precum întrebări, utilizatori și rezultate.
    /// </summary>
    /// <typeparam name="T">Tipul entității gestionate de repository.</typeparam>
    public interface IRepository<T>
    {
        List<T> LoadData();
        void SaveData();
        List<T> GetAll();
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
