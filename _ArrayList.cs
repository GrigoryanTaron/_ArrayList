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
        private static Object[] emptyArray = new Object[0];
        private int _size;
        private int _version;
        public _ArrayList()
        {
            _items = emptyArray;
        }
        public _ArrayList(int capacity)
        {
            if (capacity < 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            if (capacity == 0)
                _items = emptyArray;
            else
                _items = new Object[capacity];
        }
        public _ArrayList(ICollection c)
        {
            if (c == null)
                throw new ArgumentNullException();
            int count = c.Count;
            if (count == 0)
                _items = emptyArray;
            else
                _items = new Object[count];
            AddRange(c);

        }
        public virtual Object this[int index]
        {
            get
            {
                if (index < 0 || index >= _size) throw new ArgumentOutOfRangeException();
                return _items[index];
            }
            set
            {
                if (index < 0 || index >= _size) throw new ArgumentOutOfRangeException();
                _items[index] = value;
                _version++;
            }
        }
        public virtual void AddRange(ICollection c)
        {
            InsertRange(_size, c);
        }

        public virtual int Count
        {
            get { return _size; }
        }
        public virtual bool IsFixedSize
        {
            get { return false; }
        }
        public virtual bool isReadonly
        {
            get { return false; }
        }
        public virtual bool IsSynchronized
        {
            get { return false; }
        }
        public virtual int Add(Object value)
        {
            if (_size == _items.Length) EnsureCapacity(_size + 1);
            _items[_size] = value;
            _version++;
            return _size++;
        }
        public virtual void AddRande(ICollection c)
        {
            InsertRange(_size, c);
        }
        public virtual void Clear()
        {
            if (_size > 0)
            {
                Array.Clear(_items, 0, _size);
                _size = 0;
            }
            _version++;
        }
        public virtual void CopyTo(Array array)
        {
            CopyTo(array, 0);
        }
        public virtual void CopyTo(Array array, int arrayIndex)
        {
            if ((array != null) && (array.Rank != 1))
                throw new ArgumentException();
            Array.Copy(_items, 0, array, arrayIndex, _size);
        }
        public virtual void CopyTo(int index, Array array, int arrayIndex, int count)
        {
            if (_size - index < count)
                throw new ArgumentException();
            if ((array != null) && (array.Rank != 1))
                throw new ArgumentException();
            Array.Copy(_items, index, array, arrayIndex, count);
        }
        public virtual Object Clone()
        {
            _ArrayList l = new _ArrayList(_size);
            l._size = _size;
            l._version = _version;
            Array.Copy(_items, 0, l._items, 0, _size);
            return l;
        }
        public virtual void Insert(int index, Object value)
        {
            if (index < 0 || index > _size)
                throw new ArgumentOutOfRangeException();
            if (_size == _items.Length) EnsureCapacity(_size + 1);
            if (index < _size)
            {
                Array.Copy(_items, index, _items, index + 1, _size - index);
            }
            _items[index] = value;
            _size++;
            _version++;
        }
        public virtual void InsertRange(int index, ICollection c)
        {
            if (c == null)
                throw new ArgumentNullException();
            if (index < 0 || index > _size)
                throw new ArgumentOutOfRangeException();
            int count = c.Count;
            if (count > 0)
            {
                EnsureCapacity(_size + count);
                if (index < _size)
                {
                    Array.Copy(_items, index, _items, index + count, _size - index);
                }
            }
        }
        public virtual int IndexOf(Object value)
        {
            return Array.IndexOf((Array)_items, value, 0, _size);
        }
        public virtual int IndexOf(Object value, int startIndex)
        {
            if (startIndex > _size)
                throw new ArgumentOutOfRangeException();
            return Array.IndexOf((Array)_items, value, startIndex, _size - startIndex);
        }
        public virtual int IndexOf(Object value, int startIndex, int count)
        {
            if (startIndex > _size)
                throw new ArgumentOutOfRangeException();
            if (count < 0 || startIndex > _size - count) throw new ArgumentOutOfRangeException();
            return Array.IndexOf((Array)_items, value, startIndex, count);
        }
        public virtual int LastIndexOf(Object value)
        {
            return LastIndexOf(value, _size - 1, _size);
        }
        public virtual int LastIndexOf(object value, int startIndex)
        {
            if (startIndex >= _size)
                throw new IndexOutOfRangeException();
            return LastIndexOf(value, startIndex, startIndex + 1);
        }
        public virtual int LastIndexOf(Object value, int startIndex, int count)
        {
            if (Count != 0 && (startIndex < 0 || count < 0))
                throw new ArgumentOutOfRangeException();
            if (_size == 0)
                return -1;
            if (startIndex >= _size || count > startIndex + 1)
                throw new ArgumentOutOfRangeException();
            return Array.LastIndexOf((Array)_items, value, startIndex, count);
        }
        public virtual void Rmove(Object obj)
        {
            int index = IndexOf(obj);
            if (index >= 0)
                RemoveAt(index);
        }
        public virtual void RemoveAt(int index)
        {
            if (index < 0 || index >= _size) throw new ArgumentOutOfRangeException();
            _size--;
            if (index < _size)
            {
                Array.Copy(_items, index + 1, _items, index, _size - index);
            }
            _items[_size] = null;
            _version++;
        }
        public virtual void RemoveRange(int index, int count)
        {
            if (index < 0)
                throw new ArgumentOutOfRangeException();
            if (count < 0)
                throw new ArgumentOutOfRangeException();
            if (_size - index < count)
                throw new ArgumentException();
            if (count > 0)
            {
                int i = _size;
                _size -= count;
                if (index < _size)
                {
                    Array.Copy(_items, index + count, _items, index, _size - index);
                }
                while (i > _size) _items[--i] = null;
                _version++;
            }
        }
        public virtual void Reverse(int index, int count)
        {
            if (index < 0)
                throw new ArgumentOutOfRangeException();
            if (count < 0)
                throw new ArgumentOutOfRangeException();
            if (_size - index < count)
                throw new ArgumentException();
            Array.Reverse(_items, index, count);
            _version++;
        }
        public virtual bool Contains(Object item)
        {
            if (item == null)
            {
                for (int i = 0; i < _size; i++)
                    if (_items[i] == null)
                        return true;
                return false;
            }
            else
            {
                for (int i = 0; i < _size; i++)
                    if ((_items[i] != null) && (_items[i].Equals(item)))
                        return true;
                return false;
            }
        }
        public virtual IEnumerator GetEnumerator()
        {
           
            return new ArrayListEnumeratorSimple(this);
        }
        public virtual int Capacity
        {
            get
            {
                return _items.Length;
            }
            set
            {
                if (value < _size)
                {
                    throw new ArgumentOutOfRangeException();
                }
                if (value != _items.Length)
                {
                    if (value > 0)
                    {
                        Object[] newItems = new Object[value];
                        if (_size > 0)
                        {
                            Array.Copy(_items, 0, newItems, 0, value);
                        }
                        _items = newItems;
                    }
                    else
                    {
                        _items = new Object[_defaultCapacity];
                    }
                }
            }
        }
        private void EnsureCapacity(int min)
        {
            if (_items.Length < min)
            {
                int newCapacity = _items.Length == 0 ? _defaultCapacity : _items.Length * 2;
                if ((uint)newCapacity > 0X7FEFFFFF) newCapacity = 0X7FEFFFFF;
                if (newCapacity < min) newCapacity = min;
                Capacity = newCapacity;
            }
        }
        private sealed class ArrayListEnumeratorSimple : IEnumerator, ICloneable
        {
            private _ArrayList list;
            private int index;
            private int version;
            private Object currentElement;
            private bool isArrayList;
            static Object dummyObject = new Object();
            public ArrayListEnumeratorSimple(_ArrayList list)
            {
                this.list = list;
                this.index = -1;
                version = list._version;
                isArrayList = (list.GetType() == typeof(ArrayList));
                currentElement = dummyObject;
            }
            public Object Clone()
            {
                return MemberwiseClone();
            }
            public bool MoveNext()
            {
                if (version != list._version)
                {
                    throw new InvalidOperationException();
                }

                if (isArrayList)
                {  
                    if (index < list._size - 1)
                    {
                        currentElement = list._items[++index];
                        return true;
                    }
                    else
                    {
                        currentElement = dummyObject;
                        index = list._size;
                        return false;
                    }
                }
                else
                {
                    if (index < list.Count - 1)
                    {
                        currentElement = list[++index];
                        return true;
                    }
                    else
                    {
                        index = list.Count;
                        currentElement = dummyObject;
                        return false;
                    }
                }
            }
            public Object Current
            {
                get
                {
                    object temp = currentElement;
                    if (dummyObject == temp)
                    { 
                        if (index == -1)
                        {
                            throw new InvalidOperationException();
                        }
                        else
                        {
                            throw new InvalidOperationException();
                        }
                    }

                    return temp;
                }
            }
            public void Reset()
            {
                if (version != list._version)
                {
                    throw new InvalidOperationException();
                }

                currentElement = dummyObject;
                index = -1;
            }
        }
    }
}





