<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/admin.Master" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="AdminorStaff.aspx.cs" Inherits="Bdbay.Admin.AdminorStaff" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Body" runat="server">
    
    <div class="app-content content">
      <div class="content-wrapper">
        <div class="content-body"><!-- Stats -->
			<div class="card-content">
                <div class="card-body card">
						
	                    <div class="form form-horizontal">
	                    	<div class="form-body">
	                    		<h4 class="form-section"><i class="ft-user"></i> Admin</h4>
                                <asp:Image ID="Image1" Width="100" Height="80" runat="server" />
			                    <div class="form-group row">
	                            	<label class="col-md-3 label-control">Full Name:</label>
		                            <div class="col-md-9">
                                        <asp:TextBox ID="txtFullname" CssClass="form-control" placeholder="Full Name" runat="server"></asp:TextBox>
		                            </div>
		                        </div>
                                <div class="form-group row">
		                            <label class="col-md-3 label-control" >Gender:</label>
		                            <div class="col-md-9">
		                            	   <asp:DropDownList ID="ddlGender" CssClass="form-control" runat="server">
                                                <asp:ListItem Value="0">Select Iteam</asp:ListItem>
                                            <asp:ListItem Value="Male">Male</asp:ListItem>
                                            <asp:ListItem Value="Female" >Female</asp:ListItem>
                                        </asp:DropDownList>
		                            </div>
		                        </div>
		                        <div class="form-group row">
	                            	<label class="col-md-3 label-control" >Address:</label>
									<div class="col-md-9">
                                        <asp:TextBox ID="txtAddress" CssClass="form-control" placeholder="Address" runat="server"></asp:TextBox>
	                            	</div>
		                        </div>

		                        <div class="form-group row">
		                            <label class="col-md-3 label-control" >NID:</label>
		                            <div class="col-md-9">
		                            	<asp:TextBox ID="txtNid" CssClass="form-control" placeholder="NID" runat="server"></asp:TextBox>
		                            </div>
		                        </div>

		                        <div class="form-group row">
		                            <label class="col-md-3 label-control" >Mobile Number:</label>
		                            <div class="col-md-9">
		                            	<asp:TextBox ID="txtMobile" CssClass="form-control" placeholder="Mobile Number" runat="server"></asp:TextBox>
		                            </div>
		                        </div>
								
								<div class="form-group row">
		                            <label class="col-md-3 label-control" >Email:</label>
		                            <div class="col-md-9">
		                            	<asp:TextBox ID="txtEmail" CssClass="form-control" TextMode="Email" placeholder="Email" runat="server"></asp:TextBox>
		                            </div>
		                        </div>

								<div class="form-group row">
		                            <label class="col-md-3 label-control" >UserName:</label>
		                            <div class="col-md-9">
		                            	<asp:TextBox ID="txtUserName" CssClass="form-control" placeholder="Username" runat="server"></asp:TextBox>
		                            </div>
		                        </div>

                                <div class="form-group row">
		                            <label class="col-md-3 label-control" >Password:</label>
		                            <div class="col-md-9">
		                            	<asp:TextBox ID="txtPassword" CssClass="form-control" TextMode="Password" placeholder="Password" runat="server"></asp:TextBox>
		                            </div>
		                        </div>

								<div class="form-group row">
									<label class="col-md-3 label-control">Image:</label>
									<div class="col-md-9">
                                        <asp:FileUpload ID="imageUpload" runat="server" />
									</div>
								</div>
								
								<div class="form-group row">
		                        	<label class="col-md-3 label-control" for="projectinput6">Authority:</label>
		                        	<div class="col-md-9">
                                        <asp:DropDownList ID="ddlAuthority" CssClass="form-control" runat="server">
                                            <asp:ListItem Value="TRUE" Selected="True">Enable</asp:ListItem>
                                            <asp:ListItem Value="FALSE" >Disable</asp:ListItem>
                                        </asp:DropDownList>
		                            </div>
		                        </div>
								
								<div class="form-group row">
		                        	<label class="col-md-3 label-control" for="projectinput6">ID Type:</label>
		                        	<div class="col-md-9">
			                             <asp:DropDownList ID="ddlType" CssClass="form-control" runat="server">
                                            <asp:ListItem Value="Admin" Selected="True">Admin</asp:ListItem>
                                            <asp:ListItem Value="Staff" >Staff</asp:ListItem>
                                        </asp:DropDownList>
		                            </div>
		                        </div>
								
								<div class="form-group row">
									<label class="col-md-3 label-control" for="projectinput9">Details Admin or Staff</label>
									<div class="col-md-9">
                                        <asp:TextBox ID="txtDetails" CssClass="form-control" placeholder="Details in Admin or Staff..." TextMode="MultiLine" Rows="5" Columns="5" runat="server"></asp:TextBox>
									</div>
								</div>
							</div>
							
							<h4 class="form-section"><i class="ft-user"></i> Authorize Page</h4>

                             <div class="form-group row">
	                        		<label class="col-md-3">
                                        <asp:CheckBox ID="chkEdit" OnCheckedChanged="chkEdit_CheckedChanged" AutoPostBack="true" Text="Update New Authoris Page" runat="server" />

	                        		</label>
	                        		<div class="col-md-9">
										<div class="input-group">
                                            <asp:GridView ID="GridView1" Width="100%" PageSize="16" runat="server" AutoGenerateColumns="False" DataKeyNames="ID" DataSourceID="SqlDataSource1" AllowPaging="True" AllowSorting="True" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Vertical">
                                                <AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
                                                <Columns>
                                                    <asp:TemplateField ShowHeader="False">
                                                        <EditItemTemplate>
                                                            <asp:LinkButton runat="server" CssClass="btn btn-success" Text="Update" CommandName="Update" CausesValidation="True" ID="LinkButton1"></asp:LinkButton>&nbsp;<asp:LinkButton runat="server" Text="Cancel" CssClass="btn btn-danger" CommandName="Cancel" CausesValidation="False" ID="LinkButton2"></asp:LinkButton>
                                                        </EditItemTemplate>
                                                        <ItemTemplate>
                                                            <asp:LinkButton runat="server" Text="Edit" CssClass="btn btn-info" CommandName="Edit" CausesValidation="False" ID="LinkButton1"></asp:LinkButton>&nbsp;<asp:LinkButton runat="server" Text="Delete" CssClass="btn btn-danger" CommandName="Delete" CausesValidation="False" ID="LinkButton2"></asp:LinkButton>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:BoundField DataField="ID" HeaderText="ID" ReadOnly="True" InsertVisible="False" SortExpression="ID"></asp:BoundField>
                                                    <asp:BoundField DataField="UserID" HeaderText="UserID" SortExpression="UserID"></asp:BoundField>
                                                    <asp:BoundField DataField="PageName" HeaderText="PageName" SortExpression="PageName"></asp:BoundField>
                                                </Columns>
                                                <FooterStyle BackColor="#CCCC99"></FooterStyle>

                                                <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White"></HeaderStyle>

                                                <PagerStyle HorizontalAlign="Right" BackColor="#F7F7DE" ForeColor="Black"></PagerStyle>

                                                <RowStyle BackColor="#F7F7DE"></RowStyle>

                                                <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White"></SelectedRowStyle>

                                                <SortedAscendingCellStyle BackColor="#FBFBF2"></SortedAscendingCellStyle>

                                                <SortedAscendingHeaderStyle BackColor="#848384"></SortedAscendingHeaderStyle>

                                                <SortedDescendingCellStyle BackColor="#EAEAD3"></SortedDescendingCellStyle>

                                                <SortedDescendingHeaderStyle BackColor="#575357"></SortedDescendingHeaderStyle>
                                            </asp:GridView>									
										</div>
									</div>
		                    </div>

                            <asp:Panel ID="pnlAuthorise" runat="server">
                            <div class="form-group row">
	                        		<label class="col-md-3 label-control">Check</label>
	                        		<div class="col-md-9">
										<div class="input-group">
											<div class="d-inline-block custom-control custom-radio mr-1">
                                                <asp:RadioButton ID="Allyes" AutoPostBack="true" OnCheckedChanged="Allyes_CheckedChanged" Text="All Yes" GroupName="aa" runat="server" />
											</div>
											<div class="d-inline-block custom-control custom-radio">
												<asp:RadioButton ID="AllNo" AutoPostBack="true" OnCheckedChanged="AllNo_CheckedChanged" Text="All No" GroupName="aa" runat="server" />
											</div>
										</div>
									</div>
		                    </div>

							<div class="form-group row">
	                        		<label class="col-md-3 label-control">1. Dashboard</label>
	                        		<div class="col-md-9">
										<div class="input-group">
											<div class="d-inline-block custom-control custom-radio mr-1">
                                                <asp:RadioButton ID="RBDashboardYes" Text="Yes" GroupName="a" runat="server" />
											</div>
											<div class="d-inline-block custom-control custom-radio">
												<asp:RadioButton ID="RBDashboardNO" Text="No" GroupName="a" runat="server" />
											</div>
										</div>
									</div>
		                    </div>
							
							<div class="form-group row">
	                        		<label class="col-md-3 label-control">2. Home Page</label>
	                        		<div class="col-md-9">
										<div class="input-group">
											<div class="d-inline-block custom-control custom-radio mr-1">
                                                <asp:RadioButton ID="RBHomePageYes" Text="Yes" GroupName="b" runat="server" />
											</div>
											<div class="d-inline-block custom-control custom-radio">
												<asp:RadioButton ID="RBHomePageNO" Text="No" GroupName="b" runat="server" />
											</div>
										</div>
									</div>
		                    </div>
							
							<div class="form-group row">
	                        		<label class="col-md-3 label-control">3. Upload Video</label>
	                        		<div class="col-md-9">
										<div class="input-group">
											<div class="d-inline-block custom-control custom-radio mr-1">
                                                <asp:RadioButton ID="RBUploadYes" Text="Yes" GroupName="c" runat="server" />
											</div>
											<div class="d-inline-block custom-control custom-radio">
												<asp:RadioButton ID="RBUploadNo" Text="No" GroupName="c" runat="server" />
											</div>
										</div>
									</div>
		                    </div>
							
							<div class="form-group row">
	                        		<label class="col-md-3 label-control">4. Write Blog</label>
	                        		<div class="col-md-9">
										<div class="input-group">
											<div class="d-inline-block custom-control custom-radio mr-1">
                                                <asp:RadioButton ID="RBWriteBlogYes" Text="Yes" GroupName="d" runat="server" />
											</div>
											<div class="d-inline-block custom-control custom-radio">
												<asp:RadioButton ID="RBWriteBlogNo" Text="No" GroupName="d" runat="server" />
											</div>
										</div>
									</div>
		                    </div>
							
							<div class="form-group row">
	                        		<label class="col-md-3 label-control">5. Show Video</label>
	                        		<div class="col-md-9">
										<div class="input-group">
											<div class="d-inline-block custom-control custom-radio mr-1">
                                                <asp:RadioButton ID="RBShowVideoYes" Text="Yes" GroupName="e" runat="server" />
											</div>
											<div class="d-inline-block custom-control custom-radio">
												<asp:RadioButton ID="RBShowVideoNo" Text="No" GroupName="e" runat="server" />
											</div>
										</div>
									</div>
		                    </div>
							
							<div class="form-group row">
	                        		<label class="col-md-3 label-control">6. Show Blog</label>
	                        		<div class="col-md-9">
										<div class="input-group">
											<div class="d-inline-block custom-control custom-radio mr-1">
                                                <asp:RadioButton ID="RBShowBlogYes" Text="Yes" GroupName="f" runat="server" />
											</div>
											<div class="d-inline-block custom-control custom-radio">
												<asp:RadioButton ID="RBShowBlogNo" Text="No" GroupName="f" runat="server" />
											</div>
										</div>
									</div>
		                    </div>
							
							<div class="form-group row">
	                        		<label class="col-md-3 label-control">7. Authorize Video</label>
	                        		<div class="col-md-9">
										<div class="input-group">
											<div class="d-inline-block custom-control custom-radio mr-1">
                                                <asp:RadioButton ID="RBAuthorizeVideoYes" Text="Yes" GroupName="g" runat="server" />
											</div>
											<div class="d-inline-block custom-control custom-radio">
												<asp:RadioButton ID="RBAuthorizeVideoNo" Text="No" GroupName="g" runat="server" />
											</div>
										</div>
									</div>
		                    </div>
							
							<div class="form-group row">
	                        		<label class="col-md-3 label-control">8. Authorize Blog</label>
	                        		<div class="col-md-9">
										<div class="input-group">
											<div class="d-inline-block custom-control custom-radio mr-1">
                                                <asp:RadioButton ID="RBAuthorizeBlogYes" Text="Yes" GroupName="h" runat="server" />
											</div>
											<div class="d-inline-block custom-control custom-radio">
												<asp:RadioButton ID="RBAuthorizeBlogNo" Text="No" GroupName="h" runat="server" />
											</div>
										</div>
									</div>
		                    </div>
							
							<div class="form-group row">
	                        		<label class="col-md-3 label-control">9. Non Authorize Video</label>
	                        		<div class="col-md-9">
										<div class="input-group">
											<div class="d-inline-block custom-control custom-radio mr-1">
                                                <asp:RadioButton ID="RBNonAuthorizeVideoYes" Text="Yes" GroupName="i" runat="server" />
											</div>
											<div class="d-inline-block custom-control custom-radio">
												<asp:RadioButton ID="RBNonAuthorizeVideoNo" Text="No" GroupName="i" runat="server" />
											</div>
										</div>
									</div>
		                    </div>
							
							<div class="form-group row">
	                        		<label class="col-md-3 label-control">10. Non Authorize Blog</label>
	                        		<div class="col-md-9">
										<div class="input-group">
											<div class="d-inline-block custom-control custom-radio mr-1">
                                                <asp:RadioButton ID="RBNonAuthorizeBlogYes" Text="Yes" GroupName="j" runat="server" />
											</div>
											<div class="d-inline-block custom-control custom-radio">
												<asp:RadioButton ID="RBNonAuthorizeBlogNo" Text="No" GroupName="j" runat="server" />
											</div>
										</div>
									</div>
		                    </div>
							
							<div class="form-group row">
	                        		<label class="col-md-3 label-control">11. Payment Settings</label>
	                        		<div class="col-md-9">
										<div class="input-group">
											<div class="d-inline-block custom-control custom-radio mr-1">
                                                <asp:RadioButton ID="RBPaymentSettingsYes" Text="Yes" GroupName="k" runat="server" />
											</div>
											<div class="d-inline-block custom-control custom-radio">
												<asp:RadioButton ID="RBPaymentSettingsNo" Text="No" GroupName="k" runat="server" />
											</div>
										</div>
									</div>
		                    </div>
							
							<div class="form-group row">
	                        		<label class="col-md-3 label-control">12. Video Settings</label>
	                        		<div class="col-md-9">
										<div class="input-group">
											<div class="d-inline-block custom-control custom-radio mr-1">
                                                <asp:RadioButton ID="RBVideoSettingsYes" Text="Yes" GroupName="l" runat="server" />
											</div>
											<div class="d-inline-block custom-control custom-radio">
												<asp:RadioButton ID="RBVideoSettingsNo" Text="No" GroupName="l" runat="server" />
											</div>
										</div>
									</div>
		                    </div>
							
							<div class="form-group row">
	                        		<label class="col-md-3 label-control">13. Blog Settings</label>
	                        		<div class="col-md-9">
										<div class="input-group">
											<div class="d-inline-block custom-control custom-radio mr-1">
                                                <asp:RadioButton ID="RBBlogSettingsYes" Text="Yes" GroupName="m" runat="server" />
											</div>
											<div class="d-inline-block custom-control custom-radio">
												<asp:RadioButton ID="RBBlogSettingsNo" Text="No" GroupName="m" runat="server" />
											</div>
										</div>
									</div>
		                    </div>
							
							<div class="form-group row">
	                        		<label class="col-md-3 label-control">14. Create Admin/Staff</label>
	                        		<div class="col-md-9">
										<div class="input-group">
											<div class="d-inline-block custom-control custom-radio mr-1">
                                                <asp:RadioButton ID="RBCreateAdminstaffYes" Text="Yes" GroupName="n" runat="server" />
											</div>
											<div class="d-inline-block custom-control custom-radio">
												<asp:RadioButton ID="RBCreateAdminstaffNo" Text="No" GroupName="n" runat="server" />
											</div>
										</div>
									</div>
		                    </div>
							
							<div class="form-group row">
	                        		<label class="col-md-3 label-control">15. Show Admin/Staff</label>
	                        		<div class="col-md-9">
										<div class="input-group">
											<div class="d-inline-block custom-control custom-radio mr-1">
                                                <asp:RadioButton ID="RBShowAdminStaffYes" Text="Yes" GroupName="o" runat="server" />
											</div>
											<div class="d-inline-block custom-control custom-radio">
												<asp:RadioButton ID="RBShowAdminStaffNo" Text="No" GroupName="o" runat="server" />
											</div>
										</div>
									</div>
		                    </div>

							<div class="form-group row">
	                        		<label class="col-md-3 label-control">16. Show User</label>
	                        		<div class="col-md-9">
										<div class="input-group">
											<div class="d-inline-block custom-control custom-radio mr-1">
                                                <asp:RadioButton ID="RBShowUserYes" Text="Yes" GroupName="pp" runat="server" />
											</div>
											<div class="d-inline-block custom-control custom-radio">
												<asp:RadioButton ID="RBShowUserNO" Text="No" GroupName="pp" runat="server" />
											</div>
										</div>
									</div>
		                    </div>

                                <div class="form-group row">
                                    <label class="col-md-3 label-control">17. Panding Video</label>
                                    <div class="col-md-9">
                                        <div class="input-group">
                                            <div class="d-inline-block custom-control custom-radio mr-1">
                                                <asp:RadioButton ID="RBPandingVideoYes" Text="Yes" GroupName="pan" runat="server" />
                                            </div>
                                            <div class="d-inline-block custom-control custom-radio">
                                                <asp:RadioButton ID="RBPandingVideoNO" Text="No" GroupName="pan" runat="server" />
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="form-group row">
                                    <label class="col-md-3 label-control">18. Panding Blog</label>
                                    <div class="col-md-9">
                                        <div class="input-group">
                                            <div class="d-inline-block custom-control custom-radio mr-1">
                                                <asp:RadioButton ID="RBPandingBlogYes" Text="Yes" GroupName="panb" runat="server" />
                                            </div>
                                            <div class="d-inline-block custom-control custom-radio">
                                                <asp:RadioButton ID="RBPandingBlogNo" Text="No" GroupName="panb" runat="server" />
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="form-group row">
                                    <label class="col-md-3 label-control">19. Advertisement</label>
                                    <div class="col-md-9">
                                        <div class="input-group">
                                            <div class="d-inline-block custom-control custom-radio mr-1">
                                                <asp:RadioButton ID="RBAdvertisementON" Text="Yes" GroupName="addo" runat="server" />
                                            </div>
                                            <div class="d-inline-block custom-control custom-radio">
                                                <asp:RadioButton ID="RBAdvertisementOFF" Text="No" GroupName="addo" runat="server" />
                                            </div>
                                        </div>
                                    </div>
                                </div>


                            </asp:Panel>

                            <asp:SqlDataSource runat="server" ID="SqlDataSource1" ConnectionString='<%$ ConnectionStrings:Admin %>' DeleteCommand="DELETE FROM [AuthorisePage] WHERE [ID] = @ID" InsertCommand="INSERT INTO [AuthorisePage] ([UserID], [PageName], [PageLink]) VALUES (@UserID, @PageName, @PageLink)" SelectCommand="SELECT * FROM [AuthorisePage] WHERE ([UserID] = @UserID)" UpdateCommand="UPDATE [AuthorisePage] SET [UserID] = @UserID, [PageName] = @PageName, [PageLink] = @PageLink WHERE [ID] = @ID">
                                <DeleteParameters>
                                    <asp:Parameter Name="ID" Type="Int32"></asp:Parameter>
                                </DeleteParameters>
                                <InsertParameters>
                                    <asp:Parameter Name="UserID" Type="String"></asp:Parameter>
                                    <asp:Parameter Name="PageName" Type="String"></asp:Parameter>
                                    <asp:Parameter Name="PageLink" Type="String"></asp:Parameter>
                                </InsertParameters>
                                <SelectParameters>
                                    <asp:QueryStringParameter QueryStringField="UserID" Name="UserID" Type="String"></asp:QueryStringParameter>
                                </SelectParameters>
                                <UpdateParameters>
                                    <asp:Parameter Name="UserID" Type="String"></asp:Parameter>
                                    <asp:Parameter Name="PageName" Type="String"></asp:Parameter>
                                    <asp:Parameter Name="PageLink" Type="String"></asp:Parameter>
                                    <asp:Parameter Name="ID" Type="Int32"></asp:Parameter>
                                </UpdateParameters>
                            </asp:SqlDataSource>
                            <div class="form-actions">
                                <asp:LinkButton ID="btnUpdate" OnClick="btnUpdate_Click" CssClass="btn btn-warning mr-1" runat="server"><i class="ft-check"></i> Update</asp:LinkButton>
                                <asp:LinkButton ID="btnSave" CssClass="btn btn-primary" OnClick="Button1_Click" runat="server"><i class="fa fa-check-square-o"></i> Save</asp:LinkButton>
                                <asp:Label ID="lblResult" runat="server" ></asp:Label>
	                        </div>
	                    </div>
	                </div> 
            </div>
        </div>
      </div>
    </div>



</asp:Content>
