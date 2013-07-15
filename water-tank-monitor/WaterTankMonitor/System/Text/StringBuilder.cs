using System;
using System.Collections;
using Microsoft.SPOT;

namespace System.Text
{
    /// <summary>
    /// Taken from http://forums.netduino.com/index.php?/topic/180-systemtextstringbuilder-class/
    /// </summary>
    public class StringBuilder
    {
        ArrayList m_charArray = new ArrayList();

        public StringBuilder()
        {
        }

        public StringBuilder(string value) : base()
        {
            Append(value);
        }

        public void Append(string value)
        {
            Char[] charArray = value.ToCharArray();
            Append(charArray, 0, charArray.Length);
        }

        public void Append(char[] value, int startIndex, int charCount)
        {
            for (int index = startIndex; index < startIndex + charCount; index++)
                m_charArray.Add(value[index]);
        }

        public int Length
        {
            get
            {
                return m_charArray.Count;
            }
        }

        public override string ToString()
        {
            return new string((char[])m_charArray.ToArray(typeof(char)));
        }
    }
}