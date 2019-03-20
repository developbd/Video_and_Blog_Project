<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/admin.Master" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="pay.aspx.cs" Inherits="Bdbay.Admin.pay" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Body" runat="server">
     <div class="app-content content">
      <div class="content-wrapper">
        <div class="content-body"><!-- Stats -->
			<div class="card-content">
                <div class="card-body card">					
                    <asp:Button ID="Button1" OnClick="Button1_Click" runat="server" Text="Go Back" />
	                    	<div class="form-body">
	                    		<h4 class="form-section"><i class="ft-user"></i> Payment Settings</h4>
			                    <div class="form-group row">
	                            	<label class="col-md-2 label-control" for="projectinput1">Payment BDT:</label>
		                            <div class="col-md-3">
                                        <asp:TextBox ID="txtBDT" CssClass="form-control" placeholder="BDT" runat="server"></asp:TextBox>
		                            </div>
									
		                        </div>	
                                <div class="form-group row">
	                            	<label class="col-md-2 label-control" for="projectinput1">Details:</label>
		                            <div class="col-md-3">
		                            	   <asp:TextBox ID="txtDeatils" CssClass="form-control" placeholder="Details " TextMode="MultiLine" runat="server"></asp:TextBox>
		                            </div>
									
		                        </div>				
		                        </div>							
							</div>						
                <asp:Label ID="lblResult" runat="server" ></asp:Label>			
	                        <div class="form-actions">	                           
                                <asp:Button ID="btnSave" CssClass="btn btn-primary" OnClick="btnSave_Click" runat="server" Text="Save" />	                         
	                        </div>
	          
					
	                </div>

            <asp:GridView ID="GridView1" runat="server" Width="100%" AutoGenerateColumns="False" DataKeyNames="ID" DataSourceID="SqlDataSource1" CellPadding="4" ForeColor="#333333" GridLines="None" AllowPaging="True" AllowSorting="True">
                <AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
                <Columns>
                    <asp:CommandField ShowEditButton="True" ShowDeleteButton="True"></asp:CommandField>
                    <asp:BoundField DataField="ID" HeaderText="ID" ReadOnly="True" InsertVisible="False" SortExpression="ID"></asp:BoundField>
                    <asp:BoundField DataField="BDT" HeaderText="BDT" SortExpression="BDT"></asp:BoundField>
                    <asp:BoundField DataField="PaymentID" HeaderText="PaymentID" SortExpression="PaymentID"></asp:BoundField>
                    <asp:BoundField DataField="VoB" HeaderText="VoB" SortExpression="VoB"></asp:BoundField>
                    <asp:BoundField DataField="Details" HeaderText="Details" SortExpression="Details"></asp:BoundField>
                    <asp:BoundField DataField="PostingDate" HeaderText="PostingDate" SortExpression="PostingDate"></asp:BoundField>
                    <asp:BoundField DataField="DateTime" HeaderText="DateTime" SortExpression="DateTime"></asp:BoundField>
                    <asp:BoundField DataField="Date" HeaderText="Date" SortExpression="Date"></asp:BoundField>
                    <asp:BoundField DataField="Time" HeaderText="Time" SortExpression="Time"></asp:BoundField>
                    <asp:BoundField DataField="Year" HeaderText="Year" SortExpression="Year"></asp:BoundField>
                    <asp:BoundField DataField="UserID" HeaderText="UserID" SortExpression="UserID"></asp:BoundField>
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
            <asp:SqlDataSource runat="server" ID="SqlDataSource1" ConnectionString='<%$ ConnectionStrings:Settings %>' DeleteCommand="DELETE FROM [Payment] WHERE [ID] = @ID" InsertCommand="INSERT INTO [Payment] ([BDT], [PaymentID], [VoB], [Details], [PostingDate], [DateTime], [Date], [Time], [Year], [UserID]) VALUES (@BDT, @PaymentID, @VoB, @Details, @PostingDate, @DateTime, @Date, @Time, @Year, @UserID)" SelectCommand="SELECT * FROM [Payment] WHERE ([UserID] = @UserID)" UpdateCommand="UPDATE [Payment] SET [BDT] = @BDT, [PaymentID] = @PaymentID, [VoB] = @VoB, [Details] = @Details, [PostingDate] = @PostingDate, [DateTime] = @DateTime, [Date] = @Date, [Time] = @Time, [Year] = @Year, [UserID] = @UserID WHERE [ID] = @ID">
                <DeleteParameters>
                    <asp:Parameter Name="ID" Type="Int32"></asp:Parameter>
                </DeleteParameters>
                <InsertParameters>
                    <asp:Parameter Name="BDT" Type="Double"></asp:Parameter>
                    <asp:Parameter Name="PaymentID" Type="String"></asp:Parameter>
                    <asp:Parameter Name="VoB" Type="String"></asp:Parameter>
                    <asp:Parameter Name="Details" Type="String"></asp:Parameter>
                    <asp:Parameter Name="PostingDate" Type="String"></asp:Parameter>
                    <asp:Parameter DbType="Date" Name="DateTime"></asp:Parameter>
                    <asp:Parameter Name="Date" Type="Int32"></asp:Parameter>
                    <asp:Parameter Name="Time" Type="Int32"></asp:Parameter>
                    <asp:Parameter Name="Year" Type="Int32"></asp:Parameter>
                    <asp:Parameter Name="UserID" Type="String"></asp:Parameter>
                </InsertParameters>
                <SelectParameters>
                    <asp:QueryStringParameter QueryStringField="UsrID" Name="UserID" Type="String"></asp:QueryStringParameter>
                </SelectParameters>
                <UpdateParameters>
                    <asp:Parameter Name="BDT" Type="Double"></asp:Parameter>
                    <asp:Parameter Name="PaymentID" Type="String"></asp:Parameter>
                    <asp:Parameter Name="VoB" Type="String"></asp:Parameter>
                    <asp:Parameter Name="Details" Type="String"></asp:Parameter>
                    <asp:Parameter Name="PostingDate" Type="String"></asp:Parameter>
                    <asp:Parameter DbType="Date" Name="DateTime"></asp:Parameter>
                    <asp:Parameter Name="Date" Type="Int32"></asp:Parameter>
                    <asp:Parameter Name="Time" Type="Int32"></asp:Parameter>
                    <asp:Parameter Name="Year" Type="Int32"></asp:Parameter>
                    <asp:Parameter Name="UserID" Type="String"></asp:Parameter>
                    <asp:Parameter Name="ID" Type="Int32"></asp:Parameter>
                </UpdateParameters>
            </asp:SqlDataSource>
        </div>
        </div>
      </div>
  

</asp:Content>
