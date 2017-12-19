<%@ Page Language="C#" AutoEventWireup="true" CodeFile="default.aspx.cs" Inherits="_default" %>



<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:HiddenField ID="hfproductID" runat="server" />
        <table>
            <tr>
                <td>
                     <asp:Label Text="PRODUCT" runat="server"></asp:Label>
                </td>
                <td colspan="2">
                    <asp:TextBox ID="txtproduct" runat="server"></asp:TextBox>

                </td>
            </tr>
             <tr>
                <td>
                     <asp:Label Text="PRICE" runat="server"></asp:Label>
                </td>
                <td colspan="2">
                    <asp:TextBox ID="txtprice" runat="server" TextMode="Number"></asp:TextBox>

                </td>
            </tr>
             <tr>
                <td>
                     <asp:Label Text="COUNT" runat="server"></asp:Label>
                </td>
                <td colspan="2">
                    <asp:TextBox ID="txtcount" runat="server" TextMode="Number"></asp:TextBox>

                </td>
            </tr>
             <tr>
                <td>
                     <asp:Label Text="DESCRIPTION" runat="server"></asp:Label>
                </td>
                <td colspan="2">
                    <asp:TextBox ID="txtdecription" runat="server"></asp:TextBox>

                </td>
            </tr>
            <tr>
                <td></td>
                <td colspan="3">
                    <asp:Button ID="btninsert" runat="server" Text="INSERT" OnClick="btninsert_Click" />
                   
                    <asp:Button ID="btnclear" runat="server" Text="CLEAR" OnClick="btnclear_Click" />
                    <asp:Button ID="btnupdate" runat="server" Text="UPDATE" OnClick="btnupdate_Click" />
                </td>
            </tr>
            <tr>
                <td></td>
                <td colspan="2">
                    <asp:Label ID="succes" runat="server" Text=""></asp:Label>
                    <asp:Label ID="error" runat="server" Text=""></asp:Label>
                </td>
            </tr>
        </table>
        <asp:GridView ID="grd1" runat="server" AutoGenerateColumns="false">
            <Columns>
                <asp:BoundField DataField="product" HeaderText="product" />
                <asp:BoundField DataField="price" HeaderText="product" />
                <asp:BoundField DataField="count" HeaderText="product" />
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton Text="edit" ID="lnkedit" CommandArgument='<%# Eval("productid") %>' runat="server" OnClick="lnk_edit"></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                      <asp:LinkButton Text="delete" ID="lnkdlt" CommandArgument='<%# Eval("productid") %>' runat="server" OnClick="lnkdlt"></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>

            </Columns>

        </asp:GridView>
       
     </div>
    </form>
    <script>
        function(){
            document.getElementById("form1").preventDefault();
        }
    </script>
</body>
</html>
