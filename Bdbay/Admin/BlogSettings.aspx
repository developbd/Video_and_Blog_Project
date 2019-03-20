<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/admin.Master"  AutoEventWireup="true" EnableEventValidation="false" ValidateRequest="false" CodeBehind="BlogSettings.aspx.cs" Inherits="Bdbay.Admin.BlogSettings" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Body" runat="server">
    <div class="app-content content">
        <div class="content-wrapper">
            <div class="content-body">
                <div class="card-content">
                    <div class="card-body card">
                        <div class="form-body">
                            <div class="form-group row">
                                <label class="col-md-2 label-control" for="projectinput1">Blog Category:</label>
                                <div class="col-md-3">
                                    <asp:TextBox ID="txtCategory" CssClass="form-control" placeholder="Category Add" runat="server"></asp:TextBox>
                                </div>                             
                            </div>
                            <div class="form-group row">
                                <label class="col-md-2 label-control" for="projectinput1">Category Value:</label>
                                <div class="col-md-3">
                                    <asp:TextBox ID="txtValue" CssClass="form-control" placeholder="Category Value for Link..." runat="server"></asp:TextBox>
                                </div>  
                                <div class="col-md-2">
                                    <asp:Button ID="btnSave" OnClick="btnSave_Click" runat="server" CssClass=" btn btn-success" Text="Save" />
                                    <asp:Label ID="lblResult" runat="server" ></asp:Label>
                                </div>                                                             
                            </div>
                              <div class="form-group row">
                                  <div class="col-md-12">
                                    <asp:CheckBox ID="chkADON" AutoPostBack="true" OnCheckedChanged="chkADON_CheckedChanged" runat="server" Text="Check All Blog Advertisement ON" />
                                  </div>
                                  <div class="col-md-12">
                                    <asp:CheckBox ID="chkADOFF" AutoPostBack="true" OnCheckedChanged="chkADOFF_CheckedChanged" runat="server" Text="Check All Blog Advertisement OFF" />
                                  </div>
                                  <div class="col-md-12">
                                    <asp:CheckBox ID="chkPUBON" AutoPostBack="true" OnCheckedChanged="chkPUBON_CheckedChanged" runat="server" Text="Check All Published ON" />
                                  </div>
                                  <div class="col-md-12">
                                    <asp:CheckBox ID="chkPUBOFF" AutoPostBack="true" OnCheckedChanged="chkPUBOFF_CheckedChanged" runat="server" Text="Check All Published OFF" />
                                  </div>
                                   <div class="col-md-12">
                                       <asp:Button ID="Button1" runat="server" CssClass="btn btn-success" OnClick="Button1_Click" Text="Save" />
                                   </div>
                              </div>
                            <div class="form-group row">
                                <label class="col-md-2 label-control" for="projectinput1">
                                    <asp:CheckBox ID="CheckBox1" runat="server" AutoPostBack="true" OnCheckedChanged="CheckBox1_CheckedChanged" Text="Category Details" /></label>
                                <div class="col-md-6">
                                    <asp:GridView ID="GridView1" Width="100%" PageSize="30" runat="server" AutoGenerateColumns="False" DataKeyNames="ID" DataSourceID="SqlDataSource1" AllowPaging="True" AllowSorting="True" BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellPadding="3" CellSpacing="2">
                                        <Columns>
                                            <asp:CommandField ShowEditButton="True" ShowDeleteButton="True"></asp:CommandField>
                                            <asp:BoundField DataField="ID" HeaderText="ID" ReadOnly="True" InsertVisible="False" SortExpression="ID"></asp:BoundField>
                                            <asp:BoundField DataField="Catagoris" HeaderText="Catagoris" SortExpression="Catagoris"></asp:BoundField>
                                            <asp:BoundField DataField="value" HeaderText="value" SortExpression="value"></asp:BoundField>
                                        </Columns>
                                        <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510"></FooterStyle>

                                        <HeaderStyle BackColor="#A55129" Font-Bold="True" ForeColor="White"></HeaderStyle>

                                        <PagerStyle HorizontalAlign="Center" ForeColor="#8C4510"></PagerStyle>

                                        <RowStyle BackColor="#FFF7E7" ForeColor="#8C4510"></RowStyle>

                                        <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White"></SelectedRowStyle>

                                        <SortedAscendingCellStyle BackColor="#FFF1D4"></SortedAscendingCellStyle>

                                        <SortedAscendingHeaderStyle BackColor="#B95C30"></SortedAscendingHeaderStyle>

                                        <SortedDescendingCellStyle BackColor="#F1E5CE"></SortedDescendingCellStyle>

                                        <SortedDescendingHeaderStyle BackColor="#93451F"></SortedDescendingHeaderStyle>
                                    </asp:GridView>
                                    <asp:SqlDataSource runat="server" ID="SqlDataSource1" ConnectionString='<%$ ConnectionStrings:Settings %>' DeleteCommand="DELETE FROM [Blog_Catagory_Tbl] WHERE [ID] = @ID" InsertCommand="INSERT INTO [Blog_Catagory_Tbl] ([Catagoris], [value]) VALUES (@Catagoris, @value)" SelectCommand="SELECT * FROM [Blog_Catagory_Tbl] order by ID DESC" UpdateCommand="UPDATE [Blog_Catagory_Tbl] SET [Catagoris] = @Catagoris, [value] = @value WHERE [ID] = @ID">
                                        <DeleteParameters>
                                            <asp:Parameter Name="ID" Type="Int32"></asp:Parameter>
                                        </DeleteParameters>
                                        <InsertParameters>
                                            <asp:Parameter Name="Catagoris" Type="String"></asp:Parameter>
                                            <asp:Parameter Name="value" Type="String"></asp:Parameter>
                                        </InsertParameters>
                                        <UpdateParameters>
                                            <asp:Parameter Name="Catagoris" Type="String"></asp:Parameter>
                                            <asp:Parameter Name="value" Type="String"></asp:Parameter>
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



</asp:Content>
