using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLClass;
using SQLHelper;

namespace SQLLogic
{
    public class ADMHeaderLogic
    {
        public MEMBERS.SQLReturnValue ADMHeader_Insert_Update(ADMHeaderClass model)
        {
            return new SqlHelper().ExecuteProceduerWithValueSpecial("ADMHeader_Insert_Update", model);
        }

        public object ADMHeader_Get_GetAll(long ADMIDP,bool? IsActive)
        {
            return new SqlHelper().GetJsonResult("ADMHeader_Get_GetAll", new object[,] { { "ADMIDP", ADMIDP }, { "IsActive", IsActive } });
        }

        public MEMBERS.SQLReturnValue ADMHeader_GeneralAction(long ADMIDP, int ActionType)
        {
            return new SqlHelper().ExecuteProceduerWithValue("ADMHeader_GeneralAction", new object[,] { { "ADMIDP", ADMIDP }, { "ActionType", ActionType } }, 3);
        }
    }
}
