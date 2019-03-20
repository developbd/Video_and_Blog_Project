<%@ Page Title="" Language="C#" MasterPageFile="~/profile.master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="Bdbay.Dashboard" %>

<%@ Register Src="~/logout.ascx" TagPrefix="uc1" TagName="logout" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript" src="https://www.gstatic.com/charts/loader.js"></script>
    <asp:PlaceHolder ID="scriptShow" runat="server"></asp:PlaceHolder>    
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
                                            <li class="clearfix"><a class="active" href="Dashboard"><i class="fa fa-dashboard"></i>Dashboard</a></li>
                                            <li class="clearfix"><a href="Videos"><i class="fa fa-video-camera"></i>Videos</a></li>
                                            <li class="clearfix"><a href="Blog"><i class="fa fa-book"></i>Blog</a></li>
                                            <li class="clearfix"><a href="subscribers"><i class="fa fa-users"></i>Your Subscribe</a></li>
                                            <li class="clearfix"><a href="settings"><i class="fa fa-gears"></i>Profile Settings</a></li>
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
                    <!-- followers -->
                    <section class="content content-with-sidebar followers margin-bottom-10">
                        <div class="row secBg">
                            <div class="large-12 columns">
                                <div class="row column head-text clearfix">
                                    <h4 class="pull-left"><i class="fa fa-users"></i>Dashboard</h4>
                                </div>
                                <div class="row collapse">
                                    <div id="chart_div" style="width:100%;height:500px;"></div>
                                </div>
                            </div>                           
                        </div>
                    </section>
                </div><!-- end left side content area -->
            </div>


</asp:Content>
