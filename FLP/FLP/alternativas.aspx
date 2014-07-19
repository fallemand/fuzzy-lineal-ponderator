<%@ Page Language="C#" AutoEventWireup="true" Title="Alternativas" MasterPageFile="~/proyecto.master" CodeBehind="alternativas.aspx.cs" Inherits="FLP.alternativas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentProyecto" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="panel panel-default shadow2">
                <div class="panel-heading">3. Definir Alternativas</div>
                <div class="panel-body">
                    <fieldset class="form validationGroup" role="form">
                        <div class="row">
                            <div class="col-md-3">
                                <div class="form-group">
                                    <input type="text" class="form-control" id="txtNombre" rangelength="4,60" required placeholder="Nombre de la Alternativa" runat="server">
                                </div>
                            </div>
                            <div class="col-md-2">
                                <div class="form-group">
                                    <input type="text" class="form-control" id="txtAbreviacion" rangelength="1,4" required placeholder="Abreviación" rel="txtTooltip" title="Máximo 4 caracteres" data-toggle="tooltip" data-placement="top" runat="server">
                                </div>
                            </div>
                            <div class="col-md-2">
                                <div class="form-group colorpick" rel="txtTooltip" title="Seleccione un color" data-toggle="tooltip" data-placement="top">
                                    <input type="text" class="form-control" id="txtColor" value="#E1E1E1" runat="server" />
                                </div>
                            </div>
                            <div class="col-md-4 clearfix">
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
                            <asp:Repeater ID="rptValoracionesCriterios" runat="server" OnItemDataBound="rptValoracionesCriterios_ItemDataBound" >
                                <ItemTemplate>
                                    <div class="col-md-3">
                                        <div class="form-group">
                                            <asp:DropDownList ID="ddlVariables" runat="server" CssClass="form-control" required></asp:DropDownList>
                                            <asp:HiddenField ID="txtIdCriterio" runat="server" />
                                        </div>
                                    </div>
                                </ItemTemplate>
                            </asp:Repeater>
                        </div>
                        <div class="row">
                            <div class="col-md-7">
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
                                    <th class="col-md-3">Variable</th>
                                    <th class="col-md-1">Abrev</th>
                                    <asp:Repeater ID="rptCriteriosTabla" runat="server">
                                        <ItemTemplate>
                                            <th class="col-md-1"><%# Eval("abreviacion") %></th>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                    <th class="col-md-1"></th>
                                </tr>
                            </thead>
                            <tbody>
                                <asp:Repeater ID="rptAlternativas" runat="server" OnItemCommand="rptAlternativas_ItemCommand" OnItemDataBound="rptAlternativas_ItemDataBound">
                                    <ItemTemplate>
                                        <tr>
                                            <td>
                                                <div class="colorPicker-picker" style="background-color: <%# Eval("color") %>;">&nbsp;</div>
                                            </td>
                                            <td><%# Eval("nombre") %></td>
                                            <td><%# Eval("abreviacion") %></td>
                                            <asp:Repeater ID="rptValoracionAlternativa" runat="server">
                                                <ItemTemplate>
                                                    <td><%# Eval("variable.abreviacion") %></td>
                                                </ItemTemplate>
                                            </asp:Repeater>
                                            <td>
                                                <asp:LinkButton ClientIDMode="AutoID" ID="btnEditar" runat="server" CssClass="editar" CommandName="editar" CommandArgument='<%# Eval("idAlternativa") %>' rel="txtTooltip" title="Editar" data-toggle="tooltip" data-placement="top"><span class="glyphicon glyphicon-pencil"></span></asp:LinkButton>
                                                <asp:LinkButton ClientIDMode="AutoID" ID="btnEliminar" runat="server" CssClass="editar" CommandName="eliminar" CommandArgument='<%# Eval("idAlternativa") %>' rel="txtTooltip" title="Eliminar" data-toggle="tooltip" data-placement="top"><span class="glyphicon glyphicon-remove eliminar"></span></asp:LinkButton>
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
                                <div id="alternativasChart"></div>
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
    <div class="modal fade bs-example-modal-sm" id="eliminarAlternativa" tabindex="-1" role="dialog" aria-labelledby="mySmallModalLabel" aria-hidden="true">
        <div class="modal-dialog modal-sm">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal"><span aria-hidden="true">&times;</span><span class="sr-only">Close</span></button>
                    <h4 class="modal-title" id="myModalLabel">Eliminar Alternativa</h4>
                </div>
                <div class="modal-body">
                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                        <ContentTemplate>
                            <strong>Alternativa: </strong><asp:Literal ID="litNombreAlternativa" runat="server"></asp:Literal>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    ¿Esta seguro de eliminar la alternativa?
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
            $('#eliminarAlternativa').modal('show');
        };
        function closeModalEliminar() {
            $('#eliminarAlternativa').modal('hide');
        };
    </script>

    <script type="text/javascript">
        google.load('visualization', '1.0', { 'packages': ['corechart'] });
        function drawAlternativas(datos, colores) {
            // Create the data table.
            var data = google.visualization.arrayToDataTable(datos);
            //Opciones
            var options = {
                height: 250,
                colors: colores,
            };
            //Dibujar
            var chart = new google.visualization.AreaChart(document.getElementById('alternativasChart'));
            chart.draw(data, options);
        }
    </script>

</asp:Content>
