<%@ Page Title="" Language="C#" MasterPageFile="~/profile.master" AutoEventWireup="true" EnableEventValidation="false" ValidateRequest="false" CodeBehind="Write.aspx.cs" Inherits="Bdbay.Write" %>

<%@ Register Src="~/logout.ascx" TagPrefix="uc1" TagName="logout" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
         <script type="text/javascript" src="../tiny_mce/tiny_mce.js"></script>
    <script type="text/javascript" language="javascript">
        tinyMCE.init({
            // General options
            mode: "textareas",
            theme: "advanced",
            plugins: "pagebreak,style,layer,table,save,advhr,advimage,advlink,emotions,iespell,inlinepopups",

        });
    </script>
   <script type="text/javascript">
        function CheckTextLength(text, long,id) {
            var maxlength = new Number(long); // Change number to your max length.
            if (text.value.length > maxlength) {
                text.value = text.value.substring(0, maxlength);
                alert(" Maximum " + long + " characters allowed");
                
            }
        }
    </script>
        <style type="text/css">
        .denger {
        background-color:#ff7070;        
        }
        .Drop {
        border:1px solid #292930;
        font-size:13px;
        color:#292930;
		border-radius:3px;
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="profilebody" runat="server">


    <div class="row">
                <!-- left sidebar -->
                <div class="large-4 columns">
                    <aside class="secBg sidebar">
                        <div class="row">
                            <!-- profile overview -->
                            <div class="large-12 columns">
                                <div class="widgetBox">
                                    <div class="widgetTitle">
                                        <h5>Profile Overview</h5>
                                    </div>
                                    <div class="widgetContent">
                                        <ul class="profile-overview">
                                            <li class="clearfix"><a href="Dashboard"><i class="fa fa-dashboard"></i>Dashboard</a></li>
                                            <li class="clearfix"><a href="Videos"><i class="fa fa-video-camera"></i>Videos</a></li>
                                            <li class="clearfix"><a href="Blog"><i class="fa fa-book"></i>Blog</a></li>
                                            <li class="clearfix"><a href="Subscribe"><i class="fa fa-users"></i>Subscribe</a></li>
                                            <li class="clearfix"><a href="settings"><i class="fa fa-gears"></i>Profile Settings</a></li>
                                            <li class="clearfix"><a href="about"><i class="fa fa-user"></i>About Me</a></li>
                                            <li class="clearfix"><a href="Payment"><i class="fa fa-cc-mastercard" aria-hidden="true"></i>Payment</a></li>
                                            <uc1:logout runat="server" ID="logout" />
                                        </ul>
                                    </div>
                                </div>
                            </div><!-- End profile overview -->
                        </div>
                    </aside>
                </div><!-- end sidebar -->
                <!-- right side content area -->
                <div class="large-8 columns profile-inner">
                    <!-- profile settings <asp:TextBox ID="txtDetails" TextMode="MultiLine" Height="400px" runat="server" onKeyUp="CheckTextLength(this,3500)" onChange="CheckTextLength(this,3500)"></asp:TextBox> -->
                    <section class="submit-post">
                        <div class="row secBg">
                            <div class="large-12 columns">
                                <div class="heading">
                                    <i class="fa fa-pencil-square-o"></i>
                                    <h4>
                                       Add new Blog Post</h4>
                                </div>
                                <div class="row">
                                    <div class="large-12 columns">
                                        <asp:Panel ID="pnlMessege" runat="server">                     
                                            <div class="alert callout" >
                                                <p><i class="fa fa-exclamation-triangle"></i>
                                                   <asp:Label ID="lblMessege" runat="server" ></asp:Label> </p>
                                            </div>
                                            </asp:Panel>


                                        <asp:Panel ID="pnlUpload" runat="server">
                                            <div class="row">
                                                <div class="large-12 columns">
                                                    <label>Title (100 Alphabet) <a style="color:red">*</a>
                                                        <asp:TextBox ID="txttitle" placeholder="enter you blog title..." onKeyUp="CheckTextLength(this,100)" onChange="CheckTextLength(this,100)" runat="server"></asp:TextBox>
                                                    </label>
                                                </div>                                            
                                                <div class="large-12 columns">
                                                    <label>Short Details (250 Alphabet)
                                                        <asp:TextBox ID="txtShortDetails" placeholder="enter you blog short details..." onKeyUp="CheckTextLength(this,250)" onChange="CheckTextLength(this,250)" runat="server"></asp:TextBox>
                                                    </label>
                                                </div> 
                                                <div class="large-12 columns">                                                    
                                                    <p class="extraMargin">Upload contant in to it.Upload contant in to it.Upload contant in to it.Upload contant in to it.Upload contant in to it.Upload contant in to it.</p>
                                                    <label>Upload Thambail<a style="color:red">*</a></label>
                                                    <div class="upload-video" style="height: 63px;">
                                                        <asp:FileUpload ID="ThambailUpload" Height="50px" CssClass="button" runat="server" />
                                                    </div>
                                                </div>

                                                <div class="large-4 columns">
                                                    <div class="post-meta">
                                                        <label>
                                                            Catagory: <a style="color:red">*</a>
                                                        <asp:DropDownList ID="ddlCatagory" CssClass="Drop" runat="server"></asp:DropDownList>
                                                        </label>
                                                    </div>
                                                </div>
                                                <div class="large-4 columns">
                                                                <div class="post-meta">
                                                                    <label>
                                                                        Show Commants: <a style="color:red">*</a>
                                                        <asp:DropDownList ID="ddlcommants" CssClass="Drop" runat="server">
                                                            <asp:ListItem Selected="True" Value="Enable">Enable</asp:ListItem>
                                                            <asp:ListItem Value="Disable">Disable</asp:ListItem>
                                                        </asp:DropDownList>
                                                                    </label>
                                                                </div>
                                                            </div>

                                                <div class="large-4 columns">
                                                    <div class="post-meta"> 
                                                        <label>Posting Type:<a style="color:red">*</a> 
                                                        <asp:DropDownList ID="ddlPostingType" CssClass="Drop" runat="server" DataSourceID="SqlDataSource1" DataTextField="PostingType" DataValueField="ID"></asp:DropDownList>
                                                            <asp:SqlDataSource runat="server" ID="SqlDataSource1" ConnectionString='<%$ ConnectionStrings:Settings %>' SelectCommand="SELECT * FROM [PostingType_Tbl]"></asp:SqlDataSource>
                                                        </label>
                                                    </div>
                                                </div>
                                                <div class="large-4 columns">
                                                   <div class="post-meta">
                                                                    <label>
                                                                        Language:<a style="color:red">*</a> 
                                                        <asp:DropDownList ID="ddlLanguage" CssClass="Drop" runat="server">
                                                            <asp:ListItem Value="AF">Afrikanns</asp:ListItem>
                                                            <asp:ListItem Value="SQ">Albanian</asp:ListItem>
                                                            <asp:ListItem Value="AR">Arabic</asp:ListItem>
                                                            <asp:ListItem Value="HY">Armenian</asp:ListItem>
                                                            <asp:ListItem Value="EU">Basque</asp:ListItem>
                                                            <asp:ListItem Value="BN">Bengali</asp:ListItem>
                                                            <asp:ListItem Value="BG">Bulgarian</asp:ListItem>
                                                            <asp:ListItem Value="CA">Catalan</asp:ListItem>
                                                            <asp:ListItem Value="KM">Cambodian</asp:ListItem>
                                                            <asp:ListItem Value="ZH">Chinese (Mandarin)</asp:ListItem>
                                                            <asp:ListItem Value="HR">Croation</asp:ListItem>
                                                            <asp:ListItem Value="CS">Czech</asp:ListItem>
                                                            <asp:ListItem Value="DA">Danish</asp:ListItem>
                                                            <asp:ListItem Value="NL">Dutch</asp:ListItem>
                                                            <asp:ListItem Selected="True" Value="EN">English</asp:ListItem>
                                                            <asp:ListItem Value="ET">Estonian</asp:ListItem>
                                                            <asp:ListItem Value="FJ">Fiji</asp:ListItem>
                                                            <asp:ListItem Value="FI">Finnish</asp:ListItem>
                                                            <asp:ListItem Value="FR">French</asp:ListItem>
                                                            <asp:ListItem Value="KA">Georgian</asp:ListItem>
                                                            <asp:ListItem Value="DE">German</asp:ListItem>
                                                            <asp:ListItem Value="EL">Greek</asp:ListItem>
                                                            <asp:ListItem Value="GU">Gujarati</asp:ListItem>
                                                            <asp:ListItem Value="HE">Hebrew</asp:ListItem>
                                                            <asp:ListItem Value="HI">Hindi</asp:ListItem>
                                                            <asp:ListItem Value="HU">Hungarian</asp:ListItem>
                                                            <asp:ListItem Value="IS">Icelandic</asp:ListItem>
                                                            <asp:ListItem Value="ID">Indonesian</asp:ListItem>
                                                            <asp:ListItem Value="GA">Irish</asp:ListItem>
                                                            <asp:ListItem Value="IT">Italian</asp:ListItem>
                                                            <asp:ListItem Value="JA">Japanese</asp:ListItem>
                                                            <asp:ListItem Value="JW">Javanese</asp:ListItem>
                                                            <asp:ListItem Value="KO">Korean</asp:ListItem>
                                                            <asp:ListItem Value="LA">Latin</asp:ListItem>
                                                            <asp:ListItem Value="LV">Latvian</asp:ListItem>
                                                            <asp:ListItem Value="LT">Lithuanian</asp:ListItem>
                                                            <asp:ListItem Value="MK">Macedonian</asp:ListItem>
                                                            <asp:ListItem Value="MS">Malay</asp:ListItem>
                                                            <asp:ListItem Value="ML">Malayalam</asp:ListItem>
                                                            <asp:ListItem Value="MT">Maltese</asp:ListItem>
                                                            <asp:ListItem Value="MI">Maori</asp:ListItem>
                                                            <asp:ListItem Value="MR">Marathi</asp:ListItem>
                                                            <asp:ListItem Value="MN">Mongolian</asp:ListItem>
                                                            <asp:ListItem Value="NE">Nepali</asp:ListItem>
                                                            <asp:ListItem Value="NO">Norwegian</asp:ListItem>
                                                            <asp:ListItem Value="FA">Persian</asp:ListItem>
                                                            <asp:ListItem Value="PL">Polish</asp:ListItem>
                                                            <asp:ListItem Value="PT">Portuguese</asp:ListItem>
                                                            <asp:ListItem Value="PA">Punjabi</asp:ListItem>
                                                            <asp:ListItem Value="QU">Quechua</asp:ListItem>
                                                            <asp:ListItem Value="RO">Romanian</asp:ListItem>
                                                            <asp:ListItem Value="RU">Russian</asp:ListItem>
                                                            <asp:ListItem Value="SM">Samoan</asp:ListItem>
                                                            <asp:ListItem Value="SR">Serbian</asp:ListItem>
                                                            <asp:ListItem Value="SK">Slovak</asp:ListItem>
                                                            <asp:ListItem Value="SL">Slovenian</asp:ListItem>
                                                            <asp:ListItem Value="ES">Spanish</asp:ListItem>
                                                            <asp:ListItem Value="SW">Swahili</asp:ListItem>
                                                            <asp:ListItem Value="SV">Swedish </asp:ListItem>
                                                            <asp:ListItem Value="TA">Tamil</asp:ListItem>
                                                            <asp:ListItem Value="TT">Tatar</asp:ListItem>
                                                            <asp:ListItem Value="TE">Telugu</asp:ListItem>
                                                            <asp:ListItem Value="TH">Thai</asp:ListItem>
                                                            <asp:ListItem Value="BO">Tibetan</asp:ListItem>
                                                            <asp:ListItem Value="TO">Tonga</asp:ListItem>
                                                            <asp:ListItem Value="TR">Turkish</asp:ListItem>
                                                            <asp:ListItem Value="UK">Ukranian</asp:ListItem>
                                                            <asp:ListItem Value="UR">Urdu</asp:ListItem>
                                                            <asp:ListItem Value="UZ">Uzbek</asp:ListItem>
                                                            <asp:ListItem Value="VI">Vietnamese</asp:ListItem>
                                                            <asp:ListItem Value="CY">Welsh</asp:ListItem>
                                                            <asp:ListItem Value="XH">Xhosa</asp:ListItem>
                                                        </asp:DropDownList>
                                                                    </label>
                                                                </div>
                                                </div>
                                                <div class="large-4 columns">
                                                    <div class="post-meta"> 
                                                        <label>Click to Write Blog Here, 
                                                       <asp:Button ID="btnPublish" OnClick="btnPublish_Click" CssClass="my_btn"  ForeColor="White" runat="server" Text="write" />  
                                                       <asp:Button ID="btn_Publish_Update" CssClass="denger" OnClick="btn_Publish_Update_Click"  ForeColor="White" runat="server" Text="Update" />  
                                                        </label>
                                                    </div>
                                                </div>
                                                <div class="large-4 columns">
                                                    <div class="post-meta"> 
                                                        <label> 
                                                       <asp:Label ID="lblResult" ForeColor="Red" runat="server" ></asp:Label>                                                            
                                                        </label>
                                                    </div>
                                                </div>
                                               </asp:Panel> 
                                                        
                                                        <asp:Panel ID="pnlwrite" runat="server">
                                                            <div class="large-12 columns">
                                                            <div class="post-meta">
                                                                <p>IF you want to put your custom meta Title then put here otherwise your post title will be the default meta Title</p>
                                                            </div>
                                                        </div>
                                                           
                                                            <div class="large-12 columns">
                                                                <div class="post-meta">
                                                                    <label>
                                                                        Write Blog: 
                                                             <asp:TextBox ID="txtWrite" Height="600" TextMode="MultiLine" runat="server"></asp:TextBox>
                                                                    </label>
                                                                </div>
                                                            </div>
                                                            <div class="large-4 columns">
                                                                <div class="post-meta">
                                                                    <label>
                                                                        Published:
                                                                        <asp:Button ID="btnAdd" OnClick="btnAdd_Click" CssClass="my_btn" ForeColor="White" runat="server" Text="ADD to Blog" />                                                                       
                                                                    </label>
                                                                </div>
                                                            </div>
                                                            <asp:Panel ID="pnlUpdate" runat="server">
                                                                <div class="large-4 columns">
                                                                    <div class="post-meta">
                                                                        <label>
                                                                            Update Blog:
                                                                         <asp:Button ID="btnUpdate" OnClick="btnUpdate_Click" CssClass="my_btn" ForeColor="White" runat="server" Text="Update Blog" />
                                                                        </label>
                                                                    </div>
                                                                </div>                                                                
                                                            </asp:Panel>
                                                            <div class="large-4 columns">
                                                                    <div class="post-meta">
                                                                        <label>
                                                                            Update Details:
                                                                         <asp:Button ID="Button1" CssClass="my_btn" ForeColor="White" runat="server" OnClick="Button1_Click" Text="Update Details" />
                                                                        </label>
                                                                    </div>
                                                                </div>
                                                            <div class="large-8 columns">
                                                                <label>
                                                                    Info:<asp:Label ID="lblinfoShow" runat="server" ForeColor="Red" ></asp:Label>
                                                                </label>
                                                            </div>

                                                        <div class="large-12 columns">
                                                             <label>
                                                                    Blog:<br />

                                                                 <asp:GridView ID="GridView1" ShowHeader="False" GridLines="None" runat="server" Width="100%" AutoGenerateColumns="False">
                                                                     <Columns>
                                                                         <asp:TemplateField  SortExpression="Blog_Write">                                                                            
                                                                             <ItemTemplate>
                                                                                 <a>Blog ID: <%# Eval("ID") %></a>&nbsp;&nbsp;<a href='<%# Eval("ID","write?bid="+Request.QueryString["bid"].ToString()+"&i=update&ref=Blog&uid="+Session["UserID"].ToString()+"&editid={0}") %>' style="color:forestgreen">Edit</a>&nbsp;&nbsp;<asp:LinkButton ID="LinkButton1" ForeColor="Red" CommandArgument='<%#Eval("ID") %>' OnClick="LinkButton1_Click" runat="server">Delete</asp:LinkButton>
                                                                                 <p><%# (Eval("Blog_Write").ToString().Length > 300)?(Eval("Blog_Write").ToString().Substring(0, 300) + "...") : Eval("Blog_Write") %></p>
                                                                             </ItemTemplate>
                                                                         </asp:TemplateField>

                                                                     </Columns>
                                                                 </asp:GridView>

                                                                 
                                                             </label>
                                                        </div>






                                                        </asp:Panel>                                                    
                                                                                             
                                            </div>
                             

                                    </div>
                            </div>
                        </div>
                    </section><!-- End profile settings -->
                </div><!-- end left side content area -->
            </div>
</asp:Content>
