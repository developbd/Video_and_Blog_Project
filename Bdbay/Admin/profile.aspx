<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/admin.Master" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="profile.aspx.cs" Inherits="Bdbay.Admin.profile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Body" runat="server">

    
    <div class="app-content content">
      <div class="content-wrapper">     


        <div class="content-body"><!-- Description -->
<section id="description" class="card">
    <div class="card-header">
      <h4 class="card-title">Description</h4>
      <a class="heading-elements-toggle"><i class="fa fa-ellipsis-v font-medium-3"></i></a>
        <div class="heading-elements">
            <ul class="list-inline mb-0">
                <li><a data-action="reload"><i class="ft-rotate-cw"></i></a></li>
                <li><a data-action="close"><i class="ft-x"></i></a></li>
            </ul>
        </div>
    </div>
    <div class="card-content">
      <div class="card-body">
          <div class="card-text">
              <asp:Image ID="profilePhoto" runat="server" />
              <asp:Label ID="lblFastname" runat="server" Font-Bold="true" Text="Fastname"></asp:Label>
              <asp:Label ID="lblLastname" runat="server" Font-Bold="true" Text="Lastname"></asp:Label><br />
             Email: <asp:Label ID="lblEmail" Font-Bold="true" runat="server" Text="Email"></asp:Label><br />
             Mobile: <asp:Label ID="lblMobile" Font-Bold="true"  runat="server" Text="Mobile"></asp:Label><br />
             Address: <asp:Label ID="lblAddress" Font-Bold="true"  runat="server" Text="Address"></asp:Label><br />
             Details: <asp:Label ID="lblDetails" Font-Bold="true"   runat="server" Text="Details"></asp:Label><br />
             Join Date: <asp:Label ID="lblJoinDate" Font-Bold="true"  runat="server" Text="Date"></asp:Label><br />
              Password: <asp:Label ID="lblPassword" Font-Bold="true"  runat="server" Text="****"></asp:Label><br /><br />
              Total Blog: <asp:Label ID="lblTotalBlog" Font-Bold="true"  runat="server" Text="54"></asp:Label><br />
              Total Video: <asp:Label ID="lblTotalVideo" Font-Bold="true"  runat="server" Text="5254"></asp:Label><br />


          </div>
      </div>
    </div>
</section>
<!--/ Description -->

<!-- Image grid -->
<section id="image-gallery" class="card">
  <div class="card-header">
    <h4 class="card-title">Blog gallery</h4>
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
  <div class="card-content">
      <div class="card-body">
          <div class="card-text">
            <p>Users All Blog are Show...</p>
          </div>
      </div>
    <div class="card-body  my-gallery" itemscope itemtype="http://schema.org/ImageGallery">
      <div class="row">
          <asp:PlaceHolder ID="pnlBlog" runat="server"></asp:PlaceHolder>              

   



      </div>
 
    </div>
  </div>
  <!--/ PhotoSwipe -->
</section>
<!--/ Image grid -->

<!-- Video grid -->
<section id="video-gallery" class="card">
  <div class="card-header">
    <h4 class="card-title">Video gallery</h4>
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
  <div class="card-content">
    <div class="card-body">
        <div class="card-text">
          <p>User All Video Show</p>
        </div>
    </div>
    <div class="card-body">
      <div class="row">
          <asp:PlaceHolder ID="pnlVideo" runat="server"></asp:PlaceHolder>              


      
        

           

           

      </div>
    </div>

  </div>
</section>
<!-- Video grid -->
        </div>
      </div>
    </div>
    <!-- ////////////////////////////////////////////////////////////////////////////-->
    
</asp:Content>
