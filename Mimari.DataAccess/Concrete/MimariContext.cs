using Mimari.Ado.Concrete;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mimari.DataAccess.Concrete
{
    public class MimariContext : IDisposable
    {
        protected string _connString = null;
        protected SqlConnection _conn = null;



        public MimariContext()
        {
            Connect();
        }

        protected void Connect()
        {
            _conn = new SqlConnection(ConfigurationManager.ConnectionStrings["baglanti"].ToString());
            _conn.Open();
        }

        public object ExecNonQueryProc(string proc, params object[] args)
        {
            using (SqlCommand cmd = CreateCommand(proc, args))
            {
                return cmd.ExecuteNonQuery();
            }

        }

        protected SqlCommand CreateCommand(string qry, params object[] args)
        {
            int count = 0;
            int i = 0;
            SqlCommand cmd = new SqlCommand(qry, _conn);

            if (args.Count() != 0)
            {
                count = ((System.Collections.Generic.Dictionary<string, object>)args[0]).Count;
                foreach (Dictionary<string, object> item in args)
                {
                    foreach (var item1 in item)
                    {
                        if (i < count)
                        {
                            SqlParameter parm = new SqlParameter();
                            parm.ParameterName = item1.Key;
                            parm.Value = item1.Value;
                            cmd.Parameters.Add(parm);
                            i++;
                        }
                    }


                }
            }
            
            return cmd;
        }


        //public SqlDataReader ExecDataReaderProc(string proc, params object[] args)
        //{
        //    using (SqlCommand cmd = CreateCommand(proc, args))
        //    {
        //        return cmd.ExecuteReader();
        //    }
        //}

        public DataSet ExecDataReaderProc(string proc,params object[] args)
        {
            using (SqlCommand cmd = CreateCommand(proc,args))
            {

                
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                sqlDataAdapter.Fill(ds);
                return ds;
            }
        }

        //public DataSet ExecDataReaderProc(string proc)
        //{
        //    using (SqlCommand cmd = CreateCommand(proc))
        //    {
        //        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
        //        DataSet ds = new DataSet();
        //        sqlDataAdapter.Fill(ds);
        //        return ds;
        //    }
        //}

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
