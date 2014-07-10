<%@ Page Title="" Language="C#" MasterPageFile="~/index.Master" AutoEventWireup="true" CodeBehind="mis-proyectos.aspx.cs" Inherits="FLP.mis_proyectos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentIndex" runat="server">
    <div class="container">
        <div class="col-md-10 col-md-offset-1">
            <div class="panel panel-default shadow2">
                <div class="panel-heading">Mis Proyectos</div>
                <div class="panel-body">
                    <fieldset class="form validationGroup" role="form">
                        <div class="col-md-4">
                            <div class="form-group">
                                <input type="text" id="txtNombre" class="form-control" required="true" maxlength="60" placeholder="Nombre del Proyecto" runat="server">
                                <asp:Literal ID="litError" runat="server" Visible="False"></asp:Literal>
                            </div>
                        </div>
                        <div class="col-md-2">
                            <asp:Button ID="btnAgregar" runat="server" Text="Crear un Nuevo Proyecto" CssClass="btn btn-default btn-sm causesValidation" OnClick="btnAgregar_Click" />
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
                                            <asp:LinkButton ID="btnSeleccionar" runat="server" CssClass="editar" CommandName="seleccionar" CommandArgument='<%# Eval("idProyecto") %>'><span class="glyphicon glyphicon-play" rel="txtTooltip" title="Seleccionar" data-toggle="tooltip" data-placement="top"></span></asp:LinkButton>
                                            <asp:LinkButton ID="btnEditar" runat="server" CssClass="editar" CommandName="editar" CommandArgument='<%# Eval("idProyecto") %>'><span class="glyphicon glyphicon-pencil" rel="txtTooltip" title="Editar" data-toggle="tooltip" data-placement="top"></span></asp:LinkButton>
                                            <asp:LinkButton ID="btnEliminar" runat="server" CssClass="editar" CommandName="eliminar" CommandArgument='<%# Eval("idProyecto") %>'><span class="glyphicon glyphicon-remove eliminar" rel="txtTooltip" title="Eliminar" data-toggle="tooltip" data-placement="top"></span></asp:LinkButton>
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
</asp:Content>
