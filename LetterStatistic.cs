using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Litery
{
    public class LetterStatistic
    {
        public List<LetterNr> allLetters { get; private set; }
        public List<LetterNr> firstLetters { get; private set; }
        public List<LetterNr> lastLetters { get; private set; }
        public string Language { get; private set; }
        public long NrLetters { get; private set; }
        public long NrFirstLetters { get; private set; }
        public long NrLastLetters { get; private set; }

        public LetterStatistic(string language)
        {
            Language = language;
            allLetters = new List<LetterNr>();
            firstLetters = new List<LetterNr>();
            lastLetters = new List<LetterNr>();
            NrLetters = 0;
            NrFirstLetters = 0;
            NrLastLetters = 0;
        }

        public void Count(char letter, char previousLetter)
        {
            if (letter == ' ' && !IgnoreLetter(previousLetter))
            {
                if (lastLetters.Exists(x => Char.ToUpper(x.Name) == Char.ToUpper(previousLetter)))
                    lastLetters.Find(x => Char.ToUpper(x.Name) == Char.ToUpper(previousLetter)).Increase();
                else
                    lastLetters.Add(new LetterNr(Char.ToUpper(previousLetter)));
                NrLastLetters++;
            }

            if (IgnoreLetter(letter)) // ignore char if it is not a letter
                return;

            if (allLetters.Exists(x => Char.ToUpper(x.Name) == Char.ToUpper(letter)))
                allLetters.Find(x => Char.ToUpper(x.Name) == Char.ToUpper(letter)).Increase();
            else
                allLetters.Add(new LetterNr(Char.ToUpper(letter)));

            if(previousLetter == ' ')
            {
                if (firstLetters.Exists(x => Char.ToUpper(x.Name) == Char.ToUpper(letter)))
                    firstLetters.Find(x => Char.ToUpper(x.Name) == Char.ToUpper(letter)).Increase();
                else
                    firstLetters.Add(new LetterNr(Char.ToUpper(letter)));
                NrFirstLetters++;
            }

            NrLetters++;
        }

        private bool IgnoreLetter(char letter)
        {
            return !Char.IsLetter(letter);
        }

        public List<LetterNr> AllOrderLetters()
        {
            var result = allLetters.OrderByDescending(item => item.Nr);
            allLetters = result.ToList();
            return allLetters;
        }

        public List<LetterNr> FirstOrderLetters()
        {
            var result = firstLetters.OrderByDescending(item => item.Nr);
            firstLetters = result.ToList();
            return firstLetters;
        }

        public List<LetterNr> LastOrderLetters()
        {
            var result = lastLetters.OrderByDescending(item => item.Nr);
            lastLetters = result.ToList();
            return lastLetters;
        }


    }
}
