<%@ Page Title="Variables" Language="C#" MasterPageFile="~/proyecto.master" AutoEventWireup="true" CodeBehind="variables.aspx.cs" Inherits="FLP.variables" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentProyecto" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="panel panel-default shadow2">
                <div class="panel-heading">2. Definir Variables Linguísticas</div>
                <div class="panel-body">
                    <div class="row">
                        <fieldset class="form validationGroup" role="form">
                            <div class="col-md-9">
                                <div class="row">
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <input type="text" class="form-control" id="txtNombre" rangelength="4,60" required placeholder="Nombre de la Variable" runat="server">
                                        </div>
                                    </div>
                                    <div class="col-md-3">
                                        <div class="form-group">
                                            <input type="text" class="form-control" id="txtAbreviacion" rangelength="1,4" required placeholder="Abreviación" rel="txtTooltip" title="Máximo 4 caracteres" data-toggle="tooltip" data-placement="top" runat="server">
                                        </div>
                                    </div>
                                    <div class="col-md-2">
                                        <div class="form-group colorpick" rel="txtTooltip" title="Seleccione un color" data-toggle="tooltip" data-placement="top">
                                            <input type="text" class="form-control" id="txtColor" value="#E1E1E1" runat="server" />
                                        </div>
                                    </div>
                                    <div class="col-md-1">
                                        <asp:UpdateProgress runat="server" ID="PageUpdateProgress" DisplayAfter="300">
                                            <ProgressTemplate>
                                                <img src="/img/theme/load2.gif" class="img-responsive center-block" />
                                            </ProgressTemplate>
                                        </asp:UpdateProgress>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-2 nopadding-right">
                                        <div class="form-group">
                                            <input type="number" class="form-control" id="txtA" placeholder="Valor a" number="true" rangelength="1, 6"  required rel="txtTooltip" title="Valor numérico de a. Como lo indica la imagen" data-toggle="tooltip" data-placement="top" runat="server">
                                        </div>
                                    </div>
                                    <div class="col-md-2 nopadding-right">
                                        <div class="form-group">
                                            <input type="number" class="form-control" id="txtB" placeholder="Valor b" number="true" rangelength="1, 6" required rel="txtTooltip" title="Valor numérico de b. Como lo indica la imagen" data-toggle="tooltip" data-placement="top" runat="server">
                                        </div>
                                    </div>
                                    <div class="col-md-2 nopadding-right">
                                        <div class="form-group">
                                            <input type="number" class="form-control" id="txtC" placeholder="Valor c" number="true" rangelength="1, 6"  required rel="txtTooltip" title="Valor numérico de c. Como lo indica la imagen" data-toggle="tooltip" data-placement="top" runat="server">
                                        </div>
                                    </div>
                                    <div class="col-md-4 clearfix">
                                        <asp:Button ID="btnAgregar" runat="server" Text="Agregar" CssClass="btn btn-default btn-sm causesValidation" OnClick="btnAgregar_Click" />
                                        <asp:Button ID="btnModificar" runat="server" Text="Editar" CssClass="btn btn-default btn-sm causesValidation" OnClick="btnModificar_Click" Visible="false" />
                                        <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" CssClass="btn btn-default btn-sm" OnClick="btnCancelar_Click" Visible="false" />
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-7">
                                        <asp:Panel ID="panFracaso" runat="server" CssClass="alert alert-danger alert-xs" Visible="False">
                                            <asp:Literal ID="litError" runat="server" Visible="False"></asp:Literal>
                                        </asp:Panel>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-3">
                                <div class="thumbnail" rel="txtTooltip" title="Hacer clic para ver más ejemplos" data-toggle="tooltip" data-placement="top">
                                    <img src="img/theme/abcPrincipal.png" class="" />
                                </div>
                            </div>
                        </fieldset>
                    </div>
                    <div class="row">
                        <table class="table col-md-12">
                            <thead>
                                <tr>
                                    <th class="col-md-1">Color</th>
                                    <th class="col-md-5">Variable</th>
                                    <th class="col-md-2">Abreviación</th>
                                    <th class="col-md-1">Valor a</th>
                                    <th class="col-md-1">Valor b</th>
                                    <th class="col-md-1">Valor c</th>
                                    <th class="col-md-1"></th>
                                </tr>
                            </thead>
                            <tbody>
                                <asp:Repeater ID="rptVariables" runat="server" OnItemCommand="rptProyectos_ItemCommand">
                                    <ItemTemplate>
                                        <tr>
                                            <td>
                                                <div class="colorPicker-picker" style="background-color: <%# Eval("color") %>;">&nbsp;</div>
                                            </td>
                                            <td><%# Eval("nombre") %></td>
                                            <td><%# Eval("abreviacion") %></td>
                                            <td><%# Eval("a") %></td>
                                            <td><%# Eval("b") %></td>
                                            <td><%# Eval("c") %></td>
                                            <td>
                                                <asp:LinkButton ClientIDMode="AutoID" ID="btnEditar" runat="server" CssClass="editar" CommandName="editar" CommandArgument='<%# Eval("idVariable") %>' rel="txtTooltip" title="Editar" data-toggle="tooltip" data-placement="top"><span class="glyphicon glyphicon-pencil"></span></asp:LinkButton>
                                                <asp:LinkButton ClientIDMode="AutoID" ID="btnEliminar" runat="server" CssClass="editar" CommandName="eliminar" CommandArgument='<%# Eval("idVariable") %>' rel="txtTooltip" title="Eliminar" data-toggle="tooltip" data-placement="top"><span class="glyphicon glyphicon-remove eliminar"></span></asp:LinkButton>
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </tbody>
                        </table>
                    </div>
                    <div class="row">
                        <div class="col-md-12">
                            <div class="well well-sm">
                                <div id="variablesChart"></div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="panel-footer clearfix ">
                    <asp:Button ID="btnSiguiente" runat="server" Text="Siguiente" CssClass="btn btn-primary pull-right" OnClick="btnSiguiente_Click"/>
                </div>
            </div>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnCancelarEliminacion" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="btnEliminar" EventName="Click" />
        </Triggers>
    </asp:UpdatePanel>
    <div class="modal fade bs-example-modal-sm" id="eliminarCriterio" tabindex="-1" role="dialog" aria-labelledby="mySmallModalLabel" aria-hidden="true">
        <div class="modal-dialog modal-sm">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal"><span aria-hidden="true">&times;</span><span class="sr-only">Close</span></button>
                    <h4 class="modal-title" id="myModalLabel">Eliminar Variable</h4>
                </div>
                <div class="modal-body">
                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                        <ContentTemplate>
                            <strong>Variable: </strong><asp:Literal ID="litNombreVariable" runat="server"></asp:Literal>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    No se podrá eliminar la variable si esta siendo utilizada por alguna alternativa.
                </div>
                <div class="modal-footer">
                    <asp:Button ID="btnCancelarEliminacion" runat="server" Text="Cancelar" CssClass="btn btn-default" data-dismiss="modal" OnClick="btnCancelarEliminacion_Click" />
                    <asp:Button ID="btnEliminar" runat="server" CssClass="btn btn-danger" Text="Eliminar" OnClick="btnEliminar_Click" />
                </div>
            </div>
        </div>
    </div>
    <script>
        function limpiarCampos() {
            $('.validationGroup').find('input[type=text], input[type=password], input[type=number], input[type=email], textarea').val('');
            $('#ContentIndex_ContentProyecto_txtColor').val('#E1E1E1')
        };
        function openModalEliminar() {
            $('#eliminarCriterio').modal('show');
        };
        function closeModalEliminar() {
            $('#eliminarCriterio').modal('hide');
        };
    </script>

    <script type="text/javascript">
        google.load('visualization', '1.0', { 'packages': ['corechart'] });
        function drawVariables(datos, colores) {
            // Create the data table.
            var data = google.visualization.arrayToDataTable(datos);
            //Opciones
            var options = {
                height: 250,
                colors: colores,
            };
            //Dibujar
            var chart = new google.visualization.AreaChart(document.getElementById('variablesChart'));
            chart.draw(data, options);
        };
    </script>
</asp:Content>
