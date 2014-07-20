<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="informe.aspx.cs" Inherits="FLP.informe" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>FLP | Fuzzy Lineal Ponderation</title>
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
    <meta name="viewport" content="width=device-width" />
    <link rel="stylesheet" href="css/bootstrap.css" />
    <link rel="stylesheet" href="css/estiloResultado.css" />
    <link rel="shortcut icon" href="img/theme/favicon.ico" type="image/x-icon" />
    <link rel="icon" href="img/theme/favicon.ico" type="image/x-icon" />
    <script type="text/javascript" src="https://www.google.com/jsapi"></script>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="MainScriptManager" runat="server" />
    <div class="container">
        <div class="row" style="margin-bottom: 10px; margin-top: 10px;">
            <asp:Panel ID="panFracaso" runat="server" CssClass="alert alert-danger alert-xs" Visible="False">
                <asp:Literal ID="litError" runat="server" Visible="False"></asp:Literal>
            </asp:Panel>
            <div class="col-xs-8">
                <div class="well well-sm">
                    <h4>Detalles del Proyecto</h4>
                    <p>
                        <strong>Nombre:</strong> <asp:Literal ID="litNombreProyecto" runat="server"></asp:Literal><br />
                        <strong>Usuario:</strong> <asp:Literal ID="litNombreUsuario" runat="server"></asp:Literal><br />
                        <strong>Mail:</strong> <asp:Literal ID="litEmailUsuario" runat="server"></asp:Literal><br />
                    </p>
                </div>
            </div>
            <div class="col-xs-4 text-right">
                <div class="well well-sm">
                    <img src="img/theme/logo-print.png" />
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-xs-12">
                <div class="panel panel-default">
                    <div class="panel-heading">
                        <h4>Criterios Definidos</h4>
                    </div>
                    <div class="panel-body">
                        <div class="row">
                            <div class="col-xs-8">
                                <table class="table">
                                    <thead>
                                        <tr>
                                            <th class="col-xs-1">Color</th>
                                            <th class="col-md-5">Criterio</th>
                                            <th class="col-md-2">Abrev</th>
                                            <th class="col-md-1">Peso</th>
                                            <th class="col-md-2">Peso Rel</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <asp:Repeater ID="rptCriterios" runat="server">
                                            <ItemTemplate>
                                                <tr>
                                                    <td class="col-xs-1">
                                                        <div class="colorPicker-picker" style="background-color: <%# Eval("color") %>;">&nbsp;</div>
                                                    </td>
                                                    <td><%# Eval("nombre") %></td>
                                                    <td><%# Eval("abreviacion") %></td>
                                                    <td><%# Eval("peso") %></td>
                                                    <td><%# Eval("pesoRelativo") %></td>
                                                </tr>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </tbody>
                                </table>
                            </div>
                            <div class="col-xs-4">
                                <div class="well well-sm">
                                    <div id="criteriosChart"></div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-xs-12">
                <div class="panel panel-default">
                    <div class="panel-heading">
                        <h4>Variables Definidas</h4>
                    </div>
                    <div class="panel-body">
                        <div class="row">
                            <div class="col-xs-12">
                                <table class="table">
                                    <thead>
                                        <tr>
                                            <th class="col-md-1">Color</th>
                                            <th class="col-md-5">Variable</th>
                                            <th class="col-md-2">Abrev</th>
                                            <th class="col-md-1">Valor a</th>
                                            <th class="col-md-1">Valor b</th>
                                            <th class="col-md-1">Valor c</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <asp:Repeater ID="rptVariables" runat="server">
                                            <ItemTemplate>
                                                <tr>
                                                    <td class="col-md-1">
                                                        <div class="colorPicker-picker" style="background-color: <%# Eval("color") %>;">&nbsp;</div>
                                                    </td>
                                                    <td><%# Eval("nombre") %></td>
                                                    <td><%# Eval("abreviacion") %></td>
                                                    <td><%# Eval("a") %></td>
                                                    <td><%# Eval("b") %></td>
                                                    <td><%# Eval("c") %></td>
                                                </tr>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </tbody>
                                </table>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-xs-12">
                                <div id="variablesChart">
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <div class="row">
            <div class="col-xs-12">
                <div class="panel panel-default">
                    <div class="panel-heading">
                        <h4>Alternativas Definidas</h4>
                    </div>
                    <div class="panel-body">
                        <div class="row">
                            <div class="col-xs-12">
                                <table class="table">
                                   <thead>
                                        <tr>
                                            <th class="col-md-1">Color</th>
                                            <th class="col-md-3">Variable</th>
                                            <th class="col-md-1">Abrev</th>
                                            <asp:Repeater ID="rptAlternativasTh" runat="server">
                                                <ItemTemplate>
                                                    <th class="col-md-1"><%# Eval("abreviacion") %> (<%# Eval("peso") %>)</th>
                                                </ItemTemplate>
                                            </asp:Repeater>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <asp:Repeater ID="rptAlternativasTd" runat="server" OnItemDataBound="rptAlternativasTd_ItemDataBound">
                                            <ItemTemplate>
                                                <tr>
                                                    <td class="col-md-1">
                                                        <div class="colorPicker-picker" style="background-color: <%# Eval("color") %>;">&nbsp;</div>
                                                    </td>
                                                    <td><%# Eval("nombre") %></td>
                                                    <td><%# Eval("abreviacion") %></td>
                                                    <asp:Repeater ID="rptAlternativaTdValoraciones" runat="server">
                                                        <ItemTemplate>
                                                            <td><%# Eval("variable.abreviacion") %></td>
                                                        </ItemTemplate>
                                                    </asp:Repeater>
                                                </tr>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </tbody>
                                </table>
                            </div>

                        </div>
                        <div class="row">
                            <div class="col-xs-12">
                                <div id="alternativasChart">
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>



        <table class="table table-bordered">
            <thead>
                <tr>
                    <th>
                        <h4>Service</h4>
                    </th>
                    <th>
                        <h4>Description</h4>
                    </th>
                    <th>
                        <h4>Hrs/Qty</h4>
                    </th>
                    <th>
                        <h4>Rate/Price</h4>
                    </th>
                    <th>
                        <h4>Sub Total</h4>
                    </th>
                </tr>
            </thead>
            <tbody>
                <tr>
                    <td>Article</td>
                    <td><a href="#">Title of your article here</a></td>
                    <td class="text-right">-</td>
                    <td class="text-right">$200.00</td>
                    <td class="text-right">$200.00</td>
                </tr>
                <tr>
                    <td>Template Design</td>
                    <td><a href="#">Details of project here</a></td>
                    <td class="text-right">10</td>
                    <td class="text-right">75.00</td>
                    <td class="text-right">$750.00</td>
                </tr>
                <tr>
                    <td>Development</td>
                    <td><a href="#">WordPress Blogging theme</a></td>
                    <td class="text-right">5</td>
                    <td class="text-right">50.00</td>
                    <td class="text-right">$250.00</td>
                </tr>
            </tbody>
        </table>

        <div class="row text-right">
            <div class="col-xs-2 col-xs-offset-8">
                <p>
                    <strong>Sub Total :
                        <br>
                        TAX :
                        <br>
                        Total :
                        <br>
                    </strong>
                </p>
            </div>
            <div class="col-xs-2">
                <strong>$1200.00
                    <br>
                    N/A
                    <br>
                    $1200.00
                    <br>
                </strong>
            </div>
        </div>


        <div class="row">
            <div class="col-xs-5">
                <div class="panel panel-info">
                    <div class="panel-heading">
                        <h4>Bank details</h4>
                    </div>
                    <div class="panel-body">
                        <p>Your Name</p>
                        <p>Bank Name</p>
                        <p>SWIFT : --------</p>
                        <p>Account Number : --------</p>
                        <p>IBAN : --------</p>
                    </div>
                </div>
            </div>
            <div class="col-xs-7">
                <div class="span7">
                    <div class="panel panel-info">
                        <div class="panel-heading">
                            <h4>Contact Details</h4>
                        </div>
                        <div class="panel-body">
                            <p>
                                Email : you@example.com
                                <br>
                                <br>
                                Mobile : --------
                                <br>
                                <br>
                                Twitter  : <a href="https://twitter.com/tahirtaous">@TahirTaous</a>
                            </p>
                            <h4>Payment should be mabe by Bank Transfer</h4>
                        </div>
                    </div>
                </div>
            </div>
        </div>

    </div>
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
            chartArea: { 'width': '100%', 'height': '95%' },
            height: '130',
            width: '165',
        };
        //Dibujar
        var chart = new google.visualization.PieChart(document.getElementById('criteriosChart'));
        chart.draw(data, options);
    };
    function drawVariables(datos, colores) {
        // Create the data table.
        var data = google.visualization.arrayToDataTable(datos);
        //Opciones
        var options = {
            height: 150,
            width: 600,
            chartArea: { 'height': '80%' },
            colors: colores,
        };
        //Dibujar
        var chart = new google.visualization.AreaChart(document.getElementById('variablesChart'));
        chart.draw(data, options);
    };
    function drawAlternativas(datos, colores) {
        // Create the data table.
        var data = google.visualization.arrayToDataTable(datos);
        //Opciones
        var options = {
            height: 150,
            width: 600,
            chartArea: { 'height': '80%' },
            colors: colores,
        };
        //Dibujar
        var chart = new google.visualization.AreaChart(document.getElementById('alternativasChart'));
        chart.draw(data, options);
    };
    </script>
         </form>
</body>
</html>
