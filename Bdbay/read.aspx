<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="read.aspx.cs" Inherits="Bdbay.read" %>

<%@ Register Src="~/sideAdd.ascx" TagPrefix="uc1" TagName="sideAdd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Body" runat="server">
    <asp:TextBox ID="txtWord" runat="server" Visible="false" TextMode="Number" >100</asp:TextBox>
    <asp:TextBox ID="txtChar" runat="server" Visible="false" TextMode="Number" >300</asp:TextBox>
            <section class="category-content">
                <div class="row">
                    <!-- left side content area -->
                    <div class="large-8 columns">
                        <div class="blog-post">
                            <div class="row secBg">
                                <div class="large-12 columns">
                                    <div class="blog-post-heading">
                                        <h3><a href="#">
                                            <asp:Label ID="lblTitle" runat="server" ></asp:Label></a></h3>
                                        <p>
                                            <span><i class="fa fa-user"></i>
                                                <asp:HyperLink ID="userName" runat="server"></asp:HyperLink>
                                            </span>
                                            <span><i class="fa fa-clock-o"></i>
                                                <asp:Label ID="lblPostingDate" runat="server" ></asp:Label></span>
                                            <span>
                                            <asp:ImageButton ID="ImageButtonfacebook" OnClick="ImageButtonfacebook_Click" ImageUrl="~/images/f.png" Width="30" Height="30" runat="server" />
                                                    <asp:ImageButton ID="ImageButtonTwitter" OnClick="ImageButtonTwitter_Click" ImageUrl="~/images/t.png" Width="30" Height="30" runat="server" />
                                           </span>
                                        </p>
                                    </div>

                                    <div class="blog-post-content">                                       
                                        <asp:Label ID="lblBlog" runat="server"></asp:Label>                                        
                                    </div>
                                </div>
                            </div>
                        </div><!-- end blog post -->
                        <!-- post written by -->
                        <div class="blog-post-written">
                            <div class="row secBg">
                                <div class="large-12 columns">
                                    <div class="media-object">
                                        <div class="media-object-section">
                                            <div class="blog-post-author-img">
                                                <asp:Image ID="BloggerImage" runat="server" />
                                            </div>
                                        </div>
                                        <div class="media-object-section">
                                            <div class="blog-post-author-des">
                                                <h5>Written by <asp:Label ID="lblwriterBy" runat="server" ></asp:Label></h5>
                                                <p>
                                                    <asp:Label ID="lblShortDetails" runat="server" ></asp:Label></p>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>  
                        
                            <div class="blog-post-written">
                                <div class="row secBg">
                                    <div class="large-12 columns">
                                        <div class="media-object">
                                            <asp:Panel ID="pnlMessege" runat="server">
                                            <div class="media-object-section">
                                                <div class="blog-post-author-img">
                                                    <asp:Image ID="ProfilePhotoCommants" runat="server" />
                                                </div>
                                            </div>
                                            <div class="media-object-section">
                                                <div class="blog-post-author-des">
                                                    <h5>
                                                        <asp:Label ID="lblUserIDName" runat="server"></asp:Label></h5>
                                                    <div class="large-12 columns">
                                                        <asp:TextBox ID="txtMessege" placeholder="Add a comment here.." Width="" Columns="100" Rows="2" TextMode="MultiLine" runat="server"></asp:TextBox>                                                    

                                                    </div>
                                                       <asp:Button ID="btnSend" runat="server" CssClass=" button success" OnClick="btnSend_Click" Text="Send" />
                                                </div>
                                            </div>
                                                 </asp:Panel>

                                            <div class="comment-sort text-right">
                                    <span>Comment :</span>
                                </div>
                                               <div class="main-comment showmore_one">
                                  <asp:PlaceHolder ID="messegeshowplc" runat="server"></asp:PlaceHolder>
                                </div>

                                        </div>
                                    </div>
                                </div>
                            </div>
                       
                                          
                     </div>
                    <div class="large-4 columns">
                        <aside class="secBg sidebar">
                            <div class="row">
                                <!-- search Widget -->
                                <uc1:sideAdd runat="server" ID="sideAdd" />
                                </div>
                                </aside>
                            </div>
                    </div>
                </section> 
                        
                    <section class="content content-with-sidebar comments" style="position:relative;">
                        <div class="row">
                            <div class="large-8 columns">
                             <%--   <asp:Panel ID="pnlMesseg3e" runat="server">
                                    <div class="comment-box thumb-border">
                                        <div class="media-object stack-for-small">
                                            <div class="media-object-section comment-img text-center">
                                                <div class="comment-box-img">
                                                    <asp:Image ID="ProfilsePhotoCommants" runat="server" />
                                                </div>
                                                <h6><a href="#">
                                                    <asp:Label ID="lblUserIDNae" runat="server"></asp:Label></a></h6>
                                            </div>
                                            <div class="media-object-section comment-textarea">
                                                <asp:TextBox ID="txtsMessege" placeholder="Add a comment here.." TextMode="MultiLine" runat="server"></asp:TextBox>
                                                <asp:Button ID="btnSsend" runat="server" OnClick="btnSend_Click" Text="Send" />

                                            </div>
                                        </div>
                                    </div>
                                </asp:Panel>--%>                           

                             

                                </div>
                            </div>
                          </section>
                       
                    
    
</asp:Content>
