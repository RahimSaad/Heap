using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heap
{
    class DynamicArray<T> where T : IComparable
    {
        private T[] arr;
        public int Length { get => arr.Length; }
        public int Size { get => size; set => size = value; }
        int size;
        public T this[int idx]
        {
            get => this.arr[idx];
            set => this.arr[idx] = value; 
        }
        public DynamicArray()
        {
            this.arr = new T[1];
            this.size = 0 ;
        }
        public bool isFull() => this.size == this.arr.Length;
        public bool isEmpty() => this.size == 0;

        private void adjustCapacity(int newCapacity)
        {
            T[] tmp = new T[newCapacity];
            for (int i = 0; i < size; i++)
            {
                tmp[i] = arr[i];
            }
            this.arr = tmp;
        }
        public void addItem(T item)
        {
            adjustCapacityOnAdd();
            this.arr[size++] = item;
        }
        // before using this method check if arr is not empty through isEmpty method.
        public T pollLast()
        {
            T tmp = arr[--size];
            adjustCapacityOnPoll();
            return tmp;
        }
        public void adjustCapacityOnPoll()
        {
            if (size <= this.arr.Length * 0.5)
            {
                adjustCapacity(this.size);
            }
        }
        public void adjustCapacityOnAdd()
        {
            if (this.isFull())
            {
                adjustCapacity(arr.Length * 2);
            }
        }
    }
}
