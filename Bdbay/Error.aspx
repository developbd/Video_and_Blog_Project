<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="Bdbay.Error" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Body" runat="server">
     <section class="error-page">
                <div class="row secBg">
                    <div class="large-8 large-centered columns">
                        <div class="error-page-content text-center">
                            <div class="error-img text-center">
                                <img src="images/404-error.png" alt="404 page">
                                <div class="spark">
                                    <img class="flash" src="images/spark.png" alt="spark">
                                </div>
                            </div>
                            <h1>Page Not Found</h1>
                            <p>
                                <asp:Label ID="lblMessege" runat="server" ></asp:Label></p>
                        </div>
                    </div>
                </div>
            </section>
</asp:Content>
