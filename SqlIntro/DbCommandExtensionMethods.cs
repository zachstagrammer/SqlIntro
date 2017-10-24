﻿using System.Data;

namespace SqlIntro
{
    public static class DbCommandExtensionMethods
    {
        public static void AddParam(this IDbCommand command, string name, object value)
        {
            var parameter = command.CreateParameter();
            parameter.ParameterName = name;
            parameter.Value = value;
            command.Parameters.Add(parameter);
        }
    }
}
