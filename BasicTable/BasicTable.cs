using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;
using System.IO;

namespace BasicTable
{
    public class BasicTable
    {
        public class Table : ITable, IAbout
        {
            private Dictionary<byte, string> table;

            public string Name { get; }

            public string Description { get; }

            public string Author { get; }

            public string Date { get; }

            public string Link { get; }

            public bool IsDefault { get; }

            public Table()
            {
                Name = "Basic Table";
                Description = "This is plugin for parsing basic table: XX=V";
                Author = "Koryshev Sergey";
                Date = "April, 2018";
                Link = string.Empty;
                IsDefault = true;
            }

            public Table(string TablePath)
            {
                try
                {
                    table = new Dictionary<byte, string>();

                    using (StreamReader fileOpen = new StreamReader(TablePath, System.Text.Encoding.Default))
                    {
                        string line;
                        string[] parsedLine;
                        char[] splitter = new char[] { '=' };

                        while ((line = fileOpen.ReadLine()) != null)
                        {
                            parsedLine = line.Split(splitter, 2);
                            table.Add(Convert.ToByte(parsedLine[0], 16), parsedLine[1]);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            public string GetValue(byte _value)
            {
                string result;

                if (table.ContainsKey(_value))
                {
                    result = table[_value];
                }
                else
                {
                    result = string.Format("[{0:x}]", _value);
                }

                return result;
            }

            public byte? GetValue(string _char)
            {
                byte? result = null;

                if (table.ContainsValue(_char))
                {
                    result = table.FirstOrDefault(item => item.Value == _char).Key;
                }

                return result;
            }

            public string ToString(List<byte> _intArray)
            {
                List<string> result = new List<string>();

                foreach (byte hex in _intArray)
                {
                    result.Add(GetValue(hex));
                }

                return string.Join("", result);
            }

            public List<byte> ToHex(string _stringArray)
            {
                List<byte> result = new List<byte>();

                byte value;

                foreach (char letter in _stringArray)
                {
                    if (GetValue(letter.ToString()) != null)
                    {
                        value = GetValue(letter.ToString()) ?? default(byte);

                        result.Add(value);
                    }
                    else
                    {
                        Console.WriteLine("Character '{0}' has not found in table.", letter);
                    }
                }

                return result;
            }

            public void About()
            {
                throw new NotImplementedException();
            }
        }
    }
}
