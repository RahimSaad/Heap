using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heap
{
    class MinHeap <T> where T : IComparable
    {
        private DynamicArray<T> arr;
        public int Size { get => arr.Size; }
        
        public MinHeap()
        {
            this.arr = new DynamicArray<T>();
        }
        
        private int getLeftChildIndexOf(int parent) => parent * 2 + 1;
        private int getRightChildIndexOf(int parent) => parent * 2 + 2;
        private int getParentIndexOf(int child) => (child - 1) / 2;
        
        private bool hasLeftChild(int parent) => getLeftChildIndexOf(parent) < arr.Size;
        private bool hasRightChild(int parent) => getRightChildIndexOf(parent) < arr.Size;
        private bool hasParent(int child) => (child > 0) ;

        private T LeftChildOf(int parent) => arr[getLeftChildIndexOf(parent)];
        private T RightChildOf(int parent) => arr[getRightChildIndexOf(parent)];
        private T ParentOf(int child) => arr[getParentIndexOf(child)];
        
        private void heapifyUp()
        {
            int idx = arr.Size - 1;
            while (hasParent(idx) && (ParentOf(idx).CompareTo(arr[idx]) > 0))
            {
                swap(idx, getParentIndexOf(idx));
                idx = getParentIndexOf(idx);
            }
        }

        private void heapifyDown()
        {
            int idx = 0;
            while (hasLeftChild(idx))
            {
                int smallerIndex = getLeftChildIndexOf(idx);
                if (hasRightChild(idx) && (RightChildOf(idx).CompareTo(LeftChildOf(idx)) < 0))
                {
                    smallerIndex = getRightChildIndexOf(idx);
                }
                if (arr[idx].CompareTo(arr[smallerIndex]) > 0)
                {
                    swap(idx, smallerIndex);
                }
                else
                {
                    break;
                }
                idx = smallerIndex;
            }
        }

        private void swap(int n1, int n2)
        {
            T tmp = arr[n1];
            arr[n1] = arr[n2];
            arr[n2] = tmp;
        }
        
        public void add(T item)
        {
            arr.addItem(item);
            heapifyUp();
        }

        public T poll()
        {
            if (this.arr.isEmpty()) { throw new Exception("the list is empty"); }
            T tmp = arr[0];
            arr[0] = arr[arr.Size - 1];
            arr.Size--;
            arr.adjustCapacityOnPoll();
            heapifyDown();
            return tmp;
        }
        
        public void sort()
        {
            int tmp = this.arr.Size;
            for (int i = this.arr.Size - 1; i > 0; i--)
            {
                swap(0, i);
                arr.Size--;
                heapifyDown();
            }
            this.arr.Size = tmp;
            reverse();
        }

        private void reverse()
        {
            int mid = (int)arr.Size / 2;
            for (int i = 0; i <mid ; i++)
            {
                swap(i, arr.Size - i - 1);
            }
        }

        public void Display()
        {
            for (int i = 0; i < this.arr.Size; i++)
            {
                Console.Write("  {0}  ", this.arr[i]);
            }
            Console.Write("\n");
        }

    }
}
