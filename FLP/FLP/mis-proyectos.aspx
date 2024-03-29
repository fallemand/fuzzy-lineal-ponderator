﻿<%@ Page Title="Proyectos" Language="C#" MasterPageFile="~/index.Master" AutoEventWireup="true" CodeBehind="mis-proyectos.aspx.cs" Inherits="FLP.mis_proyectos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentIndex" runat="server">
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <div class="container">
                <div class="col-md-10 col-md-offset-1">
                    <div class="panel panel-default shadow2">
                        <div class="panel-heading">Mis Proyectos</div>
                        <div class="panel-body">
                            <fieldset class="form validationGroup" role="form">
                                <div class="row">
                                    <div class="col-md-5">
                                        <div class="form-group">
                                            <input type="text" id="txtNombre" class="form-control" required="true" maxlength="60" placeholder="Nombre del Proyecto" runat="server">
                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <asp:Button ID="btnAgregar" runat="server" Text="Crear un Nuevo Proyecto" CssClass="btn btn-default btn-sm causesValidation" OnClick="btnAgregar_Click" />
                                        <asp:Button ID="btnModificar" runat="server" Text="Modificar Nombre" CssClass="btn btn-default btn-sm causesValidation" OnClick="btnModificar_Click" Visible="false" />
                                        <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" CssClass="btn btn-default btn-sm" OnClick="btnCancelar_Click" Visible="false" />
                                    </div>
                                    <div class="col-md-1">
                                        <asp:UpdateProgress runat="server" ID="PageUpdateProgress">
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
                                    <asp:Repeater ID="rptProyectos" runat="server" OnItemCommand="rptProyectos_ItemCommand">
                                        <ItemTemplate>
                                            <tr>
                                                <td><%# Eval("nombre") %></td>
                                                <td><%# Eval("fecha") %></td>
                                                <td><%# Eval("cantCriterios") %></td>
                                                <td><%# Eval("cantVariables") %></td>
                                                <td><%# Eval("cantAlternativas") %></td>
                                                <td>
                                                    <asp:LinkButton ClientIDMode="AutoID" ID="btnSeleccionar" runat="server" CssClass="editar" CommandName="seleccionar" CommandArgument='<%# Eval("idProyecto") %>'><span class="glyphicon glyphicon-play" rel="txtTooltip" title="Seleccionar" data-toggle="tooltip" data-placement="top"></span></asp:LinkButton>
                                                    <asp:LinkButton ClientIDMode="AutoID" ID="btnEditar" runat="server" CssClass="editar" CommandName="editar" CommandArgument='<%# Eval("idProyecto") %>'><span class="glyphicon glyphicon-pencil" rel="txtTooltip" title="Editar" data-toggle="tooltip" data-placement="top"></span></asp:LinkButton>
                                                    <asp:LinkButton ClientIDMode="AutoID" ID="btnEliminar" runat="server" CssClass="editar" CommandName="eliminar" CommandArgument='<%# Eval("idProyecto") %>'><span class="glyphicon glyphicon-remove eliminar" rel="txtTooltip" title="Eliminar" data-toggle="tooltip" data-placement="top"></span></asp:LinkButton>
                                                </td>
                                            </tr>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </tbody>
                            </table>
                        </div>
                    </div>
                </div>
            </div>
            </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnCancelarEliminacion" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="btnEliminar" EventName="Click" />
        </Triggers>
    </asp:UpdatePanel>
            <div class="modal fade bs-example-modal-sm" id="eliminarProyecto" tabindex="-1" role="dialog" aria-labelledby="mySmallModalLabel" aria-hidden="true">
                <div class="modal-dialog modal-sm">
                    <div class="modal-content">
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal"><span aria-hidden="true">&times;</span><span class="sr-only">Close</span></button>
                            <h4 class="modal-title" id="myModalLabel">Eliminar Proyecto</h4>
                        </div>
                        <div class="modal-body">
                            <asp:UpdatePanel runat="server">
                                <ContentTemplate>
                                    <strong>Proyecto: </strong><asp:Literal ID="litNombreProyecto" runat="server"></asp:Literal>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                            ¿Esta seguro? Se eliminarán todas las variables, alternativas y criterios asociados.
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
                    $('#eliminarProyecto').modal('show');
                };
                function closeModalEliminar() {
                    $('#eliminarProyecto').modal('toggle');
                };
            </script>
</asp:Content>
