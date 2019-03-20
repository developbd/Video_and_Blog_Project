<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="Registation.aspx.cs" Inherits="Bdbay.Registation" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .Drop {
        border:1px solid #e6e6e6;
        font-size:13px;
        color:#676565;
        
        }
    </style>
    	<script>
    	    function olafuction() {
    	        var x = document.getElementById("Body_txtPassword");
    	        if (x.type === "password") {
    	            x.type = "text";
    	        } else {
    	            x.type = "password";
    	        }
    	    }
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Body" runat="server">

              <!-- registration -->
            <section class="registration">
                <div class="row secBg">
                    <div class="large-12 columns">
                        <div class="login-register-content">
                            <div class="row collapse borderBottom">
                                <div class="medium-6 large-centered medium-centered">
                                    <div class="page-heading text-center">
                                        <h3>User Registeration</h3>
                                      
                                    </div>
                                </div>
                            </div>
                            <div class="row" data-equalizer data-equalize-on="medium" id="test-eq">
                                
                                <div class="large-4 medium-6 columns end hide_text">gfg</div>
 
                                <div class="large-4 medium-6 columns end">
                                    <div class="register-form">
                                        <h5 class="text-center">Create your Account</h5>

                                            <div class="input-group">
                                                <span class="input-group-label"><i class="fa fa-user"></i></span>
                                                <asp:TextBox ID="txtFastName" CssClass="input-group-field" placeholder="Enter Fast Name" runat="server" ></asp:TextBox> 
                                            </div>
                                            <div class="input-group">
                                                <span class="input-group-label"><i class="fa fa-user"></i></span>
                                                <asp:TextBox ID="txtLastName" CssClass="input-group-field" placeholder="Enter Last Name" runat="server" ></asp:TextBox> 
                                            </div>
                                            <div class="input-group">
                                                <span class="input-group-label"><i class="fa fa-envelope"></i></span>
                                                 <asp:TextBox ID="txtEmail" CssClass="input-group-field" placeholder="Email" TextMode="Email" runat="server" ></asp:TextBox> 
                                            </div>                                            
                                            <div class="input-group">
                                                <span class="input-group-label"><i class="fa fa-lock"></i></span>
                                                <asp:TextBox ID="txtPassword" CssClass="input-group-field" placeholder="Password" TextMode="Password" runat="server" ></asp:TextBox> 
                                            </div>   
                                            <span style="display:inline-flex; font-weight:bold; font-size:12px;"><input type="checkbox" class="my_checkbox" onclick="olafuction()"/>Show Password</span><br/><br/>

                                            <div class="input-group">                                            
                                                <asp:DropDownList ID="ddlCountry" CssClass="Drop" runat="server">
<asp:ListItem value="0" Selected="True">Select Country</asp:ListItem>
<asp:ListItem value="AF">Afghanistan</asp:ListItem>
<asp:ListItem value="AL">Albania</asp:ListItem>
<asp:ListItem value="DZ">Algeria</asp:ListItem>
<asp:ListItem value="AS">American Samoa</asp:ListItem>
<asp:ListItem value="AD">Andorra</asp:ListItem>
<asp:ListItem value="AO">Angola</asp:ListItem>
<asp:ListItem value="AI">Anguilla</asp:ListItem>
<asp:ListItem value="AQ">Antarctica</asp:ListItem>
<asp:ListItem value="AG">Antigua And Barbuda</asp:ListItem>
<asp:ListItem value="AR">Argentina</asp:ListItem>
<asp:ListItem value="AM">Armenia</asp:ListItem>
<asp:ListItem value="AW">Aruba</asp:ListItem>
<asp:ListItem value="AU">Australia</asp:ListItem>
<asp:ListItem value="AT">Austria</asp:ListItem>
<asp:ListItem value="AZ">Azerbaijan</asp:ListItem>
<asp:ListItem value="BS">Bahamas</asp:ListItem>
<asp:ListItem value="BH">Bahrain</asp:ListItem>
<asp:ListItem value="BD">Bangladesh</asp:ListItem>
<asp:ListItem value="BB">Barbados</asp:ListItem>
<asp:ListItem value="BY">Belarus</asp:ListItem>
<asp:ListItem value="BE">Belgium</asp:ListItem>
<asp:ListItem value="BZ">Belize</asp:ListItem>
<asp:ListItem value="BJ">Benin</asp:ListItem>
<asp:ListItem value="BM">Bermuda</asp:ListItem>
<asp:ListItem value="BT">Bhutan</asp:ListItem>
<asp:ListItem value="BO">Bolivia</asp:ListItem>
<asp:ListItem value="BA">Bosnia And Herzegowina</asp:ListItem>
<asp:ListItem value="BW">Botswana</asp:ListItem>
<asp:ListItem value="BV">Bouvet Island</asp:ListItem>
<asp:ListItem value="BR">Brazil</asp:ListItem>
<asp:ListItem value="IO">British Indian Ocean Territory</asp:ListItem>
<asp:ListItem value="BN">Brunei Darussalam</asp:ListItem>
<asp:ListItem value="BG">Bulgaria</asp:ListItem>
<asp:ListItem value="BF">Burkina Faso</asp:ListItem>
<asp:ListItem value="BI">Burundi</asp:ListItem>
<asp:ListItem value="KH">Cambodia</asp:ListItem>
<asp:ListItem value="CM">Cameroon</asp:ListItem>
<asp:ListItem value="CA">Canada</asp:ListItem>
<asp:ListItem value="CV">Cape Verde</asp:ListItem>
<asp:ListItem value="KY">Cayman Islands</asp:ListItem>
<asp:ListItem value="CF">Central African Republic</asp:ListItem>
<asp:ListItem value="TD">Chad</asp:ListItem>
<asp:ListItem value="CL">Chile</asp:ListItem>
<asp:ListItem value="CN">China</asp:ListItem>
<asp:ListItem value="CX">Christmas Island</asp:ListItem>
<asp:ListItem value="CC">Cocos (Keeling) Islands</asp:ListItem>
<asp:ListItem value="CO">Colombia</asp:ListItem>
<asp:ListItem value="KM">Comoros</asp:ListItem>
<asp:ListItem value="CG">Congo</asp:ListItem>
<asp:ListItem value="CK">Cook Islands</asp:ListItem>
<asp:ListItem value="CR">Costa Rica</asp:ListItem>
<asp:ListItem value="CI">Cote D'Ivoire</asp:ListItem>
<asp:ListItem value="HR">Croatia (Local Name: Hrvatska)</asp:ListItem>
<asp:ListItem value="CU">Cuba</asp:ListItem>
<asp:ListItem value="CY">Cyprus</asp:ListItem>
<asp:ListItem value="CZ">Czech Republic</asp:ListItem>
<asp:ListItem value="DK">Denmark</asp:ListItem>
<asp:ListItem value="DJ">Djibouti</asp:ListItem>
<asp:ListItem value="DM">Dominica</asp:ListItem>
<asp:ListItem value="DO">Dominican Republic</asp:ListItem>
<asp:ListItem value="TP">East Timor</asp:ListItem>
<asp:ListItem value="EC">Ecuador</asp:ListItem>
<asp:ListItem value="EG">Egypt</asp:ListItem>
<asp:ListItem value="SV">El Salvador</asp:ListItem>
<asp:ListItem value="GQ">Equatorial Guinea</asp:ListItem>
<asp:ListItem value="ER">Eritrea</asp:ListItem>
<asp:ListItem value="EE">Estonia</asp:ListItem>
<asp:ListItem value="ET">Ethiopia</asp:ListItem>
<asp:ListItem value="FK">Falkland Islands (Malvinas)</asp:ListItem>
<asp:ListItem value="FO">Faroe Islands</asp:ListItem>
<asp:ListItem value="FJ">Fiji</asp:ListItem>
<asp:ListItem value="FI">Finland</asp:ListItem>
<asp:ListItem value="FR">France</asp:ListItem>
<asp:ListItem value="GF">French Guiana</asp:ListItem>
<asp:ListItem value="PF">French Polynesia</asp:ListItem>
<asp:ListItem value="TF">French Southern Territories</asp:ListItem>
<asp:ListItem value="GA">Gabon</asp:ListItem>
<asp:ListItem value="GM">Gambia</asp:ListItem>
<asp:ListItem value="GE">Georgia</asp:ListItem>
<asp:ListItem value="DE">Germany</asp:ListItem>
<asp:ListItem value="GH">Ghana</asp:ListItem>
<asp:ListItem value="GI">Gibraltar</asp:ListItem>
<asp:ListItem value="GR">Greece</asp:ListItem>
<asp:ListItem value="GL">Greenland</asp:ListItem>
<asp:ListItem value="GD">Grenada</asp:ListItem>
<asp:ListItem value="GP">Guadeloupe</asp:ListItem>
<asp:ListItem value="GU">Guam</asp:ListItem>
<asp:ListItem value="GT">Guatemala</asp:ListItem>
<asp:ListItem value="GN">Guinea</asp:ListItem>
<asp:ListItem value="GW">Guinea-Bissau</asp:ListItem>
<asp:ListItem value="GY">Guyana</asp:ListItem>
<asp:ListItem value="HT">Haiti</asp:ListItem>
<asp:ListItem value="HM">Heard And Mc Donald Islands</asp:ListItem>
<asp:ListItem value="VA">Holy See (Vatican City State)</asp:ListItem>
<asp:ListItem value="HN">Honduras</asp:ListItem>
<asp:ListItem value="HK">Hong Kong</asp:ListItem>
<asp:ListItem value="HU">Hungary</asp:ListItem>
<asp:ListItem value="IS">Icel And</asp:ListItem>
<asp:ListItem value="IN">India</asp:ListItem>
<asp:ListItem value="ID">Indonesia</asp:ListItem>
<asp:ListItem value="IR">Iran (Islamic Republic Of)</asp:ListItem>
<asp:ListItem value="IQ">Iraq</asp:ListItem>
<asp:ListItem value="IE">Ireland</asp:ListItem>
<asp:ListItem value="IL">Israel</asp:ListItem>
<asp:ListItem value="IT">Italy</asp:ListItem>
<asp:ListItem value="JM">Jamaica</asp:ListItem>
<asp:ListItem value="JP">Japan</asp:ListItem>
<asp:ListItem value="JO">Jordan</asp:ListItem>
<asp:ListItem value="KZ">Kazakhstan</asp:ListItem>
<asp:ListItem value="KE">Kenya</asp:ListItem>
<asp:ListItem value="KI">Kiribati</asp:ListItem>
<asp:ListItem value="KP">Korea, Dem People'S Republic</asp:ListItem>
<asp:ListItem value="KR">Korea, Republic Of</asp:ListItem>
<asp:ListItem value="KW">Kuwait</asp:ListItem>
<asp:ListItem value="KG">Kyrgyzstan</asp:ListItem>
<asp:ListItem value="LA">Lao People'S Dem Republic</asp:ListItem>
<asp:ListItem value="LV">Latvia</asp:ListItem>
<asp:ListItem value="LB">Lebanon</asp:ListItem>
<asp:ListItem value="LS">Lesotho</asp:ListItem>
<asp:ListItem value="LR">Liberia</asp:ListItem>
<asp:ListItem value="LY">Libyan Arab Jamahiriya</asp:ListItem>
<asp:ListItem value="LI">Liechtenstein</asp:ListItem>
<asp:ListItem value="LT">Lithuania</asp:ListItem>
<asp:ListItem value="LU">Luxembourg</asp:ListItem>
<asp:ListItem value="MO">Macau</asp:ListItem>
<asp:ListItem value="MK">Macedonia</asp:ListItem>
<asp:ListItem value="MG">Madagascar</asp:ListItem>
<asp:ListItem value="MW">Malawi</asp:ListItem>
<asp:ListItem value="MY">Malaysia</asp:ListItem>
<asp:ListItem value="MV">Maldives</asp:ListItem>
<asp:ListItem value="ML">Mali</asp:ListItem>
<asp:ListItem value="MT">Malta</asp:ListItem>
<asp:ListItem value="MH">Marshall Islands</asp:ListItem>
<asp:ListItem value="MQ">Martinique</asp:ListItem>
<asp:ListItem value="MR">Mauritania</asp:ListItem>
<asp:ListItem value="MU">Mauritius</asp:ListItem>
<asp:ListItem value="YT">Mayotte</asp:ListItem>
<asp:ListItem value="MX">Mexico</asp:ListItem>
<asp:ListItem value="FM">Micronesia, Federated States</asp:ListItem>
<asp:ListItem value="MD">Moldova, Republic Of</asp:ListItem>
<asp:ListItem value="MC">Monaco</asp:ListItem>
<asp:ListItem value="MN">Mongolia</asp:ListItem>
<asp:ListItem value="MS">Montserrat</asp:ListItem>
<asp:ListItem value="MA">Morocco</asp:ListItem>
<asp:ListItem value="MZ">Mozambique</asp:ListItem>
<asp:ListItem value="MM">Myanmar</asp:ListItem>
<asp:ListItem value="NA">Namibia</asp:ListItem>
<asp:ListItem value="NR">Nauru</asp:ListItem>
<asp:ListItem value="NP">Nepal</asp:ListItem>
<asp:ListItem value="NL">Netherlands</asp:ListItem>
<asp:ListItem value="AN">Netherlands Ant Illes</asp:ListItem>
<asp:ListItem value="NC">New Caledonia</asp:ListItem>
<asp:ListItem value="NZ">New Zealand</asp:ListItem>
<asp:ListItem value="NI">Nicaragua</asp:ListItem>
<asp:ListItem value="NE">Niger</asp:ListItem>
<asp:ListItem value="NG">Nigeria</asp:ListItem>
<asp:ListItem value="NU">Niue</asp:ListItem>
<asp:ListItem value="NF">Norfolk Island</asp:ListItem>
<asp:ListItem value="MP">Northern Mariana Islands</asp:ListItem>
<asp:ListItem value="NO">Norway</asp:ListItem>
<asp:ListItem value="OM">Oman</asp:ListItem>
<asp:ListItem value="PK">Pakistan</asp:ListItem>
<asp:ListItem value="PW">Palau</asp:ListItem>
<asp:ListItem value="PA">Panama</asp:ListItem>
<asp:ListItem value="PG">Papua New Guinea</asp:ListItem>
<asp:ListItem value="PY">Paraguay</asp:ListItem>
<asp:ListItem value="PE">Peru</asp:ListItem>
<asp:ListItem value="PH">Philippines</asp:ListItem>
<asp:ListItem value="PN">Pitcairn</asp:ListItem>
<asp:ListItem value="PL">Poland</asp:ListItem>
<asp:ListItem value="PT">Portugal</asp:ListItem>
<asp:ListItem value="PR">Puerto Rico</asp:ListItem>
<asp:ListItem value="QA">Qatar</asp:ListItem>
<asp:ListItem value="RE">Reunion</asp:ListItem>
<asp:ListItem value="RO">Romania</asp:ListItem>
<asp:ListItem value="RU">Russian Federation</asp:ListItem>
<asp:ListItem value="RW">Rwanda</asp:ListItem>
<asp:ListItem value="KN">Saint K Itts And Nevis</asp:ListItem>
<asp:ListItem value="LC">Saint Lucia</asp:ListItem>
<asp:ListItem value="VC">Saint Vincent, The Grenadines</asp:ListItem>
<asp:ListItem value="WS">Samoa</asp:ListItem>
<asp:ListItem value="SM">San Marino</asp:ListItem>
<asp:ListItem value="ST">Sao Tome And Principe</asp:ListItem>
<asp:ListItem value="SA">Saudi Arabia</asp:ListItem>
<asp:ListItem value="SN">Senegal</asp:ListItem>
<asp:ListItem value="SC">Seychelles</asp:ListItem>
<asp:ListItem value="SL">Sierra Leone</asp:ListItem>
<asp:ListItem value="SG">Singapore</asp:ListItem>
<asp:ListItem value="SK">Slovakia (Slovak Republic)</asp:ListItem>
<asp:ListItem value="SI">Slovenia</asp:ListItem>
<asp:ListItem value="SB">Solomon Islands</asp:ListItem>
<asp:ListItem value="SO">Somalia</asp:ListItem>
<asp:ListItem value="ZA">South Africa</asp:ListItem>
<asp:ListItem value="GS">South Georgia , S Sandwich Is.</asp:ListItem>
<asp:ListItem value="ES">Spain</asp:ListItem>
<asp:ListItem value="LK">Sri Lanka</asp:ListItem>
<asp:ListItem value="SH">St. Helena</asp:ListItem>
<asp:ListItem value="PM">St. Pierre And Miquelon</asp:ListItem>
<asp:ListItem value="SD">Sudan</asp:ListItem>
<asp:ListItem value="SR">Suriname</asp:ListItem>
<asp:ListItem value="SJ">Svalbard, Jan Mayen Islands</asp:ListItem>
<asp:ListItem value="SZ">Sw Aziland</asp:ListItem>
<asp:ListItem value="SE">Sweden</asp:ListItem>
<asp:ListItem value="CH">Switzerland</asp:ListItem>
<asp:ListItem value="SY">Syrian Arab Republic</asp:ListItem>
<asp:ListItem value="TW">Taiwan</asp:ListItem>
<asp:ListItem value="TJ">Tajikistan</asp:ListItem>
<asp:ListItem value="TZ">Tanzania, United Republic Of</asp:ListItem>
<asp:ListItem value="TH">Thailand</asp:ListItem>
<asp:ListItem value="TG">Togo</asp:ListItem>
<asp:ListItem value="TK">Tokelau</asp:ListItem>
<asp:ListItem value="TO">Tonga</asp:ListItem>
<asp:ListItem value="TT">Trinidad And Tobago</asp:ListItem>
<asp:ListItem value="TN">Tunisia</asp:ListItem>
<asp:ListItem value="TR">Turkey</asp:ListItem>
<asp:ListItem value="TM">Turkmenistan</asp:ListItem>
<asp:ListItem value="TC">Turks And Caicos Islands</asp:ListItem>
<asp:ListItem value="TV">Tuvalu</asp:ListItem>
<asp:ListItem value="UG">Uganda</asp:ListItem>
<asp:ListItem value="UA">Ukraine</asp:ListItem>
<asp:ListItem value="AE">United Arab Emirates</asp:ListItem>
<asp:ListItem value="GB">United Kingdom</asp:ListItem>
<asp:ListItem value="US">United States</asp:ListItem>
<asp:ListItem value="UM">United States Minor Is.</asp:ListItem>
<asp:ListItem value="UY">Uruguay</asp:ListItem>
<asp:ListItem value="UZ">Uzbekistan</asp:ListItem>
<asp:ListItem value="VU">Vanuatu</asp:ListItem>
<asp:ListItem value="VE">Venezuela</asp:ListItem>
<asp:ListItem value="VN">Viet Nam</asp:ListItem>
<asp:ListItem value="VG">Virgin Islands (British)</asp:ListItem>
<asp:ListItem value="VI">Virgin Islands (U.S.)</asp:ListItem>
<asp:ListItem value="WF">Wallis And Futuna Islands</asp:ListItem>
<asp:ListItem value="EH">Western Sahara</asp:ListItem>
<asp:ListItem value="YE">Yemen</asp:ListItem>
<asp:ListItem value="ZR">Zaire</asp:ListItem>
<asp:ListItem value="ZM">Zambia</asp:ListItem>
<asp:ListItem value="ZW">Zimbabwe</asp:ListItem>

                                                </asp:DropDownList>

                                                <asp:DropDownList ID="ddlGender" CssClass="Drop" runat="server">
                                                    <asp:ListItem Selected="True" Value="0"> Select Gender </asp:ListItem>
                                                    <asp:ListItem Value="Male"> Male  </asp:ListItem>
                                                    <asp:ListItem Value="Female"> Female </asp:ListItem>
                                                </asp:DropDownList>
                                            </div>                                       
                                            <span class="form-error">your email is invalid</span>
                                            <asp:Button ID="btnREG" CssClass="button expanded" OnClick="btnREG_Click" runat="server" Text="Register Now" />                                           
                                            <p class="loginclick"> <a href="login">Login here</a></p>
                                    
                                            <asp:Label ID="lblResult" runat="server" Font-Bold="true" ForeColor="Red"></asp:Label>
                                    


                                    </div>
                                </div>
                                <div class="large-4 medium-6 columns end hide_text">gfg</div>

                            </div>
                        </div>
                    </div>
                </div>
            </section>
</asp:Content>
