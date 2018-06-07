using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickSort
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 23, 44, 3, 76, 98, 11, 66, 9, 7 };
            Console.WriteLine("需要排序的数组为：");
            for (int i = 0; i < arr.Length - 1; i++)
            {
                Console.Write(arr[i] + " ");
            }
            Console.WriteLine();

            //快速排序：通过一趟排序将要排序的数据分割成独立的两部分，其中一部分的所有数据都比另外一部分的所有数据都要小，
            //然后再按此方法对这两部分数据分别进行快速排序，整个排序过程可以递归进行，以此达到整个数据变成有序序列。
            Sort(arr, 0, arr.Length - 1);

            Console.WriteLine("排序后的数组为：");
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i] + " ");
            }

            Console.ReadKey();
        }

        /// <summary>
        /// 对部分数组进行快速排序
        /// </summary>
        /// <param name="arr">待排序数组</param>
        /// <param name="low">起始位置</param>
        /// <param name="high">终止位置</param>
        /// <returns></returns>
        public static int UnitSort(int[] arr, int low, int high)
        {
            //选择某个值作为分界值：前小后大
            int key = arr[low];
            while(low < high)
            {
                //根据选定值比较大小，交换位置，大值在后
                while (arr[high] >= key && low < high) //借助while循环，快速定位第一个小于key的值的位置。
                    --high;
                arr[low] = arr[high];

                while (arr[low] <= key && low < high) //low < high 条件很重要。
                    ++low;
                arr[high] = arr[low];                
            }
            arr[low] = key;
            return high;
        }

        /// <summary>
        /// 一次快速排序并不能完成排序，利用递归的思想完成。
        /// </summary>
        /// <param name="array"></param>
        /// <param name="low"></param>
        /// <param name="high"></param>
        public static void Sort(int[] array, int low, int high)
        {
            if (low >= high)
                return;
            /*完成一次单元排序*/
            int index = UnitSort(array, low, high);
            /*对左边单元进行排序*/
            Sort(array, low, index - 1);
            /*对右边单元进行排序*/
            Sort(array, index + 1, high);
        }
    }
}
