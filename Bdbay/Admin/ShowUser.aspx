<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/admin.Master" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="ShowUser.aspx.cs" Inherits="Bdbay.Admin.ShowUser" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Body" runat="server">        
    
    
     <div class="app-content content">
      <div class="content-wrapper">
        <div class="content-header row">
        </div>
        <div class="content-body"><!-- Stats -->
			<div class="card-content">
                    <div class="card-body">

                        <asp:GridView ID="GridView1" runat="server" Width="100%" GridLines="None" AutoGenerateColumns="False" DataKeyNames="ID" DataSourceID="SqlDataSource1" AllowPaging="True">
                            <Columns>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <div class="row">
                                            <div class="col-md-1">
                                                <asp:Image ID="Image1" Width="80" Height="80" ImageUrl='<%# Bind("Image","../Profileimage/{0}") %>' runat="server" />
                                            </div>
                                            <div class="col-md-3">
                                                <asp:Label ID="Label1" runat="server" ForeColor="#6699ff"  Font-Bold="true" Text='<%# Bind("FastName") %>'></asp:Label>
                                                <asp:Label ID="Label2" runat="server" ForeColor="#6699ff"  Font-Bold="true" Text='<%# Bind("LastName") %>'></asp:Label><br />
                                                Email: <asp:Label ID="Label3" runat="server" ForeColor="#000000" Font-Bold="true" Text='<%# Bind("Email") %>'></asp:Label><br />
                                                Gender: <asp:Label ID="Label4" runat="server" ForeColor="#000000" Font-Bold="true" Text='<%# Bind("Gender") %>'></asp:Label><br />
                                                Country: <asp:Label ID="Label5" runat="server" ForeColor="#000000" Font-Bold="true" Text='<%# Bind("Country") %>'></asp:Label><br />                                                
                                            </div>
                                            <div class="col-md-3">
                                                Mobile: <asp:Label ID="Label6" runat="server" ForeColor="#000000" Font-Bold="true" Text='<%# Bind("Phone") %>'></asp:Label><br />
                                                Authority: <asp:Label ID="Label7" runat="server" ForeColor="#000000" Font-Bold="true" Text='<%# Bind("Authority") %>'></asp:Label><br />
                                            </div>
                                             <div class="col-md-3">
                                                 <asp:LinkButton ID="LinkButton1" CssClass="btn btn-info" runat="server" PostBackUrl='<%#Eval("ID","profile?={0}") %>'>Show Profile</asp:LinkButton>
                                                 <asp:LinkButton ID="LinkButton2" CssClass="btn btn-danger" runat="server" OnCommand="LinkButton2_Command" CommandArgument='<%# Eval("ID") %>'>Delete</asp:LinkButton>
                                             </div>

                                        </div>
                                        <br />

                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>


                        <asp:SqlDataSource runat="server" ID="SqlDataSource1" ConnectionString='<%$ ConnectionStrings:Settings %>' SelectCommand="SELECT * FROM [Registation_Tbl]">
                         
                        </asp:SqlDataSource>
                    </div>
                </div>
            </div>
          </div>
         </div>

</asp:Content>
