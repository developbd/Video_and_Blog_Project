using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using Bdbay;

namespace Bdbay
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AuthConfig.RegisterOpenAuth();
            RegisterRoutes(RouteTable.Routes);
        }
        static void RegisterRoutes(RouteCollection routes)
        {
            routes.MapPageRoute("about", "about", "~/about.aspx");
            routes.MapPageRoute("blog", "blog", "~/blog.aspx");
            routes.MapPageRoute("channel", "channel", "~/channel.aspx");
            routes.MapPageRoute("click", "click", "~/click.aspx");
            routes.MapPageRoute("confirm", "confirm", "~/confirm.aspx");
            routes.MapPageRoute("Dashboard", "Dashboard", "~/Dashboard.aspx");
            routes.MapPageRoute("Home2", "Home", "~/Default.aspx");
            routes.MapPageRoute("Default", "Default", "~/Default.aspx");
            routes.MapPageRoute("delete", "delete", "~/delete.aspx");
            routes.MapPageRoute("Education", "Education", "~/Education.aspx");
            routes.MapPageRoute("Error", "Error", "~/Error.aspx");
            routes.MapPageRoute("History", "History", "~/History.aspx");
            routes.MapPageRoute("Like", "Like", "~/Like.aspx");
            routes.MapPageRoute("login", "login", "~/login.aspx");
            routes.MapPageRoute("logout", "logout", "~/logout.aspx");
            routes.MapPageRoute("Payment", "Payment", "~/Payment.aspx");
            routes.MapPageRoute("read", "read", "~/read.aspx");
            routes.MapPageRoute("Registation", "Registation", "~/Registation.aspx");
            routes.MapPageRoute("replay", "replay", "~/replay.aspx");
            routes.MapPageRoute("search", "search", "~/search.aspx");
            routes.MapPageRoute("settings", "settings", "~/settings.aspx");
            routes.MapPageRoute("subscribe", "subscribe", "~/subscribe.aspx");
            routes.MapPageRoute("upload", "upload", "~/upload.aspx");
            routes.MapPageRoute("videos", "videos", "~/videos.aspx");
            routes.MapPageRoute("watch", "watch", "~/watch.aspx");
            routes.MapPageRoute("Write", "Write", "~/Write.aspx");
            routes.MapPageRoute("Unsubscribe", "Unsubscribe", "~/Unsubscribe.aspx");
            routes.MapPageRoute("forgotpassword", "forgotpassword", "~/forgotpassword.aspx");
            routes.MapPageRoute("subscribers", "subscribers", "~/subscribers.aspx");


            routes.MapPageRoute("Home", "Admin/Home", "~/Admin/Home.aspx");
            routes.MapPageRoute("AdminorStaff", "Admin/AdminorStaff", "~/Admin/AdminorStaff.aspx");
            routes.MapPageRoute("Advertisement", "Admin/Advertisement", "~/Admin/Advertisement.aspx");
            routes.MapPageRoute("BlogSettings", "Admin/BlogSettings", "~/Admin/BlogSettings.aspx");
            routes.MapPageRoute("CreateStafforAdmin", "Admin/CreateStafforAdmin", "~/Admin/CreateStafforAdmin.aspx");
            routes.MapPageRoute("HomePageAdd", "Admin/HomePageAdd", "~/Admin/HomePageAdd.aspx");
            routes.MapPageRoute("pay", "Admin/pay", "~/Admin/pay.aspx");
            routes.MapPageRoute("PaymentSettings", "Admin/PaymentSettings", "~/Admin/PaymentSettings.aspx");
            routes.MapPageRoute("profile", "Admin/profile", "~/Admin/profile.aspx");
            routes.MapPageRoute("Show", "Admin/Show", "~/Admin/Show.aspx");
            routes.MapPageRoute("ShowAdminStaff", "Admin/ShowAdminStaff", "~/Admin/ShowAdminStaff.aspx");
            routes.MapPageRoute("ShowUser", "Admin/ShowUser", "~/Admin/ShowUser.aspx");
            routes.MapPageRoute("uploadVideo", "Admin/uploadVideo", "~/Admin/uploadVideo.aspx");
            routes.MapPageRoute("VideoSettings", "Admin/VideoSettings", "~/Admin/VideoSettings.aspx");
            routes.MapPageRoute("watch2", "Admin/watch", "~/Admin/watch.aspx");
            routes.MapPageRoute("WriteBlog", "Admin/WriteBlog", "~/Admin/WriteBlog.aspx");
            routes.MapPageRoute("Dashboard2", "Admin/Dashboard", "~/Admin/Dashboard.aspx");


        }
        void Application_End(object sender, EventArgs e)
        {
            //  Code that runs on application shutdown

        }

        void Application_Error(object sender, EventArgs e)
        {
            // Code that runs when an unhandled error occurs

        }
    }
}
