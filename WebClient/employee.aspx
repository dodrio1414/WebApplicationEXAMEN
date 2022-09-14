<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="employee.aspx.cs" Inherits="WebClient.employee" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h3>Mantenimiento para empleados</h3>


    <p>
        Id del empleado: <asp:TextBox runat="server" Id="txtId"  />
    </p>
    
    <p>
        Nombre del empleado : <asp:TextBox runat="server" Id="txtNombre" />
    </p>

    <p>
        minit del empleado : <asp:TextBox runat="server" Id="TextMinit" />
    </p>
    
    <p>
        lname del empleado : <asp:TextBox runat="server" Id="TextLastname" />
    </p>

    <p>
        id de rubro del empleado : <asp:TextBox runat="server" Id="Textjob_id" />
    </p>

  
    <p>
        nivel de trabajo del empleado : <asp:TextBox runat="server" Id="Textjob_lvl" />
    </p>

    

    <p>
        pub_id del empleado : <asp:TextBox runat="server" Id="Textpub_id" />
    </p>

     <p>
       fecha de contrato del empleado : <asp:TextBox runat="server" Id="Texthire_date" type ="date"  />
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
