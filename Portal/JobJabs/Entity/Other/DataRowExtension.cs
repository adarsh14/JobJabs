using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;

namespace JobJabs.Entity
{
  public static class DataRowExtension
    {
        public static int ConvertToInt32(this DataRow row, string column)
        {
            string str = (row[column] == null ? "0" : Convert.ToString(row[column]));
            int value;
            if (!int.TryParse(str, out value))
            {
                str = "0";
            }
            return Convert.ToInt32(str);
        }

        public static string ConvertToString(this DataRow row, string column)
        {
            string str = (row[column] == null ? "0" : Convert.ToString(row[column]));
            return str;
        }

        public static decimal ConvertToDecimal(this DataRow row, string column)
        {
            string str = (row[column] == null ? "0" : Convert.ToString(row[column]));
            decimal value;
            if (!decimal.TryParse(str, out value))
            {
                str = "0";
            }
            return Convert.ToDecimal(str);
        }

        public static DateTime  ConvertToDateTime(this DataRow row, string column)
        {
            string str = (row[column] == null ? "0" : Convert.ToString(row[column]));
            DateTime value;
            if (!DateTime.TryParse(str, out value))
            {
                str = DateTime.Now.ToString();
            }
            return Convert.ToDateTime(str);
        }

        public static Boolean ConvertToBoolean(this DataRow row, string column)
        {
            string str = (row[column] == null ? "0" : Convert.ToString(row[column]));
            bool value;
            if (!Boolean.TryParse(str, out value))
            {
                return false;
            }
            return Convert.ToBoolean(str);
        }

    }

    public static class QueryStringExtension
  {
      public static int ConvertToInt32(this HttpRequestBase request, string column)
      {
          string str = (request.QueryString[column] == null ? "0" : Convert.ToString(request.QueryString[column]));
          int value;
          if (!int.TryParse(str, out value))
          {
              str = "0";
          }
          return Convert.ToInt32(str);
      }

      public static string ConvertToString(this HttpRequestBase request, string column)
      {
          string str = (request.QueryString[column] == null ? "" : Convert.ToString(request.QueryString[column]));
          return str;
      }

        public static DateTime ConvertToDateTime(this HttpRequestBase request, string column)
        {
            string str = (request.QueryString[column] == null ? "0" : Convert.ToString(request.QueryString[column]));
            DateTime value;
            if (!DateTime.TryParse(str, out value))
            {
                str = DateTime.Now.ToString();
            }
            return Convert.ToDateTime(str);
        }

    }

    public static class EnumerableExtension
  {
      public static IEnumerable<T> Except<T>(this IEnumerable<T> listA, IEnumerable<T> listB,
                                             Func<T, T, bool> lambda)
      {
          return listA.Except(listB, new Comparer<T>(lambda));
      }

      public static IEnumerable<T> Intersect<T>(this IEnumerable<T> listA, IEnumerable<T> listB,
                                                Func<T, T, bool> lambda)
      {
          return listA.Intersect(listB, new Comparer<T>(lambda));
      }

        public static IEnumerable<TSource> DistinctBy<TSource, TKey> (this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
        {
            HashSet<TKey> seenKeys = new HashSet<TKey>();
            foreach (TSource element in source)
            {
                if (seenKeys.Add(keySelector(element)))
                {
                    yield return element;
                }
            }
        }
    }

  public class Comparer<T> : IEqualityComparer<T>
  {
      private readonly Func<T, T, bool> _expression;

      public Comparer(Func<T, T, bool> lambda)
      {
          _expression = lambda;
      }

      public bool Equals(T x, T y)
      {
          return _expression(x, y);
      }

      public int GetHashCode(T obj)
      {
          /*
           If you just return 0 for the hash the Equals comparer will kick in. 
           The underlying evaluation checks the hash and then short circuits the evaluation if it is false.
           Otherwise, it checks the Equals. If you force the hash to be true (by assuming 0 for both objects), 
           you will always fall through to the Equals check which is what we are always going for.
          */
          return 0;
      }
  }

    public static class GenericListExtension
    {
        public static T NextOf<T>(this IList<T> list, T item)
        {
            return list[(list.IndexOf(item) + 1) == list.Count ? 0 : (list.IndexOf(item) + 1)];
        }
    }
}
