<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="Bdbay.login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    	<script>
    	    function olafuction() {
    	        var x = document.getElementById("Body_txtpassword");
    	        if (x.type === "password") {
    	            x.type = "text";
    	        } else {
    	            x.type = "password";
    	        }
    	    }
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Body" runat="server">
     <section class="registration">
                <div class="row secBg">
                    <div class="large-12 columns">
                        <div class="login-register-content">
                            <div class="row collapse borderBottom">
                                <div class="medium-6 large-centered medium-centered">
                                    <div class="page-heading text-center">
                                        <h3>User login</h3>
                                    </div>
                                </div>
                            </div>
                            <div class="row" data-equalizer data-equalize-on="medium" id="test-eq">
                               <%-- <div class="large-4 large-offset-1 medium-6 columns">
                                    <div class="social-login" data-equalizer-watch>
                                        <h5 class="text-center">Login via Social Profile</h5>
                                        <div class="social-login-btn facebook">
                                            <a href="#"><i class="fa fa-facebook"></i>login via facebook</a>
                                        </div>
                                        <div class="social-login-btn twitter">
                                            <a href="#"><i class="fa fa-twitter"></i>login via twitter</a>
                                        </div>
                                        <div class="social-login-btn g-plus">
                                            <a href="#"><i class="fa fa-google-plus"></i>login via google plus</a>
                                        </div>
                                        <div class="social-login-btn linkedin">
                                            <a href="#"><i class="fa fa-linkedin"></i>login via linkedin</a>
                                        </div>
                                    </div>
                                </div>
                                <div class="large-2 medium-2 columns show-for-large">
                                    <div class="middle-text text-center hide-for-small-only" data-equalizer-watch>
                                        <p>
                                            <i class="fa fa-arrow-left arrow-left"></i>
                                            <span>OR</span>
                                            <i class="fa fa-arrow-right arrow-right"></i>
                                        </p>
                                    </div>
                                </div>--%>
                               <div class="large-4 medium-6 columns end hide_text">gfg</div>
                                <div class="large-4 medium-6 columns end">
                                    <div class="register-form">
                                        <h5 class="text-center">Create your Account</h5>                                             
                                            <div class="input-group">
                                                <span class="input-group-label"><i class="fa fa-user"></i></span>
                                                <asp:TextBox ID="txtEmail" CssClass="input-group-field" placeholder="Enter your username"  runat="server"></asp:TextBox>                                            
                                            </div>
                                            <div class="input-group">
                                                <span class="input-group-label"><i class="fa fa-lock"></i></span>
                                                <asp:TextBox ID="txtpassword" TextMode="Password"  placeholder="Enter your password"  runat="server"></asp:TextBox>                                  
                                            </div>     
                                         		
										<span style="display:inline-flex; font-weight:bold; font-size:12px;"><input type="checkbox" class="my_checkbox" onclick="olafuction()"/>Show Password</span><br/><br/>

										
										
										
										<asp:Label ID="lblResult" ForeColor="Red" runat="server" Font-Bold="true"></asp:Label><br/>                                                                
                                            <asp:Button ID="btnLogin" CssClass="button expanded" OnClick="btnLogin_Click" runat="server" Text="login Now" />
                                            <p class="loginclick"><a href="forgotpassword">Forgot Password</a> New Here? <a href="Registation">Create a new Account</a></p>                                    
                                    </div>
                                </div>
                                <div class="large-4 medium-6 columns end hide_text">fgfg</div>
                                 
                            </div>
                        </div>
                    </div>
                </div>
            </section>

</asp:Content>
