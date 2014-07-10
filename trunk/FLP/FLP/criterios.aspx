<%@ Page Title="" Language="C#" MasterPageFile="~/proyecto.master" AutoEventWireup="true" CodeBehind="criterios.aspx.cs" Inherits="FLP.criterios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentProyecto" runat="server">
    <div class="panel panel-default shadow2">
        <div class="panel-heading">1. Definir Criterios</div>
        <div class="panel-body">
            <fieldset class="form validationGroup" role="form">
                <div class="col-md-4">
                    <div class="form-group">
                        <input type="text" class="form-control" id="txtNombre" placeholder="Nombre del Criterio" maxlength="60" required runat="server">
                        <asp:Literal ID="litError" runat="server" Visible="False"></asp:Literal>
                    </div>
                </div>
                <div class="col-md-2">
                    <div class="form-group">
                        <input type="text" class="form-control" id="txtAbreviacion" placeholder="Abreviación"  maxlength="4" required rel="txtTooltip" title="Máximo 4 caracteres" data-toggle="tooltip" data-placement="top" runat="server">
                    </div>
                </div>
                <div class="col-md-2">
                    <div class="form-group">
                        <input type="text" class="form-control" id="txtPeso" placeholder="Peso" rel="txtTooltip" digit="true" max="10" min="1" maxlength="2" required title="Valor entre 1 y 10" data-toggle="tooltip" data-placement="top" runat="server">
                    </div>
                </div>
                <div class="col-md-2">
                    <div class="form-group colorpick" rel="txtTooltip" title="Seleccione un color" data-toggle="tooltip" data-placement="top">
                        <input type="text" class="form-control" id="txtColor" value="#E1E1E1" runat="server" />
                    </div>
                </div>
                <div class="col-md-2">
                    <asp:Button ID="btnAgregar" runat="server" Text="Agregar" CssClass="btn btn-default btn-sm causesValidation" OnClick="btnAgregar_Click" />
                </div>
            </fieldset>
            <table class="table">
                <thead>
                    <tr>
                        <th class="col-md-1">Color</th>
                        <th class="col-md-5">Criterio</th>
                        <th class="col-md-2">Abreviación</th>
                        <th class="col-md-1">Peso</th>
                        <th class="col-md-2">Peso Relativo</th>
                        <th class="col-md-1"></th>
                    </tr>
                </thead>
                <tbody>
                    <tr>
                        <td>
                            <div class="colorPicker-picker" style="background-color: rgb(123, 209, 72);">&nbsp;</div>
                        </td>
                        <td>Mano de Obra</td>
                        <td>MO</td>
                        <td>4</td>
                        <td>0.25</td>
                        <td>
                            <a href="#" class="editar"><span class="glyphicon glyphicon-pencil" rel="txtTooltip" title="Editar" data-toggle="tooltip" data-placement="top"></span></a>
                            <a href="#" class="editar"><span class="glyphicon glyphicon-remove eliminar" rel="txtTooltip" title="Eliminar" data-toggle="tooltip" data-placement="top"></span></a>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <div class="colorPicker-picker" style="background-color: rgb(70, 214, 219);">&nbsp;</div>
                        </td>
                        <td>Beneficio</td>
                        <td>BEN</td>
                        <td>8</td>
                        <td>0.5</td>
                        <td>
                            <a href="#" class="editar"><span class="glyphicon glyphicon-pencil" rel="txtTooltip" title="Editar" data-toggle="tooltip" data-placement="top"></span></a>
                            <a href="#" class="editar"><span class="glyphicon glyphicon-remove eliminar" rel="txtTooltip" title="Eliminar" data-toggle="tooltip" data-placement="top"></span></a>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <div class="colorPicker-picker" style="background-color: rgb(255, 136, 124);">&nbsp;</div>
                        </td>
                        <td>Impacto Ambiental</td>
                        <td>IA</td>
                        <td>4</td>
                        <td>0.25</td>

                        <td>
                            <a href="#" class="editar"><span class="glyphicon glyphicon-pencil" rel="txtTooltip" title="Editar" data-toggle="tooltip" data-placement="top"></span></a>
                            <a href="#" class="editar"><span class="glyphicon glyphicon-remove eliminar" rel="txtTooltip" title="Eliminar" data-toggle="tooltip" data-placement="top"></span></a>
                        </td>
                    </tr>
                </tbody>
            </table>
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
        <div class="panel-footer clearfix ">
            <button class="btn btn-primary pull-right">Siguiente</button>
        </div>
    </div>
</asp:Content>
