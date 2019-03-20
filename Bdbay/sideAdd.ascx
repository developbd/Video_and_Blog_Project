<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="sideAdd.ascx.cs" Inherits="Bdbay.sideAdd" %>
   <!-- ad banner widget -->
                            <div class="large-12 medium-7 medium-centered columns">
                                <div class="widgetBox">                                   
                                    <div class="widgetContent">
                                        <div class="advBanner text-center">

                                            <asp:GridView ID="GridView1" Width="100%" AutoGenerateColumns="false" GridLines="None" ShowHeader="false" runat="server" DataSourceID="SqlDataSource1">
                                                <Columns>
                                                    <asp:TemplateField>
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="btnImg" runat="server" ><a href='<%# Eval("ID","Click?={0}") %>'><img src='<%# Eval("Image") %>' alt="ads"></a></asp:LinkButton>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>

                                            <asp:SqlDataSource runat="server" ID="SqlDataSource1" ConnectionString='<%$ ConnectionStrings:Settings %>' SelectCommand="SELECT top 1 * FROM [Advertisement] where HV='Vertical' order by NEWID() "></asp:SqlDataSource>
                                        </div>
                                    </div>
                                </div>
                            </div><!-- end ad banner widget -->
                            <!-- most view Widget -->
                          <div class="large-12 medium-7 medium-centered columns">
                                    <div class="widgetBox">                                        
                                        <div class="widgetContent">
                                            <asp:PlaceHolder ID="showAdd" runat="server"></asp:PlaceHolder>

                                           


                                        </div>
                                    </div>
                                </div>