<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SideBar.ascx.cs" Inherits="Bdbay.Admin.SideBar" %>
 <div class="main-menu menu-fixed menu-dark menu-accordion menu-shadow" data-scroll-to-active="true">
      <div class="main-menu-content">
        <ul class="navigation navigation-main" id="main-menu-navigation" data-menu="menu-navigation">

            <li><a href="http://bdbayonline.com">Bdbayonline</a></li>
            <asp:PlaceHolder ID="showSideBar" runat="server"></asp:PlaceHolder>
           
        </ul>
      </div>
    </div>