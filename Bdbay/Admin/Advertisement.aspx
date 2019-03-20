<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/admin.Master" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="Advertisement.aspx.cs" Inherits="Bdbay.Admin.Advertisement" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Body" runat="server">
    <div class="app-content content">
      <div class="content-wrapper">
        <div class="content-body"><!-- Stats -->
			<div class="card-content">
                <div class="card-body card">                   
                    <asp:Panel ID="pnlAdd" runat="server">
                        <div class="form form-horizontal">
                            <div class="form-body">
                                <h4 class="form-section"><i class="ft-user"></i>Advertisement</h4>
                                <hr>
                                <div class="form-group row">
                                    <label class="col-md-3 label-control" for="projectinput1">Link:</label>
                                    <div class="col-md-9">
                                        <asp:TextBox ID="txtlink" CssClass="form-control" placeholder="Company Url" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group row">
                                    <label class="col-md-3 label-control" for="projectinput2">Horizontal/Vertical:</label>
                                    <div class="col-md-9">
                                        <asp:DropDownList ID="ddlHV" CssClass="form-control" runat="server">
                                            <asp:ListItem Selected="True" Value="0">Select Iteam</asp:ListItem>
                                            <asp:ListItem Value="Horizontal">Horizontal</asp:ListItem>
                                            <asp:ListItem Value="Vertical">Vertical</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="form-group row">
                                    <label class="col-md-3 label-control">Image: Horizontal(728x90) Vertical(300x250)</label>
                                    <div class="col-md-9">
                                        <asp:FileUpload ID="FileUpload1" runat="server" />
                                    </div>
                                </div>
                            </div>
                            <asp:Label ID="lblResult" runat="server"></asp:Label>
                            <div class="form-actions">
                                <asp:Button ID="btnsave" runat="server" Text="Make Advertisement" OnClick="btnsave_Click" CssClass="btn btn-primary" />
                            </div>

                              <div class="form-body">
                                <h4 class="form-section"><i class="ft-user"></i>Video Advertisement</h4>
                                <hr>
                                <div class="form-group row">
                                    <label class="col-md-3 label-control">Video: Mp4 Only 2-5 min</label>
                                    <div class="col-md-9">
                                        <asp:FileUpload ID="FileUpload3" runat="server" />
                                    </div>
                                </div>
                                  <div class="form-group row">
                                    <label class="col-md-3 label-control">Total Video Sec/Duration :</label>
                                     <div class="col-md-2">
                                        <asp:TextBox ID="txtsec" CssClass="form-control" placeholder="Sec. example: 250" TextMode="Number" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="form-actions">
                                <asp:Button ID="btnVideoAdd" runat="server" Text="Video Advertisement" OnClick="btnVideoAdd_Click" CssClass="btn btn-primary" />
                            </div>
                        </div>
                    </asp:Panel>	
                    <br><br>

                    <asp:Panel ID="pnlEditAdd" runat="server">
                    <div class="form form-horizontal">
                       	<div class="form-body">
	                    		<h4 class="form-section"><i class="ft-user"></i> Edit Option</h4>
								<hr>
                               <asp:Image ID="EditImageShow" runat="server" />
		                        <div class="form-group row">
		                            <label class="col-md-3 label-control" for="projectinput3">Link:</label>
		                            <div class="col-md-9">
                                        <asp:TextBox ID="txtEditLink" CssClass="form-control" placeholder="Video Link" runat="server"></asp:TextBox>
		                            </div>
		                        </div>	                       															
								 <div class="form-group row">
                                    <label class="col-md-3 label-control" for="projectinput2">Horizontal/Vertical:</label>
                                    <div class="col-md-9">
                                        <asp:DropDownList ID="ddleditA" CssClass="form-control" runat="server">
                                            <asp:ListItem Selected="True" Value="0">Select Iteam</asp:ListItem>
                                            <asp:ListItem Value="Horizontal">Horizontal</asp:ListItem>
                                            <asp:ListItem Value="Vertical">Vertical</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
								<div class="form-group row">
									<label class="col-md-3 label-control">Image: Horizontal(728x90) Vertical(300x250)</label>
									<div class="col-md-9">
                                        <asp:FileUpload ID="FileUpload2" runat="server" />
									</div>                                    
								</div>
							<asp:Button ID="btnImageUpdate"  runat="server" Text="Image Update" OnClick="btnImageUpdate_Click"  CssClass="btn btn-primary" />	
                               <asp:Button ID="btnDetailsUpdate"  runat="server" Text="Details Update" OnClick="btnDetailsUpdate_Click"  CssClass="btn btn-primary" />																		
							</div>
                            
                            														
	                        <div class="form-actions">	                           
                                <asp:Label ID="lblEditResult" runat="server"></asp:Label>	
	                        </div>
                    </div>
                    </asp:Panel>



						<div class="form form-horizontal">
	                    	<div class="form-body">
	                    		<h4 class="form-section"><i class="ft-user"></i> Show</h4>
								<hr>
                                <div class="form-group row">			    
                                    <div class="col-md-6">            		                        
                                <asp:GridView ID="GridView1" runat="server" Width="100%" AutoGenerateColumns="False" DataKeyNames="ID" DataSourceID="SqlDataSource1" CellPadding="4" ForeColor="#333333" GridLines="None" AllowPaging="True" AllowSorting="True">
                                    <AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
                                    <Columns>
                                        <asp:CommandField ShowDeleteButton="True"></asp:CommandField>
                                        <asp:BoundField DataField="Link" HeaderText="Link" SortExpression="Link"></asp:BoundField>
                                        <asp:BoundField DataField="HV" HeaderText="HV" SortExpression="HV"></asp:BoundField>
                                        <asp:TemplateField HeaderText="Image" SortExpression="Image">
                                            <EditItemTemplate>
                                                <asp:TextBox runat="server" Text='<%# Bind("Image") %>' ID="TextBox1"></asp:TextBox>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:Image ID="Image1" Width="100" Height="80" ImageUrl='<%# Bind("Image","../{0}") %>' runat="server" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="Click" HeaderText="Click" SortExpression="Click"></asp:BoundField>
                                        <asp:TemplateField HeaderText="Edit">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="LinkButton1" CssClass="btn btn-danger" runat="server" CommandArgument='<%# Eval("ID") %>' OnCommand="LinkButton1_Command">Edit</asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
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
                                <asp:SqlDataSource runat="server" ID="SqlDataSource1" ConnectionString='<%$ ConnectionStrings:Settings %>' DeleteCommand="DELETE FROM [Advertisement] WHERE [ID] = @ID" InsertCommand="INSERT INTO [Advertisement] ([Link], [HV], [Image], [Click]) VALUES (@Link, @HV, @Image, @Click)" SelectCommand="SELECT * FROM [Advertisement]" UpdateCommand="UPDATE [Advertisement] SET [Link] = @Link, [HV] = @HV, [Image] = @Image, [Click] = @Click WHERE [ID] = @ID">
                                    <DeleteParameters>
                                        <asp:Parameter Name="ID" Type="Int32"></asp:Parameter>
                                    </DeleteParameters>
                                    <InsertParameters>
                                        <asp:Parameter Name="Link" Type="String"></asp:Parameter>
                                        <asp:Parameter Name="HV" Type="String"></asp:Parameter>
                                        <asp:Parameter Name="Image" Type="String"></asp:Parameter>
                                        <asp:Parameter Name="Click" Type="Int32"></asp:Parameter>
                                    </InsertParameters>
                                    <UpdateParameters>
                                        <asp:Parameter Name="Link" Type="String"></asp:Parameter>
                                        <asp:Parameter Name="HV" Type="String"></asp:Parameter>
                                        <asp:Parameter Name="Image" Type="String"></asp:Parameter>
                                        <asp:Parameter Name="Click" Type="Int32"></asp:Parameter>
                                        <asp:Parameter Name="ID" Type="Int32"></asp:Parameter>
                                    </UpdateParameters>
                                </asp:SqlDataSource>
                                        </div>


                                 <div class="col-md-6">   
                                     <asp:GridView ID="GridView2" runat="server" Width="100%" AutoGenerateColumns="False" DataKeyNames="ID" DataSourceID="SqlDataSource2" CellPadding="4" ForeColor="#333333" GridLines="None" AllowPaging="True" AllowSorting="True">
                                    <AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
                                    <Columns>
                                        <asp:CommandField ShowEditButton="True" ShowDeleteButton="True"></asp:CommandField>
                                        <asp:BoundField DataField="ID" HeaderText="ID" ReadOnly="True" InsertVisible="False" SortExpression="ID"></asp:BoundField>
                                        
                                        <asp:TemplateField HeaderText="ADDLink" SortExpression="ADDLink">
                                            <EditItemTemplate>
                                          <%--      <asp:TextBox runat="server" Text='<%# Bind("ADDLink") %>' ID="TextBox1"></asp:TextBox>--%>
                                                 <asp:Label runat="server" Text='<%# Bind("ADDLink") %>' ID="Label1"></asp:Label>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <video src='<%# Eval("ADDLink","../{0}") %>' width="200" height="100" controls="controls" ></video>                                               
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="Sec" HeaderText="Sec" SortExpression="Sec"></asp:BoundField>

                                    </Columns>
                                    <EditRowStyle BackColor="#2461BF"></EditRowStyle>

                                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White"></FooterStyle>

                                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White"></HeaderStyle>

                                    <PagerStyle HorizontalAlign="Center" BackColor="#2461BF" ForeColor="White"></PagerStyle>

                                    <RowStyle BackColor="#EFF3FB"></RowStyle>

                                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333"></SelectedRowStyle>

                                    <SortedAscendingCellStyle BackColor="#F5F7FB"></SortedAscendingCellStyle>

                                    <SortedAscendingHeaderStyle BackColor="#6D95E1"></SortedAscendingHeaderStyle>

                                    <SortedDescendingCellStyle BackColor="#E9EBEF"></SortedDescendingCellStyle>

                                    <SortedDescendingHeaderStyle BackColor="#4870BE"></SortedDescendingHeaderStyle>
                                </asp:GridView>
                                     <asp:SqlDataSource runat="server" ID="SqlDataSource2" ConnectionString='<%$ ConnectionStrings:video %>' DeleteCommand="DELETE FROM [VideoADD] WHERE [ID] = @ID" InsertCommand="INSERT INTO [VideoADD] ([VideoID], [ADDLink], [ShowVideo], [Sec]) VALUES (@VideoID, @ADDLink, @ShowVideo, @Sec)" SelectCommand="SELECT * FROM [VideoADD]" UpdateCommand="UPDATE [VideoADD] SET [VideoID] = @VideoID, [ADDLink] = @ADDLink, [ShowVideo] = @ShowVideo, [Sec] = @Sec WHERE [ID] = @ID">
                                         <DeleteParameters>
                                             <asp:Parameter Name="ID" Type="Int32"></asp:Parameter>
                                         </DeleteParameters>
                                         <InsertParameters>
                                             <asp:Parameter Name="VideoID" Type="String"></asp:Parameter>
                                             <asp:Parameter Name="ADDLink" Type="String"></asp:Parameter>
                                             <asp:Parameter Name="ShowVideo" Type="Int32"></asp:Parameter>
                                             <asp:Parameter Name="Sec" Type="Int32"></asp:Parameter>
                                         </InsertParameters>
                                         <UpdateParameters>
                                             <asp:Parameter Name="VideoID" Type="String"></asp:Parameter>
                                             <asp:Parameter Name="ADDLink" Type="String"></asp:Parameter>
                                             <asp:Parameter Name="ShowVideo" Type="Int32"></asp:Parameter>
                                             <asp:Parameter Name="Sec" Type="Int32"></asp:Parameter>
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
    </div>
</asp:Content>
