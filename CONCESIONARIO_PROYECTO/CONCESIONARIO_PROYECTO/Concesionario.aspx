<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Concesionario.aspx.cs" Inherits="CONCESIONARIO_PROYECTO.Concesionario" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="Content/bootstrap.min.css" rel="stylesheet" crossorigin="anonymous" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <script src="Scripts/bootstrap.bundle.min.js" crossorigin="anonymous"></script>
    <title>ConcesionariusMaximus</title>
</head>
<body>
    <nav class="navbar navbar-dark navbar-expand-lg bg-dark text-light">
        <div class="container-fluid">
            <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarTogglerDemo03" aria-controls="navbarTogglerDemo03" aria-expanded="false" aria-label="Toggle navigation">
                <span class="navbar-toggler-icon"></span>
            </button>
            <a class="navbar-brand" href="#">
                <img src="Imgs\kitty.png" alt="Logo" width="30" height="24" class="" />
            </a>
            <div class="collapse navbar-collapse" id="navbarScroll">
                <ul class="navbar-nav me-auto my-2 my-lg-0 navbar-nav-scroll" style="--bs-scroll-height: 100px;">
                    <li class="nav-item">
                        <a class="nav-link active" aria-current="page" href="Concesionario">Home</a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link" href="InsertConcesionario">Insertar</a>
                    </li>
                </ul>
                <form class="d-flex" role="search">
                    <input class="form-control me-2" type="search" placeholder="Search" aria-label="Search"/>
                    <button class="btn btn-outline-success" type="submit">Search</button>
                </form>
            </div>
        </div>
    </nav>
    <form id="form1" runat="server">
        <div class="container-fluid ">

            <p></p>
            <asp:GridView class="table table-dark table-hover table-striped" ID="concesionarioTabla" runat="server" AutoGenerateColumns="False" OnRowCommand="concesionarioTabla_RowCommand">
                <Columns>
                    <asp:BoundField DataField="idVehiculo" HeaderText="ID" />
                    <asp:BoundField DataField="nombreVehiculo" HeaderText="Nombre Vehiculo" />
                    <asp:BoundField DataField="tipoVehiculo" HeaderText="Tipo de Vehiculo" />
                    <asp:BoundField DataField="modelo" HeaderText="Modelo" />
                    <asp:BoundField DataField="motor" HeaderText="Motor" />
                    <asp:BoundField DataField="nombreMarca" HeaderText="Marca" />
                    <asp:BoundField DataField="pais" HeaderText="Pais" />
                    <asp:BoundField DataField="anno" HeaderText="Año Marca" />
                    <asp:ButtonField ButtonType="Button" Text="Edit" CommandName="editVehiculo" HeaderText="">
                        <ControlStyle CssClass="btn btn-primary" />
                    </asp:ButtonField>
                    <asp:ButtonField ButtonType="Button" CommandName="deleteVehiculo" HeaderText="" Text="Delete">
                        <ControlStyle CssClass="btn btn-danger" />
                    </asp:ButtonField>
                </Columns>
            </asp:GridView>
        </div>
    </form>
    <script src="Scripts/bootstrap.bundle.min.js" crossorigin="anonymous"></script>
</body>
</html>
