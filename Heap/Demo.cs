using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Heap
{
    class Demo
    {
        static void Main(string[] args)
        {
            Console.WriteLine("---------MinHeap---------");
            MinHeap<int> minH = new MinHeap<int>();
            minH.add(99); minH.add(88); minH.add(77); minH.add(-56); minH.add(147); minH.add(166); minH.add(5); minH.add(2); minH.add(1);
            minH.sort();
            minH.Display();

            Console.WriteLine("---------MaxHeap---------");
            MaxHeap<int> maxH = new MaxHeap<int>();
            maxH.add(1); maxH.add(2); maxH.add(77); maxH.add(4); maxH.add(-5); maxH.add(-45); maxH.add(92);
            maxH.sort();
            maxH.Display();

        }
        
    }
     
}
