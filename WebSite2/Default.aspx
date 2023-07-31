<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>  
  
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">  
  
<html xmlns="http://www.w3.org/1999/xhtml">  
<head  id="Head1" runat="server">    
    <title>Article by Vithal Wadje</title>    
</head>    
<body bgcolor="gray">    
    <form  id="form1" runat="server" enctype="multipart/form-data">
    <div style="color: blue;">    
        <h4>    
Загрузка домов в базу данных
        </h4>    
        <table>    
            <tr>    
                <td>    
Выбрать фаил, чтобы загрузить базу данных домов
                </td>    
                <td>    
                    <asp:FileUpload ID=  "FileUpload1" runat="server"/>    
                </td>    
                <td>    
                </td>    
                <td>    
                    <asp:Button ID=    "Button1" runat="server" Text="Загрузить базу" OnClick="Button1_Click"/> 
                </td>  
            </tr>    
        </table>      
        <table>    
            <tr>    
                <td style="margin-left: 40px">    
                    Нажмите, чтобы получить данные домов    
                    <asp:Button ID1=    "Button2" runat="server" Text="Показать" OnClick="Button2_Click"/>
                </td>    
            </tr>    
            <tr>    
                <td style="margin-left: 40px">    
                    Нажмите если хотите ввести дом вручную<asp:Button ID2=    "Button3" runat="server" Text="Перейти к заполнению" OnClick="Button3_Click" ID="Button3" PostBackUrl="Page2.aspx"/>
                </td>    
            </tr>    
            <tr>    
                <td style="margin-left: 40px">    
                </td>    
            </tr>    
        </table>  <br /><br />  
        <asp:Repeater ID="RptCourse" runat="server">
        <HeaderTemplate>
            <table>
                <tr>
                    <th>City </th>
                    <th>House</th>
                </tr>
        </HeaderTemplate>

        <ItemTemplate>
            <tr>
                <td>
                    <asp:Label runat="server" ID="Label1"
                        Text='<%# Eval("City") %>' />
                </td>
                <td >
                    <asp:Label runat="server" ID="Label2"
                        Text='<%# Eval("House") %>' />
                </td>
            </tr>
        </ItemTemplate>

        <AlternatingItemTemplate>
            <tr>
                <td>
                    <asp:Label runat="server" ID="Label1"
                        Text='<%# Eval("City") %>' />
                </td>
                <td >
                    <asp:Label runat="server" ID="Label2"
                        Text='<%# Eval("House") %>' />
                </td>
            </tr>
        </AlternatingItemTemplate>
        <FooterTemplate>
            </table>
        </FooterTemplate>
    </asp:Repeater>
    </div>    
      
    </form>    
</body>    
</html>
