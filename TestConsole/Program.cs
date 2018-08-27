using CoreHelpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using TestConsole.Models;

namespace TestConsole
{
    class Program
    {
        private static object getValue(DataRow row, DataColumnCollection columns, string propertyName)
        {

            foreach (DataColumn c in row.Table.Columns)
            {
                string name = c.ColumnName;
            }
            for (int i = 0; i < columns.Count; i++)
            {
                if (columns[i].ColumnName == propertyName)
                {
                    if (Type.GetType(row.Table.Columns[i].ColumnName) == typeof(string))
                    {
                        return row[i].ToString();
                    }
                    else if (Type.GetType(row.Table.Columns[i].ColumnName) == typeof(int))
                    {
                        return (int)row[i];
                    }
                    else if (Type.GetType(row.Table.Columns[i].ColumnName) == typeof(decimal))
                    {
                        return (decimal)row[i];
                    }
                    else if (Type.GetType(row.Table.Columns[i].ColumnName) == typeof(DateTime))
                    {
                        return (DateTime)row[i];
                    }
                }
            }

            return null;
        }


        static void Main(string[] args)
        {
            SQLAdo sql = new SQLAdo(@"Data Source=CT1313\SQLEXPRESS;Initial Catalog=Events;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

            var reader = sql.GetDataReader("SELECT * FROM CUSTOMER",
                new List<DbParameter>() { }, System.Data.CommandType.Text);

            var singleCustomer = Mapper.Map<CustomerDTO>(new CustomerDTO(), reader);



        }
    }
}
