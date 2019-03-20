<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/admin.Master" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="ShowAdminStaff.aspx.cs" Inherits="Bdbay.Admin.ShowAdminStaff" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Body" runat="server">
            <div class="app-content content">
                <div class="content-wrapper">
                    <div class="content-body">
                        <!-- Stats -->
                        <div class="card-content">
                            <div class="card-body card">

                                <div class="form-body">
                                    <h4 class="form-section"><i class="ft-user"></i>Admin Settings
                                        <asp:Label ID="lblResult" Font-Bold="true" runat="server"></asp:Label></h4>
                                    <div class="form-group row">
                                        <div class="col-md-12">
                                            <asp:GridView ID="GridView1" Width="100%" PageSize="50" runat="server" AutoGenerateColumns="False" DataKeyNames="ID" DataSourceID="SqlDataSource1" CellPadding="4" ForeColor="#333333" GridLines="None" AllowPaging="True" AllowSorting="True">
                                                <AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
                                                <Columns>
                                                    <asp:CommandField ShowEditButton="True" ShowDeleteButton="True"></asp:CommandField>
                                                    <asp:BoundField DataField="ID" HeaderText="ID" ReadOnly="True" InsertVisible="False" SortExpression="ID"></asp:BoundField>
                                                    <asp:BoundField DataField="FullName" HeaderText="FullName" SortExpression="FullName"></asp:BoundField>
                                                    <asp:BoundField DataField="Mobile" HeaderText="Mobile" SortExpression="Mobile"></asp:BoundField>
                                                    <asp:TemplateField HeaderText="Image" SortExpression="Image">
                                                        <EditItemTemplate>
                                                            <asp:TextBox runat="server" Text='<%# Bind("Image") %>' ID="TextBox1"></asp:TextBox>
                                                        </EditItemTemplate>
                                                        <ItemTemplate>
                                                            <asp:Image ID="Image1" Width="80" Height="80" ImageUrl='<%# Bind("Image","../Admin/Image/{0}") %>' runat="server" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Authority" SortExpression="Authority">
                                                        <EditItemTemplate>
                                                             <asp:DropDownList ID="ddlYear" SelectedValue='<%# Bind("Authority") %>' runat="server">
                                                                 <asp:ListItem Value="TRUE">True</asp:ListItem>
                                                                 <asp:ListItem Value="FALSE">False</asp:ListItem>
                                                             </asp:DropDownList>                                                            
                                                        </EditItemTemplate>
                                                        <ItemTemplate>
                                                            <asp:Label runat="server" Text='<%# Bind("Authority") %>' ID="Label1"></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:BoundField DataField="IDType" HeaderText="IDType" SortExpression="IDType"></asp:BoundField>
                                                    <asp:BoundField DataField="username" HeaderText="username" SortExpression="username"></asp:BoundField>
                                                    <asp:BoundField DataField="password" HeaderText="password" SortExpression="password"></asp:BoundField>
                                                    <asp:TemplateField HeaderText="Edit">
                                                       <ItemTemplate>
                                                           <asp:LinkButton ID="LinkButton1" runat="server" CssClass="btn btn-danger" CommandArgument='<%# Eval("ID") %>' OnCommand="LinkButton1_Command">Settings</asp:LinkButton>

                                                       </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                                <EditRowStyle BackColor="#7C6F57"></EditRowStyle>

                                                <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White"></FooterStyle>

                                                <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White"></HeaderStyle>

                                                <PagerStyle HorizontalAlign="Center" BackColor="#666666" ForeColor="White"></PagerStyle>

                                                <RowStyle BackColor="#E3EAEB"></RowStyle>

                                                <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333"></SelectedRowStyle>

                                                <SortedAscendingCellStyle BackColor="#F8FAFA"></SortedAscendingCellStyle>

                                                <SortedAscendingHeaderStyle BackColor="#246B61"></SortedAscendingHeaderStyle>

                                                <SortedDescendingCellStyle BackColor="#D4DFE1"></SortedDescendingCellStyle>

                                                <SortedDescendingHeaderStyle BackColor="#15524A"></SortedDescendingHeaderStyle>
                                            </asp:GridView>
    <asp:SqlDataSource runat="server" ID="SqlDataSource1" ConnectionString='<%$ ConnectionStrings:Admin %>' DeleteCommand="DELETE FROM [AdminID] WHERE [ID] = @ID" InsertCommand="INSERT INTO [AdminID] ([UserID], [FullName], [Gender], [Address], [NID], [Mobile], [Email], [Image], [Authority], [IDType], [Date], [username], [password], [Details]) VALUES (@UserID, @FullName, @Gender, @Address, @NID, @Mobile, @Email, @Image, @Authority, @IDType, @Date, @username, @password, @Details)" SelectCommand="SELECT * FROM [AdminID]" UpdateCommand="UPDATE [AdminID] SET [UserID] = @UserID, [FullName] = @FullName, [Gender] = @Gender, [Address] = @Address, [NID] = @NID, [Mobile] = @Mobile, [Email] = @Email, [Image] = @Image, [Authority] = @Authority, [IDType] = @IDType, [Date] = @Date, [username] = @username, [password] = @password, [Details] = @Details WHERE [ID] = @ID">
        <DeleteParameters>
            <asp:Parameter Name="ID" Type="Int32"></asp:Parameter>
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="UserID" Type="String"></asp:Parameter>
            <asp:Parameter Name="FullName" Type="String"></asp:Parameter>
            <asp:Parameter Name="Gender" Type="String"></asp:Parameter>
            <asp:Parameter Name="Address" Type="String"></asp:Parameter>
            <asp:Parameter Name="NID" Type="String"></asp:Parameter>
            <asp:Parameter Name="Mobile" Type="String"></asp:Parameter>
            <asp:Parameter Name="Email" Type="String"></asp:Parameter>
            <asp:Parameter Name="Image" Type="String"></asp:Parameter>
            <asp:Parameter Name="Authority" Type="String"></asp:Parameter>
            <asp:Parameter Name="IDType" Type="String"></asp:Parameter>
            <asp:Parameter Name="Date" Type="String"></asp:Parameter>
            <asp:Parameter Name="username" Type="String"></asp:Parameter>
            <asp:Parameter Name="password" Type="String"></asp:Parameter>
            <asp:Parameter Name="Details" Type="String"></asp:Parameter>
        </InsertParameters>
        <UpdateParameters>
            <asp:Parameter Name="UserID" Type="String"></asp:Parameter>
            <asp:Parameter Name="FullName" Type="String"></asp:Parameter>
            <asp:Parameter Name="Gender" Type="String"></asp:Parameter>
            <asp:Parameter Name="Address" Type="String"></asp:Parameter>
            <asp:Parameter Name="NID" Type="String"></asp:Parameter>
            <asp:Parameter Name="Mobile" Type="String"></asp:Parameter>
            <asp:Parameter Name="Email" Type="String"></asp:Parameter>
            <asp:Parameter Name="Image" Type="String"></asp:Parameter>
            <asp:Parameter Name="Authority" Type="String"></asp:Parameter>
            <asp:Parameter Name="IDType" Type="String"></asp:Parameter>
            <asp:Parameter Name="Date" Type="String"></asp:Parameter>
            <asp:Parameter Name="username" Type="String"></asp:Parameter>
            <asp:Parameter Name="password" Type="String"></asp:Parameter>
            <asp:Parameter Name="Details" Type="String"></asp:Parameter>
            <asp:Parameter Name="ID" Type="Int32"></asp:Parameter>
        </UpdateParameters>
    </asp:SqlDataSource>


                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>






            </div>
</asp:Content>
