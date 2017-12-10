using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrystalConsole
{
    class Pointer: IEnumerable
    {
        private List<int> offsets;

        public Pointer() { }

        public Pointer(int value)
        {
            Add(value);
        }

        public Pointer(params int[] values)
        {
            AddRange(values);
        }

        private void Add(int value)
        {
            offsets.Add(value);
        }

        private void AddRange(params int[] values)
        {
            offsets.AddRange(values);
        }

        public int Count()
        {
            return offsets.Count();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return offsets.GetEnumerator();
        }
    }
}
