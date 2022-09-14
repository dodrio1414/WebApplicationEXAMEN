<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="titleauthor.aspx.cs" Inherits="WebClient.titleauthor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">




    <h3>Mantenimiento para empleados</h3>


    <p>
        id del autor titulo: <asp:TextBox runat="server" Id="txtau_id"  />
    </p>

    <p>
        id del titulo: <asp:TextBox runat="server" Id="Texttitle_id"  />
    </p>

    <p>
        orden del titulo: <asp:TextBox runat="server" Id="Textau_ord"  />
    </p>

    <p>
        royaltyper del titulo: <asp:TextBox runat="server" Id="Textroyaltyper"  />
    </p>
    
    

    

   
    
    <p>
        <asp:Button Text="Agregar" runat="server" Id="btnAgregar" OnClick="btnAgregar_Click"  />
        <asp:Button Text="Eliminar" runat="server" Id="btnEliminar" OnClick="btnEliminar_Click" />
        <asp:Button Text="Actualizar" runat="server" Id="btnActualizar" OnClick="btnActualizar_Click"/>
    </p>
    <p>
        Buscar : <asp:TextBox runat="server" Id="txtBuscar" />    
        <asp:DropDownList runat="server" Id="List" >
            <asp:ListItem text="Id" />
            <asp:ListItem text="Id del autor" />
            
        </asp:DropDownList>
        
        <asp:Button Text="Buscar" runat="server" Id="btnBuscar" OnClick="btnBuscar_Click"/>

    </p>
    <p>
        <asp:GridView runat="server" ID ="gvExamen"></asp:GridView>
    </p>
</asp:Content>
