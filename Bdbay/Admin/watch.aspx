<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/admin.Master" AutoEventWireup="true" EnableEventValidation="false" ValidateRequest="false" CodeBehind="watch.aspx.cs" Inherits="Bdbay.Admin.watch" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Body" runat="server">
    <div style="padding-left:300px;">
        <asp:PlaceHolder ID="videoShow" runat="server"></asp:PlaceHolder>
        </div>
     <div class="app-content content">
      <div class="content-wrapper">
        <div class="content-body"><!-- Stats -->
			<div class="card-content">


                <asp:Panel ID="pnlVideoShow" runat="server">
                    <div class="card-body card">
                        <div class="form-body">
                            <h4 class="form-section"><i class="ft-user"></i>Video Details</h4>

                            <div class="form-group row">
                                <label class="col-md-2 label-control" for="projectinput1">Title:</label>
                                <div class="col-md-6">
                                    <asp:TextBox ID="txtTitle" CssClass="form-control" placeholder="title" runat="server"></asp:TextBox>
                                </div>

                            </div>
                            <div class="form-group row">
                                <label class="col-md-2 label-control" for="projectinput1">Details:</label>
                                <div class="col-md-6">
                                    <asp:Label ID="txtDeatils" runat="server"></asp:Label>
                                </div>
                            </div>
                            <div class="form-group row">
                                <label class="col-md-2 label-control" for="projectinput1">Authority:</label>
                                <div class="col-md-6">
                                    <asp:DropDownList ID="ddlAuthority" CssClass="form-control" runat="server">
                                        <asp:ListItem Value="0" Selected="True">Select Iteam</asp:ListItem>
                                        <asp:ListItem Value="TRUE">Approve </asp:ListItem>
                                        <asp:ListItem Value="FALSE">Not Approve </asp:ListItem>
                                        <asp:ListItem Value="PANDING">Panding</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>

                            <div class="form-group row">
                                <label class="col-md-2 label-control" for="projectinput1">Advertise:</label>
                                <div class="col-md-6">
                                    <asp:DropDownList ID="ddlADD" CssClass="form-control" runat="server">
                                        <asp:ListItem Value="TRUE">TRUE</asp:ListItem>
                                        <asp:ListItem Value="FALSE">FALSE</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>

                            <div class="form-group row">
                                <label class="col-md-2 label-control" for="projectinput1">Error Messege:</label>
                                <div class="col-md-6">
                                    <asp:TextBox ID="txtErrorMessege" CssClass="form-control" placeholder="Error Messege/ Authority Cancle Messege" TextMode="MultiLine" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <asp:Label ID="lblResult" runat="server"></asp:Label>
                        <div class="form-actions">
                            <asp:Button ID="btnSave" OnClick="btnSave_Click" CssClass="btn btn-primary" runat="server" Text="Save" />
                            <asp:Button ID="btnDelete" OnClick="btnDelete_Click" CssClass="btn btn-danger" runat="server" Text="Delete" />
                        </div>
                    </div>
                </asp:Panel>

                <asp:Panel ID="pnlBlogShow" runat="server">
                         <div class="card-body card">
                        <div class="form-body">
                            <h4 class="form-section"><i class="ft-user"></i>Blog Details</h4>

                            <div class="form-group row">
                                <label class="col-md-2 label-control" for="projectinput1">Title:</label>
                                <div class="col-md-6">
                                    <asp:TextBox ID="txtBlogTitle" CssClass="form-control" placeholder="title" runat="server"></asp:TextBox>
                                </div>

                            </div>
                            <div class="form-group row">
                                <label class="col-md-2 label-control" for="projectinput1">Short Details:</label>
                                <div class="col-md-6">
                                    <asp:TextBox ID="txtBlogDetails" CssClass="form-control" placeholder="Details... " TextMode="MultiLine" runat="server"></asp:TextBox>
                                </div>
                            </div>

                                <div class="form-group row">
                                <label class="col-md-2 label-control" for="projectinput1">Advertise:</label>
                                <div class="col-md-6">
                                    <asp:DropDownList ID="ddlADDBlog" CssClass="form-control" runat="server">
                                        <asp:ListItem Value="TRUE">TRUE</asp:ListItem>
                                        <asp:ListItem Value="FALSE">FALSE</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>

                            <div class="form-group row">
                                <label class="col-md-2 label-control" for="projectinput1">Authority:</label>
                                <div class="col-md-6">
                                    <asp:DropDownList ID="ddlBlogAuthority" CssClass="form-control" runat="server">
                                        <asp:ListItem Value="0" Selected="True">Select Iteam</asp:ListItem>
                                        <asp:ListItem Value="TRUE">Approve </asp:ListItem>
                                        <asp:ListItem Value="FALSE">Not Approve </asp:ListItem>
                                        <asp:ListItem Value="PANDING">Panding</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-group row">
                                <label class="col-md-2 label-control" for="projectinput1">Error Messege:</label>
                                <div class="col-md-6">
                                    <asp:TextBox ID="txtBlogErrorMessege" CssClass="form-control" placeholder="Error Messege/ Authority Cancle Messege" TextMode="MultiLine" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group row">
                                <label class="col-md-2 label-control" for="projectinput1">Blog View:</label>
                                <div class="col-md-6">
                                    <asp:Button ID="btnBlogShow" OnClick="btnBlogShow_Click"  runat="server" Text="Show" />
                                </div>
                            </div>



                        </div>
                        <asp:Label ID="Label1" runat="server"></asp:Label>
                        <div class="form-actions">
                            <asp:Button ID="btnBlogSave" OnClick="btnBlogSave_Click"  CssClass="btn btn-primary" runat="server" Text="Save" />
                            <asp:Button ID="btnDeleteBlog" OnClick="btnDeleteBlog_Click"  CssClass="btn btn-danger" runat="server" Text="Delete" />
                        </div>
                    </div>
                </asp:Panel>


                <asp:Panel ID="pnlVideo" runat="server">
                <div class="card-body card"  style="visibility:hidden;">
                    <div class="form-body">
                        <h4 class="form-section"><i class="ft-user"></i>Video Add Settings</h4>
                        <div class="form-group row">
                            <label class="col-md-2 label-control" for="projectinput1">Video Add Submit upto (2-5 Min):</label>
                            <asp:FileUpload ID="FileUpload1" runat="server" />
                        </div>
                        <div class="form-group row">
                            <label class="col-md-2 label-control" for="projectinput1">Video Duration type Sec:</label>
                            <div class="col-md-3">
                                <asp:TextBox ID="txtsec" TextMode="Number" CssClass="form-control" placeholder="Example: 120" runat="server"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <asp:Label ID="lblAddResult" runat="server"></asp:Label>
                    <div class="form-actions">
                        <asp:Button ID="btnAdd" OnClick="btnAdd_Click" CssClass="btn btn-primary" runat="server" Text="Save" />
                    </div>
                    
                </div>
                    <asp:GridView ID="GridView2" Width="100%" runat="server" AutoGenerateColumns="False" DataKeyNames="ID" DataSourceID="SqlDataSource2" CellPadding="4" ForeColor="#333333" GridLines="None" AllowPaging="True" AllowSorting="True">
                        <AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
                        <Columns>
                            <asp:CommandField ShowEditButton="True" ShowDeleteButton="True"></asp:CommandField>
                            <asp:BoundField DataField="ID" HeaderText="ID" ReadOnly="True" InsertVisible="False" SortExpression="ID"></asp:BoundField>
                            <asp:BoundField DataField="VideoID" HeaderText="VideoID" SortExpression="VideoID"></asp:BoundField>
                            <asp:TemplateField HeaderText="ADDLink" SortExpression="ADDLink">
                                <EditItemTemplate>
                                    <asp:TextBox runat="server" Text='<%# Bind("ADDLink") %>' ID="TextBox1"></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <video src='<%# Eval("ADDLink","../{0}") %>' width="200" height="150" controls="controls" />                                  
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:BoundField DataField="ShowVideo" HeaderText="ShowVideo" SortExpression="ShowVideo"></asp:BoundField>
                        </Columns>
                        <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White"></FooterStyle>

                        <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White"></HeaderStyle>

                        <PagerStyle HorizontalAlign="Center" BackColor="#FFCC66" ForeColor="#333333"></PagerStyle>

                        <RowStyle BackColor="#FFFBD6" ForeColor="#333333"></RowStyle>

                        <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy"></SelectedRowStyle>

                        <SortedAscendingCellStyle BackColor="#FDF5AC"></SortedAscendingCellStyle>

                        <SortedAscendingHeaderStyle BackColor="#4D0000"></SortedAscendingHeaderStyle>

                        <SortedDescendingCellStyle BackColor="#FCF6C0"></SortedDescendingCellStyle>

                        <SortedDescendingHeaderStyle BackColor="#820000"></SortedDescendingHeaderStyle>
                    </asp:GridView>
                    <asp:SqlDataSource runat="server" ID="SqlDataSource2" ConnectionString='<%$ ConnectionStrings:video %>' DeleteCommand="DELETE FROM [VideoADD] WHERE [ID] = @ID" InsertCommand="INSERT INTO [VideoADD] ([VideoID], [ADDLink], [ShowVideo]) VALUES (@VideoID, @ADDLink, @ShowVideo)" SelectCommand="SELECT * FROM [VideoADD] WHERE ([VideoID] = @VideoID)" UpdateCommand="UPDATE [VideoADD] SET [VideoID] = @VideoID, [ADDLink] = @ADDLink, [ShowVideo] = @ShowVideo WHERE [ID] = @ID">
                        <DeleteParameters>
                            <asp:Parameter Name="ID" Type="Int32"></asp:Parameter>
                        </DeleteParameters>
                        <InsertParameters>
                            <asp:Parameter Name="VideoID" Type="String"></asp:Parameter>
                            <asp:Parameter Name="ADDLink" Type="String"></asp:Parameter>
                            <asp:Parameter Name="ShowVideo" Type="Int32"></asp:Parameter>
                        </InsertParameters>
                        <SelectParameters>
                            <asp:QueryStringParameter QueryStringField="" Name="VideoID" Type="String"></asp:QueryStringParameter>
                        </SelectParameters>
                        <UpdateParameters>
                            <asp:Parameter Name="VideoID" Type="String"></asp:Parameter>
                            <asp:Parameter Name="ADDLink" Type="String"></asp:Parameter>
                            <asp:Parameter Name="ShowVideo" Type="Int32"></asp:Parameter>
                            <asp:Parameter Name="ID" Type="Int32"></asp:Parameter>
                        </UpdateParameters>
                    </asp:SqlDataSource>
                </asp:Panel>   
                      
                <asp:Panel ID="pnlBlog" runat="server">
                <div class="card-body card">
                    <div class="form-body">
                        <h4 class="form-section"><i class="ft-user"></i>Blog Add Settings</h4>
                        <div class="form-group row">
                            <label class="col-md-2 label-control" for="projectinput1">Blog Image Add Submit </label>
                            <asp:FileUpload ID="FileUpload2" runat="server" />
                        </div>
                    </div>
                    <asp:Label ID="lblBlogResult" runat="server"></asp:Label>
                    <div class="form-actions">
                        <asp:Button ID="btnBlogADDSave" OnClick="btnBlogADDSave_Click"  CssClass="btn btn-primary" runat="server" Text="Save" />
                    </div>


                </div>
                    <asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" AutoGenerateColumns="False" DataKeyNames="ID" DataSourceID="SqlDataSource1" AllowPaging="True" AllowSorting="True">
                        <AlternatingRowStyle BackColor="White"></AlternatingRowStyle>

                        <Columns>
                            <asp:CommandField ShowEditButton="True" ShowDeleteButton="True"></asp:CommandField>
                            <asp:BoundField DataField="ID" HeaderText="ID" ReadOnly="True" InsertVisible="False" SortExpression="ID"></asp:BoundField>
                            <asp:BoundField DataField="BlogID" HeaderText="BlogID" SortExpression="BlogID"></asp:BoundField>
                            <asp:BoundField DataField="AddLink" HeaderText="AddLink" SortExpression="AddLink"></asp:BoundField>
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

                    <asp:SqlDataSource runat="server" ID="SqlDataSource1" ConnectionString='<%$ ConnectionStrings:blogcs %>' SelectCommand="SELECT * FROM [BlogADD] WHERE ([BlogID] = @BlogID)" DeleteCommand="DELETE FROM [BlogADD] WHERE [ID] = @ID" InsertCommand="INSERT INTO [BlogADD] ([BlogID], [AddLink]) VALUES (@BlogID, @AddLink)" UpdateCommand="UPDATE [BlogADD] SET [BlogID] = @BlogID, [AddLink] = @AddLink WHERE [ID] = @ID">
                        <DeleteParameters>
                            <asp:Parameter Name="ID" Type="Int32"></asp:Parameter>
                        </DeleteParameters>
                        <InsertParameters>
                            <asp:Parameter Name="BlogID" Type="String"></asp:Parameter>
                            <asp:Parameter Name="AddLink" Type="String"></asp:Parameter>
                        </InsertParameters>
                        <SelectParameters>
                            <asp:QueryStringParameter QueryStringField="" Name="BlogID" Type="String"></asp:QueryStringParameter>
                        </SelectParameters>
                        <UpdateParameters>
                            <asp:Parameter Name="BlogID" Type="String"></asp:Parameter>
                            <asp:Parameter Name="AddLink" Type="String"></asp:Parameter>
                            <asp:Parameter Name="ID" Type="Int32"></asp:Parameter>
                        </UpdateParameters>
                    </asp:SqlDataSource>
                </asp:Panel>          							
										




	          
					
	                </div> 
            </div>
        </div>
      </div>
</asp:Content>
