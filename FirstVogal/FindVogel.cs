using FirstVogal;
using System;

namespace FirstVogel
{
    public class StringStream : IStream
    {
        public string stream;

        private int indexOf = 0;

        public StringStream(string s)
        {
            stream = s;
        }

        public char getNext() => stream[indexOf++];
        public bool hasNext() => (stream.Length > indexOf);
    }

    public class SearchVogel
    {
        public char FirstChar(IStream input)
        {
            char c;
            int index = 0;
            int found;
            char[] chars = new char[((StringStream)(input)).stream.Length];
            short[] repeated = new short[((StringStream)(input)).stream.Length];

            while (input.hasNext())
            {
                c = input.getNext();
                found = ReturnIndex(c, chars);

                if (found >= 0)
                    repeated[found]++;
                else
                {
                    chars[index] = c;
                    repeated[index]++;
                    index++;
                }
            }

            int firstCharIndex = FirstIndex(repeated);

            if (firstCharIndex < 0)
                throw new Exception("Nenhum char repetido foi encontrado.");

            return chars[firstCharIndex];
        }

        private int FirstIndex(short[] repeated)
        {
            for (int i = 0; i < repeated.Length; i++)
            {
                if (repeated[i].Equals(1))
                    return i;
            }

            return -1;
        }

        private int ReturnIndex(char c, char[] chars)
        {
            for (int i = 0; i < chars.Length; i++)
            {
                if (c.Equals(chars[i]))
                    return i;
            }

            return -1;
        }
    }
}
