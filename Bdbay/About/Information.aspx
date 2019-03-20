﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Information.aspx.cs" Inherits="Bdbay.About.Information" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Site Details</title>
    <link rel="stylesheet" href="css/app.css">
    <link rel="stylesheet" href="css/theme.css">
    <link rel="stylesheet" href="css/font-awesome.min.css">
    <link href='https://fonts.googleapis.com/css?family=Open+Sans:300,400,600,700,800' rel='stylesheet' type='text/css'>
    <link rel="stylesheet" type="text/css" href="layerslider/css/layerslider.css">
    <link rel="stylesheet" href="css/owl.carousel.min.css">
    <link rel="stylesheet" href="css/owl.theme.default.min.css">
    <link rel="stylesheet" href="css/jquery.kyco.easyshare.css">
    <link rel="stylesheet" href="css/responsive.css">
    <link rel="shortcut icon" href="../videoads.png" />
</head>
<body>
<div class="off-canvas-wrapper">
    <div class="off-canvas-wrapper-inner" data-off-canvas-wrapper>
        <!--header-->
        <div class="off-canvas position-left light-off-menu" id="offCanvas-responsive" data-off-canvas>
            <div class="off-menu-close">
                <h3>Menu</h3>
                <span data-toggle="offCanvas-responsive"><i class="fa fa-times"></i></span>
            </div>
            <ul class="vertical menu off-menu" data-responsive-menu="drilldown">
                <li class="has-submenu">
                    <a href="../Default"><i class="fa fa-home"></i>Home</a>
                    <ul class="submenu menu vertical" data-submenu data-animate="slide-in-down slide-out-up">
                        <li><a href="home-v1.html"><i class="fa fa-home"></i>Home page v1</a></li>
                        <li><a href="home-v2.html"><i class="fa fa-home"></i>Home page v2</a></li>
                        <li><a href="home-v3.html"><i class="fa fa-home"></i>Home page v3</a></li>
                        <li><a href="home-v4.html"><i class="fa fa-home"></i>Home page v4</a></li>
                        <li><a href="home-v5.html"><i class="fa fa-home"></i>Home page v5</a></li>
                        <li><a href="home-v6.html"><i class="fa fa-home"></i>Home page v6</a></li>
                        <li><a href="home-v7.html"><i class="fa fa-home"></i>Home page v7</a></li>
                        <li><a href="home-v8.html"><i class="fa fa-home"></i>Home page v8</a></li>
                        <li><a href="home-v9.html"><i class="fa fa-home"></i>Home page v9</a></li>
                        <li><a href="home-v10.html"><i class="fa fa-home"></i>Home page v10</a></li>
                    </ul>
                </li>
                <li class="has-submenu" data-dropdown-menu="example1">
                    <a href="#"><i class="fa fa-film"></i>Videos</a>
                    <ul class="submenu menu vertical" data-submenu data-animate="slide-in-down slide-out-up">
                        <li><a href="single-video-v1.html"><i class="fa fa-film"></i>single video v1</a></li>
                        <li><a href="single-video-v2.html"><i class="fa fa-film"></i>single video v2</a></li>
                        <li><a href="single-video-v3.html"><i class="fa fa-film"></i>single video v3</a></li>
                        <li><a href="submit-post.html"><i class="fa fa-film"></i>submit post</a></li>
                    </ul>
                </li>
                <li><a href="categories.html"><i class="fa fa-th"></i>category</a></li>
                <li>
                    <a href="blog.html"><i class="fa fa-edit"></i>blog</a>
                    <ul class="submenu menu vertical" data-submenu data-animate="slide-in-down slide-out-up">
                        <li><a href="blog-single-post.html"><i class="fa fa-edit"></i>blog single post</a></li>
                    </ul>
                </li>
                <li>
                    <a href="#"><i class="fa fa-magic"></i>features</a>
                    <ul class="submenu menu vertical" data-submenu data-animate="slide-in-down slide-out-up">
                        <li><a href="404.html"><i class="fa fa-magic"></i>404 Page</a></li>
                        <li><a href="archives.html"><i class="fa fa-magic"></i>Archives</a></li>
                        <li><a href="login.html"><i class="fa fa-magic"></i>login</a></li>
                        <li><a href="login-forgot-pass.html"><i class="fa fa-magic"></i>Forgot Password</a></li>
                        <li><a href="login-register.html"><i class="fa fa-magic"></i>Register</a></li>
                        <li>
                            <a href="#"><i class="fa fa-magic"></i>profile</a>
                            <ul class="submenu menu vertical" data-submenu data-animate="slide-in-down slide-out-up">
                                <li><a href="profile-page-v1.html"><i class="fa fa-magic"></i>profile v1</a></li>
                                <li><a href="profile-page-v2.html"><i class="fa fa-magic"></i>profile v2</a></li>
                                <li><a href="profile-about-me.html"><i class="fa fa-magic"></i>Profile About Me</a></li>
                                <li><a href="profile-comments.html"><i class="fa fa-magic"></i>profile comments</a></li>
                                <li><a href="profile-favorite.html"><i class="fa fa-magic"></i>profile favorites</a></li>
                                <li><a href="profile-followers.html"><i class="fa fa-magic"></i>profile followers</a></li>
                                <li><a href="profile-settings.html"><i class="fa fa-magic"></i>profile settings</a></li>
                            </ul>
                        </li>
                        <li><a href="profile-video.html"><i class="fa fa-magic"></i>Author Page</a></li>
                        <li><a href="search-results.html"><i class="fa fa-magic"></i>search results</a></li>
                        <li><a href="terms-condition.html"><i class="fa fa-magic"></i>Terms &amp; Condition</a></li>
                    </ul>
                </li>
                <li><a href="about-us.html"><i class="fa fa-user"></i>about</a></li>
                <li><a href="contact-us.html"><i class="fa fa-envelope"></i>contact</a></li>
            </ul>
            <div class="responsive-search">
                <form method="post">
                    <div class="input-group">
                        <input class="input-group-field" type="text" placeholder="search Here">
                        <div class="input-group-button">
                            <button type="submit" name="search"><i class="fa fa-search"></i></button>
                        </div>
                    </div>
                </form>
            </div>
            <div class="off-social">
                <h6>Get Socialize</h6>
                <a href="#"><i class="fa fa-facebook"></i></a>
                <a href="#"><i class="fa fa-twitter"></i></a>
                <a href="#"><i class="fa fa-google-plus"></i></a>
                <a href="#"><i class="fa fa-instagram"></i></a>
                <a href="#"><i class="fa fa-vimeo"></i></a>
                <a href="#"><i class="fa fa-youtube"></i></a>
            </div>
            <div class="top-button">
                <ul class="menu">
                    <li>
                        <a href="submit-post.html">upload Video</a>
                    </li>
                    <li class="dropdown-login">
                        <a href="login.html">login/Register</a>
                    </li>
                </ul>
            </div>
        </div>
        <div class="off-canvas-content" data-off-canvas-content>
            
            <!--breadcrumbs-->
            <section id="breadcrumb" class="breadMargin">
                <div class="row">
                    <div class="large-12 columns">
                        <nav aria-label="You are here:" role="navigation">
                            <ul class="breadcrumbs">
                                <li><i class="fa fa-home"></i><a href="../Default">Home</a></li>
                                <li>
                                    <span class="show-for-sr">Current: </span> About Us
                                </li>
                            </ul>
                        </nav>
                    </div>
                </div>
            </section><!--end breadcrumbs-->

            <section class="category-content">
                <div class="row">
					<!-- sidebar -->
                    <div class="large-4 columns">
                        <aside class="secBg sidebar">
                            <div class="row">                               
                                <!-- categories -->
                                <div class="large-12 medium-7 medium-centered columns">
                                    <div class="widgetBox">                                        
                                        <div class="about_sidebar">
											<ul>
												<li><a href="about.html">About bdbay</a></li>
												<li><a href="our_team.html">Our Team</a></li>
												<li><a href="our_policy.html">Our Policy</a></li>												
												<li><a href="corporate_partner.html">Our Corporate Partners</a></li>
												<li><a href="our_sponser.html">Our Sponsers</a></li>
												<li><a href="contact.html">Contact Us</a></li>
												<li><a href="user_manual.html">User Manual</a></li>
                                                <li class="active"><a href="Information">Site Details</a></li>
											</ul>
										</div>
                                    </div>
                                </div>
                            </div>
                        </aside>
                    </div><!-- end sidebar -->
                    <!-- left side content area -->
                    <div class="large-8 columns">
                        <section class="content content-with-sidebar">
                            <!-- newest video -->
                            <div class="main-heading removeMargin">
                                <div class="row secBg padding-14 removeBorderBottom">
                                    <div class="medium-8 small-8 columns">
                                        <div class="head-title">
                                            <i class="fa fa-envelope-open" aria-hidden="true"></i>
                                            <h4>Contact Us</h4>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="row secBg">
                                <div class="large-12 columns">
                                   <div class="about_contact">
									<div class="row">
										<div class="medium-6 large-6 columns">
											<div class="contact_area">
												<ul>
													<li><span>Subscribers: </span> <asp:Label ID="lblSubscribers" ForeColor="Black" runat="server"></asp:Label></li>
													<li><span>Total View: </span> <asp:Label ID="lblView" ForeColor="Black" runat="server"></asp:Label></li>
													<li><span>Total Video's: </span> <asp:Label ID="lblVideo" ForeColor="Black" runat="server"></asp:Label></li>
													<li><span>Total Blog's: </span> <asp:Label ID="lblBlog" ForeColor="Black" runat="server"></asp:Label></li>
                                                    <li><span>Today View's: </span> <asp:Label ID="lblTodayView" ForeColor="Black" runat="server"></asp:Label></li>
												</ul>
											</div>
										</div>
										<div class="medium-6 large-6 columns">
											
										</div>
									</div>
								   </div>
                                </div>																
                            </div>
                        </section>
                    </div><!-- end left side content area -->                    
                </div>
            </section><!-- End Category Content-->
                      
        </div><!--end off canvas content-->
    </div><!--end off canvas wrapper inner-->
</div><!--end off canvas wrapper-->
<!-- script files -->
<script src="bower_components/jquery/dist/jquery.js"></script>
<script src="bower_components/what-input/what-input.js"></script>
<script src="bower_components/foundation-sites/dist/foundation.js"></script>
<script src="js/jquery.showmore.src.js" type="text/javascript"></script>
<script src="js/app.js"></script>
<script src="layerslider/js/greensock.js" type="text/javascript"></script>
<!-- LayerSlider script files -->
<script src="layerslider/js/layerslider.transitions.js" type="text/javascript"></script>
<script src="layerslider/js/layerslider.kreaturamedia.jquery.js" type="text/javascript"></script>
<script src="js/owl.carousel.min.js"></script>
<script src="js/inewsticker.js" type="text/javascript"></script>
<script src="js/jquery.kyco.easyshare.js" type="text/javascript"></script>
</body>

</html>