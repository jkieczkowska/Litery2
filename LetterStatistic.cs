using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Litery
{
    public class LetterStatistic
    {
        public List<LetterNr> letters { get; private set; }
        public string Language { get; private set; }
        public long NrLetters { get; private set; }

        public LetterStatistic(string language)
        {
            Language = language;
            letters = new List<LetterNr>();
            NrLetters = 0;
        }

        public void Count(char letter)
        {
            if (letters.Exists(x => x.Name == letter))
                letters.Find(x => x.Name == letter).Increase();
            else
                letters.Add(new LetterNr(letter));
            NrLetters++;

            var result = letters.OrderByDescending(item => item.Nr);
            var result2 = from item in letters orderby item.Nr select item;
            letters = result.ToList();
            List<LetterNr> list = result2.ToList();
        }

       


    }
}
