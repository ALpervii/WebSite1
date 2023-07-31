<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Page2.aspx.cs" Inherits="_Default" %>  
  
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">  
  
<html xmlns="http://www.w3.org/1999/xhtml">  
<head  id="Head1" runat="server">    
    <title>Article by Vithal Wadje</title>    
    <style type="text/css">
        .auto-style1 {
            width: 269px;
        }
        .auto-style2 {
            height: 23px;
        }
    </style>
</head>    
<body bgcolor="gray">    
    <form  id="form1" runat="server" enctype="multipart/form-data">
    <div style="color: blue;">    
        <h4>    
            Загрузить дом
        </h4>    
        <table>    
            <tr>    
                <td style="margin-left: 40px">    
                    Введите время создания<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                </td>    
            </tr>    
            <tr>    
                <td style="margin-left: 40px">    
                    Введите введите время редактирования&nbsp;&nbsp;&nbsp; <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                </td>    
            </tr>    
            <tr>    
                <td style="margin-left: 40px">    
                    Введите город&nbsp;
                    <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
                </td>    
            </tr>    
        </table>        
        <table>    
            <tr>    
                <td style="margin-left: 40px" class="auto-style1">    
                    Введите AdmDistrict<asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
                </td>    
            </tr>    
        </table>        
        <table>    
            <tr>
                <td style="margin-left: 40px">    
                &nbsp;Введите&nbsp; District<asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
                </td>    
            </tr>
            <tr>
                <td style="margin-left: 40px">    
                    Введите улицу<asp:TextBox ID="TextBox6" runat="server"></asp:TextBox>
                </td>    
            </tr>
            <tr>
                <td style="margin-left: 40px">    
                    Введите дом<asp:TextBox ID="TextBox7" runat="server"></asp:TextBox>
                </td>    
            </tr>
            <tr>
                <td style="margin-left: 40px" class="auto-style2">    
                    Введите корпус<asp:TextBox ID="TextBox8" runat="server"></asp:TextBox>
                </td>    
            </tr>
            <tr>
                <td style="margin-left: 40px">    
                    Введите год постройки<asp:TextBox ID="TextBox9" runat="server"></asp:TextBox>
                </td>    
            </tr>
        </table>      
                    <asp:Button ID= "Button" runat="server" Text="Загрузить базу" OnClick="Button_Click"/> 
        <br /><br />  
    </div>    
      
    </form>    
</body>    
</html>
