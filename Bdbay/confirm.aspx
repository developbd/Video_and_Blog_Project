<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="confirm.aspx.cs" Inherits="Bdbay.confirm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Body" runat="server">
     <!-- registration -->
            <section class="registration">
                <div class="row secBg">
                    <div class="large-12 columns">
                        <div class="login-register-content">
                            <div class="row collapse borderBottom">
                                <div class="medium-6 large-centered medium-centered">
                                    <div class="page-heading text-center">
                                        <h3>Email Confirmation</h3>
                                        <p>Your Email</p>
                                    </div>
                                </div>
                            </div>
                            <div class="row" data-equalizer data-equalize-on="medium" id="test-eq">
                                <div class="large-4 medium-6 large-centered medium-centered columns">
                                    <div class="register-form">
                                        <h5 class="text-center">Confirmation Code</h5>
                                        
                                            <div class="input-group">
                                                <span class="input-group-label"><i class="fa fa-comment"></i></span>
                                                <input type="email" placeholder="Code" >
                                                
                                            </div>
                                            <button class="button expanded" type="submit" name="submit">Confirm</button>
                                        <asp:LinkButton ID="LinkButton1" runat="server" Font-Size="12px" ForeColor="Black" >Code Send Again</asp:LinkButton>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </section>
</asp:Content>
