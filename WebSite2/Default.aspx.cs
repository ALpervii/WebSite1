using System;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.UI.WebControls;
using System.Data.Entity;
using System.Runtime.InteropServices;
using System.Web.Providers.Entities;

public partial class _Default : System.Web.UI.Page
{

    SqlConnection con;

    string sqlconn;
    protected void Page_Load(object sender, EventArgs e)
    {
    }
    private void connection()
    {
        //string sqlconn = (@"server=.\SQLEXPRESS; Persist Security Info=true; Integrated Security=true;  Initial Catalog=Excel;");
        string sqlconn = (@"server = localhost; user = some_user; database = some_db; password = some_pass; charset = utf8;  Initial Catalog=Excel;");
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
        string CSVFilePath = Path.GetFullPath(@"C:\Users\123\Desktop\ric_House.csv");
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
}