using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Litery
{
    public class LetterNr
    {
        public char Name { get; private set; }
        public long Nr { get; private set; }

        public LetterNr(char name)
        {
            this.Name = name;
            Nr = 1;
        }

        public void Increase()
        {
            Nr++;
        }

    }
}
