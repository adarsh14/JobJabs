using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Reflection;
using JobJabs.Entity;

namespace JobJabs.BAL
{
   public class Business
    {
        protected static List<T> ConvertToList<T>(DataTable dt)
        {
            var columnNames = dt.Columns.Cast<DataColumn>()
                .Select(c => c.ColumnName.ToLower())
                .ToList();

            var properties = typeof(T).GetProperties();

            return dt.AsEnumerable().Select(row =>
            {
                var objT = Activator.CreateInstance<T>();

                foreach (var pro in properties)
                {
                    if (columnNames.Contains(pro.Name.ToLower()))
                    {
                        SetPropertyValue(row, pro, objT);
                    }
                }

                return objT;
            }).ToList();

        }

        protected static List<T> ConvertToListByAttribute<T>(DataTable dt)
        {
            var columnNames = dt.Columns.Cast<DataColumn>()
                .Select(c => c.ColumnName.ToLower())
                .ToList();

            var properties = typeof(T).GetProperties();

            return dt.AsEnumerable().Select(row =>
            {
                var objT = Activator.CreateInstance<T>();

                foreach (var pro in properties)
                {
                    string propName;
                    try
                    {
                        propName = Convert.ToString(pro.GetCustomAttributesData()[0].ConstructorArguments[0].Value);
                    }
                    catch (Exception e)
                    {
                        e = null;
                        propName = pro.Name;
                    }

                    if (columnNames.Contains(propName.ToLower()))
                    {
                        SetPropertyValue(row, pro, objT);
                    }
                }

                return objT;
            }).ToList();

        }

        protected static void SetPropertyValue(DataRow row, PropertyInfo pro, dynamic objT)
        {
            if (pro.PropertyType.Name.ToLower() == "datetime" || row[pro.Name].GetType().Name.ToLower() == "datetime")
                pro.SetValue(objT, row.ConvertToDateTime(pro.Name), null);
            else if (pro.PropertyType.Name.ToLower() == "int32" || row[pro.Name].GetType().Name.ToLower() == "int")
                pro.SetValue(objT, row.ConvertToInt32(pro.Name), null);
            else if (pro.PropertyType.Name.ToLower() == "decimal" || row[pro.Name].GetType().Name.ToLower() == "decimal")
                pro.SetValue(objT, row.ConvertToDecimal(pro.Name), null);
            else if (pro.PropertyType.Name.ToLower() == "boolean" || row[pro.Name].GetType().Name.ToLower() == "boolean")
                pro.SetValue(objT, row.ConvertToBoolean(pro.Name), null);
            else
                pro.SetValue(objT, row.ConvertToString(pro.Name), null);
        }

        protected static dynamic ConvertToList(DataTable dt,string className)
        {
            var columnNames = dt.Columns.Cast<DataColumn>()
                .Select(c => c.ColumnName.ToLower())
                .ToList();
            var type = MagicallyGetType(className);
            var properties = type.GetProperties();

            return dt.AsEnumerable().Select(row =>
            {
                var objT = Activator.CreateInstance(type); 

                foreach (var pro in properties)
                {
                    if (columnNames.Contains(pro.Name.ToLower()))
                    {
                        SetPropertyValue(row, pro, objT);
                    }
                }

                return objT;
            }).ToList();

        }

        //private static object MagicallyCreateInstance(string className)
        //{
        //    var assembly = Assembly.GetExecutingAssembly();

        //    var type = assembly.GetTypes()
        //        .First(t => t.Name == className);

        //    return Activator.CreateInstance(type);
        //}

        private static Type MagicallyGetType(string className)
        {
            //var assembly = Assembly.GetExecutingAssembly();
            //return assembly.GetTypes()
            //    .First(t => t.Name == className);

          return Assembly.GetExecutingAssembly().GetReferencedAssemblies() .Select(x => Assembly.Load(x))
                .SelectMany(x => x.GetTypes()).First(x => x.FullName == className);
        }

      
    }
}
