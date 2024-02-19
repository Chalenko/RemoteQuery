﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoteQuery
{
    public interface IConnectionStringType
    {
        string GetConnectionString(string serverName, string dbName, string userName, string userPassword);
        UserNameState GetUserNameState();

        UserPasswordState GetUserPasswordState();
    }

    public abstract class ConnectionStringType : IConnectionStringType
    {
        internal readonly string _ConnectionString;

        public string DisplayName { get; protected set; }

        public string ServerName { get; set; }
        public string DBName { get; set; }
        public string UserName { get; set; }
        public string UserPassword { get; set; }

        public ConnectionStringType(string connectionString)
        {
            _ConnectionString = connectionString;
        }

        public abstract string GetConnectionString(string serverName, string dbName, string userName, string userPassword);
        public abstract UserNameState GetUserNameState();
        public abstract UserPasswordState GetUserPasswordState();

        public static SQLConnectionStringType SQLConnectionStringType 
        {
            get
            {
                return SQLConnectionStringType.Instance;
            }
        }

        public static WindowsConnectionStringType WindowsConnectionStringType
        {
            get
            {
                return WindowsConnectionStringType.Instance;
            }
        }
    }

    public class SQLConnectionStringType : ConnectionStringType
    {
        protected static SQLConnectionStringType _instance;

        private SQLConnectionStringType() : base("Data Source={0}; Initial Catalog={1}; User ID={2}; Password={3}; Timeout=60000;") 
        {
            DisplayName = "SQL"; 
        }

        public static SQLConnectionStringType Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new SQLConnectionStringType();
                return _instance;
            }
        }

        public override string GetConnectionString(string serverName, string dbName, string userName, string userPassword)
        {
           return string.Format(_ConnectionString, serverName, dbName, userName, userPassword);
        }

        public override UserNameState GetUserNameState() => new UserNameState() { IsEditable = true, Name = string.Empty };
        public override UserPasswordState GetUserPasswordState() => new UserPasswordState() { IsEditable = true, Password = string.Empty };
    }

    public class WindowsConnectionStringType : ConnectionStringType
    {
        protected static WindowsConnectionStringType _instance;

        private WindowsConnectionStringType() : base("Data Source={0}; Initial Catalog={1}; Integrated Security=True; Timeout=60000;") 
        {
            DisplayName = "Windows"; 
        }

        public static WindowsConnectionStringType Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new WindowsConnectionStringType();
                return _instance;
            }
        }

        public override string GetConnectionString(string serverName, string dbName, string userName, string userPassword)
        {
            return string.Format(_ConnectionString, serverName, dbName);
        }

        public override UserNameState GetUserNameState() => new UserNameState() { IsEditable = false, Name = string.Format("{0}\\{1}", Environment.UserDomainName, Environment.UserName) };
        public override UserPasswordState GetUserPasswordState() => new UserPasswordState() { IsEditable = false, Password = string.Empty };
    }

    public class UserNameState
    {
        public bool IsEditable { get; set; }
        public string Name { get; set; }
    }

    public class UserPasswordState
    {
        public bool IsEditable { get; set; }
        public string Password { get; set; }
    }
}
