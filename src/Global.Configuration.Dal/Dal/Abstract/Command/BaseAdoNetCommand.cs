using System.Collections.Generic;
using Terrasoft.Core;
using Terrasoft.Core.DB;

namespace Global.Configuration.Dal.Abstract.Command
{
    public abstract class BaseAdoNetCommand : BaseDBCommand<IDBCommand>
    {
        protected BaseAdoNetCommand(UserConnection userConnection, Dictionary<string, object> arguments = default) : base(userConnection, arguments) { }

        public override void Execute()
        {            
            Command.Execute();
        }
    }
}
