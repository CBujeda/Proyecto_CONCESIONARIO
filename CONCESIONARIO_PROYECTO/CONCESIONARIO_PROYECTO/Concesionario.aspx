<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Concesionario.aspx.cs" Inherits="CONCESIONARIO_PROYECTO.Concesionario" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="Content/bootstrap.min.css" rel="stylesheet" crossorigin="anonymous">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <script src="Scripts/bootstrap.bundle.min.js" crossorigin="anonymous"></script>
    </body>
    <title>ConcesionariusMaximus</title>

</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:GridView class="table table-dark table-hover table-striped" ID="concesionarioTabla" runat="server" AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField DataField="idVehiculo" HeaderText="ID" />
                    <asp:BoundField DataField="nombreVehiculo" HeaderText="Nombre Vehiculo" />
                    <asp:BoundField DataField="tipoVehiculo" HeaderText="Tipo de Vehiculo" />
                    <asp:BoundField DataField="modelo" HeaderText="Modelo" />
                    <asp:BoundField DataField="motor" HeaderText="Motor" />
                    <asp:BoundField DataField="nombreMarca" HeaderText="Marca" />
                    <asp:BoundField DataField="pais" HeaderText="Pais" />
                    <asp:BoundField DataField="anno" HeaderText="Año" />
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
