<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="AfexPrueba._Default" Async="true" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1 class="text col-md-5 p-lg-3 mx-auto my-1">Añadir Nuevo Video</h1>
        <div class="input-group mb-5 text col-md-5 p-lg-3 mx-auto my-1">
            <asp:TextBox CssClass="form-control" ID="txtUrl" runat="server"></asp:TextBox>
            <div class="input-group-append">
                <asp:Button runat="server" ID="btnBuscar" Text="Buscar" CssClass="btn btn-success" OnClick="btnBuscar_Click" />
            </div>
        </div>
    </div>

    <asp:ListView ID="ListView" runat="server" ItemType="AfexPrueba.Model.Videos" SelectMethod="ListView_GetData">
        <EmptyDataTemplate>
            <table>
                <tr>
                    <td>No hay data</td>
                </tr>
            </table>
        </EmptyDataTemplate>
        <ItemTemplate>
            <table>
                <tr>
                    <td>
                        <img width="300" height="300" src="<%#:Item.Imagen%>" />
                    </td>
                </tr>
            </table>
        </ItemTemplate>
    </asp:ListView>

</asp:Content>
