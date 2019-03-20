<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/admin.Master" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="VideoSettings.aspx.cs" Inherits="Bdbay.Admin.VideoSettings" %>
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
                                <label class="col-md-2 label-control" for="projectinput1">Video Category:</label>
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
                                    <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" CssClass=" btn btn-success" Text="Save" />
                                    <asp:Label ID="lblResult" runat="server" ></asp:Label>
                                </div>                                                             
                            </div>
                              <div class="form-group row">
                                  <div class="col-md-12">
                                    <asp:CheckBox ID="chkADON" AutoPostBack="true"  runat="server" OnCheckedChanged="chkADON_CheckedChanged" Text="Check All Video Advertisement ON" />
                                  </div>
                                  <div class="col-md-12">
                                    <asp:CheckBox ID="chkADOFF" AutoPostBack="true"  runat="server" OnCheckedChanged="chkADOFF_CheckedChanged" Text="Check All Video Advertisement OFF" />
                                  </div>
                                  <div class="col-md-12">
                                    <asp:CheckBox ID="chkPUBON" AutoPostBack="true"  runat="server" OnCheckedChanged="chkPUBON_CheckedChanged" Text="Check All Published ON" />
                                  </div>
                                  <div class="col-md-12">
                                    <asp:CheckBox ID="chkPUBOFF" AutoPostBack="true"  runat="server" OnCheckedChanged="chkPUBOFF_CheckedChanged" Text="Check All Published OFF" />
                                  </div>
                                   <div class="col-md-12">
                                       <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" CssClass="btn btn-success"  Text="Save" />
                                   </div>
                              </div>
                            <div class="form-group row">
                                <label class="col-md-2 label-control" for="projectinput1">
                                    <asp:CheckBox ID="CheckBox1" runat="server" OnCheckedChanged="CheckBox1_CheckedChanged" AutoPostBack="true"  Text="Category Details" /></label>
                                <div class="col-md-6">
                                    <asp:GridView ID="GridView1" Width="100%" PageSize="30" runat="server" AutoGenerateColumns="False" DataKeyNames="ID" DataSourceID="SqlDataSource1" BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellPadding="3" CellSpacing="2" AllowPaging="True" AllowSorting="True">
                                        <Columns>
                                            <asp:CommandField ShowEditButton="True" ShowDeleteButton="True"></asp:CommandField>
                                            <asp:BoundField DataField="ID" HeaderText="ID" ReadOnly="True" InsertVisible="False" SortExpression="ID"></asp:BoundField>
                                            <asp:BoundField DataField="Catagories" HeaderText="Catagories" SortExpression="Catagories"></asp:BoundField>
                                            <asp:BoundField DataField="Value" HeaderText="Value" SortExpression="Value"></asp:BoundField>
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
                                    <asp:SqlDataSource runat="server" ID="SqlDataSource1" ConnectionString='<%$ ConnectionStrings:Settings %>' DeleteCommand="DELETE FROM [Video_Catagories_Tbl] WHERE [ID] = @ID" InsertCommand="INSERT INTO [Video_Catagories_Tbl] ([Catagories], [Value]) VALUES (@Catagories, @Value)" SelectCommand="SELECT * FROM [Video_Catagories_Tbl]" UpdateCommand="UPDATE [Video_Catagories_Tbl] SET [Catagories] = @Catagories, [Value] = @Value WHERE [ID] = @ID">
                                        <DeleteParameters>
                                            <asp:Parameter Name="ID" Type="Int32"></asp:Parameter>
                                        </DeleteParameters>
                                        <InsertParameters>
                                            <asp:Parameter Name="Catagories" Type="String"></asp:Parameter>
                                            <asp:Parameter Name="Value" Type="String"></asp:Parameter>
                                        </InsertParameters>
                                        <UpdateParameters>
                                            <asp:Parameter Name="Catagories" Type="String"></asp:Parameter>
                                            <asp:Parameter Name="Value" Type="String"></asp:Parameter>
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
