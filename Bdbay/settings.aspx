<%@ Page Title="" Language="C#" MasterPageFile="~/profile.master" EnableEventValidation="false" ValidateRequest="false" AutoEventWireup="true" CodeBehind="settings.aspx.cs" Inherits="Bdbay.settings" %>

<%@ Register Src="~/logout.ascx" TagPrefix="uc1" TagName="logout" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        function CheckTextLength(text, long,id) {
            var maxlength = new Number(long); // Change number to your max length.
            if (text.value.length > maxlength) {
                text.value = text.value.substring(0, maxlength);
                alert(" Maximum " + long + " characters allowed");
                
            }
        }
    </script>
     <style type="text/css">
        .Drop {
        border:1px solid #292930;
        font-size:13px;
        color:#676565;
		border-radius:3px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="profilebody" runat="server">
    <div class="row">
                <!-- left sidebar -->
                <div class="large-4 columns">
                    <aside class="secBg sidebar">
                        <div class="row">
                            <!-- profile overview -->
                            <div class="large-12 columns">
                                <div class="widgetBox">
                                    <div class="widgetTitle">
                                        <h5>Profile Overview</h5>
                                    </div>
                                    <div class="widgetContent">
                                        <ul class="profile-overview">
                                            <li class="clearfix"><a href="Dashboard"><i class="fa fa-dashboard"></i>Dashboard</a></li>
                                            <li class="clearfix"><a href="Videos"><i class="fa fa-video-camera"></i>Videos</a></li>
                                            <li class="clearfix"><a href="Blog"><i class="fa fa-book"></i>Blog</a></li>
                                            <li class="clearfix"><a href="subscribers"><i class="fa fa-users"></i>Your Subscribe</a></li>
                                            <li class="clearfix"><a  class="active" href="settings"><i class="fa fa-gears"></i>Profile Settings</a></li>
                                            <li class="clearfix"><a href="Payment"><i class="fa fa-cc-mastercard" aria-hidden="true"></i>Payment</a></li>
                                            <uc1:logout runat="server" id="logout" />
                                        </ul>
                                       
                                    </div>
                                </div>
                            </div><!-- End profile overview -->
                        </div>
                    </aside>
                </div><!-- end sidebar -->
                <!-- right side content area -->
                <div class="large-8 columns profile-inner">
                    <!-- profile settings -->
                    <section class="profile-settings">
                        <div class="row secBg">
                            <div class="large-12 columns">
                                <div class="heading">
                                    <i class="fa fa-gears"></i>
                                    <h4>Profile Settings</h4>
                                </div>
                                <div class="row">
                                    <div class="large-12 columns">
                                        <div class="setting-form">
                                    
                                                <div class="setting-form-inner">
                                                    <div class="row">
                                                        <div class="large-12 columns">
                                                            <h6 class="borderBottom">User Setting:</h6>
                                                        </div>
                                                        <div class="medium-6 columns">
                                                            <label>First Name:
                                                                <asp:TextBox ID="txtFastName" placeholder="enter your first name.." runat="server"></asp:TextBox>                                                                
                                                            </label>
                                                        </div>
                                                        <div class="medium-6 columns">
                                                            <label>Last Name:
                                                                 <asp:TextBox ID="txtLastName" placeholder="enter your last name.." runat="server"></asp:TextBox>    
                                                            </label>
                                                        </div>                                                       
                                                    </div>
                                                </div>
                                                <div class="setting-form-inner">
                                                    <div class="row">
                                                        <div class="large-12 columns">
                                                            <h6 class="borderBottom">Update Password:</h6>
                                                        </div>
                                                        <div class="medium-6 columns">
                                                            <label>New Password:
                                                                <asp:TextBox ID="txtNewPassword" placeholder="enter your new password.." runat="server"></asp:TextBox> 
                                                            </label>
                                                        </div>
                                                        <div class="medium-6 columns">
                                                            <label>Retype Password:
                                                                <asp:TextBox ID="txtRetypePassword" placeholder="enter your new password.." runat="server"></asp:TextBox> 
                                                            </label>
                                                        </div>
                                                        <div class="setting-form-inner">
                                                            <asp:Button ID="btnupdateNamePassword" CssClass="my_btn" OnClick="btnupdateNamePassword_Click" runat="server" Text="UPDATE NAME & PASSWORD" />
                                                            <asp:Label ID="lblUpdateNamePassword" Font-Bold="true" Font-Size="12px"  runat="server" ></asp:Label>
                                                </div>
                                                    </div>
                                                </div>
                                                <div class="setting-form-inner">
                                                    <div class="row">
                                                        <div class="large-12 columns">
                                                            <h6 class="borderBottom">About Me:</h6>
                                                        </div>
                                                        <div class="medium-6 columns">
                                                            <label>Email ID:
                                                                <asp:TextBox ID="txtEmail" Enabled="false" placeholder="enter your email" runat="server"></asp:TextBox> 
                                                            </label>
                                                        </div>
                                                        <div class="medium-6 columns">
                                                            <label>Website URL:
                                                                <asp:TextBox ID="txtWebsite" placeholder="enter your website.." runat="server"></asp:TextBox> 
                                                            </label>
                                                        </div>
                                                        <div class="medium-6 columns end">
                                                            <label>Phone No:
                                                                <asp:TextBox ID="txtPhone" placeholder="enter your phone number.." runat="server"></asp:TextBox> 
                                                            </label>
                                                        </div>
                                                        <div class="medium-6 columns end">
                                                            <label>Gender:
                                                                <asp:DropDownList CssClass="Drop" ID="ddlgender" runat="server">
                                                                    <asp:ListItem Value="Male">Male</asp:ListItem>
                                                                    <asp:ListItem Value="Female">Female</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </label>
                                                        </div>
                                                        <div class="medium-12 columns">
                                                            <label>Address: 
                                                                  <asp:TextBox runat="server" ID="txtAddress"  placeholder="enter your address.." TextMode="MultiLine"
            onKeyUp="CheckTextLength(this,400)" onChange="CheckTextLength(this,400)"></asp:TextBox>
                                                            </label>
                                                        </div>
                                                        <div class="medium-12 columns">
                                                            <label>Bio Description:
                                                                <asp:TextBox runat="server" ID="txtDetails"  placeholder="enter your details.." TextMode="MultiLine"
            onKeyUp="CheckTextLength(this,3500)" onChange="CheckTextLength(this,3500)"></asp:TextBox>

                                                            </label>
                                                        </div>
                                                        <div class="setting-form-inner">
                                                       <asp:Button ID="btnUpdateDetails" OnClick="btnUpdateDetails_Click" CssClass="my_btn"  runat="server" Text="UPDATE DETAILS" />
                                                       <asp:Label ID="lblUpdateDetails" Font-Bold="true" Font-Size="12px"  runat="server" ></asp:Label>
                                                </div>
                                                    </div>
                                                </div>
                                                <div class="setting-form-inner">
                                                    <div class="row">
                                                        <div class="large-12 columns">
                                                            <h6 class="borderBottom">Profile Picture:</h6>
                                                        </div>
                                                        <div class="medium-6 columns">
                                                            <label>Profile Photo: (120x110)
                                                                <asp:FileUpload ID="FUprofilePhoto" runat="server" />
                                                            </label>
                                                        </div>
                                                        <div class="medium-6 columns">
                                                            <label>Cover Photo: (1600x350)
                                                                <asp:FileUpload ID="FUCoverphoto" runat="server" />
                                                            </label>
                                                        </div>                                                      
                                                    </div>
                                                </div>
                                                <div class="setting-form-inner">
                                                    <asp:Button ID="btnProfilePhoto"  CssClass="my_btn"  OnClick="btnProfilePhoto_Click" runat="server" Text="UPDATE PROFILE PHOTO" />
                                                    <asp:Label ID="lblProfilePhoto" Font-Bold="true" Font-Size="12px"  runat="server" ></asp:Label>
                                                </div>
                                          
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </section><!-- End profile settings -->
                </div><!-- end left side content area -->
            </div>
</asp:Content>
