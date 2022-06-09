using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _ArrayList
{
    public class _ArrayList
    {
        private Object[] _items;
        private const int _defaultCapacity = 4;
        private static  Object[] emptyArray = new Object [0];
        public _ArrayList()
        {
            _items = emptyArray;
        }
        public _ArrayList(int capacity)
        {
            if(capacity < 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            if(capacity==0)
                _items=emptyArray;
            else
                _items=new Object[capacity];
        }
        public _ArrayList(ICollection c)
        {
            if(c == null)
                throw new ArgumentNullException();
            int count = c.Count;
            if (count == 0)
                _items = emptyArray;
            else
                _items=new Object[count];
            AddRange(c);

        }
    }
}
