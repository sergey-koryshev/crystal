using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Table
{
    public class Table : ITable
    {
        private string name = "Basic Table";

        private Dictionary<int, string> table;

        /// <summary>
        /// Name of class
        /// </summary>
        public string Name
        {
            get { return name; }
        }

        public Table() { }

        /// <summary>
        /// Main constructor of Table class
        /// </summary>
        /// <param name="TablePath">Path to table</param>
        public Table(string TablePath)
        {
            try
            {
                //creating new dictionary
                table = new Dictionary<int, string>();

                //reading table
                using (StreamReader fileOpen = new StreamReader(TablePath, System.Text.Encoding.Default))
                {
                    string line;
                    string[] parsedLine;
                    while ((line = fileOpen.ReadLine()) != null)
                    {
                        parsedLine = line.Split(new char[] { '=' }, 2);
                        table.Add(int.Parse(parsedLine[0], System.Globalization.NumberStyles.HexNumber), parsedLine[1]);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Gets Char from table according to Value
        /// </summary>
        /// <param name="_value"></param>
        /// <returns></returns>
        public string GetChar(int _value)
        {
            string result;

            if (table.ContainsKey(_value))
            {
                result = table[_value];
            } else
            {
                result = string.Format("[{0}]", _value);
            }
            
            return result;
        }

        /// <summary>
        /// Gets Value from table according to Char
        /// </summary>
        /// <param name="_char"></param>
        /// <returns></returns>
        public int? GetValue(string _char)
        {
            int? result = null;

            if (table.ContainsValue(_char))
            {
                result = table.FirstOrDefault(x => x.Value == _char).Key;
            }

            return result;
        }
    }
}
