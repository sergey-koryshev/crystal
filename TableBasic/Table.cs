﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Interfaces;

namespace Testing
{
    public class Table : ITable, IName
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
                    char[] splitter = new char[] { '=' };

                    while ((line = fileOpen.ReadLine()) != null)
                    {
                        parsedLine = line.Split(splitter, 2);
                        table.Add(Convert.ToInt32(parsedLine[0], 16), parsedLine[1]);
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
        public string GetValue(int _value)
        {
            string result;

            if (table.ContainsKey(_value))
            {
                result = table[_value];
            } else
            {
                result = string.Format("[{0:x}]", _value);
            }
            
            return result;
        }

        /// <summary>
        /// Gets digital value from table according to Char
        /// </summary>
        /// <param name="_char"></param>
        /// <returns></returns>
        public int? GetValue(string _char)
        {
            int? result = null;

            if (table.ContainsValue(_char))
            {
                result = table.FirstOrDefault(item => item.Value == _char).Key;
            }

            return result;
        }

        public string ToString(List<int> _intArray)
        {
            List<string> result = new List<string>();

            foreach (int hex in _intArray)
            {
                result.Add(GetValue(hex));
            }

            return string.Join("", result);
        }

        public List<int> ToHex(string _stringArray)
        {
            List<int> result = new List<int>();

            int value;

            foreach(char letter in _stringArray)
            {
                if (GetValue(letter.ToString()) != null)
                {
                    value = GetValue(letter.ToString()) ?? default(int);

                    result.Add(value);
                } else
                {
                    Console.WriteLine("Character '{0}' has not found in table.", letter);
                }
            }

            return result;
        }
    }
}
