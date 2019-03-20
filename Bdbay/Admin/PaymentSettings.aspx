<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/admin.Master" EnableEventValidation="false" AutoEventWireup="true" ValidateRequest="false" CodeBehind="PaymentSettings.aspx.cs" Inherits="Bdbay.Admin.PaymentSettings" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Body" runat="server">
        <div class="app-content content">
      <div class="content-wrapper">
        <div class="content-body"><!-- Stats -->
			<div class="card-content">
                <div class="card-body card">					
	                   
	                    	<div class="form-body">
	                    		<h4 class="form-section"><i class="ft-user"></i> Payment Settings <asp:Label ID="lblResult" Font-Bold="true" runat="server" ></asp:Label></h4> 
			                    <div class="form-group row">
	                            	<label class="col-md-1 label-control" for="projectinput1">Video</label>
		                            <div class="col-md-3">
                                        <asp:TextBox ID="txtVideoTarget1st" CssClass="form-control" placeholder="Your Video Terget Minimum" runat="server"></asp:TextBox>
		                            </div>
									<div class="col-md-3">
		                            	<asp:TextBox ID="txtVideoTarget2nd" CssClass="form-control"  placeholder="Your Video Terget Maximum" runat="server"></asp:TextBox>
		                            </div>
									<div class="col-md-3">
                                        <asp:TextBox ID="txtVideoTargetAmount" CssClass="form-control" placeholder="Amount(BDT)" runat="server"></asp:TextBox>
		                            </div>
                                    <div class="col-md-2">
                                        <asp:Button ID="btnVideo" OnClick="btnVideo_Click" CssClass="btn btn-success" runat="server" Text="Save" />
                                    </div>
		                        </div>
                                <asp:GridView ID="GridView1" Width="100%" runat="server" AutoGenerateColumns="False" DataKeyNames="ID" DataSourceID="SqlDataSource1" BackColor="White" BorderColor="#336666" BorderStyle="Double" BorderWidth="3px" CellPadding="4" GridLines="Horizontal" AllowPaging="True" AllowSorting="True">
                                    <Columns>
                                        <asp:CommandField ShowEditButton="True" ShowDeleteButton="True"></asp:CommandField>
                                        <asp:BoundField DataField="ID" HeaderText="ID" ReadOnly="True" InsertVisible="False" SortExpression="ID"></asp:BoundField>
                                        <asp:BoundField DataField="VoB" HeaderText="VoB" SortExpression="VoB"></asp:BoundField>
                                        <asp:BoundField DataField="FirstTarget" HeaderText="FirstTarget" SortExpression="FirstTarget"></asp:BoundField>
                                        <asp:BoundField DataField="LastTarget" HeaderText="LastTarget" SortExpression="LastTarget"></asp:BoundField>
                                        <asp:BoundField DataField="Amount" HeaderText="Amount" SortExpression="Amount"></asp:BoundField>
                                        <asp:BoundField DataField="DateTime" HeaderText="DateTime" SortExpression="DateTime"></asp:BoundField>
                                    </Columns>
                                    <FooterStyle BackColor="White" ForeColor="#333333"></FooterStyle>

                                    <HeaderStyle BackColor="#336666" Font-Bold="True" ForeColor="White"></HeaderStyle>

                                    <PagerStyle HorizontalAlign="Center" BackColor="#336666" ForeColor="White"></PagerStyle>

                                    <RowStyle BackColor="White" ForeColor="#333333"></RowStyle>

                                    <SelectedRowStyle BackColor="#339966" Font-Bold="True" ForeColor="White"></SelectedRowStyle>

                                    <SortedAscendingCellStyle BackColor="#F7F7F7"></SortedAscendingCellStyle>

                                    <SortedAscendingHeaderStyle BackColor="#487575"></SortedAscendingHeaderStyle>

                                    <SortedDescendingCellStyle BackColor="#E5E5E5"></SortedDescendingCellStyle>

                                    <SortedDescendingHeaderStyle BackColor="#275353"></SortedDescendingHeaderStyle>
                                </asp:GridView>


                                <asp:SqlDataSource runat="server" ID="SqlDataSource1" ConnectionString='<%$ ConnectionStrings:Settings %>' DeleteCommand="DELETE FROM [Auto_Payment_Settings] WHERE [ID] = @ID" InsertCommand="INSERT INTO [Auto_Payment_Settings] ([VoB], [FirstTarget], [LastTarget], [Amount], [DateTime]) VALUES (@VoB, @FirstTarget, @LastTarget, @Amount, @DateTime)" SelectCommand="SELECT * FROM [Auto_Payment_Settings] WHERE ([VoB] = @VoB)" UpdateCommand="UPDATE [Auto_Payment_Settings] SET [VoB] = @VoB, [FirstTarget] = @FirstTarget, [LastTarget] = @LastTarget, [Amount] = @Amount, [DateTime] = @DateTime WHERE [ID] = @ID">
                                    <DeleteParameters>
                                        <asp:Parameter Name="ID" Type="Int32"></asp:Parameter>
                                    </DeleteParameters>
                                    <InsertParameters>
                                        <asp:Parameter Name="VoB" Type="String"></asp:Parameter>
                                        <asp:Parameter Name="FirstTarget" Type="Int32"></asp:Parameter>
                                        <asp:Parameter Name="LastTarget" Type="Int32"></asp:Parameter>
                                        <asp:Parameter Name="Amount" Type="Double"></asp:Parameter>
                                        <asp:Parameter Name="DateTime" Type="String"></asp:Parameter>
                                    </InsertParameters>
                                    <SelectParameters>
                                        <asp:Parameter DefaultValue="VIDEO" Name="VoB" Type="String"></asp:Parameter>
                                    </SelectParameters>
                                    <UpdateParameters>
                                        <asp:Parameter Name="VoB" Type="String"></asp:Parameter>
                                        <asp:Parameter Name="FirstTarget" Type="Int32"></asp:Parameter>
                                        <asp:Parameter Name="LastTarget" Type="Int32"></asp:Parameter>
                                        <asp:Parameter Name="Amount" Type="Double"></asp:Parameter>
                                        <asp:Parameter Name="DateTime" Type="String"></asp:Parameter>
                                        <asp:Parameter Name="ID" Type="Int32"></asp:Parameter>
                                    </UpdateParameters>
                                </asp:SqlDataSource>


                                <br /><br />
                                <div class="form-group row">
	                            	<label class="col-md-1 label-control" for="projectinput1">Blog</label>
		                             <div class="col-md-3">
                                        <asp:TextBox ID="txtBlogTarget1st" CssClass="form-control" placeholder="Your Blog Terget Minimum" runat="server"></asp:TextBox>
		                            </div>
									<div class="col-md-3">
		                            	<asp:TextBox ID="txtBlogTarget2nd" CssClass="form-control" placeholder="Your Blog Terget Maximum" runat="server"></asp:TextBox>
		                            </div>
									<div class="col-md-3">
                                        <asp:TextBox ID="txtBlogTargetAmount" CssClass="form-control" placeholder="Amount(BDT)" runat="server"></asp:TextBox>
		                            </div>
                                     <div class="col-md-2">
                                        <asp:Button ID="btnBlog" CssClass="btn btn-success" OnClick="btnBlog_Click" runat="server" Text="Save" />
                                    </div>
		                        </div>	
							</div>


                    


                    <asp:GridView ID="GridView2" runat="server" Width="100%" AutoGenerateColumns="False" DataKeyNames="ID" DataSourceID="SqlDataSource2" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" AllowPaging="True" AllowSorting="True">
                        <Columns>
                            <asp:CommandField ShowEditButton="True" ShowDeleteButton="True"></asp:CommandField>
                            <asp:BoundField DataField="ID" HeaderText="ID" ReadOnly="True" InsertVisible="False" SortExpression="ID"></asp:BoundField>
                            <asp:BoundField DataField="VoB" HeaderText="VoB" SortExpression="VoB"></asp:BoundField>
                            <asp:BoundField DataField="FirstTarget" HeaderText="FirstTarget" SortExpression="FirstTarget"></asp:BoundField>
                            <asp:BoundField DataField="LastTarget" HeaderText="LastTarget" SortExpression="LastTarget"></asp:BoundField>
                            <asp:BoundField DataField="Amount" HeaderText="Amount" SortExpression="Amount"></asp:BoundField>
                            <asp:BoundField DataField="DateTime" HeaderText="DateTime" SortExpression="DateTime"></asp:BoundField>
                        </Columns>
                        <FooterStyle BackColor="White" ForeColor="#000066"></FooterStyle>

                        <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White"></HeaderStyle>

                        <PagerStyle HorizontalAlign="Left" BackColor="White" ForeColor="#000066"></PagerStyle>

                        <RowStyle ForeColor="#000066"></RowStyle>

                        <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White"></SelectedRowStyle>

                        <SortedAscendingCellStyle BackColor="#F1F1F1"></SortedAscendingCellStyle>

                        <SortedAscendingHeaderStyle BackColor="#007DBB"></SortedAscendingHeaderStyle>

                        <SortedDescendingCellStyle BackColor="#CAC9C9"></SortedDescendingCellStyle>

                        <SortedDescendingHeaderStyle BackColor="#00547E"></SortedDescendingHeaderStyle>
                    </asp:GridView>

                    <%--<form class="form form-horizontal">
	                    	<div class="form-body">
	                    		<h4 class="form-section"><i class="ft-user"></i> Withdraw Settings</h4>
			                    <div class="form-group row">
	                            	<label class="col-md-3 label-control" for="projectinput1">Step-1:</label>
		                            <div class="col-md-9">
		                            	<input type="text" id="projectinput1" class="form-control" placeholder="Valid NID" name="fname">
		                            </div>																		
		                        </div>
								<div class="form-group row">
	                            	<label class="col-md-3 label-control" for="projectinput1">Step-2:</label>
		                            
									<div class="col-md-9">
		                            	<input type="text" id="projectinput1" class="form-control" placeholder="No Copy/Paste" name="fname">
		                            </div>
		                        </div>
								<div class="form-group row">
	                            	<label class="col-md-3 label-control" for="projectinput1">Step-3:</label>
		                            <div class="col-md-9">
		                            	<input type="text" id="projectinput1" class="form-control" placeholder="Religious feelings can not be hurt" name="fname">
		                            </div>
									
		                        </div>	
								<div class="form-group row">
	                            	<label class="col-md-3 label-control" for="projectinput1">Step-4:</label>
		                            <div class="col-md-9">
		                            	<input type="text" id="projectinput1" class="form-control" placeholder="Trust Ours" name="fname">
		                            </div>
									
		                        </div>
								<div class="form-group row">
	                            	<label class="col-md-3 label-control" for="projectinput1">Step-5:</label>
		                            									
									<div class="col-md-9">
		                            	<input type="text" id="projectinput1" class="form-control" placeholder="Get Payment After 5000 View Completed" name="fname">
		                            </div>
		                        </div>									
								
							</div>									
	                        <div class="form-actions">
	                            <button type="button" class="btn btn-warning mr-1">
	                            	<i class="ft-x"></i> Cancel
	                            </button>
	                            <button type="submit" class="btn btn-primary">
	                                <i class="fa fa-check-square-o"></i> Save
	                            </button>
	                        </div>
	                    </form>--%>

                    <asp:SqlDataSource runat="server" ID="SqlDataSource2" ConnectionString='<%$ ConnectionStrings:Settings %>' DeleteCommand="DELETE FROM [Auto_Payment_Settings] WHERE [ID] = @ID" InsertCommand="INSERT INTO [Auto_Payment_Settings] ([VoB], [FirstTarget], [LastTarget], [Amount], [DateTime]) VALUES (@VoB, @FirstTarget, @LastTarget, @Amount, @DateTime)" SelectCommand="SELECT * FROM [Auto_Payment_Settings] WHERE ([VoB] = @VoB)" UpdateCommand="UPDATE [Auto_Payment_Settings] SET [VoB] = @VoB, [FirstTarget] = @FirstTarget, [LastTarget] = @LastTarget, [Amount] = @Amount, [DateTime] = @DateTime WHERE [ID] = @ID">
                        <DeleteParameters>
                            <asp:Parameter Name="ID" Type="Int32"></asp:Parameter>
                        </DeleteParameters>
                        <InsertParameters>
                            <asp:Parameter Name="VoB" Type="String"></asp:Parameter>
                            <asp:Parameter Name="FirstTarget" Type="Int32"></asp:Parameter>
                            <asp:Parameter Name="LastTarget" Type="Int32"></asp:Parameter>
                            <asp:Parameter Name="Amount" Type="Double"></asp:Parameter>
                            <asp:Parameter Name="DateTime" Type="String"></asp:Parameter>
                        </InsertParameters>
                        <SelectParameters>
                            <asp:Parameter DefaultValue="BLOG" Name="VoB" Type="String"></asp:Parameter>
                        </SelectParameters>
                        <UpdateParameters>
                            <asp:Parameter Name="VoB" Type="String"></asp:Parameter>
                            <asp:Parameter Name="FirstTarget" Type="Int32"></asp:Parameter>
                            <asp:Parameter Name="LastTarget" Type="Int32"></asp:Parameter>
                            <asp:Parameter Name="Amount" Type="Double"></asp:Parameter>
                            <asp:Parameter Name="DateTime" Type="String"></asp:Parameter>
                            <asp:Parameter Name="ID" Type="Int32"></asp:Parameter>
                        </UpdateParameters>
                    </asp:SqlDataSource>


                    
                </div> 

            </div>
        </div>
      </div>
    </div>
</asp:Content>
