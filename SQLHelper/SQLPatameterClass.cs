using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLHelper
{
    public class SQLPatameterClass
    {
        public SqlParameter[] ConvertClassToSQLParams(object obj)
        {
            var props = (from p in obj.GetType().GetProperties() select new { Property = p }).ToList();

            SqlParameter[] param = new SqlParameter[props.Count];

            for (int i = 0; i < props.Count; i++)
            {
                param[i] = new SqlParameter("@" + props[i].Property.Name, props[i].Property.GetValue(obj) ?? DBNull.Value);
            }

            //props.ForEach(p =>
            //{
            //    var pinfo = new QueryParamInfo();
            //    pinfo.Name = p.Property.Name.Replace("@", "");
            //    pinfo.Value = p.Property.GetValue(obj) ?? DBNull.Value;

            //    var sqlParam = new SqlParameter(pinfo.Name, p.Property.PropertyType)
            //    {
            //        Value = pinfo.Value
            //    };

            //    result.Add(sqlParam);
            //});

            return param;
        }
    }
}
