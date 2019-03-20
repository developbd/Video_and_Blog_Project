<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Bdbay.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Body" runat="server">
    <asp:TextBox ID="txtShowFirstVideo" runat="server" Visible="false" TextMode="Number">10</asp:TextBox>
    <asp:TextBox ID="txtShowFirstBlog" runat="server" Visible="false" TextMode="Number">10</asp:TextBox>
            <!-- Premium Videos -->
            <section id="premium" class="premium-v4">
                <div id="owl-demo" class="owl-carousel carousel" data-car-length="4" data-items="4" data-loop="true" data-nav="false" data-autoplay="true" data-autoplay-timeout="3000" data-dots="false" data-auto-width="false" data-responsive-small="1" data-responsive-medium="2" data-responsive-xlarge="5">
                    <asp:PlaceHolder ID="showADD" runat="server"></asp:PlaceHolder>
                   


                </div>
            </section><!-- End Premium Videos -->
            <!-- Category -->

    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>

            <asp:PlaceHolder ID="showAll" runat="server"></asp:PlaceHolder>

            <div style="text-align: center; margin: 5px;">
                <asp:Button ID="btnViewMoreVideo" OnClick="btnViewMoreVideo_Click" CssClass="button"  runat="server" Text="Show Video" />
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>

            <div class="googleAdv text-center">
                
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
            </div>

    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <ContentTemplate>
            <asp:PlaceHolder ID="showBlog" runat="server"></asp:PlaceHolder>
        </ContentTemplate>
    </asp:UpdatePanel>
<div style="text-align: center; margin: 5px;">
    <asp:Button ID="btnViewMoreBlog" CssClass="button" runat="server" OnClick="btnViewMoreBlog_Click" Text="Show Blog" />

            </div>

            <!-- End ad Section -->
</asp:Content>
