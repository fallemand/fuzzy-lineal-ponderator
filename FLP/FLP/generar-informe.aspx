<%@ Page Title="" Language="C#" MasterPageFile="~/proyecto.master" AutoEventWireup="true" CodeBehind="generar-informe.aspx.cs" Inherits="FLP.generar_informe" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentProyecto" runat="server">
    <div class="panel panel-default shadow2">
        <div class="panel-heading">4. Generar Informe</div>
        <div class="panel-body">
            <p>A continuación podrá generar un informe de su proyecto</p>
            <div class="well well-lg">
                <asp:Button ID="btnGenerarInforme" runat="server" Text="Generar Informe" CssClass="btn btn-xl btn-primary center-block" OnClick="btnGenerarInforme_Click"/>
            </div>
        </div>
    </div>
</asp:Content>
