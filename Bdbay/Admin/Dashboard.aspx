<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/admin.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="Dashboard.aspx.cs" Inherits="Bdbay.Admin.Dashboard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Body" runat="server">
        <div class="app-content content">
      <div class="content-wrapper">
        <div class="content-header row">
        </div>
        <div class="content-body"><!-- fitness target -->
<div class="row">
    <div class="col-12">
        <div class="card">
            <div class="card-content">
                <div class="row">
                    <div class="col-xl-3 col-lg-6 col-md-12 border-right-blue-grey border-right-lighten-5">
                        <div class="my-1 text-center">
                            <div class="card-header mb-2 pt-0">
                                <h5 class="primary">Today Videos Post</h5>
                                <h3 class="font-large-2 text-bold-200"> <asp:Label ID="lblToadypostVideo" runat="server" ></asp:Label></h3>
                            </div>
                            <div class="card-content">
                                <ul class="list-inline clearfix pt-1 mb-0">
                                    <li class="border-right-grey border-right-lighten-2 pr-2">
                                        <h2 class="grey darken-1 text-bold-400"> <asp:Label ID="lblPublishedVideo" runat="server" ></asp:Label></h2>
                                        <span class="primary"><span class="ft-arrow-up"></span>Published</span>
                                    </li>
                                    <li class="pl-2">
                                        <h2 class="grey darken-1 text-bold-400"> <asp:Label ID="lblUnpublishedVideo" runat="server" ></asp:Label></h2>
                                        <span class="danger"><span class="ft-arrow-down"></span>UnPublished</span>
                                    </li>
                                </ul>
                            </div>
                        </div>
                    </div>
                   <div class="col-xl-3 col-lg-6 col-md-12 border-right-blue-grey border-right-lighten-5">
                        <div class="my-1 text-center">
                            <div class="card-header mb-2 pt-0">
                                <h5 class="primary">Today Blog Post</h5>
                                <h3 class="font-large-2 text-bold-200"> <asp:Label ID="lblTodayBlogPost" runat="server" ></asp:Label></h3>
                            </div>
                            <div class="card-content">
                                <ul class="list-inline clearfix pt-1 mb-0">
                                    <li class="border-right-grey border-right-lighten-2 pr-2">
                                        <h2 class="grey darken-1 text-bold-400"> <asp:Label ID="lblPubishBlog" runat="server" ></asp:Label></h2>
                                        <span class="primary"><span class="ft-arrow-up"></span>Published</span>
                                    </li>
                                    <li class="pl-2">
                                        <h2 class="grey darken-1 text-bold-400"> <asp:Label ID="lblUnpublishBlog" runat="server" ></asp:Label></h2>
                                        <span class="danger"><span class="ft-arrow-down"></span>UnPublished</span>
                                    </li>
                                </ul>
                            </div>
                        </div>
                    </div>
                    <div class="col-xl-3 col-lg-6 col-md-12 border-right-blue-grey border-right-lighten-5">
                        <div class="my-1 text-center">
                            <div class="card-header mb-2 pt-0">
                                <h5 class="warning">Total Video</h5>
                            </div>
                            <div class="card-content">
                                <ul class="list-inline clearfix pt-1 mb-0">
                                    <li>
                                        <h2 class="grey darken-1 text-bold-400">
                                            <asp:Label ID="lblTotalVideo" runat="server" ></asp:Label></h2>
                                        <span class="warning">Videos</span>
                                    </li>
                                </ul>
                            </div>
                        </div>
                    </div>
                    <div class="col-xl-3 col-lg-6 col-md-12 border-right-blue-grey border-right-lighten-5">
                        <div class="my-1 text-center">
                            <div class="card-header mb-2 pt-0">
                                <h5 class="warning">Total Blog</h5>
                            </div>
                            <div class="card-content">
                                <ul class="list-inline clearfix pt-1 mb-0">
                                    <li>
                                        <h2 class="grey darken-1 text-bold-400"> <asp:Label ID="lblTotalBlog" runat="server" ></asp:Label></h2>
                                        <span class="warning">Blog</span>
                                    </li>
                                </ul>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>



<%--<div class="row match-height">
    <div class="col-xl-8 col-lg-12">
        <div class="card">
            <div class="card-header border-0-bottom">
                <h4 class="card-title">Activity Chart <span class="text-muted text-bold-400">Weekly</span></h4>
                <a class="heading-elements-toggle"><i class="fa fa-ellipsis-v font-medium-3"></i></a>
                <div class="heading-elements">
                    <ul class="list-inline mb-0">
                        <li><a data-action="reload"><i class="ft-rotate-cw"></i></a></li>
                    </ul>
                </div>
            </div>
            <div class="card-content">
                <div class="card-body">
                    <div id="weekly-activity-chart" class="height-250"></div>
                    <ul class="list-inline text-center m-0">
                        <li>
                            <h6><i class="ft-circle danger"></i> Runnig</h6>
                        </li>
                        <li class="ml-1">
                            <h6><i class="ft-circle success"></i> Walking</h6>
                        </li>
                        <li class="ml-1">
                            <h6><i class="ft-circle warning"></i> Cycling</h6>
                        </li>
                    </ul>
                </div>
            </div>
        </div>
    </div>
    <div class="col-xl-4 col-lg-12">
        <div class="card">
            <div class="card-content">
                <div class="card-body">
                    <div id="activity-division" class="height-250 echart-container"></div>
                </div>
            </div>
        </div>
    </div>
</div>--%>



            
        </div>
      </div>
    </div>
</asp:Content>
