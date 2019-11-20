using Global.Configuration.Dal.Abstract.Command.Interfaces;
using System;
using System.Collections.Generic;
using Terrasoft.Core;

namespace Global.Configuration.Dal.Abstract.Command
{
    public abstract class BaseDBCommand<TCommandType> : BaseDBOperation, IDBCommand
    {
        protected BaseDBCommand(UserConnection userConnection, Dictionary<string, object> arguments = default) : base(userConnection, arguments)
        {
            InstantiateCommand();
        }

        protected TCommandType Command { get; private set; }

        private void InstantiateCommand()
        {
            var command = GetCommand();
            if (command == null)
            {
                throw new ArgumentNullException("Command cannot be null");
            }
            Command = command;
        }

        protected abstract TCommandType GetCommand();

        public abstract void Execute();
    }
}
