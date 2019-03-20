<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="search.aspx.cs" Inherits="Bdbay.search" %>

<%@ Register Src="~/sideAdd.ascx" TagPrefix="uc1" TagName="sideAdd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Body" runat="server">
            <section class="category-content">
                <div class="row">
                    <!-- left side content area -->
                    <div class="large-8 columns">
                        <section class="content content-with-sidebar">
                           
                            <div class="row secBg">
                                <div class="large-12 columns">
                                    <div class="row column head-text clearfix">
                                        <p class="pull-left"></p>
                                        
                                    </div>
                                    <div class="tabs-content" data-tabs-content="newVideos">
                                        <div class="tabs-panel is-active" id="new-all">
                                            <div class="row list-group">
    <asp:PlaceHolder ID="pnlShowScarch" runat="server"></asp:PlaceHolder>                                      
                                            </div>
                                        </div>
                                        <div class="tabs-panel" id="new-hd">
                                            <div class="row list-group">
                                                <div class="item large-4 medium-6 columns grid-medium">
                                                    <div class="post thumb-border">
                                                        <div class="post-thumb">
                                                            <img src="images/video-thumbnail/1.jpg" alt="new video">
                                                            <a href="watch" class="hover-posts">
                                                                <span><i class="fa fa-play"></i>Watch Video</span>
                                                            </a>
                                                            <div class="video-stats clearfix">
                                                                <div class="thumb-stats pull-left">
                                                                    <h6>HD</h6>
                                                                </div>
                                                                <div class="thumb-stats pull-left">
                                                                    <i class="fa fa-heart"></i>
                                                                    <span>506</span>
                                                                </div>
                                                                <div class="thumb-stats pull-right">
                                                                    <span>05:56</span>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="post-des">
                                                            <h6><a href="watch">There are many variations of passage.</a></h6>
                                                            <div class="post-stats clearfix">
                                                                <p class="pull-left">
                                                                    <i class="fa fa-user"></i>
                                                                    <span><a href="#">admin</a></span>
                                                                </p>
                                                                <p class="pull-left">
                                                                    <i class="fa fa-clock-o"></i>
                                                                    <span>5 January 16</span>
                                                                </p>
                                                                <p class="pull-left">
                                                                    <i class="fa fa-eye"></i>
                                                                    <span>1,862K</span>
                                                                </p>
                                                            </div>
                                                            <div class="post-summary">
                                                                <p>Sed ut perspiciatis unde omnis iste natus error sit voluptatem accusantium doloremque laudantium, totam rem aperiam, eaque ipsa quae ab illo inventore veritatis et quasi architecto sequi nesciunt.</p>
                                                            </div>
                                                            <div class="post-button">
                                                                <a href="watch" class="secondary-button"><i class="fa fa-play-circle"></i>watch video</a>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="item large-4 medium-6 columns grid-medium">
                                                    <div class="post thumb-border">
                                                        <div class="post-thumb">
                                                            <img src="images/video-thumbnail/7.jpg" alt="new video">
                                                            <a href="watch" class="hover-posts">
                                                                <span><i class="fa fa-play"></i>Watch Video</span>
                                                            </a>
                                                            <div class="video-stats clearfix">
                                                                <div class="thumb-stats pull-left">
                                                                    <h6>HD</h6>
                                                                </div>
                                                                <div class="thumb-stats pull-left">
                                                                    <i class="fa fa-heart"></i>
                                                                    <span>506</span>
                                                                </div>
                                                                <div class="thumb-stats pull-right">
                                                                    <span>05:56</span>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="post-des">
                                                            <h6><a href="watch">There are many variations of passage.</a></h6>
                                                            <div class="post-stats clearfix">
                                                                <p class="pull-left">
                                                                    <i class="fa fa-user"></i>
                                                                    <span><a href="#">admin</a></span>
                                                                </p>
                                                                <p class="pull-left">
                                                                    <i class="fa fa-clock-o"></i>
                                                                    <span>5 January 16</span>
                                                                </p>
                                                                <p class="pull-left">
                                                                    <i class="fa fa-eye"></i>
                                                                    <span>1,862K</span>
                                                                </p>
                                                            </div>
                                                            <div class="post-summary">
                                                                <p>Sed ut perspiciatis unde omnis iste natus error sit voluptatem accusantium doloremque laudantium, totam rem aperiam, eaque ipsa quae ab illo inventore veritatis et quasi architecto sequi nesciunt.</p>
                                                            </div>
                                                            <div class="post-button">
                                                                <a href="watch" class="secondary-button"><i class="fa fa-play-circle"></i>watch video</a>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>

                                                <div class="item large-4 medium-6 columns grid-medium">
                                                    <div class="post thumb-border">
                                                        <div class="post-thumb">
                                                            <img src="images/video-thumbnail/14.jpg" alt="new video">
                                                            <a href="watch" class="hover-posts">
                                                                <span><i class="fa fa-play"></i>Watch Video</span>
                                                            </a>
                                                            <div class="video-stats clearfix">
                                                                <div class="thumb-stats pull-left">
                                                                    <h6>HD</h6>
                                                                </div>
                                                                <div class="thumb-stats pull-left">
                                                                    <i class="fa fa-heart"></i>
                                                                    <span>506</span>
                                                                </div>
                                                                <div class="thumb-stats pull-right">
                                                                    <span>05:56</span>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="post-des">
                                                            <h6><a href="watch">There are many variations of passage.</a></h6>
                                                            <div class="post-stats clearfix">
                                                                <p class="pull-left">
                                                                    <i class="fa fa-user"></i>
                                                                    <span><a href="#">admin</a></span>
                                                                </p>
                                                                <p class="pull-left">
                                                                    <i class="fa fa-clock-o"></i>
                                                                    <span>5 January 16</span>
                                                                </p>
                                                                <p class="pull-left">
                                                                    <i class="fa fa-eye"></i>
                                                                    <span>1,862K</span>
                                                                </p>
                                                            </div>
                                                            <div class="post-summary">
                                                                <p>Sed ut perspiciatis unde omnis iste natus error sit voluptatem accusantium doloremque laudantium, totam rem aperiam, eaque ipsa quae ab illo inventore veritatis et quasi architecto sequi nesciunt.</p>
                                                            </div>
                                                            <div class="post-button">
                                                                <a href="watch" class="secondary-button"><i class="fa fa-play-circle"></i>watch video</a>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>

                                                <div class="item large-4 medium-6 columns grid-medium">
                                                    <div class="post thumb-border">
                                                        <div class="post-thumb">
                                                            <img src="images/video-thumbnail/5.jpg" alt="new video">
                                                            <a href="watch" class="hover-posts">
                                                                <span><i class="fa fa-play"></i>Watch Video</span>
                                                            </a>
                                                            <div class="video-stats clearfix">
                                                                <div class="thumb-stats pull-left">
                                                                    <h6>HD</h6>
                                                                </div>
                                                                <div class="thumb-stats pull-left">
                                                                    <i class="fa fa-heart"></i>
                                                                    <span>506</span>
                                                                </div>
                                                                <div class="thumb-stats pull-right">
                                                                    <span>05:56</span>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="post-des">
                                                            <h6><a href="watch">There are many variations of passage.</a></h6>
                                                            <div class="post-stats clearfix">
                                                                <p class="pull-left">
                                                                    <i class="fa fa-user"></i>
                                                                    <span><a href="#">admin</a></span>
                                                                </p>
                                                                <p class="pull-left">
                                                                    <i class="fa fa-clock-o"></i>
                                                                    <span>5 January 16</span>
                                                                </p>
                                                                <p class="pull-left">
                                                                    <i class="fa fa-eye"></i>
                                                                    <span>1,862K</span>
                                                                </p>
                                                            </div>
                                                            <div class="post-summary">
                                                                <p>Sed ut perspiciatis unde omnis iste natus error sit voluptatem accusantium doloremque laudantium, totam rem aperiam, eaque ipsa quae ab illo inventore veritatis et quasi architecto sequi nesciunt.</p>
                                                            </div>
                                                            <div class="post-button">
                                                                <a href="watch" class="secondary-button"><i class="fa fa-play-circle"></i>watch video</a>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="item large-4 medium-6 columns grid-medium end">
                                                    <div class="post thumb-border">
                                                        <div class="post-thumb">
                                                            <img src="images/video-thumbnail/9.jpg" alt="new video">
                                                            <a href="watch" class="hover-posts">
                                                                <span><i class="fa fa-play"></i>Watch Video</span>
                                                            </a>
                                                            <div class="video-stats clearfix">
                                                                <div class="thumb-stats pull-left">
                                                                    <h6>HD</h6>
                                                                </div>
                                                                <div class="thumb-stats pull-left">
                                                                    <i class="fa fa-heart"></i>
                                                                    <span>506</span>
                                                                </div>
                                                                <div class="thumb-stats pull-right">
                                                                    <span>05:56</span>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="post-des">
                                                            <h6><a href="watch">There are many variations of passage.</a></h6>
                                                            <div class="post-stats clearfix">
                                                                <p class="pull-left">
                                                                    <i class="fa fa-user"></i>
                                                                    <span><a href="#">admin</a></span>
                                                                </p>
                                                                <p class="pull-left">
                                                                    <i class="fa fa-clock-o"></i>
                                                                    <span>5 January 16</span>
                                                                </p>
                                                                <p class="pull-left">
                                                                    <i class="fa fa-eye"></i>
                                                                    <span>1,862K</span>
                                                                </p>
                                                            </div>
                                                            <div class="post-summary">
                                                                <p>Sed ut perspiciatis unde omnis iste natus error sit voluptatem accusantium doloremque laudantium, totam rem aperiam, eaque ipsa quae ab illo inventore veritatis et quasi architecto sequi nesciunt.</p>
                                                            </div>
                                                            <div class="post-button">
                                                                <a href="watch" class="secondary-button"><i class="fa fa-play-circle"></i>watch video</a>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="item large-4 medium-6 columns grid-medium end">
                                                    <div class="post thumb-border">
                                                        <div class="post-thumb">
                                                            <img src="images/video-thumbnail/11.jpg" alt="new video">
                                                            <a href="watch" class="hover-posts">
                                                                <span><i class="fa fa-play"></i>Watch Video</span>
                                                            </a>
                                                            <div class="video-stats clearfix">
                                                                <div class="thumb-stats pull-left">
                                                                    <h6>HD</h6>
                                                                </div>
                                                                <div class="thumb-stats pull-left">
                                                                    <i class="fa fa-heart"></i>
                                                                    <span>506</span>
                                                                </div>
                                                                <div class="thumb-stats pull-right">
                                                                    <span>05:56</span>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="post-des">
                                                            <h6><a href="watch">There are many variations of passage.</a></h6>
                                                            <div class="post-stats clearfix">
                                                                <p class="pull-left">
                                                                    <i class="fa fa-user"></i>
                                                                    <span><a href="#">admin</a></span>
                                                                </p>
                                                                <p class="pull-left">
                                                                    <i class="fa fa-clock-o"></i>
                                                                    <span>5 January 16</span>
                                                                </p>
                                                                <p class="pull-left">
                                                                    <i class="fa fa-eye"></i>
                                                                    <span>1,862K</span>
                                                                </p>
                                                            </div>
                                                            <div class="post-summary">
                                                                <p>Sed ut perspiciatis unde omnis iste natus error sit voluptatem accusantium doloremque laudantium, totam rem aperiam, eaque ipsa quae ab illo inventore veritatis et quasi architecto sequi nesciunt.</p>
                                                            </div>
                                                            <div class="post-button">
                                                                <a href="watch" class="secondary-button"><i class="fa fa-play-circle"></i>watch video</a>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    
                                    </div>
                            </div>
                        </section>
                        <!-- ad Section -->
                
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
            </section><!-- End Category Content-->
</asp:Content>
