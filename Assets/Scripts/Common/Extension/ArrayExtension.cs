

using System;
using System.Collections.Generic;

namespace MyFramework {
    public static class ArrayExtension {

        static int SHUFFLE_THRESHOLD = 5;
        static Random r;

        /// <summary>
        /// Rands the sort.
        /// </summary>
        /// <returns>The sort.</returns>
        /// <param name="arry">Arry.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        public static T[] RandSort<T>(T[] arry) {
            T[] arryNew = new T[arry.Length];
            Random rnd = new Random();
            int n = arry.Length;
            int i = 0;
            while (n > 0) {
                int index = rnd.Next(n);
                arryNew[i] = arry[index];
                arry[index] = arry[n - 1];
                n--;
                i++;
            }

            return arryNew;

        }

        /// <summary>
        /// Shuffle the specified list.
        /// </summary>
        /// <param name="list">List.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        public static void Shuffle01<T>(ref List<T> list) {
            Random rand = new Random(Guid.NewGuid().GetHashCode());
            List<T> newList = new List<T>();//儲存結果的集合
            foreach (T item in list) {
                newList.Insert(rand.Next(0, newList.Count), item);
            }
            newList.Remove(list[0]);//移除list[0]的值
            newList.Insert(rand.Next(0, newList.Count), list[0]);//再重新隨機插入第一筆

            list = newList;
        }


        public static void Shuffle<T>(List<T> list) {
            Random rnd = r;
            if (rnd == null)
                r = rnd = new Random(); // harmless race.
            Shuffle(list, rnd);
        }

        private static void swap<T>(T[] arr, int i, int j) {
            T tmp = arr[i];
            arr[i] = arr[j];
            arr[j] = tmp;
        }

        public static void Shuffle<T>(List<T> list, Random rnd) {
            int size = list.Count;
            if (size < SHUFFLE_THRESHOLD) {
                for (int i = size; i > 1; i--)
                    swap(list, i - 1, rnd.Next(i));
            }
            else {
                T[] arr = list.ToArray();
                for (int i = size; i > 1; i--)
                    swap(arr, i - 1, rnd.Next(i));
                for (int i = 0; i < list.Count; i++) {
                    list[i] = arr[i];
                }
            }
        }

        public static void swap<T>(List<T> list, int i, int j) {
            List<T> l = list;
            T tmp = l[i];
            l[i] = l[j];
            l[j] = tmp;
        }

    }
}