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
       //string sqlconn = "server = localhost; user = some_user; database = some_db; password = some_pass; Initial Catalog=Excel;";
        con = new SqlConnection(sqlconn);
        //Коннект к базе данных
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        //Создание обьекта базы данных  
        DataTable tblcsv = new DataTable();
        //Создание колонок  
        tblcsv.Columns.Add("id");
        tblcsv.Columns.Add("DateCreate");
        tblcsv.Columns.Add("DateEditing");
        tblcsv.Columns.Add("City");
        tblcsv.Columns.Add("AdmDistrict");
        tblcsv.Columns.Add("District");
        tblcsv.Columns.Add("Street");
        tblcsv.Columns.Add("House");
        tblcsv.Columns.Add("Corps");
        tblcsv.Columns.Add("YearBuilding");
        //Положение файла  
        string CSVFilePath = Path.GetFullPath(@"C:\Users\123\Desktop\Какой то дом.csv");
        //string CSVFilePath = Path.GetFullPath(FileUpload1.PostedFile.FileName);
        //Прочитать весь текст  
        string ReadCSV = File.ReadAllText(CSVFilePath);
        //Сплит до новых строк  
        foreach (string csvRow in ReadCSV.Split('\n'))
        {
            if (!string.IsNullOrEmpty(csvRow))
            {
                //добавление в колонки  
                tblcsv.Rows.Add();
                int count = 0;
                foreach (string FileRec in csvRow.Split(';'))
                {
                    tblcsv.Rows[tblcsv.Rows.Count - 1][count] = FileRec;
                    count++;
                }
            }
        }
         
        InsertCSVRecords(tblcsv);
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





    // Загрузка краткой базы данных домов
    protected void Button2_Click(object sender, EventArgs e)
    {
        RptCourse.DataSource = GetCourses();
        RptCourse.DataBind();
    }

    private List<Course> GetCourses()
    {
        var dataTable = new DataTable();

        using (var sqlConnection = new SqlConnection(@"server=.\SQLEXPRESS;Initial Catalog=Excel;Integrated Security=True"))
        {
            sqlConnection.Open();

            using (var sqlCommand = new SqlCommand("select * from Users", sqlConnection))
            {
                using (var sqlReader = sqlCommand.ExecuteReader())
                {
                    dataTable.Load(sqlReader);
                }
            }
        }

        var courses = new List<Course>();

        foreach (DataRow dataRow in dataTable.Rows)
        {
            var course = new Course()
            {
                City = (string)dataRow["City"],
                House = (string)dataRow["House"]
            };
            courses.Add(course);
        }

        return courses;
    }


    protected void TextBox1_TextChanged(object sender, EventArgs e)
    {

    }
















    protected void Button3_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Page2.aspx");



        //DataTable infobox = new DataTable();

        //infobox.Columns.Add("id");
        //infobox.Columns.Add("DateCreate");
        //infobox.Columns.Add("DateEditing");
        //infobox.Columns.Add("City");
        //infobox.Columns.Add("AdmDistrict");
        //infobox.Columns.Add("District");
        //infobox.Columns.Add("Street");
        //infobox.Columns.Add("House");
        //infobox.Columns.Add("Corps");
        //infobox.Columns.Add("YearBuilding");




        //foreach (string csvRow in text.Split('\n'))
        //{
        //    if (!string.IsNullOrEmpty(csvRow))
        //    {
        //        //добавление в колонки  
        //        infobox.Rows.Add();
        //        int count = 0;
        //        foreach (string FileRec in csvRow.Split(';'))
        //        {
        //            if (count == 0)
        //            {
        //                string id = System.Guid.NewGuid().ToString();
        //                //string id = 
        //                infobox.Rows[infobox.Rows.Count - 1][count] = id;
        //                count++;
        //            }

        //            if (count == 1) 
        //            { 


        //            }

        //            {
        //                infobox.Rows[infobox.Rows.Count - 1][count] = FileRec;
        //                count++;
        //            }
        //        }
        //    }
        //}

        //InsertCSVRecords(infobox);
    }





}






public class Course
{
    public string City { get; set; }
    public string House { get; set; }

}








