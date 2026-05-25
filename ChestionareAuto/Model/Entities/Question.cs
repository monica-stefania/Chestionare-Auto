/**************************************************************************
 * *
 * File:        Question.cs                                              *
 * Copyright:   (c) 2026, Luca Monica, Macovei Paul, Talmaciu Theodor    *              
 * Description: Această clasă reprezintă modelul de date pentru o        *
 *              întrebare, conținând textul, variantele și imaginile.    *
 * Author:      Luca Monica, Macovei Paul, Talmaciu Theodor              *
 * Proiect:     Chestionare Auto                                         *
                                         
 * *
 * Acest software a fost dezvoltat de 3 studenți ca proiect educațional  *
 * și a fost conceput pentru a fi utilizat în mod gratuit de către       *
 * oricine dorește să învețe sau să se testeze pentru examenul auto.     *
 
 * Sunteți liberi să utilizați și să modificați acest cod sursă în       *
 * aplicațiile voastre, cu condiția să păstrați această notă de          *
 * copyright și autorii originali.                                       *
 *                                                                       *
 **************************************************************************/

namespace Entities
{
    /// <summary>
    /// Reprezintă o întrebare dintr-un chestionar auto, conținând textul întrebării, opțiunile de răspuns, indexurile opțiunilor corecte, imaginea asociată și categoria întrebării.
    /// </summary>
    public class Question
    {
        /// <summary>
        /// Identificatorul unic al întrebării
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Textul întrebării
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// Lista de opțiuni de răspuns pentru întrebare
        /// </summary>
        public List<string> Options { get; set; }

        /// <summary>
        /// Lista indexurilor opțiunilor corecte din lista de opțiuni.
        /// </summary>
        public List<int> CorrectOptionsIndex { get; set; }

        /// <summary>
        /// Imaginea asociată întrebării
        /// </summary>
        public string Image { get; set; }

        /// <summary>
        /// Categoria întrebării, cum ar fi "Semne de circulație", "Reguli de circulație", "Conducere defensivă" etc.
        /// </summary>
        public string Category { get; set; } = string.Empty;

        /// <summary>
        /// Constructor pentru inițializarea unei întrebări cu toate proprietățile necesare.
        /// </summary>
        public Question(int id, string text, List<string> options, List<int> correctOptionsIndex, string image, string category)
        {
            Id = id;
            Text = text;
            Options = options;
            CorrectOptionsIndex = correctOptionsIndex;
            Image = image;
            Category = category;
        }
    }
}