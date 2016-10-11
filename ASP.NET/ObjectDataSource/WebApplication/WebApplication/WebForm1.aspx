<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WebApplication.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:ObjectDataSource 
            ID="CitiesObjectDataSource" 
            runat="server" 
            TypeName="WebApplication.City" 
            DataObjectTypeName="Samples.AspNet.ObjectDataSource.City"
            SortParameterName="SortColumns"
            EnablePaging="true"
            StartRowIndexParameterName="StartRecord"
            MaximumRowsParameterName="MaxRecords" 
            SelectMethod="GetCityCollection" >
        </asp:ObjectDataSource>


            <asp:GridView ID="CitiesGridView" 
              DataSourceID="CitiesObjectDataSource" 
              AutoGenerateColumns="false"
              AllowSorting="true"
              AllowPaging="true"
              PageSize="5"
              DataKeyNames="Name" 
              RunAt="server">

              <HeaderStyle backcolor="lightblue" forecolor="black"/>

              <Columns>                
                <asp:ButtonField Text="Details..."
                                 HeaderText="Show Details"
                                 CommandName="Select"/>  

                <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                <asp:BoundField DataField="Language"  HeaderText="Language" SortExpression="Language" />                   
              </Columns>                
            </asp:GridView>            
        
    </div>
    </form>
</body>
</html>
