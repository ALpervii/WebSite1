using System;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.UI.WebControls;
using System.Data.Entity;
using System.Runtime.InteropServices;
using System.Web.Providers.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

public partial class _Default : System.Web.UI.Page
{

    SqlConnection con;

    string sqlconn;
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    private void connection()
    {
        string sqlconn = (@"server=.\SQLEXPRESS; Persist Security Info=true; Integrated Security=true;  Initial Catalog=Excel;");
        con = new SqlConnection(sqlconn);
    }
    

    private void InsertCSVRecords(DataTable csvdt)
    {

        connection();
        SqlBulkCopy objbulk = new SqlBulkCopy(con);
        //имя таблички   
        objbulk.DestinationTableName = "Users";
        //Запись в колонки   
        objbulk.ColumnMappings.Add("id", "id");
        objbulk.ColumnMappings.Add("DateCreate", "DateCreate");
        objbulk.ColumnMappings.Add("DateEditing", "DateEditing");
        objbulk.ColumnMappings.Add("City", "City");
        objbulk.ColumnMappings.Add("AdmDistrict", "AdmDistrict");
        objbulk.ColumnMappings.Add("District", "District");
        objbulk.ColumnMappings.Add("Street", "Street");
        objbulk.ColumnMappings.Add("House", "House");
        objbulk.ColumnMappings.Add("Corps", "Corps");
        objbulk.ColumnMappings.Add("YearBuilding", "YearBuilding");
        con.Open();
        objbulk.WriteToServer(csvdt);
        con.Close();
    }



    protected void Button_Click(object sender, EventArgs e)
    {
        DataTable infobox = new DataTable();

        infobox.Columns.Add("id");
        infobox.Columns.Add("DateCreate");
        infobox.Columns.Add("DateEditing");
        infobox.Columns.Add("City");
        infobox.Columns.Add("AdmDistrict");
        infobox.Columns.Add("District");
        infobox.Columns.Add("Street");
        infobox.Columns.Add("House");
        infobox.Columns.Add("Corps");
        infobox.Columns.Add("YearBuilding");

        String id = System.Guid.NewGuid().ToString();
        string DateCreate = TextBox1.Text;
        string DateEditing = TextBox2.Text;
        string City = TextBox3.Text;
        string AdmDistrict = TextBox4.Text;
        string District = TextBox5.Text;
        string Street = TextBox6.Text;
        string House = TextBox7.Text;
        string Corps = TextBox8.Text;
        string YearBuilding = TextBox9.Text;
        int count = 0;
        for (int i = 0; i < 11; i++)
        {
            infobox.Rows.Add();
            if (i == 0) 
            {
                infobox.Rows[infobox.Rows.Count - 1][count] = id;
                count++;
            }
            if (i == 1)
            {
                infobox.Rows[infobox.Rows.Count - 1][count] = DateCreate;
                count++;
            }
            if (i == 2)
            {
                infobox.Rows[infobox.Rows.Count - 1][count] =DateEditing;
                count++;
            }
            if (i == 3)
            {
                infobox.Rows[infobox.Rows.Count - 1][count] = City;
                count++;
            }
            if (i == 4)
            {
                infobox.Rows[infobox.Rows.Count - 1][count] = AdmDistrict;
                count++;
            }
            if (i == 5)
            {
                infobox.Rows[infobox.Rows.Count - 1][count] = District;
                count++;
            }
            if (i == 6)
            {
                infobox.Rows[infobox.Rows.Count - 1][count] = Street;
                count++;
            }
            if (i == 7)
            {
                infobox.Rows[infobox.Rows.Count - 1][count] = House;
                count++;
            }
            if (i == 8)
            {
                infobox.Rows[infobox.Rows.Count - 1][count] = Corps;
                count++;
            }
            if (i == 9)
            {
                infobox.Rows[infobox.Rows.Count - 1][count] = YearBuilding;
                count++;
            }
        }
        




        InsertCSVRecords(infobox);
    }






}




    








