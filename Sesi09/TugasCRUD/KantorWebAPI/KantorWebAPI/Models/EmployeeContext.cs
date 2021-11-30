﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;

namespace Kantor_WebAPI.Models
{
    public class EmployeeContext
    {
        public string ConnectionString { get; set; }

        public EmployeeContext(string connectionString)
        {
            this.ConnectionString = connectionString;
        }

        private MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString);
        }

        public List<EmployeeItem> GetAllEmployee()
        {
            List<EmployeeItem> list = new List<EmployeeItem>();

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM employee", conn);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new EmployeeItem()
                        {
                            id = reader.GetInt32("id"),
                            nama = reader.GetString("nama"),
                            jenisKelamin = reader.GetString("jenis_kelamin"),
                            alamat = reader.GetString("alamat")
                        });
                    }
                }
            }

            return list;
        }

        public List<EmployeeItem> GetEmployee(string id)
        {
            List<EmployeeItem> list = new List<EmployeeItem>();

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM employee WHERE id =@id", conn);
                cmd.Parameters.AddWithValue("@id", id);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new EmployeeItem()
                        {
                            id = reader.GetInt32("id"),
                            nama = reader.GetString("nama"),
                            jenisKelamin = reader.GetString("jenis_kelamin"),
                            alamat = reader.GetString("alamat")
                        });
                    }
                }
            }

            return list;
        }

        //public async Task<IActionResult> CreateEmployee(string nama, string jenisK, string alamat)
        //{
        //    using (MySqlConnection conn = GetConnection())
        //    {
        //        try
        //        {
        //conn.Open();
        //            MySqlCommand cmd = new MySqlCommand("INSERT INTO employees(nama,jenis_kelamin,alamat) VALUES (@nama,@jenis_kelamin,@alamat)", conn);
        //cmd.Parameters.AddWithValue("@nama", nama);
        //            cmd.Parameters.AddWithValue("@jenis_kelamin", jenisK);
        //            cmd.Parameters.AddWithValue("@alamat", alamat);
        //        }
        //        catch (Exception e)
        //        {
        //            return new JsonResult("Something went wrong") {StatusCode = 500};
        //        }

        //        return new JsonResult("created") {StatusCode = 200};

        //    }
        //}

        public string InsertEmployee(EmployeeItem item)
        {
            using (MySqlConnection conn=GetConnection())
            {
                conn.Open();
                string query = "INSERT INTO employee(nama,jenis_kelamin,alamat) VALUES (@nama,@jenis_kelamin,@alamat)";
                try
                {
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@nama", item.nama);
                        cmd.Parameters.AddWithValue("@jenis_kelamin", item.jenisKelamin);
                        cmd.Parameters.AddWithValue("@alamat", item.alamat);
                        cmd.ExecuteNonQuery();
                        conn.Close();
                    }

                    return "berhasil";
                }
                catch (Exception e)
                {
                    return "gagal";
                    //throw;
                }
            }
        }

        public string UpdateEmployee(int id, EmployeeItem item)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                string query = "UPDATE employee SET nama=@nama, jenis_kelamin=@jenis_kelamin, alamat=@alamat WHERE id=@id";
                try
                {
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@nama", item.nama);
                        cmd.Parameters.AddWithValue("@jenis_kelamin", item.jenisKelamin);
                        cmd.Parameters.AddWithValue("@alamat", item.alamat);
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.ExecuteNonQuery();
                        conn.Close();
                    }

                    return "berhasil";
                }
                catch (Exception e)
                {
                    return "gagal";
                    //throw;
                }
            }
        }

        public string DeleteEmployee(int id)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                string query = "DELETE FROM employee WHERE id=@id";
                try
                {
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.ExecuteNonQuery();
                        conn.Close();
                    }

                    return "berhasil";
                }
                catch (Exception e)
                {
                    return "gagal";
                    //throw;
                }
            }
        }
    }
}