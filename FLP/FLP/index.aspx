<%@ Page Title="" Language="C#" MasterPageFile="~/index.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="FLP.index1" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentIndex" runat="server">
    <div class="container">
        <div id="da-slider" class="da-slider">
            <div class="da-slide">
                <h2>Simple e Intituivo</h2>
                <p>Cargue criterios, variables linguísticas y alternativas de una forma sencilla e intuitiva, con interfaces que lo guiarán paso a paso</p>
                <a href="#" onclick="$('#ContentIndex_txtNombre').focus(); return false;" class="da-link">Registrarse</a>
                <div class="da-img">
                    <img src="img/theme/simple.png" alt="image01" /></div>
            </div>
            <div class="da-slide">
                <h2>Elegantes Gráficas</h2>
                <p>Luego de la carga de datos, se generará de forma automática elegantes gráficos que representen los datos.</p>
                <a href="#" onclick="$('#ContentIndex_txtNombre').focus(); return false;" class="da-link">Registrarse</a>
                <div class="da-img">
                    <img src="img/theme/graficos.png" alt="image01" /></div>
            </div>
            <div class="da-slide">
                <h2>Obtenga Informes</h2>
                <p>Podrá generar un completo informe con datos, tablas y gráficos de sus proyectos, permitiendo imprimirlos o exportarlos.</p>
                <a href="#" onclick="$('#ContentIndex_txtNombre').focus(); return false;" class="da-link">Registrarse</a>
                <div class="da-img">
                    <img src="img/theme/informe.png" alt="image01" /></div>
            </div>
            <div class="da-slide">
                <h2>Guarde Proyectos</h2>
                <p>Almacenaremos todos sus proyectos, de forma tal que tenga acceso a ellos desde cualquier parte. Simplemente ingrese con su usuario y podrá acceder a todos ellos</p>
                <a href="#" onclick="$('#ContentIndex_txtNombre').focus(); return false;" class="da-link">Registrarse</a>
                <div class="da-img">
                    <img src="img/theme/guardar.png" alt="image01" /></div>
            </div>
            <nav class="da-arrows">
                <span class="da-arrows-prev"></span>
                <span class="da-arrows-next"></span>
            </nav>
        </div>
        <div class="col-md-8 ">
            <div class="panel panel-default">
                <div class="panel-heading">Pasos para Realizar un Proyecto</div>
                <div class="panel-body">
                    <ul class="nav nav-tabs responsive" style="margin-bottom: 15px;">
                        <li class="active"><a href="#home" data-toggle="tab">1. Definir Criterios</a></li>
                        <li class=""><a href="#profile" data-toggle="tab">2. Definir Variables</a></li>
                        <li class=""><a href="#drop" data-toggle="tab">3. Definir Alternativas</a></li>
                        <li class=""><a href="#drop" data-toggle="tab">4. Generar Informe</a></li>
                    </ul>
                    <div id="myTabContent" class="tab-content responsive">
                        <div class="tab-pane fade active in thumbnail" id="home">
                            <img src="img/theme/criterios.png" alt="criterios" />
                        </div>
                        <div class="tab-pane fade thumbnail" id="profile">
                            <img src="img/theme/variables.png" alt="variables" />
                        </div>
                        <div class="tab-pane fade thumbnail" id="drop">
                            <p>Etsy mixtape wayfarers, ethical wes anderson tofu before they sold out mcsweeney's organic lomo retro fanny pack lo-fi farm-to-table readymade. Messenger bag gentrify pitchfork tattooed craft beer, iphone skateboard locavore carles etsy salvia banksy hoodie helvetica. DIY synth PBR banksy irony. Leggings gentrify squid 8-bit cred pitchfork.</p>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="col-md-4">
            <div class="panel panel-default">
                <div class="panel-heading">Registrarse</div>
                <div class="panel-body">
                    <fieldset id="registrar" class="validationGroup">
                        <p>Por favor ingrese sus datos</p>
                        <div class="form-group">
                            <div class="input-group">
                                <span class="input-group-addon"><i class="glyphicon glyphicon-user"></i></span>
                                <input type="text" class="form-control" id="txtNombre"  minlength="5" maxlength="40" required="true" placeholder="Nombre" runat="server">
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="input-group">
                                <span class="input-group-addon"><i class="glyphicon glyphicon-envelope"></i></span>
                                <input type="text" class="form-control" id="txtEmail" email="true" maxlength="60" required="true" placeholder="Email" runat="server">
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="input-group">
                                <span class="input-group-addon"><i class="glyphicon glyphicon-lock"></i></span>
                                <input type="password" class="form-control" id="txtContrasenia" minlength="5" maxlength="20" required="true" placeholder="Contraseña" runat="server">
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="input-group">
                                <span class="input-group-addon"><i class="glyphicon glyphicon-lock"></i></span>
                                <input type="password" class="form-control" id="txtRepContrasenia" equalto="#ContentIndex_txtContrasenia" required="true" placeholder="Repita Contraseña">
                            </div>
                        </div>
                        <div class="clearfix">
                            <div class="col-xs-7">
                                <div class="form-group">
                                    <label class="checkbox nomargin-top">
                                        <input type="checkbox" id="cbTerminos" required="true" name="cbTerminos">
                                        Acuerdo con los <a href="">Términos y Condiciones</a>
                                    </label>
                                </div>
                            </div>
                            <div class="col-xs-5">
                                <asp:Button ID="btnRegistrar" runat="server" Text="Registrar" CssClass="btn btn-default pull-right causesValidation" OnClick="btnRegistrar_Click" />
                            </div>
                        </div>
                        <asp:UpdatePanel ID="pnlRegistrar" runat="server">
                            <ContentTemplate>
                                <asp:UpdateProgress runat="server" id="PageUpdateProgress">
                                    <ProgressTemplate>
                                        <div class="col-xs-12">
                                                <img src="/img/theme/load.gif" class="img-responsive center-block"/>
                                        </div>
                                    </ProgressTemplate>
                                </asp:UpdateProgress>
                                <asp:Panel ID="panExito" runat="server" CssClass="alert alert-success" Visible="False"><asp:Literal ID="litMensaje" runat="server"></asp:Literal></asp:Panel>
                                <asp:Panel ID="panFracaso" runat="server" CssClass="alert alert-danger" Visible="False"><strong><asp:Literal ID="litError" runat="server"></asp:Literal></strong></asp:Panel>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </fieldset>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
