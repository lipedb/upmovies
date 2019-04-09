using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace UpMovies.Extensions
{
    public static class ExtensionMethods
    {
        //RegExp for validating Alphanumeric strings
        private const string AlphanumericRegex = @"^[A-Za-z\d-]+$";
        private const string EmptyStringRegex = @"\s+";
        public static IEnumerable<IEnumerable<T>> AsBatchOfSize<T>(this IEnumerable<T> collection, int batchSize)
        {
            List<T> nextbatch = new List<T>(batchSize);
            foreach (T item in collection)
            {
                nextbatch.Add(item);
                if (nextbatch.Count == batchSize)
                {
                    yield return nextbatch;
                    nextbatch = new List<T>();
                    // or nextbatch.Clear(); but see Servy's comment below
                }
            }

            if (nextbatch.Count > 0)
                yield return nextbatch;
        }
        public static bool IsAlphanumeric(this string str)
        {
            if (string.IsNullOrEmpty(str)) return false;
            return Regex.IsMatch(str, AlphanumericRegex);
        }
        public static string RemoveWhiteSpaces(this string str)
        {
            if (string.IsNullOrEmpty(str)) return string.Empty;
            return Regex.Replace(str, EmptyStringRegex, "");
        }
    }
}

