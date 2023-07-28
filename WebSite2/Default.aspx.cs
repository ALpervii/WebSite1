using System;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{

    SqlConnection con;

    string sqlconn;
    protected void Page_Load(object sender, EventArgs e)
    {
    }
    private void connection()
    {
        string sqlconn = (@"server=.\SQLEXPRESS; Persist Security Info=true; Integrated Security=true; Initial Catalog=Excel");
        con = new SqlConnection(sqlconn);
        //SqlConnection con = new SqlConnection(@"server=.\SQLEXPRESS; Persist Security Info=true; Integrated Security=true; Initial Catalog=Users");
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        //Creating object of datatable  
        DataTable tblcsv = new DataTable();
        //creating columns  
        tblcsv.Columns.Add("id");
        tblcsv.Columns.Add("name");
        tblcsv.Columns.Add("City");
        tblcsv.Columns.Add("House");
        //getting full file path of Uploaded file  
        string CSVFilePath = Path.GetFullPath(@"C:\Users\123\Desktop\info.csv");
        //Reading All text  
        string ReadCSV = File.ReadAllText(CSVFilePath);
        //spliting row after new line  
        foreach (string csvRow in ReadCSV.Split('\n'))
        {
            if (!string.IsNullOrEmpty(csvRow))
            {
                //Adding each row into datatable  
                tblcsv.Rows.Add();
                int count = 0;
                foreach (string FileRec in csvRow.Split(','))
                {
                    tblcsv.Rows[tblcsv.Rows.Count - 1][count] = FileRec;
                    count++;
                }
            }
        }
        //Calling insert Functions  
        InsertCSVRecords(tblcsv);
    }
    //Function to Insert Records  
    private void InsertCSVRecords(DataTable csvdt)
    {

        connection();
        //creating object of SqlBulkCopy   
        SqlBulkCopy objbulk = new SqlBulkCopy(con);
        //assigning Destination table name   
        objbulk.DestinationTableName = "Users";
        //Mapping Table column   
        objbulk.ColumnMappings.Add("id", "id");
        objbulk.ColumnMappings.Add("name", "name");
        objbulk.ColumnMappings.Add("City", "City");
        objbulk.ColumnMappings.Add("House", "House");
        //inserting Datatable Records to DataBase   
        con.Open();
        objbulk.WriteToServer(csvdt);
        con.Close();
    }
}