<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="forgotpassword.aspx.cs" Inherits="Bdbay.forgotpassword" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Body" runat="server">
    <asp:TextBox ID="txtSecureServer" Visible="false" runat="server">smtpout.secureserver.net</asp:TextBox>
     <section class="registration">
                <div class="row secBg">
                    <div class="large-12 columns">
                        <div class="login-register-content">
                            <div class="row collapse borderBottom">
                                <div class="medium-6 large-centered medium-centered">
                                    <div class="page-heading text-center">
                                        <h3>Forgot Password</h3>
                                    </div>
                                </div>
                            </div>
                            <div class="row" data-equalizer data-equalize-on="medium" id="test-eq">                              
                               <div class="large-4 medium-6 columns end hide_text">gfg</div>
                                <div class="large-4 medium-6 columns end">
                                    <div class="register-form">
                                        <h5 class="text-center">Forgot Password</h5>                                             
                                            <div class="input-group">
                                                <span class="input-group-label"><i class="fa fa-user"></i></span>
                                                <asp:TextBox ID="txtEmail" CssClass="input-group-field" placeholder="Enter your Email"  runat="server"></asp:TextBox>                                            
                                            </div>                                               
                                         <asp:Label ID="lblResult" runat="server" Font-Bold="true"></asp:Label>                                                            
                                            <asp:Button OnClick="btnLogin_Click" ID="btnLogin" CssClass="button expanded" runat="server" Text="Forgot Password" />                                                                          
                                    </div>
                                </div>
                                <div class="large-4 medium-6 columns end hide_text">fgfg</div>
                                 
                            </div>
                        </div>
                    </div>
                </div>
            </section>

</asp:Content>
