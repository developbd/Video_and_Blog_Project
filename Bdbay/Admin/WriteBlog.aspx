<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/admin.Master" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="WriteBlog.aspx.cs" Inherits="Bdbay.Admin.WriteBlog" %>
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
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Body" runat="server">

         <div class="app-content content">
      <div class="content-wrapper">
        <div class="content-header row">
        </div>
        <div class="content-body"><!-- Stats -->
			<div class="card-content">
                    <div class="card-body">
                        <asp:Panel ID="Panel1" runat="server">
                        <div class="row">
                            <div class="col-md-12 mb-1">
                                <fieldset class="form-group">
                                    <label for="tittle" class="font-20">Tittle(100 Character)</label>
                                    <asp:TextBox ID="txttitle" CssClass="form-control" placeholder="Enter Your Blog Tittle Here.." runat="server"></asp:TextBox>
                                </fieldset>
                            </div>
							<div class="col-md-6">
                                <fieldset class="form-group">
                                    <label for="placeTextarea" class="font-20">Short Description(250 Character)</label>
                                    <asp:TextBox ID="txtShortDetails" CssClass="form-control"  placeholder="Enter Your Blog Short Description Here.." runat="server"></asp:TextBox>
									<label>Upload Content By Yourself.Don't Copy/Paste.............</label>
                                </fieldset>                                
                            </div>
						                            
                            <div class="col-md-6">
                                <fieldset class="form-group">
                                    <label for="thumbnail" class="font-20">Upload Thumbnail</label>
                                    <asp:FileUpload ID="ThambailUpload" CssClass="form-control-file" runat="server" />
                                </fieldset>
                            </div>                      		
							
							<div class="col-md-4">
								<fieldset class="form-group position-relative">
									<label class="font-20">Category:</label>
                                    <asp:DropDownList ID="ddlCatagory" CssClass="form-control" runat="server" DataSourceID="SqlDataSource1" DataTextField="Catagoris" DataValueField="ID"></asp:DropDownList>
                                    <asp:SqlDataSource runat="server" ID="SqlDataSource1" ConnectionString='<%$ ConnectionStrings:Settings %>' SelectCommand="SELECT * FROM [Blog_Catagory_Tbl]"></asp:SqlDataSource>
                                </fieldset>
							</div>
							
							<div class="col-md-4">
								<fieldset class="form-group position-relative">
									<label class="font-20">Show Comments:</label>
									<asp:DropDownList ID="ddlcommants" CssClass="form-control" runat="server">
                                                            <asp:ListItem Selected="True" Value="Enable">Enable</asp:ListItem>
                                                            <asp:ListItem Value="Disable">Disable</asp:ListItem>
                                                        </asp:DropDownList>
								</fieldset>
							</div>
							<div class="col-md-4">
								<fieldset class="form-group position-relative">
									<label class="font-20">Language:</label>
									<asp:DropDownList ID="ddlLanguage" CssClass="form-control" runat="server">
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
								</fieldset>
							</div>
							<div class="col-md-6">
								<fieldset class="form-group position-relative">
									<label class="font-20">Posting Type:</label>
									<asp:DropDownList ID="ddlPostingType" CssClass="form-control" runat="server" DataSourceID="SqlDataSource2" DataTextField="PostingType" DataValueField="ID"></asp:DropDownList>
                                    <asp:SqlDataSource runat="server" ID="SqlDataSource2" ConnectionString='<%$ ConnectionStrings:Settings %>' SelectCommand="SELECT * FROM [PostingType_Tbl]"></asp:SqlDataSource>
								</fieldset>
							</div>
                            <div class="col-md-6">
								<fieldset class="form-group position-relative">
									<label class="font-20">Channel Selected:</label>
                                    <asp:DropDownList ID="ddlChanelSelected" CssClass="form-control" runat="server"  ></asp:DropDownList>
                                </fieldset>
							</div>
                            <asp:Label ID="lblResult" runat="server" Text="Label"></asp:Label>
							<div class="col-md-6">
                                <asp:Button ID="btnpubish" CssClass="btn btn-primary mar-15" OnClick="Button1_Click" runat="server" Text="Publish" />							
							</div>
                        </div>
                      </asp:Panel>

                        <asp:Panel ID="Panel2" runat="server">
                            <div class="row">
                            <div class="col-md-12 mb-1">
                                <label class="font-20"> Blog Write 3500 Alphabet than Click add Blog Then Write More 3500 Alphabet</label>
                                <asp:TextBox ID="txtWrite" runat="server"></asp:TextBox>
                                    </div>
                                <asp:Label ID="lblinfoShow" runat="server"></asp:Label>
                                <div class="col-md-6">
                                    <asp:Button ID="Button1"  CssClass="btn btn-primary mar-15" OnClick="Button1_Click1" runat="server" Text="Add Blog" />
                                    </div>
                                </div>
                        </asp:Panel>
                    </div>
                </div>
        </div>
      </div>
    </div>
</asp:Content>
