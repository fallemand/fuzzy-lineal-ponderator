﻿<%@ Page Title="Criterios" Language="C#" MasterPageFile="~/proyecto.master" AutoEventWireup="true" CodeBehind="criterios.aspx.cs" Inherits="FLP.criterios" %>
<%@ MasterType VirtualPath="~/proyecto.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentProyecto" runat="server">
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <div class="panel panel-default shadow2">
                <div class="panel-heading">1. Definir Criterios</div>
                <div class="panel-body">
                    <fieldset class="form validationGroup" role="form">
                        <div class="row">
                            <div class="col-md-3">
                                <div class="form-group">
                                    <input type="text" class="form-control" id="txtNombre" placeholder="Nombre del Criterio" maxlength="60" required runat="server">
                                </div>
                            </div>
                            <div class="col-md-2">
                                <div class="form-group">
                                    <input type="text" class="form-control" id="txtAbreviacion" placeholder="Abreviación" maxlength="4" required rel="txtTooltip" title="Máximo 4 caracteres" data-toggle="tooltip" data-placement="top" runat="server">
                                </div>
                            </div>
                            <div class="col-md-2">
                                <div class="form-group">
                                    <input type="number" class="form-control" id="txtPeso" placeholder="Peso" rel="txtTooltip" digit="true" max="10" min="1" maxlength="2" required title="Valor entre 1 y 10" data-toggle="tooltip" data-placement="top" runat="server">
                                </div>
                            </div>
                            <!--<div class="col-md-2 nopadding-right">
                                <div class="form-group">
                                    <asp:DropDownList ID="ddlTipoCriterio" runat="server" CssClass="form-control">
                                        <asp:ListItem Selected="True" Value="1">Max</asp:ListItem>
                                        <asp:ListItem Value="0">Min</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>-->
                            <div class="col-md-1">
                                <div class="form-group colorpick" rel="txtTooltip" title="Seleccione un color" data-toggle="tooltip" data-placement="top">
                                    <input type="text" class="form-control" id="txtColor" value="#E1E1E1" runat="server" />
                                </div>
                            </div>
                            <div class="col-md-3 nopadding-right">
                                <asp:Button ID="btnAgregar" runat="server" Text="Agregar" CssClass="btn btn-default btn-sm causesValidation" OnClick="btnAgregar_Click" />
                                <asp:Button ID="btnModificar" runat="server" Text="Editar" CssClass="btn btn-default btn-sm causesValidation" OnClick="btnModificar_Click" Visible="false" />
                                <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" CssClass="btn btn-default btn-sm" OnClick="btnCancelar_Click" Visible="false" />
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
                            <div class="col-md-5">
                                <asp:Panel ID="panFracaso" runat="server" CssClass="alert alert-danger alert-xs" Visible="False">
                                    <asp:Literal ID="litError" runat="server" Visible="False"></asp:Literal>
                                </asp:Panel>
                            </div>
                        </div>
                    </fieldset>
                    <div class="row">
                        <table class="table col-md-12">
                            <thead>
                                <tr>
                                    <th class="col-md-1">Color</th>
                                    <th class="col-md-4">Criterio</th>
                                    <th class="col-md-1">Abrev</th>
                                    <!--<th class="col-md-1">Tipo</th>-->
                                    <th class="col-md-1">Peso</th>
                                    <th class="col-md-1">Peso Rel</th>
                                    <th class="col-md-1"></th>
                                </tr>
                            </thead>
                            <tbody>
                                <asp:Repeater ID="rptCriterios" runat="server" OnItemCommand="rptProyectos_ItemCommand">
                                    <ItemTemplate>
                                        <tr>
                                            <td>
                                                <div class="colorPicker-picker" style="background-color: <%# Eval("color") %>;">&nbsp;</div>
                                            </td>
                                            <td><%# Eval("nombre") %></td>
                                            <td><%# Eval("abreviacion") %></td>
                                            <!--<td>//obtenerTipoCriterio(Eval("esTipoMax"))></td>-->
                                            <td><%# Eval("peso") %></td>
                                            <td><%# Eval("pesoRelativo") %></td>
                                            <td>
                                                <asp:LinkButton ClientIDMode="AutoID" ID="btnEditar" runat="server" CssClass="editar" CommandName="editar" CommandArgument='<%# Eval("idCriterio") %>' rel="txtTooltip" title="Editar" data-toggle="tooltip" data-placement="top"><span class="glyphicon glyphicon-pencil"></span></asp:LinkButton>
                                                <asp:LinkButton ClientIDMode="AutoID" ID="btnEliminar" runat="server" CssClass="editar" CommandName="eliminar" CommandArgument='<%# Eval("idCriterio") %>' rel="txtTooltip" title="Eliminar" data-toggle="tooltip" data-placement="top"><span class="glyphicon glyphicon-remove eliminar"></span></asp:LinkButton>
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </tbody>
                        </table>
                    </div>
                    <div class="row">
                        <div class="col-md-6 ">
                            <div class="well well-sm">
                                <div id="pesosChart1"></div>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="well well-sm">
                                <div id="pesosChart2"></div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="panel-footer clearfix ">
                    <asp:Button ID="btnSiguiente" runat="server" Text="Siguiente" CssClass="btn btn-primary pull-right" OnClick="btnSiguiente_Click" />
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
                    <h4 class="modal-title" id="myModalLabel">Eliminar Criterio</h4>
                </div>
                <div class="modal-body">
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <strong>Criterio: </strong>
                            <asp:Literal ID="litNombreCriterio" runat="server"></asp:Literal>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    ¿Esta seguro? Se eliminará el criterio de todas las alternativas
                </div>
                <div class="modal-footer">
                    <asp:Button ID="btnCancelarEliminacion" runat="server" Text="Cancelar" CssClass="btn btn-default" data-dismiss="modal" OnClick="btnCancelarEliminacion_Click" />
                    <asp:Button ID="btnEliminar" runat="server" CssClass="btn btn-danger" Text="Eliminar" OnClick="btnEliminar_Click" />
                </div>
            </div>
        </div>
    </div>
    <script>
        function openModalEliminar() {
            $('#eliminarCriterio').modal('show');
        };
        function closeModalEliminar() {
            $('#eliminarCriterio').modal('hide');
        };
    </script>

    <script type="text/javascript">
        google.load('visualization', '1.0', { 'packages': ['corechart'] });
        function drawPesosRelativos(datos, colores) {
            // Create the data table.
            var data = new google.visualization.DataTable();
            data.addColumn('string', 'Topping');
            data.addColumn('number', 'Slices');
            data.addRows(
                datos
            );
            //Opciones
            var options = {
                legend: 'none',
                backgroundColor: '#FAFAFA',
                colors: colores,
            };
            //Dibujar
            var chart = new google.visualization.PieChart(document.getElementById('pesosChart2'));
            chart.draw(data, options);
        };

        function drawPesos(datos) {
            // Create the data table.
            var data = google.visualization.arrayToDataTable(datos);
            //Opciones
            var options = {
                legend: 'none',
                backgroundColor: '#FAFAFA',
            };
            //Dibujar
            var chart = new google.visualization.ColumnChart(document.getElementById('pesosChart1'));
            chart.draw(data, options);
        };
    </script>
</asp:Content>
