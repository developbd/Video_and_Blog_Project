<%@ Page Title="" Language="C#" MasterPageFile="~/profile.master" AutoEventWireup="true" CodeBehind="blog.aspx.cs" Inherits="Bdbay.blog" %>

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
                                            <li class="clearfix"><a  class="active" href="Blog"><i class="fa fa-book"></i>Blog</a></li>
                                            <li class="clearfix"><a href="subscribers"><i class="fa fa-users"></i>Your Subscribe</a></li>
                                            <li class="clearfix"><a href="settings"><i class="fa fa-gears"></i>Profile Settings</a></li>
                                            <li class="clearfix"><a href="Payment"><i class="fa fa-user"></i>Payment</a></li>
                                            <uc1:logout runat="server" ID="logout" />
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
                    <section class="profile-videos">
                        <div class="row secBg">
                            <div class="large-12 columns">
                                <div class="heading">
                                    <i class="fa fa-video-camera"></i>
                                    <h4>My Blogs</h4>
                                </div>

                                <asp:GridView ID="GridView1" Width="100%" PageIndex="50"  ShowHeader="false" ShowFooter="false" GridLines="None" AutoGenerateColumns="False" runat="server">
                                    <Columns>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <div class="profile-video">
                                                    <div class="media-object stack-for-small">
                                                        <div class="media-object-section media-img-content">
                                                            <div class="video-img">
                                                                <img src='<%# Eval("LinkThumbnail") %>' alt="video thumbnail">
                                                            </div>
                                                        </div>
                                                        <div class="media-object-section media-video-content">
                                                            <div class="video-content">
                                                                <h5><a href='<%# Eval("BlogID","Read?={0}") %>'><%# Eval("Title") %></a></h5>
                                                                <p><%# (Eval("ShortDetails").ToString().Length > 150)?(Eval("ShortDetails").ToString().Substring(0, 150) + "...") : Eval("ShortDetails") %></p>
                                                            </div>
                                                            <div class="video-detail clearfix">
                                                                <div class="video-stats">
                                                                    <span><%# Eval("ErrorMessege") %></span>
                                                                    <span><i class="fa fa-clock-o"></i><%# Eval("PostingDate") %></span>                                                                   
                                                                </div>
                                                                <div class="video-btns" style="margin-left:200px;">                                                                    
                                                                     <a class="video-btn" href='<%# Eval("BlogID","write?bid={0}&i=update&ref=Blog&uid="+Session["UserID"].ToString()) %>'> <i class="fa fa-pencil-square-o" ></i>Edit</a>     
                                                                     <a class="video-btn" onclick="return confirm('Are you sure to delete?');"  href='<%# Eval("BlogID","write?Delete={0}&ref=Blog&uid="+Session["UserID"].ToString()) %>'> <i class="fa  fa-trash" ></i>Delete</a>                          
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>                                    
                                </asp:GridView>
                                                                



                                
                            </div>
                        </div>
                    </section><!-- End single post description -->
                    </div>
                    </div>
</asp:Content>
