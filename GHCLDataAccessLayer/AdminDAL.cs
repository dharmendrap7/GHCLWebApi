using System;
using System.Data;
using System.Data.SqlClient;
using GHCLEntityLayer;
using System.Collections.Generic;
using System.Linq;

namespace GHCLDataAccessLayer
{
    public class AdminDAL
    {
        #region Variable Declaration
        SqlConnection connection = null;
        #endregion

        #region ZoneMethods
        public bool AddZone(Zone zone)
        {
            bool isSuccess = false;
            try
            {
                connection = SQLConnection.GetConnection();
                SqlParameter[] spParams = new SqlParameter[]
                {
                   new SqlParameter("@ZoneName",zone.ZoneName),
                   new SqlParameter("@IsActive",zone.IsActive),
                   new SqlParameter("@CreatedBy",zone.CreatedBy)
                };
                int result = Convert.ToInt32(SQLHelper.ExecuteNonQuery(connection, CommandType.StoredProcedure, SPName_Constants.AddZone, spParams));
                if (result > 0)
                {
                    isSuccess = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
                connection.Dispose();
            }
            return isSuccess;
        }

        /// <summary>
        /// To get all added universities and colleges.
        /// </summary>
        /// <returns></returns>
        public List<Zone> GetZones()
        {
            DataSet dsZones = null;
            List<Zone> zones = new List<Zone>();
            try
            {
                connection = SQLConnection.GetConnection();
                dsZones = new DataSet();
                dsZones = SQLHelper.ExecuteDataset(connection, CommandType.StoredProcedure, SPName_Constants.GetZones, null);
                if (dsZones != null && dsZones.Tables.Count > 0 && dsZones.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < dsZones.Tables[0].Rows.Count; i++)
                    {
                        Zone zone = new Zone();
                        if (dsZones.Tables[0].Rows[i]["Id"] != DBNull.Value)
                        {
                            zone.Id = Convert.ToInt32(dsZones.Tables[0].Rows[i]["Id"].ToString());
                        }
                        zone.ZoneName = dsZones.Tables[0].Rows[i]["ZoneName"].ToString();
                        if (dsZones.Tables[0].Rows[i]["IsActive"] != DBNull.Value)
                        {
                            zone.IsActive = Convert.ToBoolean(dsZones.Tables[0].Rows[i]["IsActive"].ToString());
                        }
                        zones.Add(zone);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
                connection.Dispose();
            }
            return zones;
        }

        #endregion

        #region StateMethods
        /// <summary>
        /// To add and update state
        /// </summary>
        /// <param name="state"></param>
        /// <returns></returns>
        public bool AddState(States state)
        {
            bool isSuccess = false;
            try
            {
                connection = SQLConnection.GetConnection();
                SqlParameter[] spParams = new SqlParameter[]
                {
                   new SqlParameter("@StateName",state.StateName),
                   new SqlParameter("@IsActive",state.IsActive),
                   new SqlParameter("@ZoneId",state.ZoneId),
                   new SqlParameter("@CreatedBy",state.CreatedBy)
                };
                int result = Convert.ToInt32(SQLHelper.ExecuteNonQuery(connection, CommandType.StoredProcedure, SPName_Constants.AddState, spParams));
                if (result > 0)
                {
                    isSuccess = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
                connection.Dispose();
            }
            return isSuccess;
        }

        /// <summary>
        /// To get all states
        /// </summary>
        /// <returns></returns>
        public List<States> GetStates()
        {
            DataSet dsStates = null;
            List<States> states = new List<States>();
            try
            {
                connection = SQLConnection.GetConnection();
                dsStates = new DataSet();
                dsStates = SQLHelper.ExecuteDataset(connection, CommandType.StoredProcedure, SPName_Constants.GetStates, null);
                if (dsStates != null && dsStates.Tables.Count > 0 && dsStates.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < dsStates.Tables[0].Rows.Count; i++)
                    {
                        States objState = new States();
                        if (dsStates.Tables[0].Rows[i]["Id"] != DBNull.Value)
                        {
                            objState.Id = Convert.ToInt32(dsStates.Tables[0].Rows[i]["Id"].ToString());
                        }
                        objState.StateName = dsStates.Tables[0].Rows[i]["StateName"].ToString();
                        if (dsStates.Tables[0].Rows[i]["IsActive"] != DBNull.Value)
                        {
                            objState.IsActive = Convert.ToBoolean(dsStates.Tables[0].Rows[i]["IsActive"].ToString());
                        }
                        if (dsStates.Tables[0].Rows[i]["ZoneId"] != DBNull.Value)
                        {
                            objState.ZoneId = Convert.ToInt32(dsStates.Tables[0].Rows[i]["ZoneId"].ToString());
                        }
                        objState.ZoneName = dsStates.Tables[0].Rows[i]["ZoneName"].ToString();
                        states.Add(objState);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
                connection.Dispose();
            }
            return states;
        }

        #endregion

        #region HeadQuaterMethods
        /// <summary>
        /// Add head quater.
        /// </summary>
        /// <param name="headQuater"></param>
        /// <returns></returns>
        public bool AddHeadQuater(HeadQuater headQuater)
        {
            bool isSuccess = false;
            try
            {
                connection = SQLConnection.GetConnection();
                SqlParameter[] spParams = new SqlParameter[]
                {
                   new SqlParameter("@HeadQuaterName",headQuater.HeadQuaterName),
                   new SqlParameter("@IsActive",headQuater.IsActive),
                   new SqlParameter("@StateId",headQuater.StateId),
                   new SqlParameter("@CreatedBy",headQuater.CreatedBy)
                };
                int result = Convert.ToInt32(SQLHelper.ExecuteNonQuery(connection, CommandType.StoredProcedure, SPName_Constants.AddHeadQuater, spParams));
                if (result > 0)
                {
                    isSuccess = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
                connection.Dispose();
            }
            return isSuccess;
        }

        /// <summary>
        /// To get head quaters.
        /// </summary>
        /// <returns></returns>
        public List<HeadQuater> GetHeadQuaters()
        {
            DataSet dsHeadQuater = null;
            List<HeadQuater> headquater = new List<HeadQuater>();
            try
            {
                connection = SQLConnection.GetConnection();
                dsHeadQuater = new DataSet();
                dsHeadQuater = SQLHelper.ExecuteDataset(connection, CommandType.StoredProcedure, SPName_Constants.GetHeadQuaters, null);
                if (dsHeadQuater != null && dsHeadQuater.Tables.Count > 0 && dsHeadQuater.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < dsHeadQuater.Tables[0].Rows.Count; i++)
                    {
                        HeadQuater objHeadQuater = new HeadQuater();
                        if (dsHeadQuater.Tables[0].Rows[i]["Id"] != DBNull.Value)
                        {
                            objHeadQuater.Id = Convert.ToInt32(dsHeadQuater.Tables[0].Rows[i]["Id"].ToString());
                        }
                        objHeadQuater.HeadQuaterName = dsHeadQuater.Tables[0].Rows[i]["HeadQuaterName"].ToString();
                        if (dsHeadQuater.Tables[0].Rows[i]["IsActive"] != DBNull.Value)
                        {
                            objHeadQuater.IsActive = Convert.ToBoolean(dsHeadQuater.Tables[0].Rows[i]["IsActive"].ToString());
                        }
                        if (dsHeadQuater.Tables[0].Rows[i]["StateId"] != DBNull.Value)
                        {
                            objHeadQuater.StateId = Convert.ToInt32(dsHeadQuater.Tables[0].Rows[i]["StateId"].ToString());
                        }
                        objHeadQuater.StateName = dsHeadQuater.Tables[0].Rows[i]["StateName"].ToString();
                        if (dsHeadQuater.Tables[0].Rows[i]["ZoneId"] != DBNull.Value)
                        {
                            objHeadQuater.ZoneId = Convert.ToInt32(dsHeadQuater.Tables[0].Rows[i]["ZoneId"].ToString());
                        }
                        objHeadQuater.ZoneName = dsHeadQuater.Tables[0].Rows[i]["ZoneName"].ToString();
                        headquater.Add(objHeadQuater);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
                connection.Dispose();
            }
            return headquater;
        }

        #endregion

        #region TownMethods
        /// <summary>
        /// To get all towns
        /// </summary>
        /// <returns></returns>
        public List<Town> GetTowns()
        {
            DataSet dsTowns = null;
            List<Town> towns = new List<Town>();
            try
            {
                connection = SQLConnection.GetConnection();
                dsTowns = new DataSet();
                dsTowns = SQLHelper.ExecuteDataset(connection, CommandType.StoredProcedure, SPName_Constants.GetTowns, null);
                if (dsTowns != null && dsTowns.Tables.Count > 0 && dsTowns.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < dsTowns.Tables[0].Rows.Count; i++)
                    {
                        Town objTown = new Town();
                        if (dsTowns.Tables[0].Rows[i]["Id"] != DBNull.Value)
                        {
                            objTown.Id = Convert.ToInt32(dsTowns.Tables[0].Rows[i]["Id"].ToString());
                        }
                        objTown.TownName = dsTowns.Tables[0].Rows[i]["TownName"].ToString();
                        if (dsTowns.Tables[0].Rows[i]["IsActive"] != DBNull.Value)
                        {
                            objTown.IsActive = Convert.ToBoolean(dsTowns.Tables[0].Rows[i]["IsActive"].ToString());
                        }
                        if (dsTowns.Tables[0].Rows[i]["HeadQuaterId"] != DBNull.Value)
                        {
                            objTown.HeadQuaterId = Convert.ToInt32(dsTowns.Tables[0].Rows[i]["HeadQuaterId"].ToString());
                        }
                        objTown.HeadQuaterName = dsTowns.Tables[0].Rows[i]["HeadQuaterName"].ToString();

                        if (dsTowns.Tables[0].Rows[i]["StateId"] != DBNull.Value)
                        {
                            objTown.StateId = Convert.ToInt32(dsTowns.Tables[0].Rows[i]["StateId"].ToString());
                        }
                        objTown.StateName = dsTowns.Tables[0].Rows[i]["StateName"].ToString();
                        if (dsTowns.Tables[0].Rows[i]["ZoneId"] != DBNull.Value)
                        {
                            objTown.ZoneId = Convert.ToInt32(dsTowns.Tables[0].Rows[i]["ZoneId"].ToString());
                        }
                        objTown.ZoneName = dsTowns.Tables[0].Rows[i]["ZoneName"].ToString();
                        towns.Add(objTown);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
                connection.Dispose();
            }
            return towns;
        }

        /// <summary>
        /// To add and update town.
        /// </summary>
        /// <param name="town"></param>
        /// <returns></returns>
        public bool AddTown(Town town)
        {
            bool isSuccess = false;
            try
            {
                connection = SQLConnection.GetConnection();
                SqlParameter[] spParams = new SqlParameter[]
                {
                   new SqlParameter("@TownName",town.TownName),
                   new SqlParameter("@IsActive",town.IsActive),
                   new SqlParameter("@HeadQuaterId",town.HeadQuaterId),
                   new SqlParameter("@CreatedBy",town.CreatedBy)
                };
                int result = Convert.ToInt32(SQLHelper.ExecuteNonQuery(connection, CommandType.StoredProcedure, SPName_Constants.AddTown, spParams));
                if (result > 0)
                {
                    isSuccess = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
                connection.Dispose();
            }
            return isSuccess;
        }
        #endregion

        #region AreaHeadMethods

        public List<AreaHead> GetAreaHeads()
        {
            DataSet dsAreaHeads = null;
            List<AreaHead> areaHeads = new List<AreaHead>();
            try
            {
                connection = SQLConnection.GetConnection();
                dsAreaHeads = new DataSet();
                dsAreaHeads = SQLHelper.ExecuteDataset(connection, CommandType.StoredProcedure, SPName_Constants.GetAreaHeads, null);
                if (dsAreaHeads != null && dsAreaHeads.Tables.Count > 0 && dsAreaHeads.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < dsAreaHeads.Tables[0].Rows.Count; i++)
                    {
                        AreaHead objAreaHead = new AreaHead();
                        if (dsAreaHeads.Tables[0].Rows[i]["Id"] != DBNull.Value)
                        {
                            objAreaHead.Id = Convert.ToInt32(dsAreaHeads.Tables[0].Rows[i]["Id"].ToString());
                        }
                        objAreaHead.AreaHeadName = dsAreaHeads.Tables[0].Rows[i]["AreaHeadName"].ToString();
                        if (dsAreaHeads.Tables[0].Rows[i]["IsActive"] != DBNull.Value)
                        {
                            objAreaHead.IsActive = Convert.ToBoolean(dsAreaHeads.Tables[0].Rows[i]["IsActive"].ToString());
                        }
                        if (dsAreaHeads.Tables[0].Rows[i]["HeadQuaterId"] != DBNull.Value)
                        {
                            objAreaHead.HeadQuaterId = Convert.ToInt32(dsAreaHeads.Tables[0].Rows[i]["HeadQuaterId"].ToString());
                        }
                        objAreaHead.HeadQuaterName = dsAreaHeads.Tables[0].Rows[i]["HeadQuaterName"].ToString();

                        if (dsAreaHeads.Tables[0].Rows[i]["StateId"] != DBNull.Value)
                        {
                            objAreaHead.StateId = Convert.ToInt32(dsAreaHeads.Tables[0].Rows[i]["StateId"].ToString());
                        }
                        objAreaHead.StateName = dsAreaHeads.Tables[0].Rows[i]["StateName"].ToString();
                        if (dsAreaHeads.Tables[0].Rows[i]["ZoneId"] != DBNull.Value)
                        {
                            objAreaHead.ZoneId = Convert.ToInt32(dsAreaHeads.Tables[0].Rows[i]["ZoneId"].ToString());
                        }
                        objAreaHead.ZoneName = dsAreaHeads.Tables[0].Rows[i]["ZoneName"].ToString();
                        areaHeads.Add(objAreaHead);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
                connection.Dispose();
            }
            return areaHeads;
        }

        /// <summary>
        /// To add area head.
        /// </summary>
        /// <param name="areaHead"></param>
        /// <returns></returns>
        public bool AddAreaHead(AreaHead areaHead)
        {
            bool isSuccess = false;
            string generatePassword = RandomCodeGenerator.RandomPassword();
            try
            {
                connection = SQLConnection.GetConnection();
                SqlParameter[] spParams = new SqlParameter[]
                {
                   new SqlParameter("@AreaHeadName",areaHead.AreaHeadName),
                   new SqlParameter("@HeadQuaterId",areaHead.HeadQuaterId),
                   new SqlParameter("@ContactNumber",areaHead.ContactNumber),
                   new SqlParameter("@Email",areaHead.Email),
                   new SqlParameter("@EmployeeId",areaHead.EmployeeId),
                   new SqlParameter("@IsActive",areaHead.IsActive),
                   new SqlParameter("@CreatedBy",areaHead.CreatedBy),
                   new SqlParameter("@Password",generatePassword),
                   new SqlParameter("@IsAdmin",areaHead.IsAdmin)
                };
                int result = Convert.ToInt32(SQLHelper.ExecuteNonQuery(connection, CommandType.StoredProcedure, SPName_Constants.AddAreaHead, spParams));
                if (result > 0)
                {
                    isSuccess = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
                connection.Dispose();
            }
            return isSuccess;
        }
        #endregion

        #region SalesOfficeMethods
        /// <summary>
        /// To get all sales officers.
        /// </summary>
        /// <returns></returns>
        public List<SalesOfficer> GetSalesOfficers()
        {
            DataSet dsSalesOfficer = null;
            List<SalesOfficer> salesOfficers = new List<SalesOfficer>();
            try
            {
                connection = SQLConnection.GetConnection();
                dsSalesOfficer = new DataSet();
                dsSalesOfficer = SQLHelper.ExecuteDataset(connection, CommandType.StoredProcedure, SPName_Constants.GetSalesOfficer, null);
                if (dsSalesOfficer != null && dsSalesOfficer.Tables.Count > 0 && dsSalesOfficer.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < dsSalesOfficer.Tables[0].Rows.Count; i++)
                    {
                        SalesOfficer objSalesOfficer = new SalesOfficer();
                        if (dsSalesOfficer.Tables[0].Rows[i]["Id"] != DBNull.Value)
                        {
                            objSalesOfficer.Id = Convert.ToInt32(dsSalesOfficer.Tables[0].Rows[i]["Id"].ToString());
                        }
                        objSalesOfficer.SalesOfficerName = dsSalesOfficer.Tables[0].Rows[i]["SalesOfficerName"].ToString();
                        if (dsSalesOfficer.Tables[0].Rows[i]["AreaHeadId"] != DBNull.Value)
                        {
                            objSalesOfficer.AreaHeadId = Convert.ToInt32(dsSalesOfficer.Tables[0].Rows[i]["AreaHeadId"].ToString());
                        }
                        objSalesOfficer.AreaHeadName = dsSalesOfficer.Tables[0].Rows[i]["AreaHeadName"].ToString();
                        if (dsSalesOfficer.Tables[0].Rows[i]["IsActive"] != DBNull.Value)
                        {
                            objSalesOfficer.IsActive = Convert.ToBoolean(dsSalesOfficer.Tables[0].Rows[i]["IsActive"].ToString());
                        }
                        if (dsSalesOfficer.Tables[0].Rows[i]["HeadQuaterId"] != DBNull.Value)
                        {
                            objSalesOfficer.HeadQuaterId = Convert.ToInt32(dsSalesOfficer.Tables[0].Rows[i]["HeadQuaterId"].ToString());
                        }
                        objSalesOfficer.HeadQuaterName = dsSalesOfficer.Tables[0].Rows[i]["HeadQuaterName"].ToString();

                        if (dsSalesOfficer.Tables[0].Rows[i]["StateId"] != DBNull.Value)
                        {
                            objSalesOfficer.StateId = Convert.ToInt32(dsSalesOfficer.Tables[0].Rows[i]["StateId"].ToString());
                        }
                        objSalesOfficer.StateName = dsSalesOfficer.Tables[0].Rows[i]["StateName"].ToString();
                        if (dsSalesOfficer.Tables[0].Rows[i]["ZoneId"] != DBNull.Value)
                        {
                            objSalesOfficer.ZoneId = Convert.ToInt32(dsSalesOfficer.Tables[0].Rows[i]["ZoneId"].ToString());
                        }
                        objSalesOfficer.ZoneName = dsSalesOfficer.Tables[0].Rows[i]["ZoneName"].ToString();
                        salesOfficers.Add(objSalesOfficer);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
                connection.Dispose();
            }
            return salesOfficers;
        }

        /// <summary>
        /// To add Sales Officer.
        /// </summary>
        /// <param name="salesOfficer"></param>
        /// <returns></returns>
        public bool AddSalesOfficer(SalesOfficer salesOfficer)
        {
            bool isSuccess = false;
            string generatePassword = RandomCodeGenerator.RandomPassword();
            try
            {
                connection = SQLConnection.GetConnection();
                SqlParameter[] spParams = new SqlParameter[]
                {
                   new SqlParameter("@SalesOfficerName",salesOfficer.SalesOfficerName),
                   new SqlParameter("@AreaHeadId",salesOfficer.AreaHeadId),
                   new SqlParameter("@ContactNumber",salesOfficer.ContactNumber),
                   new SqlParameter("@Email",salesOfficer.Email),
                   new SqlParameter("@EmployeeId",salesOfficer.EmployeeId),
                   new SqlParameter("@IsActive",salesOfficer.IsActive),
                   new SqlParameter("@CreatedBy",salesOfficer.CreatedBy),
                   new SqlParameter("@Password",generatePassword),
                   new SqlParameter("@IsAdmin",salesOfficer.IsAdmin)
                };
                int result = Convert.ToInt32(SQLHelper.ExecuteNonQuery(connection, CommandType.StoredProcedure, SPName_Constants.AddSalesOfficer, spParams));
                if (result > 0)
                {
                    isSuccess = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
                connection.Dispose();
            }
            return isSuccess;
        }
        #endregion

        #region DistributorMethods
        /// <summary>
        /// To get all distributors.
        /// </summary>
        /// <returns></returns>
        public List<Distributor> GetDistributors()
        {
            DataSet dsDistributors = null;
            List<Distributor> distributors = new List<Distributor>();
            try
            {
                connection = SQLConnection.GetConnection();
                dsDistributors = new DataSet();
                dsDistributors = SQLHelper.ExecuteDataset(connection, CommandType.StoredProcedure, SPName_Constants.GetDistributor, null);
                if (dsDistributors != null && dsDistributors.Tables.Count > 0 && dsDistributors.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < dsDistributors.Tables[0].Rows.Count; i++)
                    {
                        Distributor objDistributor = new Distributor();
                        if (dsDistributors.Tables[0].Rows[i]["Id"] != DBNull.Value)
                        {
                            objDistributor.Id = Convert.ToInt32(dsDistributors.Tables[0].Rows[i]["Id"].ToString());
                        }
                        objDistributor.DistributorName = dsDistributors.Tables[0].Rows[i]["DistributorName"].ToString();
                        if (dsDistributors.Tables[0].Rows[i]["DistributorType"] != DBNull.Value)
                        {
                            objDistributor.DistributorType = Convert.ToInt32(dsDistributors.Tables[0].Rows[i]["DistributorType"].ToString());
                        }
                        objDistributor.DistributorTypeShort = dsDistributors.Tables[0].Rows[i]["DistributorTypeShort"].ToString();
                        if (dsDistributors.Tables[0].Rows[i]["AreaHeadId"] != DBNull.Value)
                        {
                            objDistributor.AreaHeadId = Convert.ToInt32(dsDistributors.Tables[0].Rows[i]["AreaHeadId"].ToString());
                        }
                        objDistributor.AreaHeadName = dsDistributors.Tables[0].Rows[i]["AreaHeadName"].ToString();
                        if (dsDistributors.Tables[0].Rows[i]["IsActive"] != DBNull.Value)
                        {
                            objDistributor.IsActive = Convert.ToBoolean(dsDistributors.Tables[0].Rows[i]["IsActive"].ToString());
                        }
                        if (dsDistributors.Tables[0].Rows[i]["HeadQuaterId"] != DBNull.Value)
                        {
                            objDistributor.HeadQuaterId = Convert.ToInt32(dsDistributors.Tables[0].Rows[i]["HeadQuaterId"].ToString());
                        }
                        objDistributor.HeadQuaterName = dsDistributors.Tables[0].Rows[i]["HeadQuaterName"].ToString();

                        if (dsDistributors.Tables[0].Rows[i]["StateId"] != DBNull.Value)
                        {
                            objDistributor.StateId = Convert.ToInt32(dsDistributors.Tables[0].Rows[i]["StateId"].ToString());
                        }
                        objDistributor.StateName = dsDistributors.Tables[0].Rows[i]["StateName"].ToString();
                        if (dsDistributors.Tables[0].Rows[i]["ZoneId"] != DBNull.Value)
                        {
                            objDistributor.ZoneId = Convert.ToInt32(dsDistributors.Tables[0].Rows[i]["ZoneId"].ToString());
                        }
                        objDistributor.ZoneName = dsDistributors.Tables[0].Rows[i]["ZoneName"].ToString();
                        objDistributor.AddressLine1 = dsDistributors.Tables[0].Rows[i]["AddressLine1"].ToString();
                        objDistributor.AddressLine2 = dsDistributors.Tables[0].Rows[i]["AddressLine2"].ToString();
                        if (dsDistributors.Tables[0].Rows[i]["DistrictId"] != DBNull.Value)
                        {
                            objDistributor.DistrictId = Convert.ToInt32(dsDistributors.Tables[0].Rows[i]["DistrictId"].ToString());
                        }
                        objDistributor.Pincode = dsDistributors.Tables[0].Rows[i]["Pincode"].ToString();
                        distributors.Add(objDistributor);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
                connection.Dispose();
            }
            return distributors;
        }

        /// <summary>
        /// To add distributor.
        /// </summary>
        /// <param name="distributor"></param>
        /// <returns></returns>
        public bool AddDistributor(Distributor distributor)
        {
            bool isSuccess = false;
            try
            {
                connection = SQLConnection.GetConnection();
                SqlParameter[] spParams = new SqlParameter[]
                {
                   new SqlParameter("@DistributorName",distributor.DistributorName),
                   new SqlParameter("@DistributorType",distributor.DistributorType),
                   new SqlParameter("@AreaHeadId",distributor.AreaHeadId),
                   new SqlParameter("@ContactNumber",distributor.ContactNumber),
                   new SqlParameter("@Email",distributor.Email),
                   new SqlParameter("@IsActive",distributor.IsActive),
                   new SqlParameter("@CreatedBy",distributor.CreatedBy),
                   new SqlParameter("@AddressLine1",distributor.AddressLine1),
                   new SqlParameter("@AddressLine2",distributor.AddressLine2),
                   new SqlParameter("@StateId",distributor.StateId),
                   new SqlParameter("@HeadQuaterId",distributor.HeadQuaterId),
                   new SqlParameter("@DistrictId",distributor.DistrictId),
                   new SqlParameter("@Pincode",distributor.Pincode),

                };
                int result = Convert.ToInt32(SQLHelper.ExecuteNonQuery(connection, CommandType.StoredProcedure, SPName_Constants.AddDistributor, spParams));
                if (result > 0)
                {
                    isSuccess = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
                connection.Dispose();
            }
            return isSuccess;
        }

        #endregion

        #region ProductCategory
        /// <summary>
        /// To get all product categories.
        /// </summary>
        /// <returns></returns>
        public List<ProductCategories> GetProductCategories()
        {
            DataSet dsProductCategory = null;
            List<ProductCategories> productCategories = new List<ProductCategories>();
            try
            {
                connection = SQLConnection.GetConnection();
                dsProductCategory = new DataSet();
                dsProductCategory = SQLHelper.ExecuteDataset(connection, CommandType.StoredProcedure, SPName_Constants.GetProductCategory, null);
                if (dsProductCategory != null && dsProductCategory.Tables.Count > 0 && dsProductCategory.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < dsProductCategory.Tables[0].Rows.Count; i++)
                    {
                        ProductCategories objProductCategory = new ProductCategories();
                        if (dsProductCategory.Tables[0].Rows[i]["Id"] != DBNull.Value)
                        {
                            objProductCategory.Id = Convert.ToInt32(dsProductCategory.Tables[0].Rows[i]["Id"].ToString());
                        }
                        objProductCategory.ProductCategory = dsProductCategory.Tables[0].Rows[i]["ProductCategory"].ToString();
                        if (dsProductCategory.Tables[0].Rows[i]["ProductTypeId"] != DBNull.Value)
                        {
                            objProductCategory.ProductTypeId = Convert.ToInt32(dsProductCategory.Tables[0].Rows[i]["ProductTypeId"].ToString());
                        }
                        objProductCategory.ProductType = dsProductCategory.Tables[0].Rows[i]["ProductType"].ToString();

                        if (dsProductCategory.Tables[0].Rows[i]["IsActive"] != DBNull.Value)
                        {
                            objProductCategory.IsActive = Convert.ToBoolean(dsProductCategory.Tables[0].Rows[i]["IsActive"].ToString());
                        }
                        objProductCategory.CreatedBy = dsProductCategory.Tables[0].Rows[i]["CreatedBy"].ToString();
                        productCategories.Add(objProductCategory);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
                connection.Dispose();
            }
            return productCategories;
        }

        /// <summary>
        /// To add and update product category.
        /// </summary>
        /// <param name="productCategories"></param>
        /// <returns></returns>
        public bool AddProductCategory(ProductCategories productCategories)
        {
            bool isSuccess = false;
            try
            {
                connection = SQLConnection.GetConnection();
                SqlParameter[] spParams = new SqlParameter[]
                {
                   new SqlParameter("@ProductCategory",productCategories.ProductCategory),
                   new SqlParameter("@ProductTypeId",productCategories.ProductTypeId),
                   new SqlParameter("@IsActive",productCategories.IsActive),
                   new SqlParameter("@CreatedBy",productCategories.CreatedBy)
                };
                int result = Convert.ToInt32(SQLHelper.ExecuteNonQuery(connection, CommandType.StoredProcedure, SPName_Constants.AddProductCategory, spParams));
                if (result > 0)
                {
                    isSuccess = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
                connection.Dispose();
            }
            return isSuccess;
        }

        #endregion

        #region Product
        /// <summary>
        /// To get all products.
        /// </summary>
        /// <returns></returns>
        public List<Product> GetProducts()
        {
            DataSet dsProduct = null;
            List<Product> products = new List<Product>();
            try
            {
                connection = SQLConnection.GetConnection();
                dsProduct = new DataSet();
                dsProduct = SQLHelper.ExecuteDataset(connection, CommandType.StoredProcedure, SPName_Constants.GetProducts, null);
                if (dsProduct != null && dsProduct.Tables.Count > 0 && dsProduct.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < dsProduct.Tables[0].Rows.Count; i++)
                    {
                        Product objProduct = new Product();
                        if (dsProduct.Tables[0].Rows[i]["Id"] != DBNull.Value)
                        {
                            objProduct.Id = Convert.ToInt32(dsProduct.Tables[0].Rows[i]["Id"].ToString());
                        }
                        objProduct.ProductName = dsProduct.Tables[0].Rows[i]["ProductName"].ToString();
                        objProduct.ProductDescription = dsProduct.Tables[0].Rows[i]["ProductDescription"].ToString();
                        objProduct.ProductSKUCode = dsProduct.Tables[0].Rows[i]["ProductSKUCode"].ToString();
                        objProduct.ProductWeightDescription = dsProduct.Tables[0].Rows[i]["ProductWeightDescription"].ToString();
                        objProduct.ProductWeight = dsProduct.Tables[0].Rows[i]["ProductWeight"].ToString();
                        if (dsProduct.Tables[0].Rows[i]["ProductCategoryId"] != DBNull.Value)
                        {
                            objProduct.ProductCategoryId = Convert.ToInt32(dsProduct.Tables[0].Rows[i]["ProductCategoryId"].ToString());
                        }
                        objProduct.ProductCategory = dsProduct.Tables[0].Rows[i]["ProductCategory"].ToString();
                        if (dsProduct.Tables[0].Rows[i]["NumberOfPieces"] != DBNull.Value)
                        {
                            objProduct.NumberOfPieces = Convert.ToInt32(dsProduct.Tables[0].Rows[i]["NumberOfPieces"].ToString());
                        }
                        if (dsProduct.Tables[0].Rows[i]["ProductPrice"] != DBNull.Value)
                        {
                            objProduct.ProductPrice = Convert.ToDecimal(dsProduct.Tables[0].Rows[i]["ProductPrice"].ToString());
                        }
                        if (dsProduct.Tables[0].Rows[i]["IsActive"] != DBNull.Value)
                        {
                            objProduct.IsActive = Convert.ToBoolean(dsProduct.Tables[0].Rows[i]["IsActive"].ToString());
                        }
                        objProduct.CreatedBy = dsProduct.Tables[0].Rows[i]["CreatedBy"].ToString();
                        products.Add(objProduct);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
                connection.Dispose();
            }
            return products;
        }

        /// <summary>
        /// To add and update product.
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        public bool AddProduct(Product product)
        {
            bool isSuccess = false;
            try
            {
                connection = SQLConnection.GetConnection();
                SqlParameter[] spParams = new SqlParameter[]
                {
                   new SqlParameter("@ProductName",product.ProductName),
                   new SqlParameter("@ProductDescription",product.ProductDescription),
                   new SqlParameter("@ProductCategoryId",product.ProductCategoryId),
                   new SqlParameter("@ProductSKUCode",product.ProductSKUCode),
                   new SqlParameter("@ProductWeightDescription",product.ProductWeightDescription),
                   new SqlParameter("@ProductWeight",product.ProductWeight),
                   new SqlParameter("@NumberOfPieces",product.NumberOfPieces),
                   new SqlParameter("@ProductPrice",product.ProductPrice),
                   new SqlParameter("@IsActive",product.IsActive),
                   new SqlParameter("@CreatedBy",product.CreatedBy)
                };
                int result = Convert.ToInt32(SQLHelper.ExecuteNonQuery(connection, CommandType.StoredProcedure, SPName_Constants.AddProduct, spParams));
                if (result > 0)
                {
                    isSuccess = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
                connection.Dispose();
            }
            return isSuccess;
        }

        #endregion

        #region MonthlyTarget
        /// <summary>
        /// To add update montly target.
        /// </summary>
        /// <param name="monthlyTarget"></param>
        /// <returns></returns>
        public bool AddMonthlyTarget(MonthlyTarget monthlyTarget)
        {
            bool isSuccess = false;
            try
            {
                connection = SQLConnection.GetConnection();
                SqlParameter[] spParams = new SqlParameter[]
                {
                   new SqlParameter("@ZoneId",monthlyTarget.ZoneId),
                   new SqlParameter("@StateId",monthlyTarget.StateId),
                   new SqlParameter("@HeadQuaterId",monthlyTarget.HeadQuaterId),
                   new SqlParameter("@AreaHeadId",monthlyTarget.AreaHeadId),
                   new SqlParameter("@SalesOfficerId",monthlyTarget.SalesOfficerId),
                   new SqlParameter("@MonthId",monthlyTarget.MonthId),
                   new SqlParameter("@Year",monthlyTarget.Year),
                   new SqlParameter("@ProductCategoryId",monthlyTarget.ProductCategoryId),
                   new SqlParameter("@AssignedTargetValue",monthlyTarget.AssignedTargetValue),
                   new SqlParameter("@IsActive",monthlyTarget.IsActive),
                   new SqlParameter("@CreatedBy",monthlyTarget.CreatedBy)
                };
                int result = Convert.ToInt32(SQLHelper.ExecuteNonQuery(connection, CommandType.StoredProcedure, SPName_Constants.AddMonthlyTarget, spParams));
                if (result > 0)
                {
                    isSuccess = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
                connection.Dispose();
            }
            return isSuccess;
        }

        /// <summary>
        /// To get monthly target.
        /// </summary>
        /// <returns></returns>
        public List<MonthlyTarget> GetMonthlyTargets()
        {
            DataSet dsMonthlyTarget = null;
            List<MonthlyTarget> monthlyTargets = new List<MonthlyTarget>();
            try
            {
                connection = SQLConnection.GetConnection();
                dsMonthlyTarget = new DataSet();
                dsMonthlyTarget = SQLHelper.ExecuteDataset(connection, CommandType.StoredProcedure, SPName_Constants.GetMonthlyTarget, null);
                if (dsMonthlyTarget != null && dsMonthlyTarget.Tables.Count > 0 && dsMonthlyTarget.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < dsMonthlyTarget.Tables[0].Rows.Count; i++)
                    {
                        MonthlyTarget objMonthlyTarget = new MonthlyTarget();
                        if (dsMonthlyTarget.Tables[0].Rows[i]["Id"] != DBNull.Value)
                        {
                            objMonthlyTarget.Id = Convert.ToInt32(dsMonthlyTarget.Tables[0].Rows[i]["Id"].ToString());
                        }
                        if (dsMonthlyTarget.Tables[0].Rows[i]["MonthId"] != DBNull.Value)
                        {
                            objMonthlyTarget.MonthId = Convert.ToInt32(dsMonthlyTarget.Tables[0].Rows[i]["MonthId"].ToString());
                        }
                        objMonthlyTarget.MonthName = dsMonthlyTarget.Tables[0].Rows[i]["MonthName"].ToString();

                        if (dsMonthlyTarget.Tables[0].Rows[i]["ZoneId"] != DBNull.Value)
                        {
                            objMonthlyTarget.ZoneId = Convert.ToInt32(dsMonthlyTarget.Tables[0].Rows[i]["ZoneId"].ToString());
                        }
                        objMonthlyTarget.ZoneName = dsMonthlyTarget.Tables[0].Rows[i]["ZoneName"].ToString();

                        if (dsMonthlyTarget.Tables[0].Rows[i]["StateId"] != DBNull.Value)
                        {
                            objMonthlyTarget.StateId = Convert.ToInt32(dsMonthlyTarget.Tables[0].Rows[i]["StateId"].ToString());
                        }
                        objMonthlyTarget.StateName = dsMonthlyTarget.Tables[0].Rows[i]["StateName"].ToString();

                        if (dsMonthlyTarget.Tables[0].Rows[i]["HeadQuaterId"] != DBNull.Value)
                        {
                            objMonthlyTarget.HeadQuaterId = Convert.ToInt32(dsMonthlyTarget.Tables[0].Rows[i]["HeadQuaterId"].ToString());
                        }
                        objMonthlyTarget.HeadQuaterName = dsMonthlyTarget.Tables[0].Rows[i]["HeadQuaterName"].ToString();

                        if (dsMonthlyTarget.Tables[0].Rows[i]["AreaHeadId"] != DBNull.Value)
                        {
                            objMonthlyTarget.AreaHeadId = Convert.ToInt32(dsMonthlyTarget.Tables[0].Rows[i]["AreaHeadId"].ToString());
                        }
                        objMonthlyTarget.AreaHeadName = dsMonthlyTarget.Tables[0].Rows[i]["AreaHeadName"].ToString();

                        if (dsMonthlyTarget.Tables[0].Rows[i]["SalesOfficerId"] != DBNull.Value)
                        {
                            objMonthlyTarget.SalesOfficerId = Convert.ToInt32(dsMonthlyTarget.Tables[0].Rows[i]["SalesOfficerId"].ToString());
                        }
                        objMonthlyTarget.SalesOfficerName = dsMonthlyTarget.Tables[0].Rows[i]["SalesOfficerName"].ToString();

                        if (dsMonthlyTarget.Tables[0].Rows[i]["ProductCategoryId"] != DBNull.Value)
                        {
                            objMonthlyTarget.ProductCategoryId = Convert.ToInt32(dsMonthlyTarget.Tables[0].Rows[i]["ProductCategoryId"].ToString());
                        }
                        objMonthlyTarget.ProductCategory = dsMonthlyTarget.Tables[0].Rows[i]["ProductCategory"].ToString();

                        if (dsMonthlyTarget.Tables[0].Rows[i]["AssignedTargetValue"] != DBNull.Value)
                        {
                            objMonthlyTarget.AssignedTargetValue = Convert.ToDecimal(dsMonthlyTarget.Tables[0].Rows[i]["AssignedTargetValue"].ToString());
                        }
                        if (dsMonthlyTarget.Tables[0].Rows[i]["AchievedTargetValue"] != DBNull.Value)
                        {
                            objMonthlyTarget.AchievedTargetValue = Convert.ToDecimal(dsMonthlyTarget.Tables[0].Rows[i]["AchievedTargetValue"].ToString());
                        }
                        if (dsMonthlyTarget.Tables[0].Rows[i]["Year"] != DBNull.Value)
                        {
                            objMonthlyTarget.Year = Convert.ToInt32(dsMonthlyTarget.Tables[0].Rows[i]["Year"].ToString());
                        }
                        if (dsMonthlyTarget.Tables[0].Rows[i]["IsActive"] != DBNull.Value)
                        {
                            objMonthlyTarget.IsActive = Convert.ToBoolean(dsMonthlyTarget.Tables[0].Rows[i]["IsActive"].ToString());
                        }
                        objMonthlyTarget.CreatedBy = dsMonthlyTarget.Tables[0].Rows[i]["CreatedBy"].ToString();
                        monthlyTargets.Add(objMonthlyTarget);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
                connection.Dispose();
            }
            return monthlyTargets;
        }

        /// <summary>
        /// To add daily Sales Retailing Data.
        /// </summary>
        /// <param name="dailySalesReporting"></param>
        /// <returns></returns>
        public bool AddDailySalesReport(DailySalesReporting dailySalesReporting)
        {
            bool isSuccess = false;
            try
            {
                //TimeZone zone = TimeZone.CurrentTimeZone;
                // Get offset.
                //TimeSpan offset = zone.GetUtcOffset(DateTime.Now);
                var newTimeOffset =
                    Convert.ToDateTime(dailySalesReporting.RetailingDate).AddHours(6);
                connection = SQLConnection.GetConnection();
                SqlParameter[] spParams = new SqlParameter[]
                {
                   new SqlParameter("@RetailingDate",newTimeOffset),
                   new SqlParameter("@SalesOfficerId",dailySalesReporting.SalesOfficerId),
                   new SqlParameter("@DistributorId",dailySalesReporting.DistributorId),
                   new SqlParameter("@TotalCalls",dailySalesReporting.TotalCalls),
                   new SqlParameter("@ProductiveCalls",dailySalesReporting.ProductiveCalls),
                   new SqlParameter("@CreatedBy",dailySalesReporting.CreatedBy),
                   new SqlParameter("@ProductId",dailySalesReporting.ProductId),
                   new SqlParameter("@ProductSKUCode",dailySalesReporting.ProductSKUCode),
                   new SqlParameter("@ProductCategoryId",dailySalesReporting.ProductCategoryId),
                   new SqlParameter("@ProductSalesQuantity",dailySalesReporting.ProductSalesQuantity),

                };
                int result = Convert.ToInt32(SQLHelper.ExecuteNonQuery(connection, CommandType.StoredProcedure, SPName_Constants.AddDailyRetailing, spParams));
                if (result > 0)
                {
                    isSuccess = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
                connection.Dispose();
            }
            return isSuccess;
        }

        /// <summary>
        /// To get daily sales report data.
        /// </summary>
        /// <returns></returns>
        public List<DailySalesReporting> GetDailySalesReports()
        {
            DataSet dsDailySalesReport = null;
            List<DailySalesReporting> dailySalesReports = new List<DailySalesReporting>();
            try
            {
                connection = SQLConnection.GetConnection();
                dsDailySalesReport = new DataSet();
                dsDailySalesReport = SQLHelper.ExecuteDataset(connection, CommandType.StoredProcedure, SPName_Constants.GetDailyReportingData, null);
                if (dsDailySalesReport != null && dsDailySalesReport.Tables.Count > 0 && dsDailySalesReport.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < dsDailySalesReport.Tables[0].Rows.Count; i++)
                    {
                        DailySalesReporting objDailySalesReport = new DailySalesReporting();
                        if (dsDailySalesReport.Tables[0].Rows[i]["Id"] != DBNull.Value)
                        {
                            objDailySalesReport.Id = Convert.ToInt32(dsDailySalesReport.Tables[0].Rows[i]["Id"].ToString());
                        }
                        if (dsDailySalesReport.Tables[0].Rows[i]["RetailingDate"] != DBNull.Value)
                        {
                            objDailySalesReport.RetailingDate = Convert.ToDateTime(dsDailySalesReport.Tables[0].Rows[i]["RetailingDate"].ToString());
                        }
                        objDailySalesReport.SalesOfficerName = dsDailySalesReport.Tables[0].Rows[i]["SalesOfficerName"].ToString();
                        objDailySalesReport.DistributorName = dsDailySalesReport.Tables[0].Rows[i]["DistributorName"].ToString();
                        objDailySalesReport.AreaHeadName = dsDailySalesReport.Tables[0].Rows[i]["AreaHeadName"].ToString();
                        objDailySalesReport.StateName = dsDailySalesReport.Tables[0].Rows[i]["StateName"].ToString();
                        objDailySalesReport.ZoneName = dsDailySalesReport.Tables[0].Rows[i]["ZoneName"].ToString();
                        objDailySalesReport.ProductCategory = dsDailySalesReport.Tables[0].Rows[i]["ProductCategory"].ToString();
                        objDailySalesReport.ProductSKUCode = dsDailySalesReport.Tables[0].Rows[i]["ProductSKUCode"].ToString();
                        objDailySalesReport.ProductName = dsDailySalesReport.Tables[0].Rows[i]["ProductName"].ToString();

                        if (dsDailySalesReport.Tables[0].Rows[i]["ProductSpecificPrice"] != DBNull.Value)
                        {
                            objDailySalesReport.ProductSpecificPrice = Convert.ToDecimal(dsDailySalesReport.Tables[0].Rows[i]["ProductSpecificPrice"].ToString());
                        }
                        if (dsDailySalesReport.Tables[0].Rows[i]["ProductSalesQuantity"] != DBNull.Value)
                        {
                            objDailySalesReport.ProductSalesQuantity = Convert.ToSingle(dsDailySalesReport.Tables[0].Rows[i]["ProductSalesQuantity"].ToString());
                        }
                        if (dsDailySalesReport.Tables[0].Rows[i]["TotalCalls"] != DBNull.Value)
                        {
                            objDailySalesReport.TotalCalls = Convert.ToInt32(dsDailySalesReport.Tables[0].Rows[i]["TotalCalls"].ToString());
                        }
                        if (dsDailySalesReport.Tables[0].Rows[i]["ProductiveCalls"] != DBNull.Value)
                        {
                            objDailySalesReport.ProductiveCalls = Convert.ToInt32(dsDailySalesReport.Tables[0].Rows[i]["ProductiveCalls"].ToString());
                        }
                        dailySalesReports.Add(objDailySalesReport);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
                connection.Dispose();
            }
            return dailySalesReports;
        }

        /// <summary>
        /// To delete daily sales reporting data.
        /// </summary>
        /// <param name="dailySalesReporting"></param>
        /// <returns></returns>
        public bool DeleteDailySalesReport(DailySalesReporting dailySalesReporting)
        {
            bool isSuccess = false;
            try
            {
                connection = SQLConnection.GetConnection();
                SqlParameter[] spParams = new SqlParameter[]
                {
                   new SqlParameter("@DailyRetailingId",dailySalesReporting.Id),
                };
                int result = Convert.ToInt32(SQLHelper.ExecuteNonQuery(connection, CommandType.StoredProcedure, SPName_Constants.DeleteDailyRetailingData, spParams));
                if (result > 0)
                {
                    isSuccess = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
                connection.Dispose();
            }
            return isSuccess;
        }
        /// <summary>
        /// This method is used to export to excel of daily retailing data.
        /// </summary>
        /// <returns></returns>
        public List<DailySalesReportingForExport> GetDailySalesReportsForExcelExport()
        {
            DataSet dsDailySalesReport = null;
            List<DailySalesReportingForExport> dailySalesReportingForExports = new List<DailySalesReportingForExport>();

            try
            {
                connection = SQLConnection.GetConnection();
                dsDailySalesReport = new DataSet();
                dsDailySalesReport = SQLHelper.ExecuteDataset(connection, CommandType.StoredProcedure, SPName_Constants.GetDailyReportingDataForExport, null);
                if (dsDailySalesReport != null && dsDailySalesReport.Tables.Count > 0 && dsDailySalesReport.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < dsDailySalesReport.Tables[0].Rows.Count; i++)
                    {
                        DailySalesReportingForExport objDailySalesReport = new DailySalesReportingForExport();

                        if (dsDailySalesReport.Tables[0].Rows[i]["RetailingDate"] != DBNull.Value)
                        {
                            objDailySalesReport.RetailingDate = Convert.ToDateTime(dsDailySalesReport.Tables[0].Rows[i]["RetailingDate"].ToString());
                        }
                        objDailySalesReport.SalesOfficerName = dsDailySalesReport.Tables[0].Rows[i]["SalesOfficerName"].ToString();
                        objDailySalesReport.DistributorName = dsDailySalesReport.Tables[0].Rows[i]["DistributorName"].ToString();
                        objDailySalesReport.AreaHeadName = dsDailySalesReport.Tables[0].Rows[i]["AreaHeadName"].ToString();
                        if (dsDailySalesReport.Tables[0].Rows[i]["TotalCalls"] != DBNull.Value)
                        {
                            objDailySalesReport.TotalCalls = Convert.ToInt32(dsDailySalesReport.Tables[0].Rows[i]["TotalCalls"].ToString());
                        }
                        if (dsDailySalesReport.Tables[0].Rows[i]["ProductiveCalls"] != DBNull.Value)
                        {
                            objDailySalesReport.ProductiveCalls = Convert.ToInt32(dsDailySalesReport.Tables[0].Rows[i]["ProductiveCalls"].ToString());
                        }
                        if (dsDailySalesReport.Tables[0].Rows[i]["I-FLO HONEY 1 KG"] != DBNull.Value)
                        {
                            objDailySalesReport.IFLOHONEY1KG = Convert.ToInt32(dsDailySalesReport.Tables[0].Rows[i]["I-FLO HONEY 1 KG"].ToString());
                        }
                        if (dsDailySalesReport.Tables[0].Rows[i]["I-FLO HONEY 500 GM"] != DBNull.Value)
                        {
                            objDailySalesReport.IFLOHONEY500GM = Convert.ToInt32(dsDailySalesReport.Tables[0].Rows[i]["I-FLO HONEY 500 GM"].ToString());
                        }
                        if (dsDailySalesReport.Tables[0].Rows[i]["I-FLO HONEY 250 GM"] != DBNull.Value)
                        {
                            objDailySalesReport.IFLOHONEY250GM = Convert.ToInt32(dsDailySalesReport.Tables[0].Rows[i]["I-FLO HONEY 250 GM"].ToString());
                        }
                        if (dsDailySalesReport.Tables[0].Rows[i]["I-FLO HONEY 100 GM"] != DBNull.Value)
                        {
                            objDailySalesReport.IFLOHONEY100GM = Convert.ToInt32(dsDailySalesReport.Tables[0].Rows[i]["I-FLO HONEY 100 GM"].ToString());
                        }
                        if (dsDailySalesReport.Tables[0].Rows[i]["I-FLO HONEY 50 GM"] != DBNull.Value)
                        {
                            objDailySalesReport.IFLOHONEY50GM = Convert.ToInt32(dsDailySalesReport.Tables[0].Rows[i]["I-FLO HONEY 50 GM"].ToString());
                        }
                        if (dsDailySalesReport.Tables[0].Rows[i]["I-FLO HONEY 20 GM"] != DBNull.Value)
                        {
                            objDailySalesReport.IFLOHONEY20GM = Convert.ToInt32(dsDailySalesReport.Tables[0].Rows[i]["I-FLO HONEY 20 GM"].ToString());
                        }
                        if (dsDailySalesReport.Tables[0].Rows[i]["I-FLO JUJUBEE HONEY 28 GM"] != DBNull.Value)
                        {
                            objDailySalesReport.IFLOJUJUBEEHONEY28GM = Convert.ToInt32(dsDailySalesReport.Tables[0].Rows[i]["I-FLO JUJUBEE HONEY 28 GM"].ToString());
                        }
                        if (dsDailySalesReport.Tables[0].Rows[i]["I-FLO JUJUBEE HONEY 350 GM"] != DBNull.Value)
                        {
                            objDailySalesReport.IFLOJUJUBEEHONEY350GM = Convert.ToInt32(dsDailySalesReport.Tables[0].Rows[i]["I-FLO JUJUBEE HONEY 350 GM"].ToString());
                        }
                        if (dsDailySalesReport.Tables[0].Rows[i]["I-FLO CARDAMOM MRP 10"] != DBNull.Value)
                        {
                            objDailySalesReport.IFLOCARDAMOMMRP10 = Convert.ToInt32(dsDailySalesReport.Tables[0].Rows[i]["I-FLO CARDAMOM MRP 10"].ToString());
                        }
                        if (dsDailySalesReport.Tables[0].Rows[i]["I-FLO CLOVE MRP 10"] != DBNull.Value)
                        {
                            objDailySalesReport.IFLOCLOVEMRP10 = Convert.ToInt32(dsDailySalesReport.Tables[0].Rows[i]["I-FLO CLOVE MRP 10"].ToString());
                        }
                        if (dsDailySalesReport.Tables[0].Rows[i]["I-FLO PEPPER MRP 10"] != DBNull.Value)
                        {
                            objDailySalesReport.IFLOPEPPERMRP10 = Convert.ToInt32(dsDailySalesReport.Tables[0].Rows[i]["I-FLO PEPPER MRP 10"].ToString());
                        }
                        if (dsDailySalesReport.Tables[0].Rows[i]["I-FLO POPPY SEEDS MRP 10"] != DBNull.Value)
                        {
                            objDailySalesReport.IFLOPOPPYSEEDSMRP10 = Convert.ToInt32(dsDailySalesReport.Tables[0].Rows[i]["I-FLO POPPY SEEDS MRP 10"].ToString());
                        }
                        if (dsDailySalesReport.Tables[0].Rows[i]["I-FLO PEPPER MRP 20"] != DBNull.Value)
                        {
                            objDailySalesReport.IFLOPEPPERMRP20 = Convert.ToInt32(dsDailySalesReport.Tables[0].Rows[i]["I-FLO PEPPER MRP 20"].ToString());
                        }
                        if (dsDailySalesReport.Tables[0].Rows[i]["I-FLO CARDAMOM MRP 20"] != DBNull.Value)
                        {
                            objDailySalesReport.IFLOCARDAMOMMRP20 = Convert.ToInt32(dsDailySalesReport.Tables[0].Rows[i]["I-FLO CARDAMOM MRP 20"].ToString());
                        }
                        if (dsDailySalesReport.Tables[0].Rows[i]["I-FLO CLOVE MRP 20"] != DBNull.Value)
                        {
                            objDailySalesReport.IFLOCLOVEMRP20 = Convert.ToInt32(dsDailySalesReport.Tables[0].Rows[i]["I-FLO CLOVE MRP 20"].ToString());
                        }
                        if (dsDailySalesReport.Tables[0].Rows[i]["I-FLO PEPPER MRP 25"] != DBNull.Value)
                        {
                            objDailySalesReport.IFLOPEPPERMRP25 = Convert.ToInt32(dsDailySalesReport.Tables[0].Rows[i]["I-FLO PEPPER MRP 25"].ToString());
                        }
                        if (dsDailySalesReport.Tables[0].Rows[i]["I-FLO CARDAMOM MRP 25"] != DBNull.Value)
                        {
                            objDailySalesReport.IFLOCARDAMOMMRP25 = Convert.ToInt32(dsDailySalesReport.Tables[0].Rows[i]["I-FLO CARDAMOM MRP 25"].ToString());
                        }
                        if (dsDailySalesReport.Tables[0].Rows[i]["I-FLO TURMERIC POWDER MRP 5"] != DBNull.Value)
                        {
                            objDailySalesReport.IFLOTURMERICPOWDERMRP5 = Convert.ToInt32(dsDailySalesReport.Tables[0].Rows[i]["I-FLO TURMERIC POWDER MRP 5"].ToString());
                        }
                        if (dsDailySalesReport.Tables[0].Rows[i]["I-FLO CHILLI POWDER MRP 5"] != DBNull.Value)
                        {
                            objDailySalesReport.IFLOCHILLIPOWDERMRP5 = Convert.ToInt32(dsDailySalesReport.Tables[0].Rows[i]["I-FLO CHILLI POWDER MRP 5"].ToString());
                        }
                        if (dsDailySalesReport.Tables[0].Rows[i]["I-FLO DHANIA POWDER MRP 5"] != DBNull.Value)
                        {
                            objDailySalesReport.IFLODHANIAPOWDERMRP5 = Convert.ToInt32(dsDailySalesReport.Tables[0].Rows[i]["I-FLO DHANIA POWDER MRP 5"].ToString());
                        }
                        if (dsDailySalesReport.Tables[0].Rows[i]["I-FLO BLACK PEPPER POWDER MRP 7"] != DBNull.Value)
                        {
                            objDailySalesReport.IFLOBLACKPEPPERPOWDERMRP7 = Convert.ToInt32(dsDailySalesReport.Tables[0].Rows[i]["I-FLO BLACK PEPPER POWDER MRP 7"].ToString());
                        }
                        if (dsDailySalesReport.Tables[0].Rows[i]["I-FLO TURMERIC POWDER MRP 10"] != DBNull.Value)
                        {
                            objDailySalesReport.IFLOTURMERICPOWDERMRP10 = Convert.ToInt32(dsDailySalesReport.Tables[0].Rows[i]["I-FLO TURMERIC POWDER MRP 10"].ToString());
                        }
                        if (dsDailySalesReport.Tables[0].Rows[i]["I-FLO CHILLI POWDER MRP 10"] != DBNull.Value)
                        {
                            objDailySalesReport.IFLOCHILLIPOWDERMRP10 = Convert.ToInt32(dsDailySalesReport.Tables[0].Rows[i]["I-FLO CHILLI POWDER MRP 10"].ToString());
                        }
                        if (dsDailySalesReport.Tables[0].Rows[i]["I-FLO DHANIA POWDER MRP 10"] != DBNull.Value)
                        {
                            objDailySalesReport.IFLODHANIAPOWDERMRP10 = Convert.ToInt32(dsDailySalesReport.Tables[0].Rows[i]["I-FLO DHANIA POWDER MRP 10"].ToString());
                        }
                        if (dsDailySalesReport.Tables[0].Rows[i]["I-FLO BLACK PEPPER POWDER MRP 10"] != DBNull.Value)
                        {
                            objDailySalesReport.IFLOBLACKPEPPERPOWDERMRP10 = Convert.ToInt32(dsDailySalesReport.Tables[0].Rows[i]["I-FLO BLACK PEPPER POWDER MRP 10"].ToString());
                        }
                        if (dsDailySalesReport.Tables[0].Rows[i]["I-FLO TURMERIC POWDER 50G"] != DBNull.Value)
                        {
                            objDailySalesReport.IFLOTURMERICPOWDER50G = Convert.ToInt32(dsDailySalesReport.Tables[0].Rows[i]["I-FLO TURMERIC POWDER 50G"].ToString());
                        }
                        if (dsDailySalesReport.Tables[0].Rows[i]["I-FLO CHILLI POWDER 50G"] != DBNull.Value)
                        {
                            objDailySalesReport.IFLOCHILLIPOWDER50G = Convert.ToInt32(dsDailySalesReport.Tables[0].Rows[i]["I-FLO CHILLI POWDER 50G"].ToString());
                        }
                        if (dsDailySalesReport.Tables[0].Rows[i]["I-FLO DHANIA POWDER 50G"] != DBNull.Value)
                        {
                            objDailySalesReport.IFLODHANIAPOWDER50G = Convert.ToInt32(dsDailySalesReport.Tables[0].Rows[i]["I-FLO DHANIA POWDER 50G"].ToString());
                        }
                        if (dsDailySalesReport.Tables[0].Rows[i]["I-FLO BLACK PEPPER POWDER 50G"] != DBNull.Value)
                        {
                            objDailySalesReport.IFLOBLACKPEPPERPOWDER50G = Convert.ToInt32(dsDailySalesReport.Tables[0].Rows[i]["I-FLO BLACK PEPPER POWDER 50G"].ToString());
                        }
                        if (dsDailySalesReport.Tables[0].Rows[i]["I-FLO TURMERIC POWDER 100G"] != DBNull.Value)
                        {
                            objDailySalesReport.IFLOTURMERICPOWDER100G = Convert.ToInt32(dsDailySalesReport.Tables[0].Rows[i]["I-FLO TURMERIC POWDER 100G"].ToString());
                        }
                        if (dsDailySalesReport.Tables[0].Rows[i]["I-FLO CHILLI POWDER 100G"] != DBNull.Value)
                        {
                            objDailySalesReport.IFLOCHILLIPOWDER100G = Convert.ToInt32(dsDailySalesReport.Tables[0].Rows[i]["I-FLO CHILLI POWDER 100G"].ToString());
                        }
                        if (dsDailySalesReport.Tables[0].Rows[i]["I-FLO DHANIA POWDER 100G"] != DBNull.Value)
                        {
                            objDailySalesReport.IFLODHANIAPOWDER100G = Convert.ToInt32(dsDailySalesReport.Tables[0].Rows[i]["I-FLO DHANIA POWDER 100G"].ToString());
                        }
                        if (dsDailySalesReport.Tables[0].Rows[i]["I-FLO TURMERIC POWDER 200G"] != DBNull.Value)
                        {
                            objDailySalesReport.IFLOTURMERICPOWDER200G = Convert.ToInt32(dsDailySalesReport.Tables[0].Rows[i]["I-FLO TURMERIC POWDER 200G"].ToString());
                        }
                        if (dsDailySalesReport.Tables[0].Rows[i]["I-FLO CHILLI POWDER 200G"] != DBNull.Value)
                        {
                            objDailySalesReport.IFLOCHILLIPOWDER200G = Convert.ToInt32(dsDailySalesReport.Tables[0].Rows[i]["I-FLO CHILLI POWDER 200G"].ToString());
                        }
                        if (dsDailySalesReport.Tables[0].Rows[i]["I-FLO DHANIA POWDER 200G"] != DBNull.Value)
                        {
                            objDailySalesReport.IFLODHANIAPOWDER200G = Convert.ToInt32(dsDailySalesReport.Tables[0].Rows[i]["I-FLO DHANIA POWDER 200G"].ToString());
                        }
                        if (dsDailySalesReport.Tables[0].Rows[i]["I-FLO TURMERIC POWDER 500G"] != DBNull.Value)
                        {
                            objDailySalesReport.IFLOTURMERICPOWDER500G = Convert.ToInt32(dsDailySalesReport.Tables[0].Rows[i]["I-FLO TURMERIC POWDER 500G"].ToString());
                        }
                        if (dsDailySalesReport.Tables[0].Rows[i]["I-FLO CHILLI POWDER 500G"] != DBNull.Value)
                        {
                            objDailySalesReport.IFLOCHILLIPOWDER500G = Convert.ToInt32(dsDailySalesReport.Tables[0].Rows[i]["I-FLO CHILLI POWDER 500G"].ToString());
                        }
                        if (dsDailySalesReport.Tables[0].Rows[i]["I-FLO DHANIA POWDER 500G"] != DBNull.Value)
                        {
                            objDailySalesReport.IFLODHANIAPOWDER500G = Convert.ToInt32(dsDailySalesReport.Tables[0].Rows[i]["I-FLO DHANIA POWDER 500G"].ToString());
                        }
                        if (dsDailySalesReport.Tables[0].Rows[i]["I-FLO TURMERIC POWDER 400G"] != DBNull.Value)
                        {
                            objDailySalesReport.IFLOTURMERICPOWDER400G = Convert.ToInt32(dsDailySalesReport.Tables[0].Rows[i]["I-FLO TURMERIC POWDER 400G"].ToString());
                        }
                        if (dsDailySalesReport.Tables[0].Rows[i]["I-FLO CHILLI POWDER 400G"] != DBNull.Value)
                        {
                            objDailySalesReport.IFLOCHILLIPOWDER400G = Convert.ToInt32(dsDailySalesReport.Tables[0].Rows[i]["I-FLO CHILLI POWDER 400G"].ToString());
                        }
                        if (dsDailySalesReport.Tables[0].Rows[i]["I-FLO DHANIA POWDER 400G"] != DBNull.Value)
                        {
                            objDailySalesReport.IFLODHANIAPOWDER400G = Convert.ToInt32(dsDailySalesReport.Tables[0].Rows[i]["I-FLO DHANIA POWDER 400G"].ToString());
                        }
                        if (dsDailySalesReport.Tables[0].Rows[i]["I-FLO GARAM MASALA MRP 10"] != DBNull.Value)
                        {
                            objDailySalesReport.IFLOGARAMMASALAMRP10 = Convert.ToInt32(dsDailySalesReport.Tables[0].Rows[i]["I-FLO GARAM MASALA MRP 10"].ToString());
                        }
                        if (dsDailySalesReport.Tables[0].Rows[i]["I-FLO SAMBAR POWDER MRP 10"] != DBNull.Value)
                        {
                            objDailySalesReport.IFLOSAMBARPOWDERMRP10 = Convert.ToInt32(dsDailySalesReport.Tables[0].Rows[i]["I-FLO SAMBAR POWDER MRP 10"].ToString());
                        }
                        if (dsDailySalesReport.Tables[0].Rows[i]["I-FLO RASAM POWDER MRP 10"] != DBNull.Value)
                        {
                            objDailySalesReport.IFLORASAMPOWDERMRP10 = Convert.ToInt32(dsDailySalesReport.Tables[0].Rows[i]["I-FLO RASAM POWDER MRP 10"].ToString());
                        }
                        if (dsDailySalesReport.Tables[0].Rows[i]["I-FLO CHANNA MASALA MRP 10"] != DBNull.Value)
                        {
                            objDailySalesReport.IFLOCHANNAMASALAMRP10 = Convert.ToInt32(dsDailySalesReport.Tables[0].Rows[i]["I-FLO CHANNA MASALA MRP 10"].ToString());
                        }
                        if (dsDailySalesReport.Tables[0].Rows[i]["I-FLO CHICKEN MASALA MRP 5"] != DBNull.Value)
                        {
                            objDailySalesReport.IFLOCHICKENMASALAMRP5 = Convert.ToInt32(dsDailySalesReport.Tables[0].Rows[i]["I-FLO CHICKEN MASALA MRP 5"].ToString());
                        }
                        if (dsDailySalesReport.Tables[0].Rows[i]["I-FLO MUTTON MASALA MRP 5"] != DBNull.Value)
                        {
                            objDailySalesReport.IFLOMUTTONMASALAMRP5 = Convert.ToInt32(dsDailySalesReport.Tables[0].Rows[i]["I-FLO MUTTON MASALA MRP 5"].ToString());
                        }
                        if (dsDailySalesReport.Tables[0].Rows[i]["I-FLO FISH CURRY MASALA MRP 5"] != DBNull.Value)
                        {
                            objDailySalesReport.IFLOFISHCURRYMASALAMRP5 = Convert.ToInt32(dsDailySalesReport.Tables[0].Rows[i]["I-FLO FISH CURRY MASALA MRP 5"].ToString());
                        }
                        if (dsDailySalesReport.Tables[0].Rows[i]["I-FLO CHICKEN MASALA MRP 10"] != DBNull.Value)
                        {
                            objDailySalesReport.IFLOCHICKENMASALAMRP10 = Convert.ToInt32(dsDailySalesReport.Tables[0].Rows[i]["I-FLO CHICKEN MASALA MRP 10"].ToString());
                        }
                        if (dsDailySalesReport.Tables[0].Rows[i]["I-FLO MUTTON MASALA MRP 10"] != DBNull.Value)
                        {
                            objDailySalesReport.IFLOMUTTONMASALAMRP10 = Convert.ToInt32(dsDailySalesReport.Tables[0].Rows[i]["I-FLO MUTTON MASALA MRP 10"].ToString());
                        }
                        if (dsDailySalesReport.Tables[0].Rows[i]["I-FLO FISH CURRY MASALA MRP 10"] != DBNull.Value)
                        {
                            objDailySalesReport.IFLOFISHCURRYMASALAMRP10 = Convert.ToInt32(dsDailySalesReport.Tables[0].Rows[i]["I-FLO FISH CURRY MASALA MRP 10"].ToString());
                        }
                        if (dsDailySalesReport.Tables[0].Rows[i]["I-FLO BIRIYANI MASALA MRP 10"] != DBNull.Value)
                        {
                            objDailySalesReport.IFLOBIRIYANIMASALAMRP10 = Convert.ToInt32(dsDailySalesReport.Tables[0].Rows[i]["I-FLO BIRIYANI MASALA MRP 10"].ToString());
                        }
                        if (dsDailySalesReport.Tables[0].Rows[i]["I-FLO GARAM MASALA 50G"] != DBNull.Value)
                        {
                            objDailySalesReport.IFLOGARAMMASALA50G = Convert.ToInt32(dsDailySalesReport.Tables[0].Rows[i]["I-FLO GARAM MASALA 50G"].ToString());
                        }
                        if (dsDailySalesReport.Tables[0].Rows[i]["I-FLO SAMBAR POWDER 50G"] != DBNull.Value)
                        {
                            objDailySalesReport.IFLOSAMBARPOWDER50G = Convert.ToInt32(dsDailySalesReport.Tables[0].Rows[i]["I-FLO SAMBAR POWDER 50G"].ToString());
                        }
                        if (dsDailySalesReport.Tables[0].Rows[i]["I-FLO RASAM POWDER 50G"] != DBNull.Value)
                        {
                            objDailySalesReport.IFLORASAMPOWDER50G = Convert.ToInt32(dsDailySalesReport.Tables[0].Rows[i]["I-FLO RASAM POWDER 50G"].ToString());
                        }
                        if (dsDailySalesReport.Tables[0].Rows[i]["I-FLO CHANNA MASALA 50G"] != DBNull.Value)
                        {
                            objDailySalesReport.IFLOCHANNAMASALA50G = Convert.ToInt32(dsDailySalesReport.Tables[0].Rows[i]["I-FLO CHANNA MASALA 50G"].ToString());
                        }
                        if (dsDailySalesReport.Tables[0].Rows[i]["I-FLO CHICKEN MASALA 50G"] != DBNull.Value)
                        {
                            objDailySalesReport.IFLOCHICKENMASALA50G = Convert.ToInt32(dsDailySalesReport.Tables[0].Rows[i]["I-FLO CHICKEN MASALA 50G"].ToString());
                        }
                        if (dsDailySalesReport.Tables[0].Rows[i]["I-FLO MUTTON MASALA 50G"] != DBNull.Value)
                        {
                            objDailySalesReport.IFLOMUTTONMASALA50G = Convert.ToInt32(dsDailySalesReport.Tables[0].Rows[i]["I-FLO MUTTON MASALA 50G"].ToString());
                        }
                        if (dsDailySalesReport.Tables[0].Rows[i]["I-FLO FISH CURRY MASALA 50G"] != DBNull.Value)
                        {
                            objDailySalesReport.IFLOFISHCURRYMASALA50G = Convert.ToInt32(dsDailySalesReport.Tables[0].Rows[i]["I-FLO FISH CURRY MASALA 50G"].ToString());
                        }
                        if (dsDailySalesReport.Tables[0].Rows[i]["I-FLO BIRIYANI MASALA 50G"] != DBNull.Value)
                        {
                            objDailySalesReport.IFLOBIRIYANIMASALA50G = Convert.ToInt32(dsDailySalesReport.Tables[0].Rows[i]["I-FLO BIRIYANI MASALA 50G"].ToString());
                        }
                        if (dsDailySalesReport.Tables[0].Rows[i]["I-FLO IDLI CHILI POWDER 50G"] != DBNull.Value)
                        {
                            objDailySalesReport.IFLOIDLICHILIPOWDER50G = Convert.ToInt32(dsDailySalesReport.Tables[0].Rows[i]["I-FLO IDLI CHILI POWDER 50G"].ToString());
                        }
                        if (dsDailySalesReport.Tables[0].Rows[i]["I-FLO HERBAL SALT 1/2 KG"] != DBNull.Value)
                        {
                            objDailySalesReport.IFLOHERBALSALT500G = Convert.ToInt32(dsDailySalesReport.Tables[0].Rows[i]["I-FLO HERBAL SALT 1/2 KG"].ToString());
                        }
                        if (dsDailySalesReport.Tables[0].Rows[i]["I-FLO HERBAL SALT 750G"] != DBNull.Value)
                        {
                            objDailySalesReport.IFLOHERBALSALT750G = Convert.ToInt32(dsDailySalesReport.Tables[0].Rows[i]["I-FLO HERBAL SALT 750G"].ToString());
                        }
                        if (dsDailySalesReport.Tables[0].Rows[i]["I-FLO TRIPLE REFINED SALT 1KG"] != DBNull.Value)
                        {
                            objDailySalesReport.IFLOTRIPLEREFINEDSALT1KG = Convert.ToInt32(dsDailySalesReport.Tables[0].Rows[i]["I-FLO TRIPLE REFINED SALT 1KG"].ToString());
                        }
                        if (dsDailySalesReport.Tables[0].Rows[i]["I-FLO MILD SALT 1/2KG"] != DBNull.Value)
                        {
                            objDailySalesReport.IFLOMILDSALT500G = Convert.ToInt32(dsDailySalesReport.Tables[0].Rows[i]["I-FLO MILD SALT 1/2KG"].ToString());
                        }
                        objDailySalesReport.HQ = dsDailySalesReport.Tables[0].Rows[i]["HeadQuaterName"].ToString();
                        objDailySalesReport.STATE = dsDailySalesReport.Tables[0].Rows[i]["StateName"].ToString();
                        objDailySalesReport.ZONE = dsDailySalesReport.Tables[0].Rows[i]["ZoneName"].ToString();

                        dailySalesReportingForExports.Add(objDailySalesReport);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
                connection.Dispose();
            }
            return dailySalesReportingForExports;
        }

        /// <summary>
        /// Getting Retailing Report Zone Wise - Dharmendra24092019
        /// </summary>
        /// <returns></returns>
        public List<RetailingReportZoneWise> GetRetailingReportZoneWiseReports()
        {
            DataSet dsRetailingReportZoneWiseReport = null;
            List<RetailingReportZoneWise> ObjRetailingReportZoneWiseList = new List<RetailingReportZoneWise>();
            try
            {
                connection = SQLConnection.GetConnection();
                dsRetailingReportZoneWiseReport = new DataSet();
                dsRetailingReportZoneWiseReport = SQLHelper.ExecuteDataset(connection, CommandType.StoredProcedure, SPName_Constants.GetRetailingZoneWiseData, null);
                if (dsRetailingReportZoneWiseReport != null && dsRetailingReportZoneWiseReport.Tables.Count > 0 && dsRetailingReportZoneWiseReport.Tables[0].Rows.Count > 0)
                {
                    var ZoneList = dsRetailingReportZoneWiseReport.Tables[0].AsEnumerable().Select(row => row.Field<string>("ZoneName")).Distinct().ToList();
                    var CurrentYear = DateTime.Now.Year;
                    var NextYear = CurrentYear + 1;
                    double AprTotal = 0;
                    double MayTotal = 0;
                    double JunTotal = 0;
                    double JulTotal = 0;
                    double AugTotal = 0;
                    double SeptTotal = 0;
                    double OctTotal = 0;
                    double NovTotal = 0;
                    double DecTotal = 0;
                    double JanTotal = 0;
                    double FebTotal = 0;
                    double MarTotal = 0;
                    double AllTotal = 0;

                    foreach (var zone in ZoneList)
                    {
                        RetailingReportZoneWise ObjRetailingReportZoneWise = new RetailingReportZoneWise();
                        ObjRetailingReportZoneWise.ZoneName = zone;
                        double ZoneTotal = 0;

                        DataRow AprRow = dsRetailingReportZoneWiseReport.Tables[0].Select("Month='Apr-" + CurrentYear + "' and ZoneName='" + zone + "'").FirstOrDefault();
                        if (AprRow != null)
                        {
                            ObjRetailingReportZoneWise.AprPrice = AprRow.Field<double>("TotalPrice").ToString();
                            AprTotal += AprRow.Field<double>("TotalPrice");
                            ZoneTotal += AprRow.Field<double>("TotalPrice");
                        }
                        else
                        {
                            ObjRetailingReportZoneWise.AprPrice = "-";
                        }

                        DataRow MayRow = dsRetailingReportZoneWiseReport.Tables[0].Select("Month='May-" + CurrentYear + "' and ZoneName='" + zone + "'").FirstOrDefault();
                        if (MayRow != null)
                        {
                            ObjRetailingReportZoneWise.MayPrice = MayRow.Field<double>("TotalPrice").ToString();
                            MayTotal += MayRow.Field<double>("TotalPrice");
                            ZoneTotal += MayRow.Field<double>("TotalPrice");
                        }
                        else
                        {
                            ObjRetailingReportZoneWise.MayPrice = "-";
                        }

                        DataRow JunRow = dsRetailingReportZoneWiseReport.Tables[0].Select("Month='Jun-" + CurrentYear + "' and ZoneName='" + zone + "'").FirstOrDefault();
                        if (JunRow != null)
                        {
                            ObjRetailingReportZoneWise.JunPrice = JunRow.Field<double>("TotalPrice").ToString();
                            JunTotal += JunRow.Field<double>("TotalPrice");
                            ZoneTotal += JunRow.Field<double>("TotalPrice");
                        }
                        else
                        {
                            ObjRetailingReportZoneWise.JunPrice = "-";
                        }

                        DataRow JulRow = dsRetailingReportZoneWiseReport.Tables[0].Select("Month='Jul-" + CurrentYear + "' and ZoneName='" + zone + "'").FirstOrDefault();
                        if (JulRow != null)
                        {
                            ObjRetailingReportZoneWise.JulPrice = JulRow.Field<double>("TotalPrice").ToString();
                            JulTotal += JulRow.Field<double>("TotalPrice");
                            ZoneTotal += JulRow.Field<double>("TotalPrice");
                        }
                        else
                        {
                            ObjRetailingReportZoneWise.JulPrice = "-";
                        }

                        DataRow AugRow = dsRetailingReportZoneWiseReport.Tables[0].Select("Month='Aug-" + CurrentYear + "' and ZoneName='" + zone + "'").FirstOrDefault();
                        if (AugRow != null)
                        {
                            ObjRetailingReportZoneWise.AugPrice = AugRow.Field<double>("TotalPrice").ToString();
                            AugTotal += AugRow.Field<double>("TotalPrice");
                            ZoneTotal += AugRow.Field<double>("TotalPrice");
                        }
                        else
                        {
                            ObjRetailingReportZoneWise.AugPrice = "-";
                        }

                        DataRow SeptRow = dsRetailingReportZoneWiseReport.Tables[0].Select("Month='Sept-" + CurrentYear + "' and ZoneName='" + zone + "'").FirstOrDefault();
                        if (SeptRow != null)
                        {
                            ObjRetailingReportZoneWise.SeptPrice = SeptRow.Field<double>("TotalPrice").ToString();
                            SeptTotal += SeptRow.Field<double>("TotalPrice");
                            ZoneTotal += SeptRow.Field<double>("TotalPrice");
                        }
                        else
                        {
                            ObjRetailingReportZoneWise.SeptPrice = "-";
                        }

                        DataRow OctRow = dsRetailingReportZoneWiseReport.Tables[0].Select("Month='Oct-" + CurrentYear + "' and ZoneName='" + zone + "'").FirstOrDefault();
                        if (OctRow != null)
                        {
                            ObjRetailingReportZoneWise.OctPrice = OctRow.Field<double>("TotalPrice").ToString();
                            OctTotal += OctRow.Field<double>("TotalPrice");
                            ZoneTotal += OctRow.Field<double>("TotalPrice");
                        }
                        else
                        {
                            ObjRetailingReportZoneWise.OctPrice = "-";
                        }

                        DataRow NovRow = dsRetailingReportZoneWiseReport.Tables[0].Select("Month='Nov-" + CurrentYear + "' and ZoneName='" + zone + "'").FirstOrDefault();
                        if (NovRow != null)
                        {
                            ObjRetailingReportZoneWise.NovPrice = NovRow.Field<double>("TotalPrice").ToString();
                            NovTotal += NovRow.Field<double>("TotalPrice");
                            ZoneTotal += NovRow.Field<double>("TotalPrice");
                        }
                        else
                        {
                            ObjRetailingReportZoneWise.NovPrice = "-";
                        }

                        DataRow DecRow = dsRetailingReportZoneWiseReport.Tables[0].Select("Month='Dec-" + CurrentYear + "' and ZoneName='" + zone + "'").FirstOrDefault();
                        if (DecRow != null)
                        {
                            ObjRetailingReportZoneWise.DecPrice = DecRow.Field<double>("TotalPrice").ToString();
                            DecTotal += DecRow.Field<double>("TotalPrice");
                            ZoneTotal += DecRow.Field<double>("TotalPrice");
                        }
                        else
                        {
                            ObjRetailingReportZoneWise.DecPrice = "-";
                        }

                        DataRow JanRow = dsRetailingReportZoneWiseReport.Tables[0].Select("Month='Jan-" + NextYear + "' and ZoneName='" + zone + "'").FirstOrDefault();
                        if (JanRow != null)
                        {
                            ObjRetailingReportZoneWise.JanPrice = JanRow.Field<double>("TotalPrice").ToString();
                            JanTotal += JanRow.Field<double>("TotalPrice");
                            ZoneTotal += JanRow.Field<double>("TotalPrice");
                        }
                        else
                        {
                            ObjRetailingReportZoneWise.JanPrice = "-";
                        }

                        DataRow FebRow = dsRetailingReportZoneWiseReport.Tables[0].Select("Month='Feb-" + NextYear + "' and ZoneName='" + zone + "'").FirstOrDefault();
                        if (FebRow != null)
                        {
                            ObjRetailingReportZoneWise.FebPrice = FebRow.Field<double>("TotalPrice").ToString();
                            FebTotal += FebRow.Field<double>("TotalPrice");
                            ZoneTotal += FebRow.Field<double>("TotalPrice");
                        }
                        else
                        {
                            ObjRetailingReportZoneWise.FebPrice = "-";
                        }

                        DataRow MarRow = dsRetailingReportZoneWiseReport.Tables[0].Select("Month='Mar-" + NextYear + "' and ZoneName='" + zone + "'").FirstOrDefault();
                        if (MarRow != null)
                        {
                            ObjRetailingReportZoneWise.MarPrice = MarRow.Field<double>("TotalPrice").ToString();
                            MarTotal += MarRow.Field<double>("TotalPrice");
                            ZoneTotal += MarRow.Field<double>("TotalPrice");
                        }
                        else
                        {
                            ObjRetailingReportZoneWise.MarPrice = "-";
                        }

                        AllTotal += ZoneTotal;
                        ObjRetailingReportZoneWise.TotalPrice = ZoneTotal.ToString();
                        ObjRetailingReportZoneWiseList.Add(ObjRetailingReportZoneWise);
                    }

                    RetailingReportZoneWise ObjRetailingReportZoneWiseTotal = new RetailingReportZoneWise();
                    ObjRetailingReportZoneWiseTotal.ZoneName = "Total";
                    ObjRetailingReportZoneWiseTotal.AprPrice = AprTotal != 0 ? AprTotal.ToString() : "-";
                    ObjRetailingReportZoneWiseTotal.MayPrice = MayTotal != 0 ? MayTotal.ToString() : "-";
                    ObjRetailingReportZoneWiseTotal.JunPrice = JunTotal != 0 ? JunTotal.ToString() : "-";
                    ObjRetailingReportZoneWiseTotal.JulPrice = JulTotal != 0 ? JulTotal.ToString() : "-";
                    ObjRetailingReportZoneWiseTotal.AugPrice = AugTotal != 0 ? AugTotal.ToString() : "-";
                    ObjRetailingReportZoneWiseTotal.SeptPrice = SeptTotal != 0 ? SeptTotal.ToString() : "-";
                    ObjRetailingReportZoneWiseTotal.OctPrice = OctTotal != 0 ? OctTotal.ToString() : "-";
                    ObjRetailingReportZoneWiseTotal.NovPrice = NovTotal != 0 ? NovTotal.ToString() : "-";
                    ObjRetailingReportZoneWiseTotal.DecPrice = DecTotal != 0 ? DecTotal.ToString() : "-";
                    ObjRetailingReportZoneWiseTotal.JanPrice = JanTotal != 0 ? JanTotal.ToString() : "-";
                    ObjRetailingReportZoneWiseTotal.FebPrice = FebTotal != 0 ? FebTotal.ToString() : "-";
                    ObjRetailingReportZoneWiseTotal.MarPrice = MarTotal != 0 ? MarTotal.ToString() : "-";
                    ObjRetailingReportZoneWiseTotal.TotalPrice = AllTotal != 0 ? AllTotal.ToString() : "-";
                    ObjRetailingReportZoneWiseList.Add(ObjRetailingReportZoneWiseTotal);

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
                connection.Dispose();
            }
            return ObjRetailingReportZoneWiseList;
        }

        /// <summary>
        /// Getting Retailing Report State Wise - Dharmendra03102019
        /// </summary>
        /// <returns></returns>
        public List<RetailingReportStateWise> GetRetailingReportStateWiseReports()
        {
            DataSet dsRetailingReportStateWiseReport = null;
            List<RetailingReportStateWise> ObjRetailingReportStateWiseList = new List<RetailingReportStateWise>();
            try
            {
                connection = SQLConnection.GetConnection();
                dsRetailingReportStateWiseReport = new DataSet();
                dsRetailingReportStateWiseReport = SQLHelper.ExecuteDataset(connection, CommandType.StoredProcedure, SPName_Constants.GetRetailingStateWiseData, null);
                if (dsRetailingReportStateWiseReport != null && dsRetailingReportStateWiseReport.Tables.Count > 0 && dsRetailingReportStateWiseReport.Tables[0].Rows.Count > 0)
                {
                    var StateList = dsRetailingReportStateWiseReport.Tables[0].AsEnumerable().Select(row => row.Field<string>("StateName")).Distinct().ToList();
                    var CurrentYear = DateTime.Now.Year;
                    var NextYear = CurrentYear + 1;
                    double AprTotal = 0;
                    double MayTotal = 0;
                    double JunTotal = 0;
                    double JulTotal = 0;
                    double AugTotal = 0;
                    double SeptTotal = 0;
                    double OctTotal = 0;
                    double NovTotal = 0;
                    double DecTotal = 0;
                    double JanTotal = 0;
                    double FebTotal = 0;
                    double MarTotal = 0;
                    double AllTotal = 0;

                    foreach (var state in StateList)
                    {
                        RetailingReportStateWise ObjRetailingReportStateWise = new RetailingReportStateWise();
                        ObjRetailingReportStateWise.StateName = state;
                        double StateTotal = 0;

                        DataRow AprRow = dsRetailingReportStateWiseReport.Tables[0].Select("Month='Apr-" + CurrentYear + "' and StateName='" + state + "'").FirstOrDefault();
                        if (AprRow != null)
                        {
                            ObjRetailingReportStateWise.AprPrice = AprRow.Field<double>("TotalPrice").ToString();
                            AprTotal += AprRow.Field<double>("TotalPrice");
                            StateTotal += AprRow.Field<double>("TotalPrice");
                        }
                        else
                        {
                            ObjRetailingReportStateWise.AprPrice = "-";
                        }

                        DataRow MayRow = dsRetailingReportStateWiseReport.Tables[0].Select("Month='May-" + CurrentYear + "' and StateName='" + state + "'").FirstOrDefault();
                        if (MayRow != null)
                        {
                            ObjRetailingReportStateWise.MayPrice = MayRow.Field<double>("TotalPrice").ToString();
                            MayTotal += MayRow.Field<double>("TotalPrice");
                            StateTotal += MayRow.Field<double>("TotalPrice");
                        }
                        else
                        {
                            ObjRetailingReportStateWise.MayPrice = "-";
                        }

                        DataRow JunRow = dsRetailingReportStateWiseReport.Tables[0].Select("Month='Jun-" + CurrentYear + "' and StateName='" + state + "'").FirstOrDefault();
                        if (JunRow != null)
                        {
                            ObjRetailingReportStateWise.JunPrice = JunRow.Field<double>("TotalPrice").ToString();
                            JunTotal += JunRow.Field<double>("TotalPrice");
                            StateTotal += JunRow.Field<double>("TotalPrice");
                        }
                        else
                        {
                            ObjRetailingReportStateWise.JunPrice = "-";
                        }

                        DataRow JulRow = dsRetailingReportStateWiseReport.Tables[0].Select("Month='Jul-" + CurrentYear + "' and StateName='" + state + "'").FirstOrDefault();
                        if (JulRow != null)
                        {
                            ObjRetailingReportStateWise.JulPrice = JulRow.Field<double>("TotalPrice").ToString();
                            JulTotal += JulRow.Field<double>("TotalPrice");
                            StateTotal += JulRow.Field<double>("TotalPrice");
                        }
                        else
                        {
                            ObjRetailingReportStateWise.JulPrice = "-";
                        }

                        DataRow AugRow = dsRetailingReportStateWiseReport.Tables[0].Select("Month='Aug-" + CurrentYear + "' and StateName='" + state + "'").FirstOrDefault();
                        if (AugRow != null)
                        {
                            ObjRetailingReportStateWise.AugPrice = AugRow.Field<double>("TotalPrice").ToString();
                            AugTotal += AugRow.Field<double>("TotalPrice");
                            StateTotal += AugRow.Field<double>("TotalPrice");
                        }
                        else
                        {
                            ObjRetailingReportStateWise.AugPrice = "-";
                        }

                        DataRow SeptRow = dsRetailingReportStateWiseReport.Tables[0].Select("Month='Sept-" + CurrentYear + "' and StateName='" + state + "'").FirstOrDefault();
                        if (SeptRow != null)
                        {
                            ObjRetailingReportStateWise.SeptPrice = SeptRow.Field<double>("TotalPrice").ToString();
                            SeptTotal += SeptRow.Field<double>("TotalPrice");
                            StateTotal += SeptRow.Field<double>("TotalPrice");
                        }
                        else
                        {
                            ObjRetailingReportStateWise.SeptPrice = "-";
                        }

                        DataRow OctRow = dsRetailingReportStateWiseReport.Tables[0].Select("Month='Oct-" + CurrentYear + "' and StateName='" + state + "'").FirstOrDefault();
                        if (OctRow != null)
                        {
                            ObjRetailingReportStateWise.OctPrice = OctRow.Field<double>("TotalPrice").ToString();
                            OctTotal += OctRow.Field<double>("TotalPrice");
                            StateTotal += OctRow.Field<double>("TotalPrice");
                        }
                        else
                        {
                            ObjRetailingReportStateWise.OctPrice = "-";
                        }

                        DataRow NovRow = dsRetailingReportStateWiseReport.Tables[0].Select("Month='Nov-" + CurrentYear + "' and StateName='" + state + "'").FirstOrDefault();
                        if (NovRow != null)
                        {
                            ObjRetailingReportStateWise.NovPrice = NovRow.Field<double>("TotalPrice").ToString();
                            NovTotal += NovRow.Field<double>("TotalPrice");
                            StateTotal += NovRow.Field<double>("TotalPrice");
                        }
                        else
                        {
                            ObjRetailingReportStateWise.NovPrice = "-";
                        }

                        DataRow DecRow = dsRetailingReportStateWiseReport.Tables[0].Select("Month='Dec-" + CurrentYear + "' and StateName='" + state + "'").FirstOrDefault();
                        if (DecRow != null)
                        {
                            ObjRetailingReportStateWise.DecPrice = DecRow.Field<double>("TotalPrice").ToString();
                            DecTotal += DecRow.Field<double>("TotalPrice");
                            StateTotal += DecRow.Field<double>("TotalPrice");
                        }
                        else
                        {
                            ObjRetailingReportStateWise.DecPrice = "-";
                        }

                        DataRow JanRow = dsRetailingReportStateWiseReport.Tables[0].Select("Month='Jan-" + NextYear + "' and StateName='" + state + "'").FirstOrDefault();
                        if (JanRow != null)
                        {
                            ObjRetailingReportStateWise.JanPrice = JanRow.Field<double>("TotalPrice").ToString();
                            JanTotal += JanRow.Field<double>("TotalPrice");
                            StateTotal += JanRow.Field<double>("TotalPrice");
                        }
                        else
                        {
                            ObjRetailingReportStateWise.JanPrice = "-";
                        }

                        DataRow FebRow = dsRetailingReportStateWiseReport.Tables[0].Select("Month='Feb-" + NextYear + "' and StateName='" + state + "'").FirstOrDefault();
                        if (FebRow != null)
                        {
                            ObjRetailingReportStateWise.FebPrice = FebRow.Field<double>("TotalPrice").ToString();
                            FebTotal += FebRow.Field<double>("TotalPrice");
                            StateTotal += FebRow.Field<double>("TotalPrice");
                        }
                        else
                        {
                            ObjRetailingReportStateWise.FebPrice = "-";
                        }

                        DataRow MarRow = dsRetailingReportStateWiseReport.Tables[0].Select("Month='Mar-" + NextYear + "' and StateName='" + state + "'").FirstOrDefault();
                        if (MarRow != null)
                        {
                            ObjRetailingReportStateWise.MarPrice = MarRow.Field<double>("TotalPrice").ToString();
                            MarTotal += MarRow.Field<double>("TotalPrice");
                            StateTotal += MarRow.Field<double>("TotalPrice");
                        }
                        else
                        {
                            ObjRetailingReportStateWise.MarPrice = "-";
                        }

                        AllTotal += StateTotal;
                        ObjRetailingReportStateWise.TotalPrice = StateTotal.ToString();
                        ObjRetailingReportStateWiseList.Add(ObjRetailingReportStateWise);
                    }

                    RetailingReportStateWise ObjRetailingReportStateWiseTotal = new RetailingReportStateWise();
                    ObjRetailingReportStateWiseTotal.StateName = "Total";
                    ObjRetailingReportStateWiseTotal.AprPrice = AprTotal != 0 ? AprTotal.ToString() : "-";
                    ObjRetailingReportStateWiseTotal.MayPrice = MayTotal != 0 ? MayTotal.ToString() : "-";
                    ObjRetailingReportStateWiseTotal.JunPrice = JunTotal != 0 ? JunTotal.ToString() : "-";
                    ObjRetailingReportStateWiseTotal.JulPrice = JulTotal != 0 ? JulTotal.ToString() : "-";
                    ObjRetailingReportStateWiseTotal.AugPrice = AugTotal != 0 ? AugTotal.ToString() : "-";
                    ObjRetailingReportStateWiseTotal.SeptPrice = SeptTotal != 0 ? SeptTotal.ToString() : "-";
                    ObjRetailingReportStateWiseTotal.OctPrice = OctTotal != 0 ? OctTotal.ToString() : "-";
                    ObjRetailingReportStateWiseTotal.NovPrice = NovTotal != 0 ? NovTotal.ToString() : "-";
                    ObjRetailingReportStateWiseTotal.DecPrice = DecTotal != 0 ? DecTotal.ToString() : "-";
                    ObjRetailingReportStateWiseTotal.JanPrice = JanTotal != 0 ? JanTotal.ToString() : "-";
                    ObjRetailingReportStateWiseTotal.FebPrice = FebTotal != 0 ? FebTotal.ToString() : "-";
                    ObjRetailingReportStateWiseTotal.MarPrice = MarTotal != 0 ? MarTotal.ToString() : "-";
                    ObjRetailingReportStateWiseTotal.TotalPrice = AllTotal != 0 ? AllTotal.ToString() : "-";
                    ObjRetailingReportStateWiseList.Add(ObjRetailingReportStateWiseTotal);

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
                connection.Dispose();
            }
            return ObjRetailingReportStateWiseList;
        }

        /// <summary>
        /// Getting Retailing Report Area Head Wise - Dharmendra03102019
        /// </summary>
        /// <returns></returns>
        public List<RetailingReportAreaHeadWise> GetRetailingReportAreaHeadWiseReports()
        {
            DataSet dsRetailingReportAreaHeadWiseReport = null;
            List<RetailingReportAreaHeadWise> ObjRetailingReportAreaHeadWiseList = new List<RetailingReportAreaHeadWise>();
            try
            {
                connection = SQLConnection.GetConnection();
                dsRetailingReportAreaHeadWiseReport = new DataSet();
                dsRetailingReportAreaHeadWiseReport = SQLHelper.ExecuteDataset(connection, CommandType.StoredProcedure, SPName_Constants.GetRetailingAreaHeadWiseData, null);
                if (dsRetailingReportAreaHeadWiseReport != null && dsRetailingReportAreaHeadWiseReport.Tables.Count > 0 && dsRetailingReportAreaHeadWiseReport.Tables[0].Rows.Count > 0)
                {
                    var AreaHeadList = dsRetailingReportAreaHeadWiseReport.Tables[0].AsEnumerable().Select(row => row.Field<string>("AreaHeadName")).Distinct().ToList();
                    var CurrentYear = DateTime.Now.Year;
                    var NextYear = CurrentYear + 1;
                    double AprTotal = 0;
                    double MayTotal = 0;
                    double JunTotal = 0;
                    double JulTotal = 0;
                    double AugTotal = 0;
                    double SeptTotal = 0;
                    double OctTotal = 0;
                    double NovTotal = 0;
                    double DecTotal = 0;
                    double JanTotal = 0;
                    double FebTotal = 0;
                    double MarTotal = 0;
                    double AllTotal = 0;

                    foreach (var areaHead in AreaHeadList)
                    {
                        RetailingReportAreaHeadWise ObjRetailingReportAreaHeadWise = new RetailingReportAreaHeadWise();
                        DataRow AreaHeadRow = dsRetailingReportAreaHeadWiseReport.Tables[0].Select("AreaHeadName= '" + areaHead + "'").FirstOrDefault();
                        if (AreaHeadRow != null)
                        {
                            ObjRetailingReportAreaHeadWise.AreaHeadName = AreaHeadRow.Field<string>("AreaHeadName").ToString();
                            ObjRetailingReportAreaHeadWise.HeadQuaterName = AreaHeadRow.Field<string>("HeadQuaterName").ToString();
                            ObjRetailingReportAreaHeadWise.StateName = AreaHeadRow.Field<string>("StateName").ToString();
                            ObjRetailingReportAreaHeadWise.ZoneName = AreaHeadRow.Field<string>("ZoneName").ToString();
                        }
                        double AreaHeadTotal = 0;

                        DataRow AprRow = dsRetailingReportAreaHeadWiseReport.Tables[0].Select("Month='Apr-" + CurrentYear + "' and AreaHeadName='" + areaHead + "'").FirstOrDefault();
                        if (AprRow != null)
                        {
                            ObjRetailingReportAreaHeadWise.AprPrice = AprRow.Field<double>("TotalPrice").ToString();
                            AprTotal += AprRow.Field<double>("TotalPrice");
                            AreaHeadTotal += AprRow.Field<double>("TotalPrice");
                        }
                        else
                        {
                            ObjRetailingReportAreaHeadWise.AprPrice = "-";
                        }

                        DataRow MayRow = dsRetailingReportAreaHeadWiseReport.Tables[0].Select("Month='May-" + CurrentYear + "' and AreaHeadName='" + areaHead + "'").FirstOrDefault();
                        if (MayRow != null)
                        {
                            ObjRetailingReportAreaHeadWise.MayPrice = MayRow.Field<double>("TotalPrice").ToString();
                            MayTotal += MayRow.Field<double>("TotalPrice");
                            AreaHeadTotal += MayRow.Field<double>("TotalPrice");
                        }
                        else
                        {
                            ObjRetailingReportAreaHeadWise.MayPrice = "-";
                        }

                        DataRow JunRow = dsRetailingReportAreaHeadWiseReport.Tables[0].Select("Month='Jun-" + CurrentYear + "' and AreaHeadName='" + areaHead + "'").FirstOrDefault();
                        if (JunRow != null)
                        {
                            ObjRetailingReportAreaHeadWise.JunPrice = JunRow.Field<double>("TotalPrice").ToString();
                            JunTotal += JunRow.Field<double>("TotalPrice");
                            AreaHeadTotal += JunRow.Field<double>("TotalPrice");
                        }
                        else
                        {
                            ObjRetailingReportAreaHeadWise.JunPrice = "-";
                        }

                        DataRow JulRow = dsRetailingReportAreaHeadWiseReport.Tables[0].Select("Month='Jul-" + CurrentYear + "' and AreaHeadName='" + areaHead + "'").FirstOrDefault();
                        if (JulRow != null)
                        {
                            ObjRetailingReportAreaHeadWise.JulPrice = JulRow.Field<double>("TotalPrice").ToString();
                            JulTotal += JulRow.Field<double>("TotalPrice");
                            AreaHeadTotal += JulRow.Field<double>("TotalPrice");
                        }
                        else
                        {
                            ObjRetailingReportAreaHeadWise.JulPrice = "-";
                        }

                        DataRow AugRow = dsRetailingReportAreaHeadWiseReport.Tables[0].Select("Month='Aug-" + CurrentYear + "' and AreaHeadName='" + areaHead + "'").FirstOrDefault();
                        if (AugRow != null)
                        {
                            ObjRetailingReportAreaHeadWise.AugPrice = AugRow.Field<double>("TotalPrice").ToString();
                            AugTotal += AugRow.Field<double>("TotalPrice");
                            AreaHeadTotal += AugRow.Field<double>("TotalPrice");
                        }
                        else
                        {
                            ObjRetailingReportAreaHeadWise.AugPrice = "-";
                        }

                        DataRow SeptRow = dsRetailingReportAreaHeadWiseReport.Tables[0].Select("Month='Sept-" + CurrentYear + "' and AreaHeadName='" + areaHead + "'").FirstOrDefault();
                        if (SeptRow != null)
                        {
                            ObjRetailingReportAreaHeadWise.SeptPrice = SeptRow.Field<double>("TotalPrice").ToString();
                            SeptTotal += SeptRow.Field<double>("TotalPrice");
                            AreaHeadTotal += SeptRow.Field<double>("TotalPrice");
                        }
                        else
                        {
                            ObjRetailingReportAreaHeadWise.SeptPrice = "-";
                        }

                        DataRow OctRow = dsRetailingReportAreaHeadWiseReport.Tables[0].Select("Month='Oct-" + CurrentYear + "' and AreaHeadName='" + areaHead + "'").FirstOrDefault();
                        if (OctRow != null)
                        {
                            ObjRetailingReportAreaHeadWise.OctPrice = OctRow.Field<double>("TotalPrice").ToString();
                            OctTotal += OctRow.Field<double>("TotalPrice");
                            AreaHeadTotal += OctRow.Field<double>("TotalPrice");
                        }
                        else
                        {
                            ObjRetailingReportAreaHeadWise.OctPrice = "-";
                        }

                        DataRow NovRow = dsRetailingReportAreaHeadWiseReport.Tables[0].Select("Month='Nov-" + CurrentYear + "' and AreaHeadName='" + areaHead + "'").FirstOrDefault();
                        if (NovRow != null)
                        {
                            ObjRetailingReportAreaHeadWise.NovPrice = NovRow.Field<double>("TotalPrice").ToString();
                            NovTotal += NovRow.Field<double>("TotalPrice");
                            AreaHeadTotal += NovRow.Field<double>("TotalPrice");
                        }
                        else
                        {
                            ObjRetailingReportAreaHeadWise.NovPrice = "-";
                        }

                        DataRow DecRow = dsRetailingReportAreaHeadWiseReport.Tables[0].Select("Month='Dec-" + CurrentYear + "' and AreaHeadName='" + areaHead + "'").FirstOrDefault();
                        if (DecRow != null)
                        {
                            ObjRetailingReportAreaHeadWise.DecPrice = DecRow.Field<double>("TotalPrice").ToString();
                            DecTotal += DecRow.Field<double>("TotalPrice");
                            AreaHeadTotal += DecRow.Field<double>("TotalPrice");
                        }
                        else
                        {
                            ObjRetailingReportAreaHeadWise.DecPrice = "-";
                        }

                        DataRow JanRow = dsRetailingReportAreaHeadWiseReport.Tables[0].Select("Month='Jan-" + NextYear + "' and AreaHeadName='" + areaHead + "'").FirstOrDefault();
                        if (JanRow != null)
                        {
                            ObjRetailingReportAreaHeadWise.JanPrice = JanRow.Field<double>("TotalPrice").ToString();
                            JanTotal += JanRow.Field<double>("TotalPrice");
                            AreaHeadTotal += JanRow.Field<double>("TotalPrice");
                        }
                        else
                        {
                            ObjRetailingReportAreaHeadWise.JanPrice = "-";
                        }

                        DataRow FebRow = dsRetailingReportAreaHeadWiseReport.Tables[0].Select("Month='Feb-" + NextYear + "' and AreaHeadName='" + areaHead + "'").FirstOrDefault();
                        if (FebRow != null)
                        {
                            ObjRetailingReportAreaHeadWise.FebPrice = FebRow.Field<double>("TotalPrice").ToString();
                            FebTotal += FebRow.Field<double>("TotalPrice");
                            AreaHeadTotal += FebRow.Field<double>("TotalPrice");
                        }
                        else
                        {
                            ObjRetailingReportAreaHeadWise.FebPrice = "-";
                        }

                        DataRow MarRow = dsRetailingReportAreaHeadWiseReport.Tables[0].Select("Month='Mar-" + NextYear + "' and AreaHeadName='" + areaHead + "'").FirstOrDefault();
                        if (MarRow != null)
                        {
                            ObjRetailingReportAreaHeadWise.MarPrice = MarRow.Field<double>("TotalPrice").ToString();
                            MarTotal += MarRow.Field<double>("TotalPrice");
                            AreaHeadTotal += MarRow.Field<double>("TotalPrice");
                        }
                        else
                        {
                            ObjRetailingReportAreaHeadWise.MarPrice = "-";
                        }

                        AllTotal += AreaHeadTotal;
                        ObjRetailingReportAreaHeadWise.TotalPrice = AreaHeadTotal.ToString();
                        ObjRetailingReportAreaHeadWiseList.Add(ObjRetailingReportAreaHeadWise);
                    }

                    RetailingReportAreaHeadWise ObjRetailingReportAreaHeadWiseTotal = new RetailingReportAreaHeadWise();
                    ObjRetailingReportAreaHeadWiseTotal.AreaHeadName = "Total";
                    ObjRetailingReportAreaHeadWiseTotal.HeadQuaterName = "";
                    ObjRetailingReportAreaHeadWiseTotal.StateName = "";
                    ObjRetailingReportAreaHeadWiseTotal.ZoneName = "";
                    ObjRetailingReportAreaHeadWiseTotal.AprPrice = AprTotal != 0 ? AprTotal.ToString() : "-";
                    ObjRetailingReportAreaHeadWiseTotal.MayPrice = MayTotal != 0 ? MayTotal.ToString() : "-";
                    ObjRetailingReportAreaHeadWiseTotal.JunPrice = JunTotal != 0 ? JunTotal.ToString() : "-";
                    ObjRetailingReportAreaHeadWiseTotal.JulPrice = JulTotal != 0 ? JulTotal.ToString() : "-";
                    ObjRetailingReportAreaHeadWiseTotal.AugPrice = AugTotal != 0 ? AugTotal.ToString() : "-";
                    ObjRetailingReportAreaHeadWiseTotal.SeptPrice = SeptTotal != 0 ? SeptTotal.ToString() : "-";
                    ObjRetailingReportAreaHeadWiseTotal.OctPrice = OctTotal != 0 ? OctTotal.ToString() : "-";
                    ObjRetailingReportAreaHeadWiseTotal.NovPrice = NovTotal != 0 ? NovTotal.ToString() : "-";
                    ObjRetailingReportAreaHeadWiseTotal.DecPrice = DecTotal != 0 ? DecTotal.ToString() : "-";
                    ObjRetailingReportAreaHeadWiseTotal.JanPrice = JanTotal != 0 ? JanTotal.ToString() : "-";
                    ObjRetailingReportAreaHeadWiseTotal.FebPrice = FebTotal != 0 ? FebTotal.ToString() : "-";
                    ObjRetailingReportAreaHeadWiseTotal.MarPrice = MarTotal != 0 ? MarTotal.ToString() : "-";
                    ObjRetailingReportAreaHeadWiseTotal.TotalPrice = AllTotal != 0 ? AllTotal.ToString() : "-";
                    ObjRetailingReportAreaHeadWiseList.Add(ObjRetailingReportAreaHeadWiseTotal);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
                connection.Dispose();
            }
            return ObjRetailingReportAreaHeadWiseList;
        }

        /// <summary>
        /// Getting Retailing Report Sales officer Wise - Dharmendra03102019
        /// </summary>
        /// <returns></returns>
        public List<RetailingReportSOWise> GetRetailingReportSOWiseReports()
        {
            DataSet dsRetailingReportSOWiseReport = null;
            List<RetailingReportSOWise> ObjRetailingReportSOWiseList = new List<RetailingReportSOWise>();
            try
            {
                connection = SQLConnection.GetConnection();
                dsRetailingReportSOWiseReport = new DataSet();
                dsRetailingReportSOWiseReport = SQLHelper.ExecuteDataset(connection, CommandType.StoredProcedure, SPName_Constants.GetRetailingSOWiseData, null);
                if (dsRetailingReportSOWiseReport != null && dsRetailingReportSOWiseReport.Tables.Count > 0 && dsRetailingReportSOWiseReport.Tables[0].Rows.Count > 0)
                {
                    var SalesOfficerList = dsRetailingReportSOWiseReport.Tables[0].AsEnumerable().Select(row => row.Field<string>("SalesOfficerName")).Distinct().ToList();
                    var CurrentYear = DateTime.Now.Year;
                    var NextYear = CurrentYear + 1;
                    double AprTotal = 0;
                    double MayTotal = 0;
                    double JunTotal = 0;
                    double JulTotal = 0;
                    double AugTotal = 0;
                    double SeptTotal = 0;
                    double OctTotal = 0;
                    double NovTotal = 0;
                    double DecTotal = 0;
                    double JanTotal = 0;
                    double FebTotal = 0;
                    double MarTotal = 0;
                    double AllTotal = 0;

                    foreach (var salesOfficer in SalesOfficerList)
                    {
                        RetailingReportSOWise ObjRetailingReportSOWise = new RetailingReportSOWise();
                        DataRow SORow = dsRetailingReportSOWiseReport.Tables[0].Select("SalesOfficerName= '" + salesOfficer + "'").FirstOrDefault();
                        if (SORow != null)
                        {
                            ObjRetailingReportSOWise.SalesOfficerName = SORow.Field<string>("SalesOfficerName").ToString();
                            ObjRetailingReportSOWise.AreaHeadName = SORow.Field<string>("AreaHeadName").ToString();
                            ObjRetailingReportSOWise.HeadQuaterName = SORow.Field<string>("HeadQuaterName").ToString();
                            ObjRetailingReportSOWise.StateName = SORow.Field<string>("StateName").ToString();
                            ObjRetailingReportSOWise.ZoneName = SORow.Field<string>("ZoneName").ToString();
                        }
                        double SOTotal = 0;

                        DataRow AprRow = dsRetailingReportSOWiseReport.Tables[0].Select("Month='Apr-" + CurrentYear + "' and SalesOfficerName='" + salesOfficer + "'").FirstOrDefault();
                        if (AprRow != null)
                        {
                            ObjRetailingReportSOWise.AprPrice = AprRow.Field<double>("TotalPrice").ToString();
                            AprTotal += AprRow.Field<double>("TotalPrice");
                            SOTotal += AprRow.Field<double>("TotalPrice");
                        }
                        else
                        {
                            ObjRetailingReportSOWise.AprPrice = "-";
                        }

                        DataRow MayRow = dsRetailingReportSOWiseReport.Tables[0].Select("Month='May-" + CurrentYear + "' and SalesOfficerName='" + salesOfficer + "'").FirstOrDefault();
                        if (MayRow != null)
                        {
                            ObjRetailingReportSOWise.MayPrice = MayRow.Field<double>("TotalPrice").ToString();
                            MayTotal += MayRow.Field<double>("TotalPrice");
                            SOTotal += MayRow.Field<double>("TotalPrice");
                        }
                        else
                        {
                            ObjRetailingReportSOWise.MayPrice = "-";
                        }

                        DataRow JunRow = dsRetailingReportSOWiseReport.Tables[0].Select("Month='Jun-" + CurrentYear + "' and SalesOfficerName='" + salesOfficer + "'").FirstOrDefault();
                        if (JunRow != null)
                        {
                            ObjRetailingReportSOWise.JunPrice = JunRow.Field<double>("TotalPrice").ToString();
                            JunTotal += JunRow.Field<double>("TotalPrice");
                            SOTotal += JunRow.Field<double>("TotalPrice");
                        }
                        else
                        {
                            ObjRetailingReportSOWise.JunPrice = "-";
                        }

                        DataRow JulRow = dsRetailingReportSOWiseReport.Tables[0].Select("Month='Jul-" + CurrentYear + "' and SalesOfficerName='" + salesOfficer + "'").FirstOrDefault();
                        if (JulRow != null)
                        {
                            ObjRetailingReportSOWise.JulPrice = JulRow.Field<double>("TotalPrice").ToString();
                            JulTotal += JulRow.Field<double>("TotalPrice");
                            SOTotal += JulRow.Field<double>("TotalPrice");
                        }
                        else
                        {
                            ObjRetailingReportSOWise.JulPrice = "-";
                        }

                        DataRow AugRow = dsRetailingReportSOWiseReport.Tables[0].Select("Month='Aug-" + CurrentYear + "' and SalesOfficerName='" + salesOfficer + "'").FirstOrDefault();
                        if (AugRow != null)
                        {
                            ObjRetailingReportSOWise.AugPrice = AugRow.Field<double>("TotalPrice").ToString();
                            AugTotal += AugRow.Field<double>("TotalPrice");
                            SOTotal += AugRow.Field<double>("TotalPrice");
                        }
                        else
                        {
                            ObjRetailingReportSOWise.AugPrice = "-";
                        }

                        DataRow SeptRow = dsRetailingReportSOWiseReport.Tables[0].Select("Month='Sept-" + CurrentYear + "' and SalesOfficerName='" + salesOfficer + "'").FirstOrDefault();
                        if (SeptRow != null)
                        {
                            ObjRetailingReportSOWise.SeptPrice = SeptRow.Field<double>("TotalPrice").ToString();
                            SeptTotal += SeptRow.Field<double>("TotalPrice");
                            SOTotal += SeptRow.Field<double>("TotalPrice");
                        }
                        else
                        {
                            ObjRetailingReportSOWise.SeptPrice = "-";
                        }

                        DataRow OctRow = dsRetailingReportSOWiseReport.Tables[0].Select("Month='Oct-" + CurrentYear + "' and SalesOfficerName='" + salesOfficer + "'").FirstOrDefault();
                        if (OctRow != null)
                        {
                            ObjRetailingReportSOWise.OctPrice = OctRow.Field<double>("TotalPrice").ToString();
                            OctTotal += OctRow.Field<double>("TotalPrice");
                            SOTotal += OctRow.Field<double>("TotalPrice");
                        }
                        else
                        {
                            ObjRetailingReportSOWise.OctPrice = "-";
                        }

                        DataRow NovRow = dsRetailingReportSOWiseReport.Tables[0].Select("Month='Nov-" + CurrentYear + "' and SalesOfficerName='" + salesOfficer + "'").FirstOrDefault();
                        if (NovRow != null)
                        {
                            ObjRetailingReportSOWise.NovPrice = NovRow.Field<double>("TotalPrice").ToString();
                            NovTotal += NovRow.Field<double>("TotalPrice");
                            SOTotal += NovRow.Field<double>("TotalPrice");
                        }
                        else
                        {
                            ObjRetailingReportSOWise.NovPrice = "-";
                        }

                        DataRow DecRow = dsRetailingReportSOWiseReport.Tables[0].Select("Month='Dec-" + CurrentYear + "' and SalesOfficerName='" + salesOfficer + "'").FirstOrDefault();
                        if (DecRow != null)
                        {
                            ObjRetailingReportSOWise.DecPrice = DecRow.Field<double>("TotalPrice").ToString();
                            DecTotal += DecRow.Field<double>("TotalPrice");
                            SOTotal += DecRow.Field<double>("TotalPrice");
                        }
                        else
                        {
                            ObjRetailingReportSOWise.DecPrice = "-";
                        }

                        DataRow JanRow = dsRetailingReportSOWiseReport.Tables[0].Select("Month='Jan-" + NextYear + "' and SalesOfficerName='" + salesOfficer + "'").FirstOrDefault();
                        if (JanRow != null)
                        {
                            ObjRetailingReportSOWise.JanPrice = JanRow.Field<double>("TotalPrice").ToString();
                            JanTotal += JanRow.Field<double>("TotalPrice");
                            SOTotal += JanRow.Field<double>("TotalPrice");
                        }
                        else
                        {
                            ObjRetailingReportSOWise.JanPrice = "-";
                        }

                        DataRow FebRow = dsRetailingReportSOWiseReport.Tables[0].Select("Month='Feb-" + NextYear + "' and SalesOfficerName='" + salesOfficer + "'").FirstOrDefault();
                        if (FebRow != null)
                        {
                            ObjRetailingReportSOWise.FebPrice = FebRow.Field<double>("TotalPrice").ToString();
                            FebTotal += FebRow.Field<double>("TotalPrice");
                            SOTotal += FebRow.Field<double>("TotalPrice");
                        }
                        else
                        {
                            ObjRetailingReportSOWise.FebPrice = "-";
                        }

                        DataRow MarRow = dsRetailingReportSOWiseReport.Tables[0].Select("Month='Mar-" + NextYear + "' and SalesOfficerName='" + salesOfficer + "'").FirstOrDefault();
                        if (MarRow != null)
                        {
                            ObjRetailingReportSOWise.MarPrice = MarRow.Field<double>("TotalPrice").ToString();
                            MarTotal += MarRow.Field<double>("TotalPrice");
                            SOTotal += MarRow.Field<double>("TotalPrice");
                        }
                        else
                        {
                            ObjRetailingReportSOWise.MarPrice = "-";
                        }

                        AllTotal += SOTotal;
                        ObjRetailingReportSOWise.TotalPrice = SOTotal.ToString();
                        ObjRetailingReportSOWiseList.Add(ObjRetailingReportSOWise);
                    }

                    RetailingReportSOWise ObjRetailingReportSOWiseTotal = new RetailingReportSOWise();
                    ObjRetailingReportSOWiseTotal.SalesOfficerName = "Total";
                    ObjRetailingReportSOWiseTotal.AreaHeadName = "";
                    ObjRetailingReportSOWiseTotal.HeadQuaterName = "";
                    ObjRetailingReportSOWiseTotal.StateName = "";
                    ObjRetailingReportSOWiseTotal.ZoneName = "";
                    ObjRetailingReportSOWiseTotal.AprPrice = AprTotal != 0 ? AprTotal.ToString() : "-";
                    ObjRetailingReportSOWiseTotal.MayPrice = MayTotal != 0 ? MayTotal.ToString() : "-";
                    ObjRetailingReportSOWiseTotal.JunPrice = JunTotal != 0 ? JunTotal.ToString() : "-";
                    ObjRetailingReportSOWiseTotal.JulPrice = JulTotal != 0 ? JulTotal.ToString() : "-";
                    ObjRetailingReportSOWiseTotal.AugPrice = AugTotal != 0 ? AugTotal.ToString() : "-";
                    ObjRetailingReportSOWiseTotal.SeptPrice = SeptTotal != 0 ? SeptTotal.ToString() : "-";
                    ObjRetailingReportSOWiseTotal.OctPrice = OctTotal != 0 ? OctTotal.ToString() : "-";
                    ObjRetailingReportSOWiseTotal.NovPrice = NovTotal != 0 ? NovTotal.ToString() : "-";
                    ObjRetailingReportSOWiseTotal.DecPrice = DecTotal != 0 ? DecTotal.ToString() : "-";
                    ObjRetailingReportSOWiseTotal.JanPrice = JanTotal != 0 ? JanTotal.ToString() : "-";
                    ObjRetailingReportSOWiseTotal.FebPrice = FebTotal != 0 ? FebTotal.ToString() : "-";
                    ObjRetailingReportSOWiseTotal.MarPrice = MarTotal != 0 ? MarTotal.ToString() : "-";
                    ObjRetailingReportSOWiseTotal.TotalPrice = AllTotal != 0 ? AllTotal.ToString() : "-";
                    ObjRetailingReportSOWiseList.Add(ObjRetailingReportSOWiseTotal);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
                connection.Dispose();
            }
            return ObjRetailingReportSOWiseList;
        }

        /// <summary>
        /// Getting Retailing Report Distributor Wise - Dharmendra15102019
        /// </summary>
        /// <returns></returns>
        public List<RetailingReportDBWise> GetRetailingReportDBWiseReports()
        {
            DataSet dsRetailingReportDBWiseReport = null;
            List<RetailingReportDBWise> ObjRetailingReportDBWiseList = new List<RetailingReportDBWise>();
            try
            {
                connection = SQLConnection.GetConnection();
                dsRetailingReportDBWiseReport = new DataSet();
                dsRetailingReportDBWiseReport = SQLHelper.ExecuteDataset(connection, CommandType.StoredProcedure, SPName_Constants.GetRetailingDBWiseData, null);
                if (dsRetailingReportDBWiseReport != null && dsRetailingReportDBWiseReport.Tables.Count > 0 && dsRetailingReportDBWiseReport.Tables[0].Rows.Count > 0)
                {
                    var DistributorList = dsRetailingReportDBWiseReport.Tables[0].AsEnumerable().Select(row => row.Field<string>("DistributorName")).Distinct().ToList();
                    var CurrentYear = DateTime.Now.Year;
                    var NextYear = CurrentYear + 1;
                    double AprTotal = 0;
                    double MayTotal = 0;
                    double JunTotal = 0;
                    double JulTotal = 0;
                    double AugTotal = 0;
                    double SeptTotal = 0;
                    double OctTotal = 0;
                    double NovTotal = 0;
                    double DecTotal = 0;
                    double JanTotal = 0;
                    double FebTotal = 0;
                    double MarTotal = 0;
                    double AllTotal = 0;

                    foreach (var distributor in DistributorList)
                    {
                        RetailingReportDBWise ObjRetailingReportDBWise = new RetailingReportDBWise();
                        DataRow DBRow = dsRetailingReportDBWiseReport.Tables[0].Select("DistributorName= '" + distributor + "'").FirstOrDefault();
                        if (DBRow != null)
                        {
                            ObjRetailingReportDBWise.DistributorName = DBRow.Field<string>("DistributorName").ToString();
                            ObjRetailingReportDBWise.AreaHeadName = DBRow.Field<string>("AreaHeadName").ToString();
                            ObjRetailingReportDBWise.HeadQuaterName = DBRow.Field<string>("HeadQuaterName").ToString();
                            ObjRetailingReportDBWise.StateName = DBRow.Field<string>("StateName").ToString();
                            ObjRetailingReportDBWise.ZoneName = DBRow.Field<string>("ZoneName").ToString();
                        }
                        double DBTotal = 0;

                        DataRow AprRow = dsRetailingReportDBWiseReport.Tables[0].Select("Month='Apr-" + CurrentYear + "' and DistributorName='" + distributor + "'").FirstOrDefault();
                        if (AprRow != null)
                        {
                            ObjRetailingReportDBWise.AprPrice = AprRow.Field<double>("TotalPrice").ToString();
                            AprTotal += AprRow.Field<double>("TotalPrice");
                            DBTotal += AprRow.Field<double>("TotalPrice");
                        }
                        else
                        {
                            ObjRetailingReportDBWise.AprPrice = "-";
                        }

                        DataRow MayRow = dsRetailingReportDBWiseReport.Tables[0].Select("Month='May-" + CurrentYear + "' and DistributorName='" + distributor + "'").FirstOrDefault();
                        if (MayRow != null)
                        {
                            ObjRetailingReportDBWise.MayPrice = MayRow.Field<double>("TotalPrice").ToString();
                            MayTotal += MayRow.Field<double>("TotalPrice");
                            DBTotal += MayRow.Field<double>("TotalPrice");
                        }
                        else
                        {
                            ObjRetailingReportDBWise.MayPrice = "-";
                        }

                        DataRow JunRow = dsRetailingReportDBWiseReport.Tables[0].Select("Month='Jun-" + CurrentYear + "' and DistributorName='" + distributor + "'").FirstOrDefault();
                        if (JunRow != null)
                        {
                            ObjRetailingReportDBWise.JunPrice = JunRow.Field<double>("TotalPrice").ToString();
                            JunTotal += JunRow.Field<double>("TotalPrice");
                            DBTotal += JunRow.Field<double>("TotalPrice");
                        }
                        else
                        {
                            ObjRetailingReportDBWise.JunPrice = "-";
                        }

                        DataRow JulRow = dsRetailingReportDBWiseReport.Tables[0].Select("Month='Jul-" + CurrentYear + "' and DistributorName='" + distributor + "'").FirstOrDefault();
                        if (JulRow != null)
                        {
                            ObjRetailingReportDBWise.JulPrice = JulRow.Field<double>("TotalPrice").ToString();
                            JulTotal += JulRow.Field<double>("TotalPrice");
                            DBTotal += JulRow.Field<double>("TotalPrice");
                        }
                        else
                        {
                            ObjRetailingReportDBWise.JulPrice = "-";
                        }

                        DataRow AugRow = dsRetailingReportDBWiseReport.Tables[0].Select("Month='Aug-" + CurrentYear + "' and DistributorName='" + distributor + "'").FirstOrDefault();
                        if (AugRow != null)
                        {
                            ObjRetailingReportDBWise.AugPrice = AugRow.Field<double>("TotalPrice").ToString();
                            AugTotal += AugRow.Field<double>("TotalPrice");
                            DBTotal += AugRow.Field<double>("TotalPrice");
                        }
                        else
                        {
                            ObjRetailingReportDBWise.AugPrice = "-";
                        }

                        DataRow SeptRow = dsRetailingReportDBWiseReport.Tables[0].Select("Month='Sept-" + CurrentYear + "' and DistributorName='" + distributor + "'").FirstOrDefault();
                        if (SeptRow != null)
                        {
                            ObjRetailingReportDBWise.SeptPrice = SeptRow.Field<double>("TotalPrice").ToString();
                            SeptTotal += SeptRow.Field<double>("TotalPrice");
                            DBTotal += SeptRow.Field<double>("TotalPrice");
                        }
                        else
                        {
                            ObjRetailingReportDBWise.SeptPrice = "-";
                        }

                        DataRow OctRow = dsRetailingReportDBWiseReport.Tables[0].Select("Month='Oct-" + CurrentYear + "' and DistributorName='" + distributor + "'").FirstOrDefault();
                        if (OctRow != null)
                        {
                            ObjRetailingReportDBWise.OctPrice = OctRow.Field<double>("TotalPrice").ToString();
                            OctTotal += OctRow.Field<double>("TotalPrice");
                            DBTotal += OctRow.Field<double>("TotalPrice");
                        }
                        else
                        {
                            ObjRetailingReportDBWise.OctPrice = "-";
                        }

                        DataRow NovRow = dsRetailingReportDBWiseReport.Tables[0].Select("Month='Nov-" + CurrentYear + "' and DistributorName='" + distributor + "'").FirstOrDefault();
                        if (NovRow != null)
                        {
                            ObjRetailingReportDBWise.NovPrice = NovRow.Field<double>("TotalPrice").ToString();
                            NovTotal += NovRow.Field<double>("TotalPrice");
                            DBTotal += NovRow.Field<double>("TotalPrice");
                        }
                        else
                        {
                            ObjRetailingReportDBWise.NovPrice = "-";
                        }

                        DataRow DecRow = dsRetailingReportDBWiseReport.Tables[0].Select("Month='Dec-" + CurrentYear + "' and DistributorName='" + distributor + "'").FirstOrDefault();
                        if (DecRow != null)
                        {
                            ObjRetailingReportDBWise.DecPrice = DecRow.Field<double>("TotalPrice").ToString();
                            DecTotal += DecRow.Field<double>("TotalPrice");
                            DBTotal += DecRow.Field<double>("TotalPrice");
                        }
                        else
                        {
                            ObjRetailingReportDBWise.DecPrice = "-";
                        }

                        DataRow JanRow = dsRetailingReportDBWiseReport.Tables[0].Select("Month='Jan-" + NextYear + "' and DistributorName='" + distributor + "'").FirstOrDefault();
                        if (JanRow != null)
                        {
                            ObjRetailingReportDBWise.JanPrice = JanRow.Field<double>("TotalPrice").ToString();
                            JanTotal += JanRow.Field<double>("TotalPrice");
                            DBTotal += JanRow.Field<double>("TotalPrice");
                        }
                        else
                        {
                            ObjRetailingReportDBWise.JanPrice = "-";
                        }

                        DataRow FebRow = dsRetailingReportDBWiseReport.Tables[0].Select("Month='Feb-" + NextYear + "' and DistributorName='" + distributor + "'").FirstOrDefault();
                        if (FebRow != null)
                        {
                            ObjRetailingReportDBWise.FebPrice = FebRow.Field<double>("TotalPrice").ToString();
                            FebTotal += FebRow.Field<double>("TotalPrice");
                            DBTotal += FebRow.Field<double>("TotalPrice");
                        }
                        else
                        {
                            ObjRetailingReportDBWise.FebPrice = "-";
                        }

                        DataRow MarRow = dsRetailingReportDBWiseReport.Tables[0].Select("Month='Mar-" + NextYear + "' and DistributorName='" + distributor + "'").FirstOrDefault();
                        if (MarRow != null)
                        {
                            ObjRetailingReportDBWise.MarPrice = MarRow.Field<double>("TotalPrice").ToString();
                            MarTotal += MarRow.Field<double>("TotalPrice");
                            DBTotal += MarRow.Field<double>("TotalPrice");
                        }
                        else
                        {
                            ObjRetailingReportDBWise.MarPrice = "-";
                        }

                        AllTotal += DBTotal;
                        ObjRetailingReportDBWise.TotalPrice = DBTotal.ToString();
                        ObjRetailingReportDBWiseList.Add(ObjRetailingReportDBWise);
                    }

                    RetailingReportDBWise ObjRetailingReportDBWiseTotal = new RetailingReportDBWise();
                    ObjRetailingReportDBWiseTotal.DistributorName = "Total";
                    ObjRetailingReportDBWiseTotal.AreaHeadName = "";
                    ObjRetailingReportDBWiseTotal.HeadQuaterName = "";
                    ObjRetailingReportDBWiseTotal.StateName = "";
                    ObjRetailingReportDBWiseTotal.ZoneName = "";
                    ObjRetailingReportDBWiseTotal.AprPrice = AprTotal != 0 ? AprTotal.ToString() : "-";
                    ObjRetailingReportDBWiseTotal.MayPrice = MayTotal != 0 ? MayTotal.ToString() : "-";
                    ObjRetailingReportDBWiseTotal.JunPrice = JunTotal != 0 ? JunTotal.ToString() : "-";
                    ObjRetailingReportDBWiseTotal.JulPrice = JulTotal != 0 ? JulTotal.ToString() : "-";
                    ObjRetailingReportDBWiseTotal.AugPrice = AugTotal != 0 ? AugTotal.ToString() : "-";
                    ObjRetailingReportDBWiseTotal.SeptPrice = SeptTotal != 0 ? SeptTotal.ToString() : "-";
                    ObjRetailingReportDBWiseTotal.OctPrice = OctTotal != 0 ? OctTotal.ToString() : "-";
                    ObjRetailingReportDBWiseTotal.NovPrice = NovTotal != 0 ? NovTotal.ToString() : "-";
                    ObjRetailingReportDBWiseTotal.DecPrice = DecTotal != 0 ? DecTotal.ToString() : "-";
                    ObjRetailingReportDBWiseTotal.JanPrice = JanTotal != 0 ? JanTotal.ToString() : "-";
                    ObjRetailingReportDBWiseTotal.FebPrice = FebTotal != 0 ? FebTotal.ToString() : "-";
                    ObjRetailingReportDBWiseTotal.MarPrice = MarTotal != 0 ? MarTotal.ToString() : "-";
                    ObjRetailingReportDBWiseTotal.TotalPrice = AllTotal != 0 ? AllTotal.ToString() : "-";
                    ObjRetailingReportDBWiseList.Add(ObjRetailingReportDBWiseTotal);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
                connection.Dispose();
            }
            return ObjRetailingReportDBWiseList;
        }

        /// <summary>
        /// Getting Monthly Report Card Zone Reports - Dharmendra19102019
        /// </summary>
        /// <returns></returns>
        public List<MonthlyReportCardZone> GetMonthlyReportCardZoneReports(int Year, int Month)
        {
            DataSet dsMonthlyReportCardZoneReport = null;
            List<MonthlyReportCardZone> ObjMonthlyReportCardZoneList = new List<MonthlyReportCardZone>();
            try
            {
                int Day = 1;
                if (Month == 01 || Month == 03 || Month == 05 || Month == 07 || Month == 08 || Month == 10 || Month == 12)
                {
                    Day = 31;
                }
                else if (Month == 02)
                {
                    Day = Year % 4 == 0 ? 29 : 28;
                }
                else
                {
                    Day = 30;
                }
                connection = SQLConnection.GetConnection();
                dsMonthlyReportCardZoneReport = new DataSet();
                SqlParameter[] spParams = new SqlParameter[]
               {
                   new SqlParameter("@Year",Year),
                   new SqlParameter("@Month",Month),
                   new SqlParameter("@Day",Day)
               };
                dsMonthlyReportCardZoneReport = SQLHelper.ExecuteDataset(connection, CommandType.StoredProcedure, SPName_Constants.GetMonthlyCardZoneData, spParams);
                if (dsMonthlyReportCardZoneReport != null && dsMonthlyReportCardZoneReport.Tables.Count > 0 && dsMonthlyReportCardZoneReport.Tables[0].Rows.Count > 0)
                {
                    var ZoneList = dsMonthlyReportCardZoneReport.Tables[0].AsEnumerable().Select(row => row.Field<string>("ZoneName")).Distinct().ToList();
                    double AllTotalTCalls = 0;
                    double AllTotalProductiveCalls = 0;
                    double AllTotalSales = 0;
                    double AllTotalWorkingManDays = 0;
                    double AllTotalSaltPrice = 0;
                    double AllTotalSaltCases = 0;
                    double AllTotalHoneyCases = 0;
                    double AllTotalHoneyPrice = 0;
                    double AllTotalWholeSpicesCases = 0;
                    double AllTotalWholeSpicesPrice = 0;
                    double AllTotalPowderSpicesCases = 0;
                    double AllTotalPowderSpicesPrice = 0;
                    double AllTotalBlendedSpicesCases = 0;
                    double AllTotalBlendedSpicesPrice = 0;
                    foreach (var zone in ZoneList)
                    {
                        MonthlyReportCardZone ObjMonthlyReportCardZone = new MonthlyReportCardZone();
                        ObjMonthlyReportCardZone.ZoneName = zone;
                        double TotalTCalls = 0;
                        double TotalProductiveCalls = 0;
                        double TotalSales = 0;
                        double TotalWorkingManDays = 0;
                        double TotalSaltPrice = 0;
                        double TotalSaltCases = 0;
                        double TotalHoneyCases = 0;
                        double TotalHoneyPrice = 0;
                        double TotalWholeSpicesCases = 0;
                        double TotalWholeSpicesPrice = 0;
                        double TotalPowderSpicesCases = 0;
                        double TotalPowderSpicesPrice = 0;
                        double TotalBlendedSpicesCases = 0;
                        double TotalBlendedSpicesPrice = 0;
                        DataRow SaltData = dsMonthlyReportCardZoneReport.Tables[0].Select("ZoneName='" + zone + "' and ProductCategory='SALT'").FirstOrDefault();
                        if (SaltData != null)
                        {
                            TotalTCalls += Convert.ToDouble(SaltData.Field<Int32>("TotalCalls"));
                            TotalWorkingManDays += SaltData.Field<Int32>("TotalSalesOfficer");
                            TotalProductiveCalls += SaltData.Field<Int32>("ProductiveCalls");
                            TotalSaltPrice = SaltData.Field<double>("TotalPrice");
                            TotalSales += TotalSaltPrice;
                            TotalSaltCases = SaltData.Field<double>("TotalCases");
                        }

                        DataRow HoneyData = dsMonthlyReportCardZoneReport.Tables[0].Select("ZoneName='" + zone + "' and ProductCategory='HONEY'").FirstOrDefault();
                        if (HoneyData != null)
                        {
                            TotalTCalls += HoneyData.Field<Int32>("TotalCalls");
                            TotalWorkingManDays += HoneyData.Field<Int32>("TotalSalesOfficer");
                            TotalProductiveCalls += HoneyData.Field<Int32>("ProductiveCalls");
                            TotalHoneyPrice = HoneyData.Field<double>("TotalPrice");
                            TotalSales += TotalHoneyPrice;
                            TotalHoneyCases = HoneyData.Field<double>("TotalCases");
                        }

                        DataRow WholeSpicesData = dsMonthlyReportCardZoneReport.Tables[0].Select("ZoneName='" + zone + "' and ProductCategory='WHOLE SPICES'").FirstOrDefault();
                        if (WholeSpicesData != null)
                        {
                            TotalTCalls += WholeSpicesData.Field<Int32>("TotalCalls");
                            TotalWorkingManDays += WholeSpicesData.Field<Int32>("TotalSalesOfficer");
                            TotalProductiveCalls += WholeSpicesData.Field<Int32>("ProductiveCalls");
                            TotalWholeSpicesPrice = WholeSpicesData.Field<double>("TotalPrice");
                            TotalSales += TotalWholeSpicesPrice;
                            TotalWholeSpicesCases = WholeSpicesData.Field<double>("TotalCases");
                        }

                        DataRow PowderSpicesData = dsMonthlyReportCardZoneReport.Tables[0].Select("ZoneName='" + zone + "' and ProductCategory='POWDER SPICES'").FirstOrDefault();
                        if (PowderSpicesData != null)
                        {
                            TotalTCalls += PowderSpicesData.Field<Int32>("TotalCalls");
                            TotalWorkingManDays += PowderSpicesData.Field<Int32>("TotalSalesOfficer");
                            TotalProductiveCalls += PowderSpicesData.Field<Int32>("ProductiveCalls");
                            TotalPowderSpicesPrice = PowderSpicesData.Field<double>("TotalPrice");
                            TotalSales += TotalPowderSpicesPrice;
                            TotalPowderSpicesCases = PowderSpicesData.Field<double>("TotalCases");
                        }

                        DataRow BlendedSpicesData = dsMonthlyReportCardZoneReport.Tables[0].Select("ZoneName='" + zone + "' and ProductCategory='BLENDED SPICES'").FirstOrDefault();
                        if (BlendedSpicesData != null)
                        {
                            TotalTCalls += BlendedSpicesData.Field<Int32>("TotalCalls");
                            TotalWorkingManDays += BlendedSpicesData.Field<Int32>("TotalSalesOfficer");
                            TotalProductiveCalls += BlendedSpicesData.Field<Int32>("ProductiveCalls");
                            TotalBlendedSpicesPrice = BlendedSpicesData.Field<double>("TotalPrice");
                            TotalSales += TotalBlendedSpicesPrice;
                            TotalBlendedSpicesCases = BlendedSpicesData.Field<double>("TotalCases");
                        }
                        ObjMonthlyReportCardZone.TotalCalls = TotalTCalls.ToString();
                        ObjMonthlyReportCardZone.ProductiveCalls = TotalProductiveCalls.ToString();
                        ObjMonthlyReportCardZone.TotalSales = TotalSales.ToString();
                        ObjMonthlyReportCardZone.WorkingManDays = TotalWorkingManDays.ToString();
                        ObjMonthlyReportCardZone.SaltPrice = TotalSaltPrice.ToString();
                        ObjMonthlyReportCardZone.HoneyPrice = TotalHoneyPrice.ToString();
                        ObjMonthlyReportCardZone.WholeSpicesPrice = TotalWholeSpicesPrice.ToString();
                        ObjMonthlyReportCardZone.PowderSpicesPrice = TotalPowderSpicesPrice.ToString();
                        ObjMonthlyReportCardZone.BlendedSpicesPrice = TotalBlendedSpicesPrice.ToString();
                        ObjMonthlyReportCardZone.SaltCases = TotalSaltCases.ToString();
                        ObjMonthlyReportCardZone.HoneyCases = TotalHoneyCases.ToString();
                        ObjMonthlyReportCardZone.WholeSpicesCases = TotalWholeSpicesCases.ToString();
                        ObjMonthlyReportCardZone.PowderSpicesCases = TotalPowderSpicesCases.ToString();
                        ObjMonthlyReportCardZone.BlendedSpicesCases = TotalBlendedSpicesCases.ToString();
                        AllTotalTCalls += TotalTCalls;
                        AllTotalProductiveCalls += TotalProductiveCalls;
                        AllTotalSales += TotalSales;
                        AllTotalWorkingManDays += TotalWorkingManDays;
                        AllTotalSaltPrice += TotalSaltPrice;
                        AllTotalSaltCases += TotalSaltCases;
                        AllTotalHoneyCases += TotalHoneyCases;
                        AllTotalHoneyPrice += TotalHoneyPrice;
                        AllTotalWholeSpicesCases += TotalWholeSpicesCases;
                        AllTotalWholeSpicesPrice += TotalWholeSpicesPrice;
                        AllTotalPowderSpicesCases += TotalPowderSpicesCases;
                        AllTotalPowderSpicesPrice += TotalPowderSpicesPrice;
                        AllTotalBlendedSpicesCases += TotalBlendedSpicesCases;
                        AllTotalBlendedSpicesPrice += TotalBlendedSpicesPrice;
                        ObjMonthlyReportCardZoneList.Add(ObjMonthlyReportCardZone);
                    }

                    MonthlyReportCardZone ObjMonthlyReportCardZoneTotal = new MonthlyReportCardZone();
                    ObjMonthlyReportCardZoneTotal.ZoneName = "Total";
                    ObjMonthlyReportCardZoneTotal.TotalCalls = AllTotalTCalls.ToString();
                    ObjMonthlyReportCardZoneTotal.ProductiveCalls = AllTotalProductiveCalls.ToString();
                    ObjMonthlyReportCardZoneTotal.TotalSales = AllTotalSales.ToString();
                    ObjMonthlyReportCardZoneTotal.WorkingManDays = AllTotalWorkingManDays.ToString();
                    ObjMonthlyReportCardZoneTotal.SaltPrice = AllTotalSaltPrice.ToString();
                    ObjMonthlyReportCardZoneTotal.HoneyPrice = AllTotalHoneyPrice.ToString();
                    ObjMonthlyReportCardZoneTotal.WholeSpicesPrice = AllTotalWholeSpicesPrice.ToString();
                    ObjMonthlyReportCardZoneTotal.PowderSpicesPrice = AllTotalPowderSpicesPrice.ToString();
                    ObjMonthlyReportCardZoneTotal.BlendedSpicesPrice = AllTotalBlendedSpicesPrice.ToString();
                    ObjMonthlyReportCardZoneTotal.SaltCases = AllTotalSaltCases.ToString();
                    ObjMonthlyReportCardZoneTotal.HoneyCases = AllTotalHoneyCases.ToString();
                    ObjMonthlyReportCardZoneTotal.WholeSpicesCases = AllTotalWholeSpicesCases.ToString();
                    ObjMonthlyReportCardZoneTotal.PowderSpicesCases = AllTotalWholeSpicesCases.ToString();
                    ObjMonthlyReportCardZoneTotal.BlendedSpicesCases = AllTotalBlendedSpicesCases.ToString();
                    ObjMonthlyReportCardZoneList.Add(ObjMonthlyReportCardZoneTotal);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
                connection.Dispose();
            }
            return ObjMonthlyReportCardZoneList;
        }

        /// <summary>
        /// Getting Monthly Report Card Area Head Reports - Dharmendra11112019
        /// </summary>
        /// <returns></returns>
        public List<MonthlyReportCardAreaHead> GetMonthlyReportCardAreaHeadReports(int Year, int Month)
        {
            DataSet dsMonthlyReportCardAreaHeadReport = null;
            List<MonthlyReportCardAreaHead> ObjMonthlyReportCardAreaHeadList = new List<MonthlyReportCardAreaHead>();
            try
            {
                int Day = 1;
                if (Month == 01 || Month == 03 || Month == 05 || Month == 07 || Month == 08 || Month == 10 || Month == 12)
                {
                    Day = 31;
                }
                else if (Month == 02)
                {
                    Day = Year % 4 == 0 ? 29 : 28;
                }
                else
                {
                    Day = 30;
                }
                connection = SQLConnection.GetConnection();
                dsMonthlyReportCardAreaHeadReport = new DataSet();
                SqlParameter[] spParams = new SqlParameter[]
               {
                   new SqlParameter("@Year",Year),
                   new SqlParameter("@Month",Month),
                   new SqlParameter("@Day",Day)
               };
                dsMonthlyReportCardAreaHeadReport = SQLHelper.ExecuteDataset(connection, CommandType.StoredProcedure, SPName_Constants.GetMonthlyCardAreaHeadData, spParams);
                if (dsMonthlyReportCardAreaHeadReport != null && dsMonthlyReportCardAreaHeadReport.Tables.Count > 0 && dsMonthlyReportCardAreaHeadReport.Tables[0].Rows.Count > 0)
                {
                    var AreaHeadList = dsMonthlyReportCardAreaHeadReport.Tables[0].AsEnumerable().Select(row => row.Field<string>("AreaHeadName")).Distinct().ToList();
                    double AllTotalTCalls = 0;
                    double AllTotalProductiveCalls = 0;
                    double AllTotalSales = 0;
                    double AllTotalWorkingManDays = 0;
                    double AllTotalSaltPrice = 0;
                    double AllTotalSaltCases = 0;
                    double AllTotalHoneyCases = 0;
                    double AllTotalHoneyPrice = 0;
                    double AllTotalWholeSpicesCases = 0;
                    double AllTotalWholeSpicesPrice = 0;
                    double AllTotalPowderSpicesCases = 0;
                    double AllTotalPowderSpicesPrice = 0;
                    double AllTotalBlendedSpicesCases = 0;
                    double AllTotalBlendedSpicesPrice = 0;
                    foreach (var AreaHead in AreaHeadList)
                    {
                        MonthlyReportCardAreaHead ObjMonthlyReportCardAreaHead = new MonthlyReportCardAreaHead();
                        DataRow AreaHeadData = dsMonthlyReportCardAreaHeadReport.Tables[0].Select("AreaHeadName='" + AreaHead + "'").FirstOrDefault();
                        ObjMonthlyReportCardAreaHead.AreaHeadName = AreaHead;
                        ObjMonthlyReportCardAreaHead.HeadQuaterName = AreaHeadData.Field<string>("HeadQuaterName");
                        ObjMonthlyReportCardAreaHead.StateName = AreaHeadData.Field<string>("StateName");
                        ObjMonthlyReportCardAreaHead.ZoneName = AreaHeadData.Field<string>("ZoneName");
                        double TotalTCalls = 0;
                        double TotalProductiveCalls = 0;
                        double TotalSales = 0;
                        double TotalWorkingManDays = 0;
                        double TotalSaltPrice = 0;
                        double TotalSaltCases = 0;
                        double TotalHoneyCases = 0;
                        double TotalHoneyPrice = 0;
                        double TotalWholeSpicesCases = 0;
                        double TotalWholeSpicesPrice = 0;
                        double TotalPowderSpicesCases = 0;
                        double TotalPowderSpicesPrice = 0;
                        double TotalBlendedSpicesCases = 0;
                        double TotalBlendedSpicesPrice = 0;
                        DataRow SaltData = dsMonthlyReportCardAreaHeadReport.Tables[0].Select("ZoneName='" + ObjMonthlyReportCardAreaHead.ZoneName + "' and AreaHeadName='"+ ObjMonthlyReportCardAreaHead.AreaHeadName + "' and StateName='"+ ObjMonthlyReportCardAreaHead.StateName + "' and HeadQuaterName='"+ ObjMonthlyReportCardAreaHead.HeadQuaterName + "' and ProductCategory='SALT'").FirstOrDefault();
                        if (SaltData != null)
                        {
                            TotalTCalls += Convert.ToDouble(SaltData.Field<Int32>("TotalCalls"));
                            TotalWorkingManDays += SaltData.Field<Int32>("TotalSalesOfficer");
                            TotalProductiveCalls += SaltData.Field<Int32>("ProductiveCalls");
                            TotalSaltPrice = SaltData.Field<double>("TotalPrice");
                            TotalSales += TotalSaltPrice;
                            TotalSaltCases = SaltData.Field<double>("TotalCases");
                        }

                        DataRow HoneyData = dsMonthlyReportCardAreaHeadReport.Tables[0].Select("ZoneName='" + ObjMonthlyReportCardAreaHead.ZoneName + "' and AreaHeadName='" + ObjMonthlyReportCardAreaHead.AreaHeadName + "' and StateName='" + ObjMonthlyReportCardAreaHead.StateName + "' and HeadQuaterName='" + ObjMonthlyReportCardAreaHead.HeadQuaterName + "' and ProductCategory='HONEY'").FirstOrDefault();
                        if (HoneyData != null)
                        {
                            TotalTCalls += HoneyData.Field<Int32>("TotalCalls");
                            TotalWorkingManDays += HoneyData.Field<Int32>("TotalSalesOfficer");
                            TotalProductiveCalls += HoneyData.Field<Int32>("ProductiveCalls");
                            TotalHoneyPrice = HoneyData.Field<double>("TotalPrice");
                            TotalSales += TotalHoneyPrice;
                            TotalHoneyCases = HoneyData.Field<double>("TotalCases");
                        }

                        DataRow WholeSpicesData = dsMonthlyReportCardAreaHeadReport.Tables[0].Select("ZoneName='" + ObjMonthlyReportCardAreaHead.ZoneName + "' and AreaHeadName='" + ObjMonthlyReportCardAreaHead.AreaHeadName + "' and StateName='" + ObjMonthlyReportCardAreaHead.StateName + "' and HeadQuaterName='" + ObjMonthlyReportCardAreaHead.HeadQuaterName + "' and ProductCategory='WHOLE SPICES'").FirstOrDefault();
                        if (WholeSpicesData != null)
                        {
                            TotalTCalls += WholeSpicesData.Field<Int32>("TotalCalls");
                            TotalWorkingManDays += WholeSpicesData.Field<Int32>("TotalSalesOfficer");
                            TotalProductiveCalls += WholeSpicesData.Field<Int32>("ProductiveCalls");
                            TotalWholeSpicesPrice = WholeSpicesData.Field<double>("TotalPrice");
                            TotalSales += TotalWholeSpicesPrice;
                            TotalWholeSpicesCases = WholeSpicesData.Field<double>("TotalCases");
                        }

                        DataRow PowderSpicesData = dsMonthlyReportCardAreaHeadReport.Tables[0].Select("ZoneName='" + ObjMonthlyReportCardAreaHead.ZoneName + "' and AreaHeadName='" + ObjMonthlyReportCardAreaHead.AreaHeadName + "' and StateName='" + ObjMonthlyReportCardAreaHead.StateName + "' and HeadQuaterName='" + ObjMonthlyReportCardAreaHead.HeadQuaterName + "' and ProductCategory='POWDER SPICES'").FirstOrDefault();
                        if (PowderSpicesData != null)
                        {
                            TotalTCalls += PowderSpicesData.Field<Int32>("TotalCalls");
                            TotalWorkingManDays += PowderSpicesData.Field<Int32>("TotalSalesOfficer");
                            TotalProductiveCalls += PowderSpicesData.Field<Int32>("ProductiveCalls");
                            TotalPowderSpicesPrice = PowderSpicesData.Field<double>("TotalPrice");
                            TotalSales += TotalPowderSpicesPrice;
                            TotalPowderSpicesCases = PowderSpicesData.Field<double>("TotalCases");
                        }

                        DataRow BlendedSpicesData = dsMonthlyReportCardAreaHeadReport.Tables[0].Select("ZoneName='" + ObjMonthlyReportCardAreaHead.ZoneName + "' and AreaHeadName='" + ObjMonthlyReportCardAreaHead.AreaHeadName + "' and StateName='" + ObjMonthlyReportCardAreaHead.StateName + "' and HeadQuaterName='" + ObjMonthlyReportCardAreaHead.HeadQuaterName + "' and ProductCategory='BLENDED SPICES'").FirstOrDefault();
                        if (BlendedSpicesData != null)
                        {
                            TotalTCalls += BlendedSpicesData.Field<Int32>("TotalCalls");
                            TotalWorkingManDays += BlendedSpicesData.Field<Int32>("TotalSalesOfficer");
                            TotalProductiveCalls += BlendedSpicesData.Field<Int32>("ProductiveCalls");
                            TotalBlendedSpicesPrice = BlendedSpicesData.Field<double>("TotalPrice");
                            TotalSales += TotalBlendedSpicesPrice;
                            TotalBlendedSpicesCases = BlendedSpicesData.Field<double>("TotalCases");
                        }
                        ObjMonthlyReportCardAreaHead.TotalCalls = TotalTCalls.ToString();
                        ObjMonthlyReportCardAreaHead.ProductiveCalls = TotalProductiveCalls.ToString();
                        ObjMonthlyReportCardAreaHead.TotalSales = TotalSales.ToString();
                        ObjMonthlyReportCardAreaHead.WorkingManDays = TotalWorkingManDays.ToString();
                        ObjMonthlyReportCardAreaHead.SaltPrice = TotalSaltPrice.ToString();
                        ObjMonthlyReportCardAreaHead.HoneyPrice = TotalHoneyPrice.ToString();
                        ObjMonthlyReportCardAreaHead.WholeSpicesPrice = TotalWholeSpicesPrice.ToString();
                        ObjMonthlyReportCardAreaHead.PowderSpicesPrice = TotalPowderSpicesPrice.ToString();
                        ObjMonthlyReportCardAreaHead.BlendedSpicesPrice = TotalBlendedSpicesPrice.ToString();
                        ObjMonthlyReportCardAreaHead.SaltCases = TotalSaltCases.ToString();
                        ObjMonthlyReportCardAreaHead.HoneyCases = TotalHoneyCases.ToString();
                        ObjMonthlyReportCardAreaHead.WholeSpicesCases = TotalWholeSpicesCases.ToString();
                        ObjMonthlyReportCardAreaHead.PowderSpicesCases = TotalPowderSpicesCases.ToString();
                        ObjMonthlyReportCardAreaHead.BlendedSpicesCases = TotalBlendedSpicesCases.ToString();
                        AllTotalTCalls += TotalTCalls;
                        AllTotalProductiveCalls += TotalProductiveCalls;
                        AllTotalSales += TotalSales;
                        AllTotalWorkingManDays += TotalWorkingManDays;
                        AllTotalSaltPrice += TotalSaltPrice;
                        AllTotalSaltCases += TotalSaltCases;
                        AllTotalHoneyCases += TotalHoneyCases;
                        AllTotalHoneyPrice += TotalHoneyPrice;
                        AllTotalWholeSpicesCases += TotalWholeSpicesCases;
                        AllTotalWholeSpicesPrice += TotalWholeSpicesPrice;
                        AllTotalPowderSpicesCases += TotalPowderSpicesCases;
                        AllTotalPowderSpicesPrice += TotalPowderSpicesPrice;
                        AllTotalBlendedSpicesCases += TotalBlendedSpicesCases;
                        AllTotalBlendedSpicesPrice += TotalBlendedSpicesPrice;
                        ObjMonthlyReportCardAreaHeadList.Add(ObjMonthlyReportCardAreaHead);
                    }

                    MonthlyReportCardAreaHead ObjMonthlyReportCardAreaHeadTotal = new MonthlyReportCardAreaHead();
                    ObjMonthlyReportCardAreaHeadTotal.AreaHeadName = "Total";
                   ObjMonthlyReportCardAreaHeadTotal.TotalCalls = AllTotalTCalls.ToString();
                    ObjMonthlyReportCardAreaHeadTotal.ProductiveCalls = AllTotalProductiveCalls.ToString();
                    ObjMonthlyReportCardAreaHeadTotal.TotalSales = AllTotalSales.ToString();
                    ObjMonthlyReportCardAreaHeadTotal.WorkingManDays = AllTotalWorkingManDays.ToString();
                    ObjMonthlyReportCardAreaHeadTotal.SaltPrice = AllTotalSaltPrice.ToString();
                    ObjMonthlyReportCardAreaHeadTotal.HoneyPrice = AllTotalHoneyPrice.ToString();
                    ObjMonthlyReportCardAreaHeadTotal.WholeSpicesPrice = AllTotalWholeSpicesPrice.ToString();
                    ObjMonthlyReportCardAreaHeadTotal.PowderSpicesPrice = AllTotalPowderSpicesPrice.ToString();
                    ObjMonthlyReportCardAreaHeadTotal.BlendedSpicesPrice = AllTotalBlendedSpicesPrice.ToString();
                    ObjMonthlyReportCardAreaHeadTotal.SaltCases = AllTotalSaltCases.ToString();
                    ObjMonthlyReportCardAreaHeadTotal.HoneyCases = AllTotalHoneyCases.ToString();
                    ObjMonthlyReportCardAreaHeadTotal.WholeSpicesCases = AllTotalWholeSpicesCases.ToString();
                    ObjMonthlyReportCardAreaHeadTotal.PowderSpicesCases = AllTotalWholeSpicesCases.ToString();
                    ObjMonthlyReportCardAreaHeadTotal.BlendedSpicesCases = AllTotalBlendedSpicesCases.ToString();
                    ObjMonthlyReportCardAreaHeadList.Add(ObjMonthlyReportCardAreaHeadTotal);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
                connection.Dispose();
            }
            return ObjMonthlyReportCardAreaHeadList;
        }

        /// <summary>
        /// Getting Monthly Report Card SO Reports - Dharmendra11112019
        /// </summary>
        /// <returns></returns>
        public List<MonthlyReportCardSO> GetMonthlyReportCardSOReports(int Year, int Month)
        {
            DataSet dsMonthlyReportCardSOReport = null;
            List<MonthlyReportCardSO> ObjMonthlyReportCardSOList = new List<MonthlyReportCardSO>();
            try
            {
                int Day = 1;
                if (Month == 01 || Month == 03 || Month == 05 || Month == 07 || Month == 08 || Month == 10 || Month == 12)
                {
                    Day = 31;
                }
                else if (Month == 02)
                {
                    Day = Year % 4 == 0 ? 29 : 28;
                }
                else
                {
                    Day = 30;
                }
                connection = SQLConnection.GetConnection();
                dsMonthlyReportCardSOReport = new DataSet();
                SqlParameter[] spParams = new SqlParameter[]
               {
                   new SqlParameter("@Year",Year),
                   new SqlParameter("@Month",Month),
                   new SqlParameter("@Day",Day)
               };
                dsMonthlyReportCardSOReport = SQLHelper.ExecuteDataset(connection, CommandType.StoredProcedure, SPName_Constants.GetMonthlyCardSOData, spParams);
                if (dsMonthlyReportCardSOReport != null && dsMonthlyReportCardSOReport.Tables.Count > 0 && dsMonthlyReportCardSOReport.Tables[0].Rows.Count > 0)
                {
                    var SalesOfficerList = dsMonthlyReportCardSOReport.Tables[0].AsEnumerable().Select(row => row.Field<string>("SalesOfficerName")).Distinct().ToList();
                    double AllTotalTCalls = 0;
                    double AllTotalProductiveCalls = 0;
                    double AllTotalSales = 0;
                    double AllTotalWorkingManDays = 0;
                    double AllTotalSaltPrice = 0;
                    double AllTotalSaltCases = 0;
                    double AllTotalHoneyCases = 0;
                    double AllTotalHoneyPrice = 0;
                    double AllTotalWholeSpicesCases = 0;
                    double AllTotalWholeSpicesPrice = 0;
                    double AllTotalPowderSpicesCases = 0;
                    double AllTotalPowderSpicesPrice = 0;
                    double AllTotalBlendedSpicesCases = 0;
                    double AllTotalBlendedSpicesPrice = 0;
                    foreach (var SalesOfficer in SalesOfficerList)
                    {
                        MonthlyReportCardSO ObjMonthlyReportCardSO = new MonthlyReportCardSO();
                        DataRow SalesOfficerData = dsMonthlyReportCardSOReport.Tables[0].Select("SalesOfficerName='" + SalesOfficer + "'").FirstOrDefault();
                        ObjMonthlyReportCardSO.SalesOfficerName = SalesOfficerData.Field<string>("SalesOfficerName");
                        ObjMonthlyReportCardSO.AreaHeadName = SalesOfficerData.Field<string>("AreaHeadName");
                        ObjMonthlyReportCardSO.HeadQuaterName = SalesOfficerData.Field<string>("HeadQuaterName");
                        ObjMonthlyReportCardSO.StateName = SalesOfficerData.Field<string>("StateName");
                        ObjMonthlyReportCardSO.ZoneName = SalesOfficerData.Field<string>("ZoneName");
                        double TotalTCalls = 0;
                        double TotalProductiveCalls = 0;
                        double TotalSales = 0;
                        double TotalWorkingManDays = 0;
                        double TotalSaltPrice = 0;
                        double TotalSaltCases = 0;
                        double TotalHoneyCases = 0;
                        double TotalHoneyPrice = 0;
                        double TotalWholeSpicesCases = 0;
                        double TotalWholeSpicesPrice = 0;
                        double TotalPowderSpicesCases = 0;
                        double TotalPowderSpicesPrice = 0;
                        double TotalBlendedSpicesCases = 0;
                        double TotalBlendedSpicesPrice = 0;
                        DataRow SaltData = dsMonthlyReportCardSOReport.Tables[0].Select("ZoneName='" + ObjMonthlyReportCardSO.ZoneName + "' and AreaHeadName='" + ObjMonthlyReportCardSO.AreaHeadName + "' and StateName='" + ObjMonthlyReportCardSO.StateName + "' and HeadQuaterName='" + ObjMonthlyReportCardSO.HeadQuaterName + "' and SalesOfficerName='"+ ObjMonthlyReportCardSO.SalesOfficerName + "' and ProductCategory='SALT'").FirstOrDefault();
                        if (SaltData != null)
                        {
                            TotalTCalls += Convert.ToDouble(SaltData.Field<Int32>("TotalCalls"));
                            TotalWorkingManDays += SaltData.Field<Int32>("TotalSalesOfficer");
                            TotalProductiveCalls += SaltData.Field<Int32>("ProductiveCalls");
                            TotalSaltPrice = SaltData.Field<double>("TotalPrice");
                            TotalSales += TotalSaltPrice;
                            TotalSaltCases = SaltData.Field<double>("TotalCases");
                        }

                        DataRow HoneyData = dsMonthlyReportCardSOReport.Tables[0].Select("ZoneName='" + ObjMonthlyReportCardSO.ZoneName + "' and AreaHeadName='" + ObjMonthlyReportCardSO.AreaHeadName + "' and StateName='" + ObjMonthlyReportCardSO.StateName + "' and HeadQuaterName='" + ObjMonthlyReportCardSO.HeadQuaterName + "' and SalesOfficerName='" + ObjMonthlyReportCardSO.SalesOfficerName + "' and ProductCategory='HONEY'").FirstOrDefault();
                        if (HoneyData != null)
                        {
                            TotalTCalls += HoneyData.Field<Int32>("TotalCalls");
                            TotalWorkingManDays += HoneyData.Field<Int32>("TotalSalesOfficer");
                            TotalProductiveCalls += HoneyData.Field<Int32>("ProductiveCalls");
                            TotalHoneyPrice = HoneyData.Field<double>("TotalPrice");
                            TotalSales += TotalHoneyPrice;
                            TotalHoneyCases = HoneyData.Field<double>("TotalCases");
                        }

                        DataRow WholeSpicesData = dsMonthlyReportCardSOReport.Tables[0].Select("ZoneName='" + ObjMonthlyReportCardSO.ZoneName + "' and AreaHeadName='" + ObjMonthlyReportCardSO.AreaHeadName + "' and StateName='" + ObjMonthlyReportCardSO.StateName + "' and HeadQuaterName='" + ObjMonthlyReportCardSO.HeadQuaterName + "' and SalesOfficerName='" + ObjMonthlyReportCardSO.SalesOfficerName + "' and ProductCategory='WHOLE SPICES'").FirstOrDefault();
                        if (WholeSpicesData != null)
                        {
                            TotalTCalls += WholeSpicesData.Field<Int32>("TotalCalls");
                            TotalWorkingManDays += WholeSpicesData.Field<Int32>("TotalSalesOfficer");
                            TotalProductiveCalls += WholeSpicesData.Field<Int32>("ProductiveCalls");
                            TotalWholeSpicesPrice = WholeSpicesData.Field<double>("TotalPrice");
                            TotalSales += TotalWholeSpicesPrice;
                            TotalWholeSpicesCases = WholeSpicesData.Field<double>("TotalCases");
                        }

                        DataRow PowderSpicesData = dsMonthlyReportCardSOReport.Tables[0].Select("ZoneName='" + ObjMonthlyReportCardSO.ZoneName + "' and AreaHeadName='" + ObjMonthlyReportCardSO.AreaHeadName + "' and StateName='" + ObjMonthlyReportCardSO.StateName + "' and HeadQuaterName='" + ObjMonthlyReportCardSO.HeadQuaterName + "' and SalesOfficerName='" + ObjMonthlyReportCardSO.SalesOfficerName + "' and ProductCategory='POWDER SPICES'").FirstOrDefault();
                        if (PowderSpicesData != null)
                        {
                            TotalTCalls += PowderSpicesData.Field<Int32>("TotalCalls");
                            TotalWorkingManDays += PowderSpicesData.Field<Int32>("TotalSalesOfficer");
                            TotalProductiveCalls += PowderSpicesData.Field<Int32>("ProductiveCalls");
                            TotalPowderSpicesPrice = PowderSpicesData.Field<double>("TotalPrice");
                            TotalSales += TotalPowderSpicesPrice;
                            TotalPowderSpicesCases = PowderSpicesData.Field<double>("TotalCases");
                        }

                        DataRow BlendedSpicesData = dsMonthlyReportCardSOReport.Tables[0].Select("ZoneName='" + ObjMonthlyReportCardSO.ZoneName + "' and AreaHeadName='" + ObjMonthlyReportCardSO.AreaHeadName + "' and StateName='" + ObjMonthlyReportCardSO.StateName + "' and HeadQuaterName='" + ObjMonthlyReportCardSO.HeadQuaterName + "' and SalesOfficerName='" + ObjMonthlyReportCardSO.SalesOfficerName + "' and ProductCategory='BLENDED SPICES'").FirstOrDefault();
                        if (BlendedSpicesData != null)
                        {
                            TotalTCalls += BlendedSpicesData.Field<Int32>("TotalCalls");
                            TotalWorkingManDays += BlendedSpicesData.Field<Int32>("TotalSalesOfficer");
                            TotalProductiveCalls += BlendedSpicesData.Field<Int32>("ProductiveCalls");
                            TotalBlendedSpicesPrice = BlendedSpicesData.Field<double>("TotalPrice");
                            TotalSales += TotalBlendedSpicesPrice;
                            TotalBlendedSpicesCases = BlendedSpicesData.Field<double>("TotalCases");
                        }
                        ObjMonthlyReportCardSO.TotalCalls = TotalTCalls.ToString();
                        ObjMonthlyReportCardSO.ProductiveCalls = TotalProductiveCalls.ToString();
                        ObjMonthlyReportCardSO.TotalSales = TotalSales.ToString();
                        ObjMonthlyReportCardSO.WorkingManDays = TotalWorkingManDays.ToString();
                        ObjMonthlyReportCardSO.SaltPrice = TotalSaltPrice.ToString();
                        ObjMonthlyReportCardSO.HoneyPrice = TotalHoneyPrice.ToString();
                        ObjMonthlyReportCardSO.WholeSpicesPrice = TotalWholeSpicesPrice.ToString();
                        ObjMonthlyReportCardSO.PowderSpicesPrice = TotalPowderSpicesPrice.ToString();
                        ObjMonthlyReportCardSO.BlendedSpicesPrice = TotalBlendedSpicesPrice.ToString();
                        ObjMonthlyReportCardSO.SaltCases = TotalSaltCases.ToString();
                        ObjMonthlyReportCardSO.HoneyCases = TotalHoneyCases.ToString();
                        ObjMonthlyReportCardSO.WholeSpicesCases = TotalWholeSpicesCases.ToString();
                        ObjMonthlyReportCardSO.PowderSpicesCases = TotalPowderSpicesCases.ToString();
                        ObjMonthlyReportCardSO.BlendedSpicesCases = TotalBlendedSpicesCases.ToString();
                        AllTotalTCalls += TotalTCalls;
                        AllTotalProductiveCalls += TotalProductiveCalls;
                        AllTotalSales += TotalSales;
                        AllTotalWorkingManDays += TotalWorkingManDays;
                        AllTotalSaltPrice += TotalSaltPrice;
                        AllTotalSaltCases += TotalSaltCases;
                        AllTotalHoneyCases += TotalHoneyCases;
                        AllTotalHoneyPrice += TotalHoneyPrice;
                        AllTotalWholeSpicesCases += TotalWholeSpicesCases;
                        AllTotalWholeSpicesPrice += TotalWholeSpicesPrice;
                        AllTotalPowderSpicesCases += TotalPowderSpicesCases;
                        AllTotalPowderSpicesPrice += TotalPowderSpicesPrice;
                        AllTotalBlendedSpicesCases += TotalBlendedSpicesCases;
                        AllTotalBlendedSpicesPrice += TotalBlendedSpicesPrice;
                        ObjMonthlyReportCardSOList.Add(ObjMonthlyReportCardSO);
                    }

                    MonthlyReportCardSO ObjMonthlyReportCardSOTotal = new MonthlyReportCardSO();
                    ObjMonthlyReportCardSOTotal.SalesOfficerName = "Total";
                    ObjMonthlyReportCardSOTotal.TotalCalls = AllTotalTCalls.ToString();
                    ObjMonthlyReportCardSOTotal.ProductiveCalls = AllTotalProductiveCalls.ToString();
                    ObjMonthlyReportCardSOTotal.TotalSales = AllTotalSales.ToString();
                    ObjMonthlyReportCardSOTotal.WorkingManDays = AllTotalWorkingManDays.ToString();
                    ObjMonthlyReportCardSOTotal.SaltPrice = AllTotalSaltPrice.ToString();
                    ObjMonthlyReportCardSOTotal.HoneyPrice = AllTotalHoneyPrice.ToString();
                    ObjMonthlyReportCardSOTotal.WholeSpicesPrice = AllTotalWholeSpicesPrice.ToString();
                    ObjMonthlyReportCardSOTotal.PowderSpicesPrice = AllTotalPowderSpicesPrice.ToString();
                    ObjMonthlyReportCardSOTotal.BlendedSpicesPrice = AllTotalBlendedSpicesPrice.ToString();
                    ObjMonthlyReportCardSOTotal.SaltCases = AllTotalSaltCases.ToString();
                    ObjMonthlyReportCardSOTotal.HoneyCases = AllTotalHoneyCases.ToString();
                    ObjMonthlyReportCardSOTotal.WholeSpicesCases = AllTotalWholeSpicesCases.ToString();
                    ObjMonthlyReportCardSOTotal.PowderSpicesCases = AllTotalWholeSpicesCases.ToString();
                    ObjMonthlyReportCardSOTotal.BlendedSpicesCases = AllTotalBlendedSpicesCases.ToString();
                    ObjMonthlyReportCardSOList.Add(ObjMonthlyReportCardSOTotal);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
                connection.Dispose();
            }
            return ObjMonthlyReportCardSOList;
        }

        /// <summary>
        /// To get user id and password.
        /// </summary>
        /// <returns></returns>
        public List<UserAndPassword> GetUserAndPassword()
        {
            DataSet dsUsersandPassword = null;
            List<UserAndPassword> userAndPasswords = new List<UserAndPassword>();
            try
            {
                connection = SQLConnection.GetConnection();
                dsUsersandPassword = new DataSet();
                dsUsersandPassword = SQLHelper.ExecuteDataset(connection, CommandType.StoredProcedure, SPName_Constants.GetUserAndTheirPassword, null);
                if (dsUsersandPassword != null && dsUsersandPassword.Tables.Count > 0 && dsUsersandPassword.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < dsUsersandPassword.Tables[0].Rows.Count; i++)
                    {
                        UserAndPassword objUserAndPassword = new UserAndPassword();

                        objUserAndPassword.UserName = dsUsersandPassword.Tables[0].Rows[i]["UserName"].ToString();
                        objUserAndPassword.ContactNumber = dsUsersandPassword.Tables[0].Rows[i]["ContactNumber"].ToString();
                        objUserAndPassword.Password = dsUsersandPassword.Tables[0].Rows[i]["Password"].ToString();

                        userAndPasswords.Add(objUserAndPassword);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
                connection.Dispose();
            }
            return userAndPasswords;
        }

        /// <summary>
        /// To check provided Contact Number or email is already used or not.
        /// </summary>
        /// <param name="customerDetailsEntity"></param>
        /// <returns></returns>
        public SalesOfficer GetExistingCustomerDetails(SalesOfficer customerDetailsEntity)
        {
            DataSet dsCustDetails = null;
            SalesOfficer customerDetails = new SalesOfficer();
            try
            {
                connection = SQLConnection.GetConnection();
                dsCustDetails = new DataSet();
                SqlParameter[] spParams = new SqlParameter[]
                {
                   new SqlParameter("@ContactNumber",customerDetailsEntity.ContactNumber),
                   new SqlParameter("@Email",customerDetailsEntity.Email)
                };
                dsCustDetails = SQLHelper.ExecuteDataset(connection, CommandType.StoredProcedure, SPName_Constants.GetExistingCustomer, spParams);
                if (dsCustDetails != null && dsCustDetails.Tables.Count > 0 && dsCustDetails.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < dsCustDetails.Tables[0].Rows.Count; i++)
                    {
                        if (dsCustDetails.Tables[0].Rows[i]["Id"] != DBNull.Value)
                        {
                            customerDetails.Id = Convert.ToInt32(dsCustDetails.Tables[0].Rows[i]["Id"].ToString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
                connection.Dispose();
            }
            return customerDetails;
        }

        /// <summary>
        /// To add update product price configuration.
        /// </summary>
        /// <param name="productPriceConfiguration"></param>
        /// <returns></returns>
        public bool AddProductPriceConfiguration(ProductPriceConfiguration productPriceConfiguration)
        {
            bool isSuccess = false;
            try
            {
                connection = SQLConnection.GetConnection();
                SqlParameter[] spParams = new SqlParameter[]
                {
                   new SqlParameter("@ProductId",productPriceConfiguration.ProductId),
                   new SqlParameter("@ZoneId",productPriceConfiguration.ZoneId),
                   new SqlParameter("@StateId",productPriceConfiguration.StateId),
                   new SqlParameter("@HeadQuaterId",productPriceConfiguration.HeadQuaterId),
                   new SqlParameter("@ProductPrice",productPriceConfiguration.ProductPrice),
                   new SqlParameter("@CreatedBy",productPriceConfiguration.CreatedBy),
                   new SqlParameter("@IsActive",productPriceConfiguration.IsActive)
                };
                int result = Convert.ToInt32(SQLHelper.ExecuteNonQuery(connection, CommandType.StoredProcedure, SPName_Constants.AddProductPriceConfiguration, spParams));
                if (result > 0)
                {
                    isSuccess = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
                connection.Dispose();
            }
            return isSuccess;
        }

        /// <summary>
        /// To get all product price configurations.
        /// </summary>
        /// <returns></returns>
        public List<ProductPriceConfiguration> GetProductPriceConfiguration()
        {
            DataSet dsProductPriceConfiguration = null;
            List<ProductPriceConfiguration> productPriceConfigurations = new List<ProductPriceConfiguration>();
            try
            {
                connection = SQLConnection.GetConnection();
                dsProductPriceConfiguration = new DataSet();
                dsProductPriceConfiguration = SQLHelper.ExecuteDataset(connection, CommandType.StoredProcedure, SPName_Constants.GetProductPriceConfiguration, null);
                if (dsProductPriceConfiguration != null && dsProductPriceConfiguration.Tables.Count > 0 && dsProductPriceConfiguration.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < dsProductPriceConfiguration.Tables[0].Rows.Count; i++)
                    {
                        ProductPriceConfiguration objProductPriceConfiguration = new ProductPriceConfiguration();

                        objProductPriceConfiguration.ProductName = dsProductPriceConfiguration.Tables[0].Rows[i]["ProductName"].ToString();
                        objProductPriceConfiguration.ZoneName = dsProductPriceConfiguration.Tables[0].Rows[i]["ZoneName"].ToString();
                        objProductPriceConfiguration.StateName = dsProductPriceConfiguration.Tables[0].Rows[i]["StateName"].ToString();
                        objProductPriceConfiguration.HeadQuaterName = dsProductPriceConfiguration.Tables[0].Rows[i]["HeadQuaterName"].ToString();
                        if (dsProductPriceConfiguration.Tables[0].Rows[i]["ProductId"] != DBNull.Value)
                        {
                            objProductPriceConfiguration.ProductId = Convert.ToInt32(dsProductPriceConfiguration.Tables[0].Rows[i]["ProductId"].ToString());
                        }
                        if (dsProductPriceConfiguration.Tables[0].Rows[i]["ZoneId"] != DBNull.Value)
                        {
                            objProductPriceConfiguration.ZoneId = Convert.ToInt32(dsProductPriceConfiguration.Tables[0].Rows[i]["ZoneId"].ToString());
                        }
                        if (dsProductPriceConfiguration.Tables[0].Rows[i]["StateId"] != DBNull.Value)
                        {
                            objProductPriceConfiguration.StateId = Convert.ToInt32(dsProductPriceConfiguration.Tables[0].Rows[i]["StateId"].ToString());
                        }
                        if (dsProductPriceConfiguration.Tables[0].Rows[i]["HeadQuaterId"] != DBNull.Value)
                        {
                            objProductPriceConfiguration.HeadQuaterId = Convert.ToInt32(dsProductPriceConfiguration.Tables[0].Rows[i]["HeadQuaterId"].ToString());
                        }
                        if (dsProductPriceConfiguration.Tables[0].Rows[i]["ProductPrice"] != DBNull.Value)
                        {
                            objProductPriceConfiguration.ProductPrice = Convert.ToDecimal(dsProductPriceConfiguration.Tables[0].Rows[i]["ProductPrice"].ToString());
                        }
                        if (dsProductPriceConfiguration.Tables[0].Rows[i]["IsActive"] != DBNull.Value)
                        {
                            objProductPriceConfiguration.IsActive = Convert.ToBoolean(dsProductPriceConfiguration.Tables[0].Rows[i]["IsActive"].ToString());
                        }
                        productPriceConfigurations.Add(objProductPriceConfiguration);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
                connection.Dispose();
            }
            return productPriceConfigurations;
        }

        /// <summary>
        /// To get all active zones.
        /// </summary>
        /// <returns></returns>
        public List<ZoneWiseAreaHeadSalesOfficer> GetActiveZones()
        {
            DataSet dsZones = null;
            List<ZoneWiseAreaHeadSalesOfficer> zones = new List<ZoneWiseAreaHeadSalesOfficer>();
            try
            {
                connection = SQLConnection.GetConnection();
                dsZones = new DataSet();
                dsZones = SQLHelper.ExecuteDataset(connection, CommandType.StoredProcedure, SPName_Constants.GetActiveZonesWithAllZones, null);
                if (dsZones != null && dsZones.Tables.Count > 0 && dsZones.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < dsZones.Tables[0].Rows.Count; i++)
                    {
                        ZoneWiseAreaHeadSalesOfficer zone = new ZoneWiseAreaHeadSalesOfficer();
                        if (dsZones.Tables[0].Rows[i]["Id"] != DBNull.Value)
                        {
                            zone.ZoneId = Convert.ToInt32(dsZones.Tables[0].Rows[i]["Id"].ToString());
                        }
                        zone.ZoneName = dsZones.Tables[0].Rows[i]["ZoneName"].ToString();
                        zones.Add(zone);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
                connection.Dispose();
            }
            return zones;
        }

        /// <summary>
        /// To get all area heads by zone.
        /// </summary>
        /// <param name="zone"></param>
        /// <returns></returns>
        public List<ZoneWiseAreaHeadSalesOfficer> GetAreaHeadsByZone(ZoneWiseAreaHeadSalesOfficer zone)
        {
            DataSet dsZones = null;
            List<ZoneWiseAreaHeadSalesOfficer> areaHeads = new List<ZoneWiseAreaHeadSalesOfficer>();
            try
            {
                connection = SQLConnection.GetConnection();
                SqlParameter[] spParams = new SqlParameter[]
                {
                   new SqlParameter("@ZoneId",zone.ZoneId)
                };
                dsZones = new DataSet();
                dsZones = SQLHelper.ExecuteDataset(connection, CommandType.StoredProcedure, SPName_Constants.GetAreaHeadsByZone, spParams);
                if (dsZones != null && dsZones.Tables.Count > 0 && dsZones.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < dsZones.Tables[0].Rows.Count; i++)
                    {
                        ZoneWiseAreaHeadSalesOfficer objAreaHead = new ZoneWiseAreaHeadSalesOfficer();
                        if (dsZones.Tables[0].Rows[i]["AreaHeadId"] != DBNull.Value)
                        {
                            objAreaHead.AreaHeadId = Convert.ToInt32(dsZones.Tables[0].Rows[i]["AreaHeadId"].ToString());
                        }
                        objAreaHead.AreaHeadName = dsZones.Tables[0].Rows[i]["AreaHeadName"].ToString();
                        areaHeads.Add(objAreaHead);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
                connection.Dispose();
            }
            return areaHeads;
        }

        /// <summary>
        /// To get all sales officers by zone.
        /// </summary>
        /// <param name="zone"></param>
        /// <returns></returns>
        public List<ZoneWiseAreaHeadSalesOfficer> GetSalesOfficersByZone(ZoneWiseAreaHeadSalesOfficer zone)
        {
            DataSet dsZones = null;
            List<ZoneWiseAreaHeadSalesOfficer> salesOfficers = new List<ZoneWiseAreaHeadSalesOfficer>();
            try
            {
                connection = SQLConnection.GetConnection();
                SqlParameter[] spParams = new SqlParameter[]
                {
                   new SqlParameter("@ZoneId",zone.ZoneId)
                };
                dsZones = new DataSet();
                dsZones = SQLHelper.ExecuteDataset(connection, CommandType.StoredProcedure, SPName_Constants.GetSalesOfficersByZone, spParams);
                if (dsZones != null && dsZones.Tables.Count > 0 && dsZones.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < dsZones.Tables[0].Rows.Count; i++)
                    {
                        ZoneWiseAreaHeadSalesOfficer objSalesOfficer = new ZoneWiseAreaHeadSalesOfficer();
                        if (dsZones.Tables[0].Rows[i]["SalesOfficerId"] != DBNull.Value)
                        {
                            objSalesOfficer.SalesOfficerId = Convert.ToInt32(dsZones.Tables[0].Rows[i]["SalesOfficerId"].ToString());
                        }
                        objSalesOfficer.SalesOfficerName = dsZones.Tables[0].Rows[i]["SalesOfficerName"].ToString();
                        salesOfficers.Add(objSalesOfficer);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
                connection.Dispose();
            }
            return salesOfficers;
        }

        /// <summary>
        /// To get avegrage total calls.
        /// </summary>
        /// <param name="averageMonthlyCalls"></param>
        /// <returns></returns>
        public AverageTotalCallsAndProductiveCall GetDashBoardDataForAvgMonthlyCalls(ZoneWiseAreaHeadSalesOfficer averageMonthlyCalls)
        {
            List<int> DistinctDailyRetailingId = new List<int>();

            float avgTotalCalls = 0;
            float avgTotalProductiveCalls = 0;
            decimal avgTotalSaleAmount = 0;
            DataSet dsResults = null;
            List<ZoneWiseAreaHeadSalesOfficer> totalCalls = new List<ZoneWiseAreaHeadSalesOfficer>();
            AverageTotalCallsAndProductiveCall averageTotal = new AverageTotalCallsAndProductiveCall();
            try
            {
                averageTotal.AvgTotalCalls = avgTotalCalls;
                averageTotal.AvgProductiveCalls = avgTotalProductiveCalls;
                averageTotal.AvgSalesAmount = avgTotalSaleAmount;
                if (averageMonthlyCalls.MonthId == 13)
                {
                    averageMonthlyCalls.MonthId = 0;
                }
                if (averageMonthlyCalls.ZoneId == 5)
                {
                    averageMonthlyCalls.ZoneId = 0;
                }
                connection = SQLConnection.GetConnection();
                SqlParameter[] spParams = new SqlParameter[]
                {
                   new SqlParameter("@MonthId",averageMonthlyCalls.MonthId),
                   new SqlParameter("@ZoneId",averageMonthlyCalls.ZoneId),
                   new SqlParameter("@AreaHeadId",averageMonthlyCalls.AreaHeadId),
                   new SqlParameter("@SalesOfficerId",averageMonthlyCalls.SalesOfficerId)
                };
                dsResults = new DataSet();
                dsResults = SQLHelper.ExecuteDataset(connection, CommandType.StoredProcedure, SPName_Constants.GetDashboardDataForAvgMonthyCalls, spParams);
                if (dsResults != null && dsResults.Tables.Count > 0 && dsResults.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < dsResults.Tables[0].Rows.Count; i++)
                    {
                        ZoneWiseAreaHeadSalesOfficer objResult = new ZoneWiseAreaHeadSalesOfficer();
                        if (dsResults.Tables[0].Rows[i]["TotalCalls"] != DBNull.Value)
                        {
                            objResult.TotalCalls = Convert.ToInt32(dsResults.Tables[0].Rows[i]["TotalCalls"].ToString());
                        }
                        if (dsResults.Tables[0].Rows[i]["ProductiveCalls"] != DBNull.Value)
                        {
                            objResult.TotalProductiveCalls = Convert.ToInt32(dsResults.Tables[0].Rows[i]["ProductiveCalls"].ToString());
                        }
                        if (dsResults.Tables[0].Rows[i]["ProductSalesQuantity"] != DBNull.Value)
                        {
                            objResult.ProductSalesQuantity = Convert.ToSingle(dsResults.Tables[0].Rows[i]["ProductSalesQuantity"].ToString());
                        }
                        if (dsResults.Tables[0].Rows[i]["ProductSpecificPrice"] != DBNull.Value)
                        {
                            objResult.ProductSpecificPrice = Convert.ToDecimal(dsResults.Tables[0].Rows[i]["ProductSpecificPrice"].ToString());
                        }
                        //this is used to check how many records are there.
                        if (dsResults.Tables[0].Rows[i]["DailyRetailingId"] != DBNull.Value)
                        {
                            int dailyRetailing = Convert.ToInt32(dsResults.Tables[0].Rows[i]["DailyRetailingId"]);
                            if (dailyRetailing != 0)
                            {
                                if (!(DistinctDailyRetailingId.Any(X => X == dailyRetailing)))
                                {
                                    DistinctDailyRetailingId.Add(dailyRetailing);
                                    objResult.DailyRetailingId = dailyRetailing;
                                }
                            }
                        }
                        totalCalls.Add(objResult);

                    }
                    if (totalCalls != null && totalCalls.Count > 0)
                    {
                        int sumTotalCall = 0;
                        int sumProductiveCall = 0;
                        decimal sumTotalSaleAmount = 0;
                        List<int> IndividualDailyRetaling = new List<int>();
                        int totalRecordCount = DistinctDailyRetailingId.Count;
                        foreach (var record in totalCalls)
                        {
                            int dailyRetailingId = Convert.ToInt32(record.DailyRetailingId);
                            if (dailyRetailingId != 0)
                            {
                                if (!(IndividualDailyRetaling.Any(X => X == dailyRetailingId)))
                                {
                                    IndividualDailyRetaling.Add(dailyRetailingId);
                                    sumTotalCall += Convert.ToInt32(record.TotalCalls);
                                    sumProductiveCall += Convert.ToInt32(record.TotalProductiveCalls);
                                }
                            }
                            sumTotalSaleAmount += (
                                (Convert.ToDecimal(record.ProductSpecificPrice))
                                * (Convert.ToInt32(record.ProductSalesQuantity)));
                        }
                        if (sumTotalCall > 0)
                        {
                            avgTotalCalls = Convert.ToSingle(sumTotalCall) / Convert.ToSingle(totalRecordCount);
                            averageTotal.AvgTotalCalls = Convert.ToSingle(Math.Round(avgTotalCalls, 0));
                        }
                        if (sumProductiveCall > 0)
                        {
                            avgTotalProductiveCalls = Convert.ToSingle(sumProductiveCall) / Convert.ToSingle(totalRecordCount);
                            averageTotal.AvgProductiveCalls = Convert.ToSingle(Math.Round(avgTotalProductiveCalls, 0));
                        }
                        if (sumTotalSaleAmount > 0)
                        {
                            avgTotalSaleAmount = sumTotalSaleAmount / totalRecordCount;
                            averageTotal.AvgSalesAmount = Math.Round(avgTotalSaleAmount, 2);
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
                connection.Dispose();
            }
            return averageTotal;
        }

        /// <summary>
        /// To get dashboard total value for chart.
        /// </summary>
        /// <returns></returns>
        public List<DashboardTotalValue> GetDashBoardTotalValues(DashboardTotalValue dashboardTotalValue)
        {
            DataSet dsTotalValue = null;
            List<DashboardTotalValue> dashboardTotals = new List<DashboardTotalValue>();
            try
            {
                if (dashboardTotalValue.ZoneId == 5)
                {
                    dashboardTotalValue.ZoneId = 0;
                }
                connection = SQLConnection.GetConnection();
                SqlParameter[] spParams = new SqlParameter[]
                {
                   new SqlParameter("@MonthId",dashboardTotalValue.MonthId),
                   new SqlParameter("@ZoneId",dashboardTotalValue.ZoneId),
                   new SqlParameter("@AreaHeadId",dashboardTotalValue.AreaHeadId),
                   new SqlParameter("@SalesOfficerId",dashboardTotalValue.SalesOfficerId)
                };
                dsTotalValue = new DataSet();
                dsTotalValue = SQLHelper.ExecuteDataset(connection, CommandType.StoredProcedure, SPName_Constants.GetDashboardDataTotalValue, spParams);
                if (dsTotalValue != null && dsTotalValue.Tables.Count > 0 && dsTotalValue.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < dsTotalValue.Tables[0].Rows.Count; i++)
                    {
                        DashboardTotalValue objdashboardTotalValue = new DashboardTotalValue();
                        if (dsTotalValue.Tables[0].Rows[i]["ProductSpecificTotalPrice"] != DBNull.Value)
                        {
                            objdashboardTotalValue.ProductSpecificTotalPrice = Convert.ToDecimal(dsTotalValue.Tables[0].Rows[i]["ProductSpecificTotalPrice"].ToString());
                        }
                        objdashboardTotalValue.ProductCategory = dsTotalValue.Tables[0].Rows[i]["ProductCategory"].ToString();
                        if (dsTotalValue.Tables[0].Rows[i]["Month"] != DBNull.Value)
                        {
                            objdashboardTotalValue.Month = this.GetMonthName(Convert.ToInt32(dsTotalValue.Tables[0].Rows[i]["Month"].ToString()));
                        }
                        if (dsTotalValue.Tables[0].Rows[i]["Month"] != DBNull.Value)
                        {
                            objdashboardTotalValue.MonthId = Convert.ToInt32(dsTotalValue.Tables[0].Rows[i]["Month"].ToString());
                        }

                        dashboardTotals.Add(objdashboardTotalValue);
                    }
                    if (dashboardTotals.Count > 0 && dashboardTotals.Count < 10)
                    {
                        string nextMonth = CalculateNextMonth(dashboardTotals);
                        string currentMonth = dashboardTotals[0].Month;
                        List<DashboardTotalValue> newdashboardTotals = new List<DashboardTotalValue>();
                        newdashboardTotals = dashboardTotals.FindAll(product => product.Month == nextMonth).ToList();

                        if ((dashboardTotals.Find(productcategory => productcategory.ProductCategory == "BLENDED SPICES"
                                && productcategory.Month == currentMonth) == null))
                        {
                            DashboardTotalValue objdashboardTotalValue = new DashboardTotalValue();
                            objdashboardTotalValue.ProductCategory = "BLENDED SPICES";
                            objdashboardTotalValue.ProductSpecificTotalPrice = 0;
                            objdashboardTotalValue.Month = dashboardTotals[0].Month;
                            dashboardTotals.Insert(0, objdashboardTotalValue);
                        }
                        if ((dashboardTotals.Find(productcategory => productcategory.ProductCategory == "HONEY"
                            && productcategory.Month == currentMonth) == null))
                        {
                            DashboardTotalValue objdashboardTotalValue = new DashboardTotalValue();
                            objdashboardTotalValue.ProductCategory = "HONEY";
                            objdashboardTotalValue.ProductSpecificTotalPrice = 0;
                            objdashboardTotalValue.Month = dashboardTotals[0].Month;
                            dashboardTotals.Insert(1, objdashboardTotalValue);
                        }
                        if ((dashboardTotals.Find(productcategory => productcategory.ProductCategory == "POWDER SPICES"
                            && productcategory.Month == currentMonth) == null))
                        {
                            DashboardTotalValue objdashboardTotalValue = new DashboardTotalValue();
                            objdashboardTotalValue.ProductCategory = "POWDER SPICES";
                            objdashboardTotalValue.ProductSpecificTotalPrice = 0;
                            objdashboardTotalValue.Month = dashboardTotals[0].Month;
                            dashboardTotals.Insert(2, objdashboardTotalValue);
                        }
                        if ((dashboardTotals.Find(productcategory => productcategory.ProductCategory == "SALT"
                            && productcategory.Month == currentMonth) == null))
                        {
                            DashboardTotalValue objdashboardTotalValue = new DashboardTotalValue();
                            objdashboardTotalValue.ProductCategory = "SALT";
                            objdashboardTotalValue.ProductSpecificTotalPrice = 0;
                            objdashboardTotalValue.Month = dashboardTotals[0].Month;
                            dashboardTotals.Insert(3, objdashboardTotalValue);
                        }
                        if ((dashboardTotals.Find(productcategory => productcategory.ProductCategory == "WHOLE SPICES"
                            && productcategory.Month == currentMonth) == null))
                        {
                            DashboardTotalValue objdashboardTotalValue = new DashboardTotalValue();
                            objdashboardTotalValue.ProductCategory = "WHOLE SPICES";
                            objdashboardTotalValue.ProductSpecificTotalPrice = 0;
                            objdashboardTotalValue.Month = dashboardTotals[0].Month;
                            dashboardTotals.Insert(4, objdashboardTotalValue);
                        }

                        if ((newdashboardTotals.Find(productcategory => productcategory.ProductCategory == "BLENDED SPICES") == null))
                        {
                            DashboardTotalValue objdashboardTotalValue = new DashboardTotalValue();
                            objdashboardTotalValue.ProductCategory = "BLENDED SPICES";
                            objdashboardTotalValue.ProductSpecificTotalPrice = 0;
                            objdashboardTotalValue.Month = nextMonth;
                            dashboardTotals.Insert(5, objdashboardTotalValue);
                        }
                        if ((newdashboardTotals.Find(productcategory => productcategory.ProductCategory == "HONEY") == null))
                        {
                            DashboardTotalValue objdashboardTotalValue = new DashboardTotalValue();
                            objdashboardTotalValue.ProductCategory = "HONEY";
                            objdashboardTotalValue.ProductSpecificTotalPrice = 0;
                            objdashboardTotalValue.Month = nextMonth;
                            dashboardTotals.Insert(6, objdashboardTotalValue);
                        }
                        if ((newdashboardTotals.Find(productcategory => productcategory.ProductCategory == "POWDER SPICES") == null))
                        {
                            DashboardTotalValue objdashboardTotalValue = new DashboardTotalValue();
                            objdashboardTotalValue.ProductCategory = "POWDER SPICES";
                            objdashboardTotalValue.ProductSpecificTotalPrice = 0;
                            objdashboardTotalValue.Month = nextMonth;
                            dashboardTotals.Insert(7, objdashboardTotalValue);
                        }
                        if ((newdashboardTotals.Find(productcategory => productcategory.ProductCategory == "SALT") == null))
                        {
                            DashboardTotalValue objdashboardTotalValue = new DashboardTotalValue();
                            objdashboardTotalValue.ProductCategory = "SALT";
                            objdashboardTotalValue.ProductSpecificTotalPrice = 0;
                            objdashboardTotalValue.Month = nextMonth;
                            dashboardTotals.Insert(8, objdashboardTotalValue);
                        }
                        if ((newdashboardTotals.Find(productcategory => productcategory.ProductCategory == "WHOLE SPICES") == null))
                        {
                            DashboardTotalValue objdashboardTotalValue = new DashboardTotalValue();
                            objdashboardTotalValue.ProductCategory = "WHOLE SPICES";
                            objdashboardTotalValue.ProductSpecificTotalPrice = 0;
                            objdashboardTotalValue.Month = nextMonth;
                            dashboardTotals.Insert(9, objdashboardTotalValue);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
                connection.Dispose();
            }
            return dashboardTotals;
        }

        private static string CalculateNextMonth(List<DashboardTotalValue> dashboardTotals)
        {
            string nextMonth = "";
            if (dashboardTotals[0].Month == "JAN")
            {
                nextMonth = "FEB";
            }
            else if (dashboardTotals[0].Month == "FEB")
            {
                nextMonth = "MAR";
            }
            else if (dashboardTotals[0].Month == "MAR")
            {
                nextMonth = "APR";
            }
            else if (dashboardTotals[0].Month == "APR")
            {
                nextMonth = "MAY";
            }
            else if (dashboardTotals[0].Month == "MAY")
            {
                nextMonth = "JUN";
            }
            else if (dashboardTotals[0].Month == "JUN")
            {
                nextMonth = "JUL";
            }
            else if (dashboardTotals[0].Month == "JUL")
            {
                nextMonth = "AUG";
            }
            else if (dashboardTotals[0].Month == "AUG")
            {
                nextMonth = "SEP";
            }
            else if (dashboardTotals[0].Month == "SEP")
            {
                nextMonth = "OCT";
            }
            else if (dashboardTotals[0].Month == "OCT")
            {
                nextMonth = "NOV";
            }
            else if (dashboardTotals[0].Month == "NOV")
            {
                nextMonth = "DEC";
            }
            return nextMonth;
        }
        public string GetMonthName(int monthId)
        {
            string MonthName = "";
            switch (monthId)
            {
                case 1:
                    MonthName = "JAN";
                    return MonthName;
                case 2:
                    MonthName = "FEB";
                    return MonthName;
                case 3:
                    MonthName = "MAR";
                    return MonthName;
                case 4:
                    MonthName = "APR";
                    return MonthName;
                case 5:
                    MonthName = "MAY";
                    return MonthName;
                case 6:
                    MonthName = "JUN";
                    return MonthName;
                case 7:
                    MonthName = "JUL";
                    return MonthName;
                case 8:
                    MonthName = "AUG";
                    return MonthName;
                case 9:
                    MonthName = "SEP";
                    return MonthName;
                case 10:
                    MonthName = "OCT";
                    return MonthName;
                case 11:
                    MonthName = "NOV";
                    return MonthName;
                case 12:
                    MonthName = "DEC";
                    return MonthName;
            }
            return MonthName;

        }

        /// <summary>
        /// To get Product category wise total for SKU analysis screen.
        /// </summary>
        /// <param name="sKUProductCategoryWise"></param>
        /// <returns></returns>
        public List<SKUProductCategoryWiseTotal> GetSkuProductCategoryWiseTotalValues(SKUProductCategoryWiseTotal sKUProductCategoryWise)
        {
            DataSet dsTotalValue = null;
            List<SKUProductCategoryWiseTotal> skuProductCategoryTotals = new List<SKUProductCategoryWiseTotal>();
            try
            {
                if (sKUProductCategoryWise.MonthId == 13)
                {
                    sKUProductCategoryWise.MonthId = 0;
                }
                if (sKUProductCategoryWise.ZoneId == 5)
                {
                    sKUProductCategoryWise.ZoneId = 0;
                }
                connection = SQLConnection.GetConnection();
                SqlParameter[] spParams = new SqlParameter[]
                {
                   new SqlParameter("@MonthId",sKUProductCategoryWise.MonthId),
                   new SqlParameter("@ZoneId",sKUProductCategoryWise.ZoneId),
                   new SqlParameter("@AreaHeadId",sKUProductCategoryWise.AreaHeadId),
                   new SqlParameter("@SalesOfficerId",sKUProductCategoryWise.SalesOfficerId)
                };
                dsTotalValue = new DataSet();
                dsTotalValue = SQLHelper.ExecuteDataset(connection, CommandType.StoredProcedure, SPName_Constants.GetSKUProductCategorywiseTotalValue, spParams);
                if (dsTotalValue != null && dsTotalValue.Tables.Count > 0 && dsTotalValue.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < dsTotalValue.Tables[0].Rows.Count; i++)
                    {
                        SKUProductCategoryWiseTotal objSKUCategoryWiseTotal = new SKUProductCategoryWiseTotal();
                        if (dsTotalValue.Tables[0].Rows[i]["ProductCategoryTotalValue"] != DBNull.Value)
                        {
                            objSKUCategoryWiseTotal.ProductCategoryTotalValue = Convert.ToDecimal(dsTotalValue.Tables[0].Rows[i]["ProductCategoryTotalValue"].ToString());
                        }
                        objSKUCategoryWiseTotal.ProductCategory = dsTotalValue.Tables[0].Rows[i]["ProductCategory"].ToString();

                        skuProductCategoryTotals.Add(objSKUCategoryWiseTotal);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
                connection.Dispose();
            }
            return skuProductCategoryTotals;
        }

        /// <summary>
        /// To get product sku wise total price.
        /// </summary>
        /// <param name="sKUProductData"></param>
        /// <returns></returns>
        public List<SKUProductWisePerformance> GetSkuProductWiseTotalValues(SKUProductWisePerformance sKUProductData)
        {
            DataSet dsTotalValue = null;
            List<SKUProductWisePerformance> skuProductWiseTotals = new List<SKUProductWisePerformance>();
            try
            {
                if (sKUProductData.MonthId == 13)
                {
                    sKUProductData.MonthId = 0;
                }
                if (sKUProductData.ZoneId == 5)
                {
                    sKUProductData.ZoneId = 0;
                }
                connection = SQLConnection.GetConnection();
                SqlParameter[] spParams = new SqlParameter[]
                {
                   new SqlParameter("@MonthId",sKUProductData.MonthId),
                   new SqlParameter("@ZoneId",sKUProductData.ZoneId),
                   new SqlParameter("@AreaHeadId",sKUProductData.AreaHeadId),
                   new SqlParameter("@SalesOfficerId",sKUProductData.SalesOfficerId),
                   new SqlParameter("@ProductCategoryId",sKUProductData.ProductCategoryId),
                };
                dsTotalValue = new DataSet();
                dsTotalValue = SQLHelper.ExecuteDataset(connection, CommandType.StoredProcedure, SPName_Constants.GetSKUProductWisePerformance, spParams);
                if (dsTotalValue != null && dsTotalValue.Tables.Count > 0 && dsTotalValue.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < dsTotalValue.Tables[0].Rows.Count; i++)
                    {
                        SKUProductWisePerformance objSKUProductWiseTotal = new SKUProductWisePerformance();
                        if (dsTotalValue.Tables[0].Rows[i]["ProductSkuWiseTotalPrice"] != DBNull.Value)
                        {
                            objSKUProductWiseTotal.ProductSkuWiseTotalPrice = Convert.ToDecimal(dsTotalValue.Tables[0].Rows[i]["ProductSkuWiseTotalPrice"].ToString());
                        }
                        objSKUProductWiseTotal.ProductName = dsTotalValue.Tables[0].Rows[i]["ProductName"].ToString();

                        skuProductWiseTotals.Add(objSKUProductWiseTotal);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
                connection.Dispose();
            }
            return skuProductWiseTotals;
        }

        /// <summary>
        /// To add stock analysis data by stock analysis screen.
        /// </summary>
        /// <param name="stockAnalysis"></param>
        /// <returns></returns>
        public bool AddStockAnalysisData(StockAnalysis stockAnalysis)
        {
            bool isSuccess = false;
            try
            {
                connection = SQLConnection.GetConnection();
                SqlParameter[] spParams = new SqlParameter[]
                {
                   new SqlParameter("@ProductId",stockAnalysis.ProductId),
                   new SqlParameter("@DistributorId",stockAnalysis.DistributorId),
                   new SqlParameter("@AreaHeadId",stockAnalysis.AreaHeadId),
                   new SqlParameter("@ClosingReportDate",stockAnalysis.ClosingReportDate),
                   new SqlParameter("@ClosingStockQuantity",stockAnalysis.ClosingStockQuantity),
                   new SqlParameter("@BillingReportDate",stockAnalysis.BillingReportDate),
                   new SqlParameter("@BillingStockQuantity",stockAnalysis.BillingStockQuantity),
                   new SqlParameter("@CreatedBy",stockAnalysis.CreatedBy)
                };
                int result = Convert.ToInt32(SQLHelper.ExecuteNonQuery(connection, CommandType.StoredProcedure, SPName_Constants.AddStockAnalysisData, spParams));
                if (result > 0)
                {
                    isSuccess = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
                connection.Dispose();
            }
            return isSuccess;
        }

        /// <summary>
        /// To get stock analysis data based on month.zone,area head and distributor.
        /// </summary>
        /// <param name="stockAnalysisDetails"></param>
        /// <returns></returns>
        public List<StockAnalysisDetailsData> GetStockAnalysisData(StockAnalysisDetailsData stockAnalysisDetails)
        {
            DataSet dsStock = null;
            List<StockAnalysisDetailsData> stockAnalysisData = new List<StockAnalysisDetailsData>();
            try
            {
                if (stockAnalysisDetails.MonthId == 13)
                {
                    stockAnalysisDetails.MonthId = 0;
                }
                if (stockAnalysisDetails.ZoneId == 5)
                {
                    stockAnalysisDetails.ZoneId = 0;
                }
                connection = SQLConnection.GetConnection();
                SqlParameter[] spParams = new SqlParameter[]
                {
                   new SqlParameter("@MonthId",stockAnalysisDetails.MonthId),
                   new SqlParameter("@ZoneId",stockAnalysisDetails.ZoneId),
                   new SqlParameter("@AreaHeadId",stockAnalysisDetails.AreaHeadId),
                   new SqlParameter("@DistributorId",stockAnalysisDetails.DistributorId)
                };
                dsStock = new DataSet();
                dsStock = SQLHelper.ExecuteDataset(connection, CommandType.StoredProcedure, SPName_Constants.GetStockAnalysisData, spParams);
                if (dsStock != null && dsStock.Tables.Count > 0 && dsStock.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < dsStock.Tables[0].Rows.Count; i++)
                    {
                        int Opening = 0;
                        int Billing = 0;
                        int Closing = 0;
                        int Actual = 0;
                        int Reported = 0;
                        int OverReporting = 0;
                        StockAnalysisDetailsData objStockAnalysis = new StockAnalysisDetailsData();
                        objStockAnalysis.ProductWeightDescription = dsStock.Tables[0].Rows[i]["ProductWeightDescription"].ToString();

                        if (dsStock.Tables[0].Rows[i]["OpeningStock"] != DBNull.Value)
                        {
                            objStockAnalysis.OpeningStock = Convert.ToInt32(dsStock.Tables[0].Rows[i]["OpeningStock"].ToString());
                            Opening = Convert.ToInt32(objStockAnalysis.OpeningStock);
                        }
                        if (dsStock.Tables[0].Rows[i]["BillingStock"] != DBNull.Value)
                        {
                            objStockAnalysis.BillingStock = Convert.ToInt32(dsStock.Tables[0].Rows[i]["BillingStock"].ToString());
                            Billing = Convert.ToInt32(objStockAnalysis.BillingStock);
                        }
                        if (dsStock.Tables[0].Rows[i]["ClosingStock"] != DBNull.Value)
                        {
                            objStockAnalysis.ClosingStock = Convert.ToInt32(dsStock.Tables[0].Rows[i]["ClosingStock"].ToString());
                            Closing = Convert.ToInt32(objStockAnalysis.ClosingStock);
                        }
                        Actual = (Opening + Billing) - Closing;
                        objStockAnalysis.ActualRetailingStock = Actual;
                        if (dsStock.Tables[0].Rows[i]["ReportedRetailing"] != DBNull.Value)
                        {
                            objStockAnalysis.ReportedRetailingStock = Convert.ToInt32(dsStock.Tables[0].Rows[i]["ReportedRetailing"].ToString());
                            Reported = Convert.ToInt32(objStockAnalysis.ReportedRetailingStock);
                        }
                        OverReporting = Actual - Reported;
                        objStockAnalysis.OverReportStock = OverReporting;

                        if (dsStock.Tables[0].Rows[i]["ProductWeightDescription"].ToString()
                            == dsStock.Tables[1].Rows[i]["ProductWeightDescription"].ToString())
                        {
                            if (dsStock.Tables[1].Rows[i]["ProductPrice"] != DBNull.Value)
                            {
                                decimal productPrice = Convert.ToDecimal(dsStock.Tables[1].Rows[i]["ProductPrice"].ToString());
                                objStockAnalysis.ValueOfStockOverReporting = productPrice * OverReporting;
                            }
                        }
                        stockAnalysisData.Add(objStockAnalysis);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
                connection.Dispose();
            }
            return stockAnalysisData;
        }

        /// <summary>
        /// To get daily work status data.
        /// </summary>
        /// <param name="dailyWorkStatus"></param>
        /// <returns></returns>
        public List<DailyWorkStatusData> GetDailyWorkStatusReport(DailyWorkStatusData dailyWorkStatus)
        {
            DataSet dsDailyWorkStatus = null;
            List<DailyWorkStatusData> dailyWorkStatusForTotalStrength = new List<DailyWorkStatusData>();
            List<DailyWorkStatusData> dailyWorkStatusDatas = new List<DailyWorkStatusData>();
            try
            {
                connection = SQLConnection.GetConnection();
                SqlParameter[] spParam = null;
                dsDailyWorkStatus = new DataSet();
                if (dailyWorkStatus.ZoneId != null)
                {
                    spParam = new SqlParameter[]
                    {
                       new SqlParameter("@ZoneId",dailyWorkStatus.ZoneId)
                    };
                }
                dsDailyWorkStatus = SQLHelper.ExecuteDataset(connection, CommandType.StoredProcedure, SPName_Constants.GetDailyWorkStatusTotalStrength, spParam);
                if (dsDailyWorkStatus != null && dsDailyWorkStatus.Tables.Count > 0 && dsDailyWorkStatus.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < dsDailyWorkStatus.Tables[0].Rows.Count; i++)
                    {
                        DailyWorkStatusData objDailyWorkForTotalStrength = new DailyWorkStatusData();
                        if (dsDailyWorkStatus.Tables[0].Rows[i]["AreaHeadId"] != DBNull.Value)
                        {
                            objDailyWorkForTotalStrength.AreaHeadId = Convert.ToInt32(dsDailyWorkStatus.Tables[0].Rows[i]["AreaHeadId"].ToString());
                        }
                        objDailyWorkForTotalStrength.AreaHeadName = dsDailyWorkStatus.Tables[0].Rows[i]["AreaHeadName"].ToString();
                        objDailyWorkForTotalStrength.HeadQuaterName = dsDailyWorkStatus.Tables[0].Rows[i]["HeadQuaterName"].ToString();
                        if (dsDailyWorkStatus.Tables[0].Rows[i]["TotalStrength"] != DBNull.Value)
                        {
                            objDailyWorkForTotalStrength.TotalStrength = Convert.ToInt32(dsDailyWorkStatus.Tables[0].Rows[i]["TotalStrength"].ToString());
                        }
                        dailyWorkStatusForTotalStrength.Add(objDailyWorkForTotalStrength);
                    }
                }
                foreach (var item in dailyWorkStatusForTotalStrength)
                {
                    try
                    {
                        DailyWorkStatusData objDailyWorkStatusForMarketWorking = new DailyWorkStatusData();
                        objDailyWorkStatusForMarketWorking.AreaHeadName = item.AreaHeadName;
                        objDailyWorkStatusForMarketWorking.HeadQuaterName = item.HeadQuaterName;
                        objDailyWorkStatusForMarketWorking.TotalStrength = item.TotalStrength;

                        connection = SQLConnection.GetConnection();
                        dsDailyWorkStatus = new DataSet();
                        SqlParameter[] spParams = new SqlParameter[]
                        {
                           new SqlParameter("@RetailingDate",dailyWorkStatus.RetailingDate),
                           new SqlParameter("@AreaHeadId",item.AreaHeadId)
                        };
                        dsDailyWorkStatus = SQLHelper.ExecuteDataset(connection, CommandType.StoredProcedure, SPName_Constants.GetDailyWorkStatusMarketWorking, spParams);
                        if (dsDailyWorkStatus != null && dsDailyWorkStatus.Tables.Count > 0 && dsDailyWorkStatus.Tables[0].Rows.Count > 0)
                        {
                            if (dsDailyWorkStatus.Tables[0].Rows[0]["MarketWorking"] != DBNull.Value)
                            {
                                objDailyWorkStatusForMarketWorking.MarketWorking = Convert.ToInt32(dsDailyWorkStatus.Tables[0].Rows[0]["MarketWorking"].ToString());
                            }
                        }
                        dailyWorkStatusDatas.Add(objDailyWorkStatusForMarketWorking);
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                    finally
                    {
                        connection.Close();
                        connection.Dispose();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
                connection.Dispose();
            }
            return dailyWorkStatusDatas;
        }
        #endregion
    }
}
