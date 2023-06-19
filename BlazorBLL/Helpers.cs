using BlazorDAL.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BlazorBLL
{
    public static class Helper
    {
        public static string ToSqlOrderBy(this IBaseParam obj, string select = null, string sortField = null, int? order = null)
        {
            if (!string.IsNullOrEmpty(sortField))
                obj.SortField = sortField;

            if (order != null)
                obj.SortOrder = order;

            string tableName = null;

            if (select != null)
                tableName = GetTableName(select, obj.SortField);


            string col;
            if (string.IsNullOrEmpty(obj.SortField))
                col = "1";
            else
                col = string.IsNullOrEmpty(tableName) ? obj.SortField : tableName + "." + obj.SortField;


            return $" ORDER BY {col} {(obj.SortOrder == 1 ? "ASC" : "DESC")} ";
        }
        private static string GetTableName(string select, string col)
        {
            if (string.IsNullOrEmpty(col))
            {
                return null;
            }
            string tableName = "";
            var cursor = select.IndexOf(col) - 1;
            if (cursor < 0 || select[cursor] != '.')
                return "";
            while (cursor != 0)
            {
                cursor--;
                if (char.IsLetterOrDigit(select[cursor]))
                    tableName = select[cursor] + tableName;
                else
                    break;
            }
            return tableName;
        }
        public static string ToSqlWhere<T>(this T obj, string select = null)
        {
            var sql = new StringBuilder(" WHERE 1=1");
            var basePropsName = typeof(BaseParameter)
                //.GetProperties(BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.Instance)
                .GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .Select(x => x.Name);
            var props = typeof(T)
                //.GetProperties(BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.Instance)
                .GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .Where(x => x.GetValue(obj) != null && !basePropsName.Contains(x.Name))
                .ToList();

            foreach (var prop in props)
            {
                var colName = select == null ? prop.Name : $"{GetTableName(select, prop.Name)}.{prop.Name}";
                sql.Append($" AND {colName} {GetOperatorByType(prop)} {GetValueByType(obj, prop)}");
            }
            return sql.ToString();
        }
        private static string GetValueByType<IBaseParam>(IBaseParam obj, PropertyInfo prop)
        {
            if (
                prop.PropertyType == typeof(short) ||
                prop.PropertyType == typeof(short?) ||
                prop.PropertyType == typeof(int) ||
                prop.PropertyType == typeof(int?) ||
                prop.PropertyType == typeof(long) ||
                prop.PropertyType == typeof(long?) ||
                prop.PropertyType == typeof(byte) ||
                prop.PropertyType == typeof(byte?)
               )
            {
                return prop.GetValue(obj).ToString();
            }
            else if (
                prop.PropertyType == typeof(float) ||
                prop.PropertyType == typeof(float?))
            {
                var val = ((float)prop.GetValue(obj)).ToString(CultureInfo.CreateSpecificCulture("en"));
                return val;
            }
            else if (
                prop.PropertyType == typeof(double) ||
                prop.PropertyType == typeof(double?))
            {
                var val = ((double)prop.GetValue(obj)).ToString(CultureInfo.CreateSpecificCulture("en"));
                return val;
            }
            else if (prop.PropertyType == typeof(bool) || prop.PropertyType == typeof(bool?))
            {
                return (bool)prop.GetValue(obj) ? "1" : "0";
            }
            else
            {
                return $"'%{prop.GetValue(obj)}%'";
            }
        }

        private static string GetOperatorByType(PropertyInfo prop)
        {
            if (prop.PropertyType == typeof(string))
            {
                return "LIKE";
            }
            else
            {
                return "=";
            }
        }



    }
}
