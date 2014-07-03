<%@ Page Title="" Language="C#" MasterPageFile="~/proyecto.master" AutoEventWireup="true" CodeBehind="variables.aspx.cs" Inherits="FLP.variables" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentProyecto" runat="server">
    <div class="panel panel-default shadow2">
        <div class="panel-heading">2. Definir Variables Linguísticas</div>
        <div class="panel-body">
            <fieldset class="form" role="form">
                <div class="col-md-9">
                    <div class="col-md-6">
                        <div class="form-group">
                            <input type="text" class="form-control" name="nombre" placeholder="Nombre de la Variable">
                        </div>
                    </div>
                    <div class="col-md-3">
                        <div class="form-group">
                            <input type="text" class="form-control" name="abreviacion" placeholder="Abreviación" rel="txtTooltip" title="Máximo 3 caracteres" data-toggle="tooltip" data-placement="top">
                        </div>
                    </div>
                    <div class="col-md-2">
                        <div class="form-group colorpick" rel="txtTooltip" title="Seleccione un color" data-toggle="tooltip" data-placement="top">
                            <input type="text" class="form-control" id="color1" name="color1" value="#E1E1E1" />
                        </div>
                    </div>
                    <div class="col-md-3">
                        <div class="form-group">
                            <input type="text" class="form-control" name="a" placeholder="Valor de a" rel="txtTooltip" title="Máximo 3 caracteres" data-toggle="tooltip" data-placement="top">
                        </div>
                    </div>
                    <div class="col-md-3">
                        <div class="form-group">
                            <input type="text" class="form-control" name="b" placeholder="Valor de b" rel="txtTooltip" title="Máximo 3 caracteres" data-toggle="tooltip" data-placement="top">
                        </div>
                    </div>
                    <div class="col-md-3">
                        <div class="form-group">
                            <input type="text" class="form-control" name="c" placeholder="Valor de c" rel="txtTooltip" title="Máximo 3 caracteres" data-toggle="tooltip" data-placement="top">
                        </div>
                    </div>
                    <div class="col-md-2 clearfix">
                        <button id="btnAgregar" type="submit" class="btn btn-default btn-sm pull-right">Agregar</button>
                    </div>
                </div>
                <div class="col-md-3">
                    <div class="thumbnail" rel="txtTooltip" title="Hacer clic para ver más ejemplos" data-toggle="tooltip" data-placement="top">
                        <img src="img/theme/abcPrincipal.png" class="" />
                    </div>
                </div>
            </fieldset>
            <table class="table">
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
                    <tr>
                        <td>
                            <div class="colorPicker-picker" style="background-color: rgb(123, 209, 72);">&nbsp;</div>
                        </td>
                        <td>Destacado</td>
                        <td>Des</td>
                        <td>0</td>
                        <td>0.1</td>
                        <td>0.2</td>
                        <td>
                            <a href="#" class="editar"><span class="glyphicon glyphicon-pencil" rel="txtTooltip" title="Editar" data-toggle="tooltip" data-placement="top"></span></a>
                            <a href="#" class="editar"><span class="glyphicon glyphicon-remove eliminar" rel="txtTooltip" title="Eliminar" data-toggle="tooltip" data-placement="top"></span></a>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <div class="colorPicker-picker" style="background-color: rgb(70, 214, 219);">&nbsp;</div>
                        </td>
                        <td>No Superante</td>
                        <td>NoS</td>
                        <td>0.1</td>
                        <td>0.2</td>
                        <td>0.3</td>
                        <td>
                            <a href="#" class="editar"><span class="glyphicon glyphicon-pencil" rel="txtTooltip" title="Editar" data-toggle="tooltip" data-placement="top"></span></a>
                            <a href="#" class="editar"><span class="glyphicon glyphicon-remove eliminar" rel="txtTooltip" title="Eliminar" data-toggle="tooltip" data-placement="top"></span></a>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <div class="colorPicker-picker" style="background-color: rgb(255, 136, 124);">&nbsp;</div>
                        </td>
                        <td>Regular</td>
                        <td>Res</td>
                        <td>0.2</td>
                        <td>0.3</td>
                        <td>0.4</td>
                        <td>
                            <a href="#" class="editar"><span class="glyphicon glyphicon-pencil" rel="txtTooltip" title="Editar" data-toggle="tooltip" data-placement="top"></span></a>
                            <a href="#" class="editar"><span class="glyphicon glyphicon-remove eliminar" rel="txtTooltip" title="Eliminar" data-toggle="tooltip" data-placement="top"></span></a>
                        </td>
                    </tr>
                </tbody>
            </table>
            <div class="col-md-12">
                <div class="well well-sm">
                    <div id="variablesChart"></div>
                </div>
            </div>
        </div>
        <div class="panel-footer clearfix">
            <button class="btn btn-primary pull-right">Siguiente</button>
        </div>
    </div>
</asp:Content>
