<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="History.aspx.cs" Inherits="Bdbay.History" %>

<%@ Register Src="~/sideAdd.ascx" TagPrefix="uc1" TagName="sideAdd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Body" runat="server">
    
            <section class="category-content">
                <div class="row">
                    <!-- left side content area -->
                    <div class="large-8 columns">
                        <section class="content content-with-sidebar">
                         
                        
                            <div class="row secBg">
                                <div class="large-12 columns">
                                    <div class="row column head-text clearfix">
                                        <p class="pull-left">
                                            <asp:Label ID="lblMessege" runat="server" ></asp:Label></p>
                                    </div>
                                    <asp:DropDownList ID="ddlSize" runat="server">
                                        <asp:ListItem Value="10">10</asp:ListItem>
                                        <asp:ListItem Value="20">20</asp:ListItem>
                                        <asp:ListItem Value="30">30</asp:ListItem>
                                        <asp:ListItem Value="40">40</asp:ListItem>
                                        <asp:ListItem Value="50">50</asp:ListItem>
                                        <asp:ListItem Value="60">60</asp:ListItem>
                                        <asp:ListItem Value="70">70</asp:ListItem>
                                        <asp:ListItem Value="80">80</asp:ListItem>
                                        <asp:ListItem Value="90">90</asp:ListItem>
                                        <asp:ListItem Value="100">100</asp:ListItem>
                                    </asp:DropDownList>
                                    <div class="tabs-content" data-tabs-content="newVideos">
                                        <div class="tabs-panel is-active" id="new-all">
                                            <div class="row list-group">


                                                <asp:PlaceHolder ID="historyShow" runat="server"></asp:PlaceHolder>



                                                
                                            </div>
                                        </div>
                                    </div>
                                    
                                </div>
                            </div>
                        </section>
                        <!-- ad Section -->

                        <div class="googleAdv">
                            <asp:GridView ID="GridView1" Width="100%" AutoGenerateColumns="false" GridLines="None" ShowHeader="false" runat="server" DataSourceID="SqlDataSource1">
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton ID="btnImg" runat="server"><a href='<%# Eval("ID","Click?={0}") %>'><img src='<%# Eval("Image") %>' alt="ads"></a></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                <asp:SqlDataSource runat="server" ID="SqlDataSource1" ConnectionString='<%$ ConnectionStrings:Settings %>' SelectCommand="SELECT top 1 * FROM [Advertisement] where HV='Horizontal' order by NEWID()"></asp:SqlDataSource>
                        </div><!-- End ad Section -->

                    </div><!-- end left side content area -->
                    <!-- sidebar -->
                    <div class="large-4 columns">
                        <aside class="secBg sidebar">
                            <div class="row">
                             
                                <uc1:sideAdd runat="server" id="sideAdd" />

                          
                                


                            </div>
                        </aside>
                    </div><!-- end sidebar -->
                </div>
            </section><!-- End Category Content-->
</asp:Content>
