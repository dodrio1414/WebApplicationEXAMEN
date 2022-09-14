<%@ Page Title="" Language="C#" 
    MasterPageFile="~/Site.Master" 
    AutoEventWireup="true" 
    CodeBehind="authors.aspx.cs" 
    Inherits="WebClient.authors" %>
<asp:Content 
    ID="Content1" 
    ContentPlaceHolderID="MainContent"
    runat="server">

    <h3>Mantenimiento para autores</h3>


    <p>
        Id : <asp:TextBox runat="server" Id="txtId"  />
    </p>
    
    <p>
        Apellido del autor : <asp:TextBox runat="server" Id="TextApellido" />
    </p>

    <p>
        Nombre del autor : <asp:TextBox runat="server" Id="txtNombre" />
    </p>

    <p>
        Telefono del autor : <asp:TextBox runat="server" Id="TextTelf" />
    </p>

    <p>
        Direccion del autor : <asp:TextBox runat="server" Id="TextDirec" />
    </p>
    
    <p>
        Ciudad del autor : <asp:TextBox runat="server" Id="TextCity" />
    </p>
    
    <p>
        Pais del autor : <asp:TextBox runat="server" Id="TextState" />
    </p>

    <p>
        Zip del autor : <asp:TextBox runat="server" Id="TextZip" />
    </p>

    <p>
        Contract del autor : <asp:TextBox runat="server" Id="TextContract" />
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
            <asp:ListItem text="Nombre" />
            <asp:ListItem text="Apellido" />
        </asp:DropDownList>
        
        <asp:Button Text="Buscar" runat="server" Id="btnBuscar" OnClick="btnBuscar_Click"/>

    </p>
    <p>
        <asp:GridView runat="server" ID ="gvExamen"></asp:GridView>
    </p>

</asp:Content>
