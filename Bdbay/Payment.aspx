<%@ Page Title="" Language="C#" MasterPageFile="~/profile.master" AutoEventWireup="true" CodeBehind="Payment.aspx.cs" Inherits="Bdbay.Payment" %>

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
                                            <li class="clearfix"><a  href="subscribers"><i class="fa fa-users"></i>Your Subscribe</a></li>
                                            <li class="clearfix"><a href="settings"><i class="fa fa-gears"></i>Profile Settings</a></li>
                                            <li class="clearfix"><a class="active" href="Payment"><i class="fa fa-cc-mastercard" aria-hidden="true"></i>Payment</a></li>
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
                                    <h4 class="pull-left"><i class="fa fa-cc-mastercard" aria-hidden="true"></i>Payment</h4>
                                </div>
                                <div class="row collapse">
                                  <h3>Total Amount : <asp:Label ID="lblBDT" runat="server" ></asp:Label> BDT</h3>

                                 
                                    <asp:PlaceHolder ID="showPament" runat="server"></asp:PlaceHolder>
                                  
                                    


                                </div>
                            </div>                           
                        </div>
                    </section>
                </div><!-- end left side content area -->
            </div>

</asp:Content>
