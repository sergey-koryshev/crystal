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

            public string Parameters { get; }

            public Table()
            {
                Name = "Basic Table";
                Description = "This is plugin for parsing basic table: XX=V";
                Author = "Sergey Koryshev";
                Date = "April, 2018";
                Link = string.Empty;
                IsDefault = true;
            }

            public Table(string TablePath, string _parameters)
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
                    if ((result == "{enter}") || (result == "{end line}"))
                    {
                        result += "\n";
                    }
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

                try
                {
                    result = table.First(item =>
                        item.Value.IndexOf(_char) == 0).Key;
                }
                catch
                {
                    return null;
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

                int i = 0;

                string seekingValue = string.Empty;
                string hexValue = string.Empty;
                bool found;

                while (i < _stringArray.Length)
                {
                    seekingValue = string.Empty;
                    hexValue = string.Empty;
                    found = true;

                    switch (_stringArray[i])
                    {
                        case '[':
                            i++;
                            do
                            {
                                hexValue += _stringArray[i];
                                i++;
                            } while (_stringArray[i] != ']');
                            i++;
                            break;
                        case '{':
                            do
                            {
                                seekingValue += _stringArray[i];
                                i++;
                            } while (_stringArray[i] != '}');
                            seekingValue += _stringArray[i];
                            i++;
                            break;
                        default:
                            seekingValue = _stringArray[i].ToString();
                            while (found && (i + 1 < _stringArray.Length))
                            {
                                if (GetValue(seekingValue + _stringArray[i + 1].ToString()) != null)
                                {
                                    i++;
                                    seekingValue += _stringArray[i].ToString();
                                }
                                else
                                {
                                    found = false;
                                }
                            }
                            i++;
                            break;
                    }
                    if (seekingValue != string.Empty)
                    {
                        if (GetValue(seekingValue) != null)
                        {
                            value = GetValue(seekingValue) ?? default(byte);
                            result.Add(value);
                        }
                        else
                        {
                            Console.WriteLine("Character '{0}' has not found in table.", seekingValue);
                        }
                    }
                    else
                    {
                        value = Convert.ToByte(hexValue, 16);
                        result.Add(value);
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
