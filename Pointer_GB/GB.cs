using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pointer_GB
{
    public interface IPointer
    {
        int ToOffset(int _pointerValue, int _countBytes);

        int ToPointer(int _offsetValue, int _countBytes);
    }

    public class GB : IPointer
    {

        public GB() { }

        public int ToOffset(int _pointerValue, int _countBytes)
        {
            int offset = 0;

            return offset;
        }

        public int ToPointer(int _offsetValue, int _countBytes)
        {
            int pointer;
            byte bankNumber;

            pointer = ((((_offsetValue & 0x3FFF) + 0x4000) & 0xFF) << 8) + (((_offsetValue & 0x3FFF) + 0x4000) >> 8) & 0xFF;
            bankNumber = (byte)Math.Truncate((double)(_offsetValue / 0x4000));

            return pointer;
        }
    }
}
