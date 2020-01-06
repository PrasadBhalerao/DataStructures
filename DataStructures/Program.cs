using System;

namespace DataStructures
{
    public class MinHeap
    {
        public int[] heap;
        public int size;
        public int maxsize;
        public static int FRONT = 1;

        public MinHeap(int maxsize)
        {
            this.maxsize = maxsize;
            heap = new int[maxsize + 1];
            this.size = 0;
            heap[0] = int.MinValue;
        }

        private int Parent(int pos)
        {
            return pos / 2;
        }

        private int LeftChild(int pos)
        {
            return (2 * pos);
        }

        private int RightChild(int pos)
        {
            return (2 * pos) + 1;
        }

        private bool IsLeaf(int pos)
        {
            if (pos >= (size / 2) && pos <= size)
            {
                return true;
            }
            return false;
        }

        private void Swap(int fpos, int spos)
        {
            int tmp;
            tmp = heap[fpos];
            heap[fpos] = heap[spos];
            heap[spos] = tmp;
        }

        private void MinHeapify(int pos)
        {
            if(!IsLeaf(pos))
            {
                if(heap[pos] > heap[LeftChild(pos)] || heap[pos] > heap[RightChild(pos)])
                {
                    if(heap[LeftChild(pos)] < heap[RightChild(pos)])
                    {
                        Swap(pos, LeftChild(pos));
                        MinHeapify(LeftChild(pos));
                    }
                    else
                    {
                        Swap(pos, RightChild(pos));
                        MinHeapify(RightChild(pos));
                    }
                }
            }
        }

        public void Insert(int element)
        {
            if (size >= maxsize)
                return;

            heap[++size] = element;
            int current = size;

            while(heap[current] < heap[Parent(current)])
            {
                Swap(current, Parent(current));
                current = Parent(current);
            }
        }

        public void Print()
        {
            for (int i = 1; i <= size/2; i++)
            {
                Console.WriteLine(" Parent: " + heap[i] + " LeftChild: " + heap[2 * i] + " RightChild: " + heap[2 * i + 1]);
            }
        }

        public void MinHeapArray()
        {
            for (int i = (size/2); i >= 1; --i)
            {
                MinHeapify(i);
            }
        }
        
        public int Remove()
        {
            int popped = heap[FRONT];
            heap[FRONT] = heap[size--];
            //heap[size--] = int.MinValue;
            MinHeapify(FRONT);
            return popped;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Min heap demo");
            MinHeap minHeap = new MinHeap(10);
            minHeap.Insert(5);
            minHeap.Insert(3);
            minHeap.Insert(17);
            minHeap.Insert(10);
            minHeap.Insert(84);
            minHeap.Insert(19);
            minHeap.Insert(6);
            minHeap.Insert(22);
            minHeap.Insert(9);
            minHeap.MinHeapArray();

            minHeap.Print();

            Console.WriteLine("The minimum element is : " + minHeap.Remove());

            minHeap.Print();

            Console.ReadLine();
        }
    }
}
