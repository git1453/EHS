using Oracle.ManagedDataAccess.Client;
using System;
using System.Data;
using System.Data.SqlClient;

namespace EHSENTITY.HR
{
    public class HRSQL : IHR
    {
        private string connectionString = "server=192.168.3.186;database=HRMS;uid=sa;pwd=shenma@0903$";
        private string strsql = @"select a.Badge,a.name,a.GENDER,f.title as xl,
a.BIRTHDAY,b.title as branch,c.title as dep,e.JobTitle as jobName,e.DepAbbr1,e.DepAbbr2,e.DepAbbr3,e.DepAbbr4,e.JoinDate,h.Photo
from[HRMS].[dbo].[evw_employee] as a
left join[HRMS].[dbo].[evw_employee_port] as e on a.Badge=e.Badge
left join[HRMS].[dbo].[OCOMPANY] as b on a.compid=b.compid
left join[HRMS].[dbo].[ODEPARTMENT] as c on a.depid=c.depid
left join[HRMS].[dbo].[ECD_EDUTYPE]  as f on a.HIGHLEVEL=f.id
left join[HRMS].[dbo].[ePhoto]  as h on a.eid=h.eid";


        public DataSet GetDataSet()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(strsql, connection);
            SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
            DataSet dataSet = new DataSet();
            dataAdapter.Fill(dataSet);
            return dataSet;
        }

        public DataSet TestDataSet()
        {
            DataSet dataSet = new DataSet();
            DataTable dt = new DataTable("HRMS");
            dt.Columns.Add(new DataColumn("badge", typeof(int)));
            dt.Columns.Add(new DataColumn("name", typeof(string)));
            dt.Columns.Add(new DataColumn("GENDER", typeof(int)));
            dt.Columns.Add(new DataColumn("xl", typeof(string)));
            dt.Columns.Add(new DataColumn("BIRTHDAY", typeof(DateTime)));
            dt.Columns.Add(new DataColumn("branch", typeof(string)));
            dt.Columns.Add(new DataColumn("dep", typeof(string)));
            dt.Columns.Add(new DataColumn("jobName", typeof(string)));
            dt.Columns.Add(new DataColumn("JoinDate", typeof(DateTime)));
            dt.Columns.Add(new DataColumn("Photo", typeof(byte[])));
            for (int i = 1; i < 20; i++)
            {
                Random ramdon = new Random();
                DataRow dr = dt.NewRow();
                dr["badge"] = 1234 + i;
                dr["name"] = "测试" + 1234 + i;
                dr["GENDER"] = i % 2;
                dr["xl"] = "d";
                dr["BIRTHDAY"] = DateTime.Now;
                dr["branch"] = "事业部" + i % 3;
                dr["dep"] = "部门" + i % 5;
                dr["jobName"] = "工作" + i;
                dr["joinDate"] = DateTime.Now;
                dr["Photo"] = 1001;
                dt.Rows.Add(dr);
            }
            DataRow dr1 = dt.NewRow();
            dr1["badge"] = 1234;
            dr1["name"] = "神马";
            dr1["GENDER"] = 1;
            dr1["xl"] = "d";
            dr1["BIRTHDAY"] = DateTime.Now;
            dr1["branch"] = "事业部";
            dr1["dep"] = "部门";
            dr1["jobName"] = "工作";
            dr1["joinDate"] = DateTime.Now;
            dr1["Photo"] = 1001;
            dt.Rows.Add(dr1);

            DataRow dr2 = dt.NewRow();
            dr2["badge"] = 12345;
            dr2["name"] = "成贤";
            dr2["GENDER"] = 2;
            dr2["xl"] = "d";
            dr2["BIRTHDAY"] = DateTime.Now;
            dr2["branch"] = "事业部";
            dr2["dep"] = "部门";
            dr2["jobName"] = "工作";
            dr2["joinDate"] = DateTime.Now;
            dr2["Photo"] = 1001;
            dt.Rows.Add(dr2);
            dataSet.Tables.Add(dt);
            return dataSet;
        }



    }

}
