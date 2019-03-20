<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/admin.Master" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="HomePageAdd.aspx.cs" Inherits="Bdbay.Admin.HomePageAdd" %>
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
	                    		<h4 class="form-section"><i class="ft-user"></i> Admin</h4>
								<hr>
			                    <div class="form-group row">
	                            	<label class="col-md-3 label-control" for="projectinput1">Tittle:</label>
		                            <div class="col-md-9">
                                        <asp:TextBox ID="txttitle" CssClass="form-control" placeholder="Video Tittle" runat="server"></asp:TextBox>
		                            </div>
		                        </div>
		                        <div class="form-group row">
	                            	<label class="col-md-3 label-control" for="projectinput2">Sub Tittle:</label>
									<div class="col-md-9">
                                        <asp:TextBox ID="txtsubtxtle" CssClass="form-control" placeholder="Sub Tittle" runat="server"></asp:TextBox>
	                            	</div>
		                        </div>

		                        <div class="form-group row">
		                            <label class="col-md-3 label-control" for="projectinput3">Link:</label>
		                            <div class="col-md-9">
                                        <asp:TextBox ID="txtlink" CssClass="form-control" placeholder="Video Link" runat="server"></asp:TextBox>
		                            </div>
		                        </div>
		                        															
								
								<div class="form-group row">
									<label class="col-md-3 label-control">Image:(400x300)</label>
									<div class="col-md-9">
                                        <asp:FileUpload ID="FileUpload1" runat="server" />
									</div>
								</div>
<div class="form-actions">	                           
                                <asp:Button ID="btnsave" runat="server" Text="Save" OnClick="btnsave_Click" CssClass="btn btn-primary" />
	                        </div>
																													
							</div>							
                            <asp:Label ID="lblResult" runat="server"></asp:Label>	                            														
	                        
														
	                    </div>
                    </asp:Panel>			
                    <div class="form form-horizontal">
                        <div class="form-group row">
                            <label class="col-md-3 label-control">Logo:(119x29)</label>
                            <div class="col-md-9">
                                <asp:FileUpload ID="logoupload" runat="server" />
                                <asp:Button ID="btnSaves" OnClick="btnSave_Click1" runat="server" Text="Save" />
                            </div>
                        </div>

                    </div>
                    
                    <br><br>
                    <asp:Panel ID="pnlEditAdd" runat="server">
                    <div class="form form-horizontal">
                       	<div class="form-body">
	                    		<h4 class="form-section"><i class="ft-user"></i> Edit Option</h4>
								<hr>
                               <asp:Image ID="EditImageShow" Width="200" Height="150" runat="server" />
			                    <div class="form-group row">
	                            	<label class="col-md-3 label-control" for="projectinput1">Tittle:</label>
		                            <div class="col-md-9">
                                        <asp:TextBox ID="txtEditTitle" CssClass="form-control" placeholder="Video Tittle" runat="server"></asp:TextBox>
		                            </div>
		                        </div>
		                        <div class="form-group row">
	                            	<label class="col-md-3 label-control" for="projectinput2">Sub Tittle:</label>
									<div class="col-md-9">
                                        <asp:TextBox ID="txtEditSubtitle" CssClass="form-control" placeholder="Sub Tittle" runat="server"></asp:TextBox>
	                            	</div>
		                        </div>

		                        <div class="form-group row">
		                            <label class="col-md-3 label-control" for="projectinput3">Link:</label>
		                            <div class="col-md-9">
                                        <asp:TextBox ID="txtEditVideoLink" CssClass="form-control" placeholder="Video Link" runat="server"></asp:TextBox>
		                            </div>
		                        </div>	                        															
								
								<div class="form-group row">
									<label class="col-md-3 label-control">Image: (400x300)</label>
									<div class="col-md-9">
                                        <asp:FileUpload ID="FileUpload2" runat="server" />
									</div>                                    
								</div>
							<asp:Button ID="btnImageUpdate" OnClick="btnImageUpdate_Click" runat="server" Text="Image Update"  CssClass="btn btn-primary" />	
                               <asp:Button ID="btnDetailsUpdate" OnClick="btnDetailsUpdate_Click" runat="server" Text="Details Update"  CssClass="btn btn-primary" />	
                              <asp:Button ID="btnClear" OnClick="btnClear_Click" runat="server" Text="Clear"  CssClass="btn btn-primary" />																		
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
                                <asp:GridView ID="GridView1" Width="100%" runat="server" AutoGenerateColumns="False" DataKeyNames="ID" DataSourceID="SqlDataSource1" CellPadding="4" ForeColor="#333333" GridLines="None" AllowPaging="True" AllowSorting="True">
                                    <AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
                                    <Columns>
                                        <asp:CommandField ShowDeleteButton="True"></asp:CommandField>
                                        <asp:BoundField DataField="ID" HeaderText="ID" ReadOnly="True" InsertVisible="False" SortExpression="ID"></asp:BoundField>
                                        <asp:BoundField DataField="Title" HeaderText="Title" SortExpression="Title"></asp:BoundField>
                                        <asp:BoundField DataField="Subtitle" HeaderText="Subtitle" SortExpression="Subtitle"></asp:BoundField>
                                        <asp:BoundField DataField="Link" HeaderText="Link" SortExpression="Link"></asp:BoundField>
                                        <asp:TemplateField HeaderText="Image" SortExpression="Image">
                                            <EditItemTemplate>
                                                <asp:TextBox runat="server" Text='<%# Bind("Image") %>' ID="TextBox1"></asp:TextBox>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:Image ID="Image1" Width="100" Height="100" ImageUrl='<%# Eval("Image","../{0}") %>' runat="server" />
                                            </ItemTemplate>
                                        </asp:TemplateField>

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


                                <asp:SqlDataSource runat="server" ID="SqlDataSource1" ConnectionString='<%$ ConnectionStrings:Settings %>' DeleteCommand="DELETE FROM [HomePageEdit] WHERE [ID] = @ID" InsertCommand="INSERT INTO [HomePageEdit] ([Title], [Subtitle], [Link], [Image]) VALUES (@Title, @Subtitle, @Link, @Image)" SelectCommand="SELECT * FROM [HomePageEdit]" UpdateCommand="UPDATE [HomePageEdit] SET [Title] = @Title, [Subtitle] = @Subtitle, [Link] = @Link, [Image] = @Image WHERE [ID] = @ID">
                                    <DeleteParameters>
                                        <asp:Parameter Name="ID" Type="Int32"></asp:Parameter>
                                    </DeleteParameters>
                                    <InsertParameters>
                                        <asp:Parameter Name="Title" Type="String"></asp:Parameter>
                                        <asp:Parameter Name="Subtitle" Type="String"></asp:Parameter>
                                        <asp:Parameter Name="Link" Type="String"></asp:Parameter>
                                        <asp:Parameter Name="Image" Type="String"></asp:Parameter>
                                    </InsertParameters>
                                    <UpdateParameters>
                                        <asp:Parameter Name="Title" Type="String"></asp:Parameter>
                                        <asp:Parameter Name="Subtitle" Type="String"></asp:Parameter>
                                        <asp:Parameter Name="Link" Type="String"></asp:Parameter>
                                        <asp:Parameter Name="Image" Type="String"></asp:Parameter>
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
