using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace desdebugger
{
    class ThumbGenerator
    {
        private Dictionary<string, uint> thumbDict = new Dictionary<string, uint>();

        public void GenerateThumbDict(Action<uint,uint,StringBuilder> disassemble)
        {
            var duplicated = new HashSet<string>();
            for (uint i = 0; i < 0x10000; i++)
            {
                uint suf = (i >> 11);
                if (suf == 0b11110)
                {
                    continue;
                }

                var buf = new StringBuilder(256);
                if (suf == 0b11111 || suf == 0b11101)
                {
                    for (uint j = 0; j < 0x800; j++)
                    {
                        disassemble(0, j, buf);
                        disassemble(0, i, buf);
                        string s = buf.ToString().ToLower();
                        if (suf == 0b11101)
                        {
                            s += " // switch to ARM9";
                        }
                        if (thumbDict.ContainsKey(s))
                        {
                            duplicated.Add(s);
                        }
                        else
                        {
                            thumbDict.Add(s, i * 0x10000 + j);
                        }
                    }
                }
                else
                {
                    disassemble(0, i, buf);
                    string s = buf.ToString().ToLower();
                    if ((i >> 8) == 0b01000111)
                    {
                        s += " // if Rs is odd, switch to ARM9";
                    }
                    if (thumbDict.ContainsKey(s))
                    {
                        duplicated.Add(s);
                    }
                    else
                    {
                        thumbDict.Add(s, i);
                    }
                }
            }

            string hoge = "var dict = new Dictionary<string, uint>();\r\n\r\n";
            foreach (string key in thumbDict.Keys)
            {
                hoge += $"dict.Add(\"{key}\",{thumbDict[key]});\r\n";
            }
            File.WriteAllText("table.cs", hoge);
        }
    }
}
