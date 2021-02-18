using System;
using System.Linq;

namespace Wynntrans_CrossAva.Core
{
    public static class Translator
    {
        public enum Language
        {
            Wynnic = 0,
            Gavellian = 1
        }
        private static readonly char[] WynnicBaseCharset = "abcdefghijklmnopqrstuvwxyz123456789.!?".ToCharArray();
        private static readonly char[] WynnicCharset = "⒜⒝⒞⒟⒠⒡⒢⒣⒤⒥⒦⒧⒨⒩⒪⒫⒬⒭⒮⒯⒰⒱⒲⒳⒴⒵⑴⑵⑶⑷⑸⑹⑺⑻⑼０１２".ToCharArray();
        private static readonly char[] GavellianBaseCharset = "abcdefghijklmnopqrstuvwxyz".ToCharArray();
        private static readonly char[] GavellianCharset = "ⓐⓑⓒⓓⓔⓕⓖⓗⓘⓙⓚⓛⓜⓝⓞⓟⓠⓡⓢⓣⓤⓥⓦⓧⓨⓩ".ToCharArray();

        public static string StringConverter(string str, Language language)
        {
            return str.ToLower().Aggregate("", (current, c) => current + CharConverter(c, language));
        }
        

        private static char CharConverter(char c, Language language)
        {
            return language switch
            {
                Language.Wynnic when !WynnicBaseCharset.Contains(c) => c,
                Language.Gavellian when !GavellianBaseCharset.Contains(c) => c,
                _ => language switch
                {
                    Language.Wynnic => WynnicCharset[Array.IndexOf(WynnicBaseCharset, c)],
                    Language.Gavellian => GavellianCharset[Array.IndexOf(GavellianBaseCharset, c)],
                    _ => c
                }
            };
        }
    }
}