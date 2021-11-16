using Dapper;
using Dapper_Project.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Dapper_Project.Repository
{
    public class CustRepository
    {
        public SqlConnection con;
        //private object objCust;

        //To Handle connection related activities      
        private void connection()
        {
            var constr = ConfigurationManager.ConnectionStrings["SqlConn"].ConnectionString;
            con = new SqlConnection(constr);
        }
        public void AddNewcustDetails(CustModel objCust)
        {
            try
        {
                connection();
                con.Open();
                con.Execute("AddNewcustDetails", objCust, commandType: CommandType.StoredProcedure);
                con.Close();
            }
        catch (Exception ex)
            {

                throw ex;
            }
        }
        public List<CustModel> GetAllCustDetails()
        {
            try
            {
                connection();
                con.Open();
                IList<CustModel> CustList = SqlMapper.Query<CustModel>(
                                  con, "GetCustomer").ToList();
                con.Close();
                return CustList.ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }
        public void UpdateCustDetails(CustModel objUpdate)
        {
            try
            {
                connection();
                con.Open();
                con.Execute("UpdateCustDetails", objUpdate, commandType: CommandType.StoredProcedure);
                con.Close();
            }
            catch (Exception)
            {

                throw;
            }

        }
        public bool DeletecustById(int Id)
        {
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@CustId", Id);
                connection();
                con.Open();
                con.Execute("DeleteCustById", param, commandType: CommandType.StoredProcedure);
                con.Close();
                return true;
            }
            catch (Exception ex)
            {
                //Log error as per your need       
                throw ex;
            }
        }
    }
}