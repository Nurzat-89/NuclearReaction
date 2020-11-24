using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace KazNuclide.Models
{
    public class BaseDataTable<T> where T:class
    {
        public DataTable Table { get; set; }
        public List<T> Data { get; set; }
        public string Name => Table.TableName;
        public BaseDataTable(string name)
        {
            Table = new DataTable(name);
            Data = new List<T>();
            InitTable();
        }
        public virtual void InitTable() 
        {
            Type t = typeof(T);
            PropertyInfo[] properties = t.GetProperties();
            foreach (var property in properties)
            {
                var tt = property.PropertyType;
                if (tt == typeof(int) || tt == typeof(double) || tt == typeof(string))
                    Table.Columns.Add(property.Name, tt);
            }
        }
        public virtual void FillTable(List<T> data) 
        {
            foreach (var d in data)
            {
                DataRow row = Table.NewRow();
                var values = getTypeValues(d);
                foreach (var keyValue in values)
                {
                    row[keyValue.Key] = keyValue.Value;
                }
                Table.Rows.Add(row);
            }

        }
        private Dictionary<string, object> getTypeValues(object atype)
        {
            if (atype == null) return new Dictionary<string, object>();
            Type t = atype.GetType();
            PropertyInfo[] props = t.GetProperties();
            Dictionary<string, object> values = new Dictionary<string, object>();
            foreach (PropertyInfo prp in props)
            {
                var tt = prp.PropertyType;
                if (tt == typeof(int) || tt == typeof(double) || tt == typeof(string))
                {
                    object value = prp.GetValue(atype, new object[] { });
                    values.Add(prp.Name, value);
                }
                    
            }
            return values;
        }
    }
}
