﻿using System;
using System.IO;
using System.Text;

namespace NGVSCAN.DAL.ROC809Connection
{
    public static class ROC809DataServiceExtensions
    {
        /// <summary>
        /// Получение подмассива из массива
        /// </summary>
        /// <typeparam name="T">Тип элементов массива</typeparam>
        /// <param name="data">Исходный массив</param>
        /// <param name="index">Начальный индекс</param>
        /// <param name="length">Количество элементов выборки</param>
        /// <returns>Результирующий массив</returns>
        public static T[] SubArray<T>(this T[] data, int index, int length)
        {
            T[] result;
            if (length == 3)
                result = new T[4];
            else if (length == 7)
                result = new T[8];
            else if (length == 10)
                result = new T[16];
            else
                result = new T[length];

            Array.Copy(data, index, result, 0, length);
            return result;
        }

        public static int GetInt32(this byte[] data, int index, int length = 4)
        {
            return BitConverter.ToInt32(data.SubArray(index, length), 0);
        }

        public static short GetInt16(this byte[] data, int index)
        {
            return BitConverter.ToInt16(data.SubArray(index, 2), 0);
        }

        public static uint GetUInt32(this byte[] data, int index, int length = 4)
        {
            return BitConverter.ToUInt32(data.SubArray(index, length), 0);
        }

        public static ushort GetUInt16(this byte[] data, int index)
        {
            return BitConverter.ToUInt16(data.SubArray(index, 2), 0);
        }

        public static bool GetBool(this byte[] data, int index)
        {
            return BitConverter.ToBoolean(data.SubArray(index, 1), 0);
        }

        public static float GetSingle(this byte[] data, int index, int length = 4)
        {
            return BitConverter.ToSingle(data.SubArray(index, length), 0);
        }

        public static double GetDouble(this byte[] data, int index, int length = 8)
        {
            return BitConverter.ToDouble(data.SubArray(index, length), 0);
        }

        public static string GetString(this byte[] data, int index, int length)
        {
            return Encoding.UTF8.GetString(data.SubArray(index, length));
        }

        public static string GetTLP(this byte[] data, int index)
        {
            return data[index] + ", " + data[index + 1] + ", " + data[index + 2];
        }

        public static decimal GetDecimal(this byte[] data, int index, int length = 10)
        {
            byte[] arr = data.SubArray(index, length);

            using (MemoryStream stream = new MemoryStream(arr))
            {
                using (BinaryReader reader = new BinaryReader(stream))
                {
                    return reader.ReadDecimal();
                }
            }
        }
    }
}