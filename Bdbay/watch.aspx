<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="watch.aspx.cs" Inherits="Bdbay.watch" %>
<%@ Register Src="~/sideAdd.ascx" TagPrefix="uc1" TagName="sideAdd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .inner-video {
            position:relative;
        }
        .SkipAdd
        {
            position:absolute;
            bottom:40px;
            right:20px;
        }
        .btnColor
        {
            border:0;
            background-color:#000;
            color:#fff;
            padding:5px 20px;
            border-radius:5px;
        }
    </style>
        <asp:PlaceHolder ID="pnlSkipAdd" runat="server"></asp:PlaceHolder>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Body" runat="server">
    <section class="mainContentv3">
            <div class="row">
                <!-- left side content area -->
                <div class="large-8 columns parentbg">
                    <div class="sidebarBg"></div>
                    <!--single inner video-->
                    <section class="content content-with-sidebar inner-video">
                        <div class="row">
                            <div class="large-12 columns inner-flex-video">
                                
                                <div class="flex-video widescreen" style="background-color:#000; ">
                                    <asp:PlaceHolder ID="plcVideo" runat="server"></asp:PlaceHolder>                                                                     
                                </div>
                                <div class="SkipAdd">
                                    <asp:Button ID="btnSkipAdd" CssClass="btnColor" OnClick="btnSkipAdd_Click" runat="server" Text="Skip Ad" />
                                </div>
                            </div>
                        </div>
                    </section>
                    <!-- single post stats -->
                    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                   
                    <section class="content content-with-sidebar SinglePostStats">
                        <!-- newest video -->
                        <div class="row">
                            <div class="large-12 columns">
                                <div class="media-object stack-for-small">
                                    <div class="media-object-section">
                                        <div class="author-img-sec">
                                            <div class="thumbnail author-single-post">
                                                <asp:Label ID="ProfilePhotos" runat="server"></asp:Label>
                                            </div>
                                            <p class="text-center">
                                                <asp:Label ID="lblUserIDName" runat="server"></asp:Label>
                                            </p>
                                        </div>
                                    </div>
                                    <div class="media-object-section object-second">
                                        <div class="author-des clearfix">
                                            <div class="post-title">
                                                <h4>
                                                    <asp:Label ID="lblTitle" runat="server"></asp:Label></h4>
                                                <p>
                                                    <span><i class="fa fa-clock-o"></i>
                                                        <asp:Label ID="lblPostingDate" runat="server"></asp:Label></span>
                                                    <span><i class="fa fa-eye"></i>
                                                        <asp:Label ID="lblview" runat="server"></asp:Label></span>
                                                    <span><i class="fa fa-thumbs-o-up"></i>
                                                        <asp:Label ID="lblLike" runat="server"></asp:Label></span>
                                                </p>
                                            </div>

                                            <div class="subscribe">
                                                <asp:Button ID="btnSubscribe" CssClass="subscribe button" runat="server" OnClick="btnSubscribe_Click" Text="Subscribe" />
                                                <asp:Button ID="btnUnsubscribe" CssClass="subscribe button" runat="server" OnClick="btnUnsubscribe_Click" Text="Unsubscribe" />
                                            </div>

                                        </div>
                                        <div class="social-share">
                                            <div class="post-like-btn clearfix">
                                                <!--  <form method="post">
                                                    <button type="submit" name="fav"><i class="fa fa-heart"></i>Add to</button>
                                                </form> -->
                                                <asp:ImageButton ID="btnlike" OnClick="btnlike_Click" ImageUrl="images/like.png" CssClass="secondary-button" Width="35px" Height="28px" runat="server" />

                                                <div class="float-right easy-share">
                                                    <asp:ImageButton ID="ImageButton1" OnClick="ImageButton1_Click" ImageUrl="~/images/f.png" Width="35" Height="35" runat="server" />
                                                    <asp:ImageButton ID="ImageButtonTwitter" OnClick="ImageButtonTwitter_Click" ImageUrl="~/images/t.png" Width="35" Height="35" runat="server" />
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </section><!-- End single post stats -->
                       
                   


                    <!-- single post description -->
                    <section class="content content-with-sidebar singlePostDescription">
                        <div class="row">
                            <div class="large-12 columns">
                                <div class="heading">
                                    <h5>Description</h5>
                                </div>
                                <div class="description showmore_one">
                                    <asp:Label ID="lblDescription" runat="server" ></asp:Label>
                                    
                                </div>
                            </div>
                        </div>
                    </section><!-- End single post description -->

       


                    <!-- Comments -->
                    <section class="content content-with-sidebar comments">
                        <div class="row">
                            <div class="large-12 columns">
                                <div class="main-heading borderBottom">
                                    <div class="row padding-14">
                                        <div class="medium-12 small-12 columns">
                                            <div class="head-title">
                                                <i class="fa fa-comments"></i>
                                                <h4>Comments <span>(<asp:Label ID="lblCommantsCount" runat="server" ></asp:Label>)</span></h4>
                                            </div>
                                        </div>
                                    </div>
                                </div>

                                <asp:Panel ID="pnlMessege" runat="server">
                                    <div class="comment-box thumb-border">
                                        <div class="media-object stack-for-small">
                                            <div class="media-object-section comment-img text-center">
                                                <div class="comment-box-img">
                                                    <asp:Image ID="ProfilePhotoCommants" runat="server" />
                                                </div>
                                                <h6><a href="#">
                                                    <asp:Label ID="lblName" runat="server"></asp:Label></a></h6>
                                            </div>
                                            <div class="media-object-section comment-textarea">
                                                <asp:TextBox ID="txtMessege" Width="100%" placeholder="Add a comment here.." TextMode="MultiLine" runat="server"></asp:TextBox>
                                                <asp:Button ID="btnSend" OnClick="btnSend_Click" runat="server" Text="Send" />

                                            </div>
                                        </div>
                                    </div>
                                </asp:Panel>
                                

                           

                                <!-- main comment -->
                                



                                <div class="comment-sort text-right">
                                    <span>Comment :</span>
                                </div>

                                <!-- main comment -->
                                
                                <div class="main-comment showmore_one">
                                  <asp:PlaceHolder ID="messegeshowplc" runat="server"></asp:PlaceHolder>
                                </div>

                            </div>
                        </div>
                    </section><!-- End Comments -->
                    

                </div><!-- end left side content area -->
                <!-- sidebar -->
                <div class="large-4 columns">
                    <aside class="secBg sidebar">
                        <div class="sidebarBg"></div>
                        <div class="row">
                           
                            <uc1:sideAdd runat="server" id="sideAdd" />  

                           
                            
                        </div>
                    </aside>
                </div><!-- end sidebar -->
            </div>
        </section>
</asp:Content>
