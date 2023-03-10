<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditConcesionarioMarca.aspx.cs" Inherits="CONCESIONARIO_PROYECTO.EditConcesionarioMarca" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="Content/bootstrap.min.css" rel="stylesheet" crossorigin="anonymous" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <script src="Scripts/bootstrap.bundle.min.js" crossorigin="anonymous"></script>
    <title>ConcesionariusMaximusEdit</title>
</head>
<body>
    <%-- Navbar --%>
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
                        <a class="nav-link active" aria-current="page" href="Concesionario">Vehiculos</a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link active" aria-current="page" href="ConcesionarioModelo">Modelos</a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link active" aria-current="page" href="ConcesionarioMarca">Marcas</a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link" href="InsertConcesionario">Insertar vehiculo</a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link" href="InsertConcesionarioModelo">Insertar Modelo</a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link" href="InsertConcesionarioMarca">Insertar Marca</a>
                    </li>
                </ul>
            </div>
        </div>
    </nav>
    <%-- FORM --%>
    <form id="form1" runat="server">
        <div class="container-fluid ">
            <div class="row">
                <div class="col-12">
                    <div class="col">
                        <a href="ConcesionarioMarca">
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
                                    <h1>Editar Marca</h1>
                                    <%-- Gardamos la ID de la Marca --%>
                                    <asp:TextBox ID="newIdMarca" Style="display: none" class="form-control" runat="server"></asp:TextBox>

                                    <label class="form-label">Nombre Marca*</label>
                                    <asp:TextBox ID="newNombreMarca" class="form-control" runat="server"></asp:TextBox>

                                    <label class="form-label">Pais*</label>
                                    <asp:TextBox ID="newPais" class="form-control" runat="server"></asp:TextBox>

                                    <label class="form-label">Fecha*</label>
                                    <asp:TextBox ID="newMarcaFecha" type="date" class="form-control" runat="server"></asp:TextBox>
                                    <asp:Button ID="newActualizar" class="btn btn-outline-secondary mt-2" runat="server" Text="Actualizar" OnClick="newActualizar_Click" />
                                    <div class="mt-5 p-3">
                                        <asp:Label ID="infoLabel" runat="server" Text=""></asp:Label>
                                    </div>
                                
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
    <%-- Js de bootstrap --%>
    <script src="Scripts/bootstrap.bundle.min.js" crossorigin="anonymous"></script>
</body>
</html>
