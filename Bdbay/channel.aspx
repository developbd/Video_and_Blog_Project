<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="channel.aspx.cs" Inherits="Bdbay.channel" %>

<%@ Register Src="~/sideAdd.ascx" TagPrefix="uc1" TagName="sideAdd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .center
        {
            text-align:center;
            margin-left:300px;
        }

    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Body" runat="server">

    <asp:Panel ID="Panel1" runat="server">
                    <div class="profile-stats">
                    <div class="row secBg">
                        <div class="large-12 columns">
                            <div class="profile-author-img">
                                <asp:Image ID="UserImage" runat="server" />                               
                            </div>                            
                            <div class="clearfix">
                                <div class="profile-author-name float-left">
                                    <h4>
                                        <asp:Label ID="lblFullname" runat="server"></asp:Label></h4>
                                    <p>Join Date : <span>
                                        <asp:Label ID="lbljoinDate" runat="server"></asp:Label></span></p>
                                </div>
                                
                                <div class="profile-author-stats float-right">
                                    <ul class="menu">
                                        <li>
                                            <div class="icon float-left">
                                                <i class="fa fa-video-camera"></i>
                                            </div>
                                            <div class="li-text float-left">
                                                <p class="number-text">
                                                    <asp:Label ID="lblVideo" runat="server"  ></asp:Label></p>
                                                <span>Videos</span>
                                            </div>
                                        </li>                                        
                                        <li>
                                            <div class="icon float-left">
                                                <i class="fa fa-eye"></i>
                                            </div>
                                            <div class="li-text float-left">
                                                <p class="number-text">
                                                    <asp:Label ID="lblView" runat="server" ></asp:Label></p>
                                                <span>Views</span>
                                            </div>
                                        </li>

                                        <li>
                                            <div class="icon float-left">
                                                <i class="fa fa-book"></i>
                                            </div>
                                            <div class="li-text float-left">
                                                <p class="number-text">
                                                    <asp:Label ID="lblBlog" runat="server" ></asp:Label></p>
                                                <span>Blog</span>
                                            </div>
                                        </li>
                                        <li>
                                            <div class="icon float-left">
                                                <i class="fa fa-eye"></i>
                                            </div>
                                            <div class="li-text float-left">
                                                <p class="number-text">
                                                    <asp:Label ID="lblBlogView" runat="server" ></asp:Label></p>
                                                <span>Views</span>
                                            </div>
                                        </li>

                                    </ul>

                                   
                                </div>
                                 
                            </div>
                        </div>
                        <div style="margin-left:35px;">
                        <asp:Button ID="btnSubscribe" OnClick="btnSubscribe_Click" BorderStyle="None" BackColor="Red" Width="100px" Height="30px" ForeColor="White"  runat="server" Text="Subscribe" />
                            <asp:Button ID="btnUnsubscribe" OnClick="btnUnsubscribe_Click" BackColor="Red" BorderStyle="None" Width="100px" Height="30px" ForeColor="White"  runat="server" Text="Unsubscribe" />
                            </div>
                        
                    </div>
                        
                </div>
        
    </asp:Panel>

            <div class="row">
                <!-- left side content area -->
                <div class="large-8 columns">
                    <section class="content content-with-sidebar margin-bottom-10">
                        <div class="row secBg">
                            <div class="large-12 columns">
                                <div class="row column head-text clearfix">
                                    <h4 class="pull-left"><i class="fa fa-video-camera"></i>Videos</h4>
                                </div>
                                <asp:Label ID="lblVideoHave" Font-Size="12px" CssClass="center" runat="server" ></asp:Label>
                                <div class="tabs-content" data-tabs-content="newVideos">
                                    <div class="tabs-panel is-active" id="new-all">
                                        <div class="row list-group">
                                            
                                            <asp:PlaceHolder ID="VideoShow" runat="server"></asp:PlaceHolder>                                          
                                               
                                        </div>
                                    </div>
                                </div>
                                
                            </div>
                            <div class="large-12 columns">
                                <div class="row column head-text clearfix">
                                    <h4 class="pull-left"><i class="fa fa-book"></i>Blog</h4>
                                </div>
                                <asp:Label ID="lblBlogHave"  Font-Size="12px" CssClass="center" runat="server" ></asp:Label>
                                <div class="tabs-content" data-tabs-content="newVideos">
                                    <div class="tabs-panel is-active" id="new-all">
                                        <div class="row list-group">                                            
                                            <asp:PlaceHolder ID="blogShow" runat="server"></asp:PlaceHolder>                                                                                     
                                        </div>
                                    </div>
                                </div>
                                
                            </div>
                        </div>
                    </section>
                    <!-- single post description -->
                    <section class="singlePostDescription">
                        <div class="row secBg">
                            <div class="large-12 columns">
                                <div class="heading">
                                    <i class="fa fa-user"></i>
                                    <h4>Description</h4>
                                </div>
                                <div class="description">
                                    <asp:Label ID="lblDescription" runat="server" ></asp:Label>
                                    <div class="site profile-margin">
                                        <button><i class="fa fa-globe"></i>Site</button>
                                        <a href="#" class="inner-btn">
                                            <asp:Label ID="lblsite" runat="server" ></asp:Label></a>
                                    </div>
                                    <div class="email profile-margin">
                                        <button><i class="fa fa-envelope"></i>Email</button>
                                        <span class="inner-btn">
                                            <asp:Label ID="lblEmail" runat="server"></asp:Label></span>
                                    </div>

                                   <%-- <div class="phone profile-margin">
                                        <button><i class="fa fa-phone"></i>Phone</button>
                                        <span class="inner-btn">
                                            <asp:Label ID="lblPhone" runat="server" ></asp:Label></span>
                                    </div>--%>

                                </div>
                            </div>
                        </div>
                    </section><!-- End single post description -->

                    <!-- author videos -->
                    

                </div><!-- end left side content area -->
                <!-- sidebar -->
                <div class="large-4 columns">
                    <aside class="secBg sidebar">
                        <div class="row">
                            <uc1:sideAdd runat="server" ID="sideAdd" />
                        </div>
                    </aside>
                </div><!-- end sidebar -->
            </div>

</asp:Content>
