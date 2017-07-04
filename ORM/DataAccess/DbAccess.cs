﻿using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

using ORM.Factories;
using ORM.DataAttributes;
using ORM.Libs;
using ORM.Expressions;

namespace ORM.DataAccess
{
    class DbAccess
    {
        private DbFactory factory = null;
        private DbConnection conn = null;
        private ConnectionString connString = null;

        internal DbFactory DbFactory { get => factory; set => factory = value; }
        internal ConnectionString ConnectionString { get => connString; set => connString = value; }

        public DbAccess(DbFactory dbFactory)
        {
            this.factory = dbFactory;
        }

        /// <summary>
        ///     Initialize connection to database
        /// </summary>
        /// <returns>True - Initialize succeed; False - Initialize fail</returns>
        public bool OpenConnection()
        {
            try
            {
                conn = factory.GetConnection();
                conn.ConnectionString = connString.ToString();
                conn.Open();
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        ///     Initialize connection to database
        /// </summary>
        /// <param name="connectionString">Connection string needs to establish connection</param>
        /// <returns>True - Initialize succeed; False - Initialize fail</returns>
        public bool OpenConnection(ConnectionString connectionString)
        {
            this.connString = connectionString;
            return OpenConnection();
        }

        /// <summary>
        ///     Close the connection
        /// </summary>
        /// <returns>True - Close succeed; False - Close fail</returns>
        public bool CloseConnection()
        {
            if (conn != null)
            {
                conn.Close();
                return true;
            }
            return false;
        }

        /// <summary>
        ///     Insert data to a database table
        /// </summary>
        /// <param name="dataObject">Object needs to insert</param>
        /// <param name="tableName">Name of the table</param>
        /// <returns>True - Insert succeed; False - Insert Fail</returns>
        public bool Insert(IDataModel dataObject,  string tableName)
        {
            try
            {
                string columns = "";
                string values = "";
                
                Type type = dataObject.GetType();
                FieldInfo[] fields = type.GetFields(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
                foreach (FieldInfo field in fields)
                {
                    Attribute attr = Attribute.GetCustomAttribute(field, typeof(ColumnAttribute));
                    columns += attr.ToString() + ",";
                    values += Util.FormatSqlValue(field.GetValue(dataObject)) + ",";
                }
                columns = columns.TrimEnd(',');
                values = values.TrimEnd(',');

                string insertString = $"INSERT INTO {tableName} ({columns}) VALUES ({values})";
                
                DbCommand cmd = factory.GetCommand();
                cmd.Connection = conn;
                cmd.CommandText = insertString;

                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        ///     Update data table
        /// </summary>
        /// <param name="dataObject">Object needs to update</param>
        /// <param name="tableName">Name of the table</param>
        /// <param name="exp">Expression of WHERE clause</param>
        /// <returns>True - Update succeed; False - Update fail</returns>
        public bool Update(IDataModel dataObject, string tableName, Expression exp)
        {
            try
            {
                string setValues = "";

                Type type = dataObject.GetType();
                FieldInfo[] fields = type.GetFields(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
                foreach (FieldInfo field in fields)
                {
                    Attribute attr = Attribute.GetCustomAttribute(field, typeof(ColumnAttribute));
                    setValues += attr.ToString() + "=" + Util.FormatSqlValue(field.GetValue(dataObject)) + ",";
                }
                setValues = setValues.TrimEnd(',');

                string updateString = $"UPDATE {tableName} SET {setValues} WHERE {exp.ToString()}";

                DbCommand cmd = factory.GetCommand();
                cmd.Connection = conn;
                cmd.CommandText = updateString;

                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        ///     Delete data from table
        /// </summary>
        /// <param name="tableName">Name of the table</param>
        /// <param name="exp">Expression of WHERE clause</param>
        /// <returns>True - Delete succeed; False - Delete fail</returns>
        public bool Delete(string tableName, Expression exp = null)
        {
            try
            {
                string deleteString = (exp == null) ? $"DELETE FROM {tableName}"
                        : $"DELETE FROM {tableName} WHERE {exp.ToString()}";

                DbCommand cmd = factory.GetCommand();
                cmd.Connection = conn;
                cmd.CommandText = deleteString;

                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dataObjectType"></param>
        /// <param name="tableName"></param>
        /// <param name="exp"></param>
        /// <returns></returns>
        public List<IDataModel> Select<T>(Type dataObjectType, string tableName, Expression exp = null)
        {
            List<IDataModel> list = new List<IDataModel>();
            DbDataReader dataReader = null;

            try
            {
                string columns = "";
                FieldInfo[] fields = dataObjectType.GetFields(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);

                foreach (FieldInfo field in fields)
                {
                    Attribute attr = Attribute.GetCustomAttribute(field, typeof(ColumnAttribute));
                    columns += attr.ToString() + ",";
                }
                columns = columns.TrimEnd(',');
                
                string selectString = (exp == null) ? $"SELECT {columns} FROM {tableName}" :
                        $"SELECT {columns} FROM {tableName} WHERE {exp.ToString()}";

                DbCommand cmd = factory.GetCommand();
                cmd.Connection = conn;
                cmd.CommandText = selectString;

                dataReader = cmd.ExecuteReader();

                while (dataReader.Read())
                {
                    T dataObject = (T)Activator.CreateInstance(dataObjectType);
                    for (int i = 0; i < dataReader.FieldCount; i++)
                    {
                        foreach (FieldInfo field in fields)
                        {
                            Attribute attr = Attribute.GetCustomAttribute(field, typeof(ColumnAttribute));
                            if (attr.ToString() == dataReader.GetName(i))
                            {
                                field.SetValue(dataObject, dataReader[i]);
                            }
                        }
                    }
                    list.Add((IDataModel) dataObject);
                }
            }
            catch (Exception)
            {
                
            }
            finally
            {
                if (dataReader != null)
                {
                    dataReader.Close();
                }
            }
            return list;
        }
    }
}
