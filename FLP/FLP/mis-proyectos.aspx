<%@ Page Title="" Language="C#" MasterPageFile="~/index.Master" AutoEventWireup="true" CodeBehind="mis-proyectos.aspx.cs" Inherits="FLP.mis_proyectos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentIndex" runat="server">
    <div class="container">
        <div class="col-md-10 col-md-offset-1">
            <div class="panel panel-default shadow2">
                <div class="panel-heading">Mis Proyectos</div>
                <div class="panel-body">
                    <fieldset class="form" role="form">
                        <div class="col-md-4">
                            <div class="form-group">
                                <input type="text" class="form-control" name="nombre" placeholder="Nombre del Proyecto">
                            </div>
                        </div>
                        <div class="col-md-2">
                            <button id="btnAgregar" type="submit" class="btn btn-default btn-sm">Crear un Nuevo Proyecto</button>
                        </div>
                    </fieldset>
                    <hr>
                    <table class="table">
                        <thead>
                            <tr>
                                <th class="col-md-5">Nombre del Proyecto</th>
                                <th class="col-md-2">Fecha</th>
                                <th class="col-md-1">Criterios</th>
                                <th class="col-md-1">Variables</th>
                                <th class="col-md-1">Alternativas</th>
                                <th class="col-md-1"></th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr>
                                <td>Mano de Obra</td>
                                <td>MO</td>
                                <td>4</td>
                                <td>4</td>
                                <td>0.25</td>
                                <td>
                                    <a href="#" class="editar"><span class="glyphicon glyphicon-play" rel="txtTooltip" title="Seleccionar" data-toggle="tooltip" data-placement="top"></span></a>
                                    <a href="#" class="editar"><span class="glyphicon glyphicon-pencil" rel="txtTooltip" title="Editar" data-toggle="tooltip" data-placement="top"></span></a>
                                    <a href="#" class="editar"><span class="glyphicon glyphicon-remove eliminar" rel="txtTooltip" title="Eliminar" data-toggle="tooltip" data-placement="top"></span></a>
                                </td>
                            </tr>
                            <tr>
                                <td>Beneficio</td>
                                <td>BEN</td>
                                <td>8</td>
                                <td>4</td>
                                <td>0.5</td>
                                <td>
                                    <a href="#" class="editar"><span class="glyphicon glyphicon-play" rel="txtTooltip" title="Seleccionar" data-toggle="tooltip" data-placement="top"></span></a>
                                    <a href="#" class="editar"><span class="glyphicon glyphicon-pencil" rel="txtTooltip" title="Editar" data-toggle="tooltip" data-placement="top"></span></a>
                                    <a href="#" class="editar"><span class="glyphicon glyphicon-remove eliminar" rel="txtTooltip" title="Eliminar" data-toggle="tooltip" data-placement="top"></span></a>
                                </td>
                            </tr>
                            <tr>
                                <td>Impacto Ambiental</td>
                                <td>IA</td>
                                <td>4</td>
                                <td>4</td>
                                <td>0.25</td>
                                <td>
                                    <a href="#" class="editar"><span class="glyphicon glyphicon-play" rel="txtTooltip" title="Seleccionar" data-toggle="tooltip" data-placement="top"></span></a>
                                    <a href="#" class="editar"><span class="glyphicon glyphicon-pencil" rel="txtTooltip" title="Editar" data-toggle="tooltip" data-placement="top"></span></a>
                                    <a href="#" class="editar"><span class="glyphicon glyphicon-remove eliminar" rel="txtTooltip" title="Eliminar" data-toggle="tooltip" data-placement="top"></span></a>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </div>
                <div class="panel-footer clearfix ">
                    <button class="btn btn-primary pull-right">Siguiente</button>
                </div>
            </div>
        </div>

    </div>
</asp:Content>
