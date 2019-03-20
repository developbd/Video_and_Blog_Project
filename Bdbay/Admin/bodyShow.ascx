<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="bodyShow.ascx.cs" Inherits="Bdbay.Admin.bodyShow" %>
<%@ Register Src="~/Admin/Header.ascx" TagPrefix="uc1" TagName="Header" %>
<%@ Register Src="~/Admin/SideBar.ascx" TagPrefix="uc1" TagName="SideBar" %>

<body  class="vertical-layout vertical-menu-modern 2-columns   menu-expanded fixed-navbar" data-open="click" data-menu="vertical-menu-modern" data-col="2-columns">
    <form id="form1" runat="server">
        <uc1:Header runat="server" ID="Header" />
        <uc1:SideBar runat="server" ID="SideBar" />
    <div class="app-content content">
      <div class="content-wrapper">
       
        <div class="content-body"><!-- Zero configuration table -->
<section id="configuration">
    <div class="row">
        <div class="col-12">
            <div class="card">
                <div class="card-header">
                    <h4 class="card-title">Show Details</h4>
                    <a class="heading-elements-toggle"><i class="fa fa-ellipsis-v font-medium-3"></i></a>
                    <div class="heading-elements">
                        <ul class="list-inline mb-0">
                            <li><a data-action="collapse"><i class="ft-minus"></i></a></li>
                            <li><a data-action="reload"><i class="ft-rotate-cw"></i></a></li>
                            <li><a data-action="expand"><i class="ft-maximize"></i></a></li>
                            <li><a data-action="close"><i class="ft-x"></i></a></li>
                        </ul>
                    </div>
                </div>
                <div class="card-content collapse show">
                    <div class="card-body card-dashboard">
                        <p class="card-text">DataTables has most features enabled by defaul</p>
                        <table class="table table-striped table-bordered zero-configuration">
                            <thead>
                                <tr>
                                    <th>ID</th>
                                    <th>Title</th>
                                    <th>Post by</th>
                                    <th>Catagory</th>                                    
                                    <th>Date</th>
                                    <th>Show</th>
                                    <th>Payment</th>
                                    <th>Details</th>

                                </tr>
                            </thead>
                            <tbody>

                                <asp:PlaceHolder ID="Show" runat="server"></asp:PlaceHolder>
                                
                               

                            </tbody>
                            <tfoot>
                                <tr>
                                    <th>ID</th>
                                    <th>Title</th>
                                    <th>Post by</th>
                                    <th>Catagory</th>                                    
                                    <th>Date</th>
                                    <th>Show</th>
                                    <th>Payment</th>
                                    <th>Details</th>
                                </tr>
                            </tfoot>
                        </table>
                    </div>
                </div>
            </div>
        </div>
    </div>
</section>
<!--/ Zero configuration table -->
<!-- Default ordering table -->


    <!-- BEGIN VENDOR JS-->
    <script src="app-assets/vendors/js/vendors.min.js" type="text/javascript"></script>
    <!-- BEGIN VENDOR JS-->
    <!-- BEGIN PAGE VENDOR JS-->
    <script src="app-assets/vendors/js/tables/datatable/datatables.min.js" type="text/javascript"></script>
    <!-- END PAGE VENDOR JS-->
    <!-- BEGIN STACK JS-->
    <script src="app-assets/js/core/app-menu.min.js" type="text/javascript"></script>
    <script src="app-assets/js/core/app.min.js" type="text/javascript"></script>
    <script src="app-assets/js/scripts/customizer.min.js" type="text/javascript"></script>
    <!-- END STACK JS-->
    <!-- BEGIN PAGE LEVEL JS-->
    <script src="app-assets/js/scripts/tables/datatables/datatable-basic.min.js" type="text/javascript"></script>
    </form>
</body>