<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="Like.aspx.cs" Inherits="Bdbay.Like" %>

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
                                        <p class="pull-left">
                                            <asp:Label ID="lblMessege" runat="server"></asp:Label>
                                        </p>
                                    </div>
                                    <div class="tabs-content" data-tabs-content="newVideos">
                                        <div class="tabs-panel is-active" id="new-all">
                                            <div class="row list-group">
                                                <asp:PlaceHolder ID="likeShow" runat="server"></asp:PlaceHolder>
                                            </div>
                                        </div>
                                    </div>

                                </div>
                            </div>
                        </section>
                        <!-- ad Section -->

                        <%--<div class="googleAdv">
                            <a href="#"><img src="images/goodleadv.png" alt="googel ads"></a>
                        </div>--%>
                        
                        <!-- End ad Section -->
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
