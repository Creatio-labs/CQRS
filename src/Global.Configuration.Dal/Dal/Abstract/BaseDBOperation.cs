using System;
using System.Collections.Generic;
using System.Linq;
using Terrasoft.Core;

namespace Global.Configuration.Dal.Abstract
{
    public abstract class BaseDBOperation
    {
        protected BaseDBOperation(UserConnection userConnection, Dictionary<string, object> arguments = default)
        {
            UserConnection = userConnection;
            InstantiateArguments(arguments);
        }

        protected UserConnection UserConnection { get; private set; }

        protected Dictionary<string, object> OperationArguments { get; private set; }

        private void InstantiateArguments(Dictionary<string, object> arguments = default)
        {
            if (!IsArgumentsValid(arguments))
            {
                throw new ArgumentException("Arguments dictionary is not valid");
            }
            OperationArguments = arguments;
        }

        protected virtual List<string> GetRequiredOperationArguments()
        {
            return new List<string>();
        }

        protected virtual bool IsArgumentsValid(Dictionary<string, object> arguments = default)
        {
            var requiredArgs = GetRequiredOperationArguments();
            return requiredArgs != null && requiredArgs.Any() && (arguments == null || !arguments.Any())
                ? false
                : arguments == null || arguments.Keys.All(i => requiredArgs.Contains(i));
        }
    }
}
