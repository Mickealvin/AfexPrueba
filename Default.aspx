<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="AfexPrueba._Default" Async="true" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <section>
        <div class=" row">
            <div class=" col-lg-12">
                <div class="jumbotron">
                    <h1 class="text col-md-5 p-lg-3 mx-auto my-1">Añadir Nuevo Video</h1>
                    <div class="input-group mb-5 text col-md-5 p-lg-3 mx-auto my-1">
                        <asp:TextBox CssClass="form-control" ID="txtUrl" runat="server"></asp:TextBox>
                        <div class="input-group-append">
                            <asp:Button runat="server" ID="btnBuscar" Text="Buscar" CssClass="btn btn-success" OnClick="btnBuscar_Click" />
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-lg-12">
                <asp:ListView ID="ListView1" runat="server" ItemType="AfexPrueba.Model.Videos" GroupItemCount="5" SelectMethod="ListView_GetData">
                    <EmptyDataTemplate>
                        <table>
                            <tr>
                                <td>No hay data</td>
                            </tr>
                        </table>
                    </EmptyDataTemplate>
                    <EmptyItemTemplate>
                        <td />
                    </EmptyItemTemplate>
                    <GroupTemplate>
                        <tr id="itemPlaceholderContainer" runat="server">
                            <td id="itemPlaceholder" runat="server"></td>
                        </tr>
                    </GroupTemplate>
                    <ItemTemplate>
                        <td runat="server">
                            <table>
                                <tr>
                                    <td>
                                        <asp:ImageButton ID="btnMostrar" runat="server"
                                            CommandName="Views"
                                            CommandArgument="<%#:Item.Id%>"
                                            ImageUrl="<%#:Item.Imagen%>"
                                            ToolTip="<%#:Item.Titulo%>"
                                            Height="220" Width="220" ImageAlign="Middle"
                                            OnCommand="Mostrar_Command" />
                                    </td>

                                </tr>
                                <tr>
                                    <td>&nbsp;</td>
                                </tr>
                            </table>
                            </p>
                        </td>
                    </ItemTemplate>
                    <LayoutTemplate>
                        <table style="width: 100%;">
                            <tbody>
                                <tr>
                                    <td>
                                        <table id="groupPlaceholderContainer" runat="server" style="width: 100%">
                                            <tr id="groupPlaceholder"></tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td></td>
                                </tr>
                                <tr></tr>
                            </tbody>
                        </table>
                    </LayoutTemplate>
                </asp:ListView>
                <div id="myModal" class="modal fade">
                    <div class="modal-dialog alert-info">
                        <div class="modal-content">
                            <asp:HiddenField ID="hdField" runat="server" Value="false" />
                            <div class="modal-header">
                                <asp:Label runat="server" ID="LB"></asp:Label>
                                <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
                            </div>
                            <div class="modal-body">
                                <asp:Image runat="server" Height="410" Width="449" CssClass="mb-3 m-2" ImageAlign="Left" ID="IMG" />
                                <asp:Label runat="server" CssClass="mb-2 sm-2" ID="DS"></asp:Label>
                            </div>
                            <div class="row">
                                <div class="col-lg-12">
                                    <center>
                                    <asp:Button runat="server" OnClientClick="return delalert(this);" OnClick="Delete_Click" CssClass="btn btn-danger sm-3 m-2" Text="Eliminar" ID="Delete" />
                                    <asp:Button runat="server" ID="video" OnClick="video_Click" CssClass="btn btn-success sm-2 m-1" Text="Ver Video"/>
                                    </center>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                 <div id="myVideoModal" class="modal fade">
                    <div class="modal-dialog alert-info">
                        <div class="modal-content">
                            <asp:HiddenField ID="HiddenField1" runat="server" Value="false" />
                            <div class="modal-header">
                                <asp:Label runat="server" ID="Label1"></asp:Label>
                                <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
                            </div>
                            <div class="modal-body">
                                <iframe runat="server" id="videoPlayer" visible="false" width="450" height="450"></iframe>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>

    <script src="https://unpkg.com/sweetalert/dist/sweetalert.min.js"></script>
    <script type="text/javascript">
        function openModal() {
            $('#myModal').modal('show');
        }
        function videoModal() {
            $('#myVideoModal').modal('show')
        }
        var delalertok = false
        function delalert(btn) {

            if (delalertok) {
                delalertok = false
                return true
            }

            swal({
                title: "Estas Seguro?",
                text: "Estas seguro de eliminar este video?",
                icon: "warning",
                buttons: true,
                dangerMode: true,
            })
                .then(willDelete => {
                    if (willDelete) {
                        delalertok = true;
                        btn.click();
                    }
                    else {
                        swal("Safe!", "Se guardaron los cambios", "success");
                    }
                });
            return false;
        }

    </script>
</asp:Content>
