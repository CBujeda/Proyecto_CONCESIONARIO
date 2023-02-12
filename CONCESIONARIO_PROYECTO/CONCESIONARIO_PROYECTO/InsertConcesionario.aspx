<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InsertConcesionario.aspx.cs" Inherits="CONCESIONARIO_PROYECTO.InsertConcesionario" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="Content/bootstrap.min.css" rel="stylesheet" crossorigin="anonymous" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <script src="Scripts/bootstrap.bundle.min.js" crossorigin="anonymous"></script>
    <title>ConcesionariusMaximusInsert</title>
</head>
<body>
    <%-- Navbar --%>
    <nav class="navbar navbar-dark navbar-expand-lg bg-dark text-light">
        <div class="container-fluid">
            <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarTogglerDemo03" aria-controls="navbarTogglerDemo03" aria-expanded="false" aria-label="Toggle navigation">
                <span class="navbar-toggler-icon"></span>
            </button>
            <a class="navbar-brand" href="#">
                <img src="Imgs\vaporeon.png" alt="Logo" width="40" height="34" class="" />
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
                    <input class="form-control me-2" type="search" placeholder="Search" aria-label="Search" />
                    <button class="btn btn-outline-success" type="submit">Search</button>
                </form>
            </div>
        </div>
    </nav>
    <form id="form1" runat="server">
        <div class="container-fluid ">
            <div class="row">
                <div class="col-12">
                    <div class="col">
                        <a href="Concesionario">
                            <svg xmlns="http://www.w3.org/2000/svg" width="30" height="30" fill="black" class="bi bi-caret-left-square" viewBox="0 0 16 16">
                                <path d="M14 1a1 1 0 0 1 1 1v12a1 1 0 0 1-1 1H2a1 1 0 0 1-1-1V2a1 1 0 0 1 1-1h12zM2 0a2 2 0 0 0-2 2v12a2 2 0 0 0 2 2h12a2 2 0 0 0 2-2V2a2 2 0 0 0-2-2H2z" />
                                <path d="M10.205 12.456A.5.5 0 0 0 10.5 12V4a.5.5 0 0 0-.832-.374l-4.5 4a.5.5 0 0 0 0 .748l4.5 4a.5.5 0 0 0 .537.082z" />
                            </svg>
                        </a>
                    </div>
                    <div class="row">
                        <div class="col">
                            <div class="row justify-content-center">
                                <div class="col-6">
                                    <h1>Añadir Vehiculo</h1>
                                    <label class="form-label">Nombre Vehiculo</label>
                                    <asp:TextBox ID="nombreVehiculo" class="form-control" runat="server"></asp:TextBox>

                                    <label class="form-label">Tipo</label>
                                    <asp:TextBox ID="tipoVehiculo" class="form-control" runat="server"></asp:TextBox>

                                    <label class="form-label">Modelo</label>
                                    <%--  <asp:TextBox ID="modelo" class="form-control" runat="server"></asp:TextBox>--%>
                                    <%-- Dropdown de los datos de modelo --%>
                                    <asp:DropDownList ID="newModelo" class="form-select" runat="server"></asp:DropDownList>
                                    <asp:Button ID="newActualizar" class="btn btn-outline-secondary mt-2" runat="server" Text="Crear" OnClick="newActualizar_Click" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
    <%-- Script Bootstrap --%>
    <script src="Scripts/bootstrap.bundle.min.js" crossorigin="anonymous"></script>
</body>
</html>
