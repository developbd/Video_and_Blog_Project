<%@ Page Title="" Language="C#" MasterPageFile="~/profile.master" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="about.aspx.cs" Inherits="Bdbay.about" %>

<%@ Register Src="~/logout.ascx" TagPrefix="uc1" TagName="logout" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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
                                            <li class="clearfix"><a href="Subscribe"><i class="fa fa-users"></i>Subscribe</a></li>
                                            <li class="clearfix"><a href="settings"><i class="fa fa-gears"></i>Profile Settings</a></li>
                                            <li class="clearfix"><a class="active" href="about"><i class="fa fa-user"></i>About Me</a></li>
                                            <li class="clearfix"><a href="Payment"><i class="fa fa-user"></i>Payment</a></li>
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
                    <!-- single post description -->
                    <section class="singlePostDescription">
                        <div class="row secBg">
                            <div class="large-12 columns">
                                <div class="heading">
                                    <i class="fa fa-user"></i>
                                    <h4>Description</h4>
                                </div>
                                <div class="description">
                                    <p style="text-align:justify;">
                                        <asp:Label ID="lblDetails" runat="server" ></asp:Label></p>
                                    <div class="site profile-margin">
                                        <button><i class="fa fa-globe"></i>Site</button>
                                        <a class="inner-btn">
                                            <asp:Label ID="lblSite" runat="server" ></asp:Label></a>
                                    </div>
                                    <div class="email profile-margin">
                                        <button><i class="fa fa-envelope"></i>Email</button>
                                        <span class="inner-btn"><asp:Label ID="lblEmail" runat="server" ></asp:Label></span>
                                    </div>
                                    <div class="phone profile-margin">
                                        <button><i class="fa fa-phone"></i>Phone</button>
                                        <span class="inner-btn"><asp:Label ID="lblPhone" runat="server" ></asp:Label></span>
                                    </div>
                                    


                                </div>
                            </div>
                        </div>
                    </section><!-- End single post description -->
                </div><!-- end left side content area -->
            </div>
</asp:Content>
