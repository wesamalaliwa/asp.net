<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="task1.aspx.cs" Inherits="ASP.NETEntityFramework.task1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/css/bootstrap.min.css"/>
    <style>
        .ss{
            text-align:center;
        }
        .ListGridViewHeader

{

 text-align:center;
}
        body{
            background-color: #e5e5f7;
opacity: 0.8;
background-image:  radial-gradient(#444cf7 0.5px, transparent 0.5px), radial-gradient(#444cf7 0.5px, #e5e5f7 0.5px);
background-size: 20px 20px;
background-position: 0 0,10px 10px;
        }

        tr{
            background:#eafaf4;
        }
 th{
     background:#0D4C92;
     text-align:center;
     color:white;
     width:10%;
 }
 .label-default {
    background-color: #0D4C92;
}
    </style>
    <script>
        Swal.fire({
            title: 'Do you want to save the changes?',
            showDenyButton: true,
            showCancelButton: true,
            confirmButtonText: 'Save',
            denyButtonText: `Don't save`,
        }).then((result) => {
            /* Read more about isConfirmed, isDenied below */
            if (result.isConfirmed) {
                Swal.fire('Saved!', '', 'success')
            } else if (result.isDenied) {
                Swal.fire('Changes are not saved', '', 'info')
            }
        })
    </script>
</head>
<body>
    <form id="form1" runat="server">
        


         

     
             <h1 style="text-align:center;">Add New Customer</h1>
            <br />
     
        <div class="container">
         <div class="form-row">
    <div class="form-group col-md-6">
      <label for="inputEmail4">Name</label>
 
        <asp:TextBox ID="TextBox1" runat="server" type="text" class="form-control" placeholder="name" required></asp:TextBox>
    </div>
    <div class="form-group col-md-6">
      <label for="inputPassword4">Age</label>
        <asp:TextBox ID="TextBox2" runat="server" type="number" class="form-control" placeholder="age" required></asp:TextBox>
    </div>
  </div>
                     <div class="form-row">
    <div class="form-group col-md-6">
      <label for="inputEmail4">Email</label>
        <asp:TextBox ID="TextBox3" runat="server" type="Email" class="form-control" placeholder="email" required></asp:TextBox>
    </div>
    <div class="form-group col-md-6">
      <label for="inputPassword4">Phone number</label>
      <asp:TextBox ID="TextBox4" runat="server" type="number" class="form-control" placeholder="Phone" required></asp:TextBox>
    </div>
  </div>

    <div class="form-group col-md-6">
      <label for="inputState">City</label>
     
          <asp:DropDownList ID="DropDownList1" runat="server" class="form-control" required></asp:DropDownList>
          
    </div>
             <div class="form-group col-md-6">
      <label for="inputState" >Upload image</label>
     
          
                             <asp:FileUpload class="form-control" ID="FileUpload1" runat="server" required/>

    </div>
                   <div class="form-group col-md-6" >
 
     
          
                       <asp:Button class="btn btn-primary" ID="Button1" runat="server" Text="Add" OnClick="Button1_Click" />

    </div>
              </div>
                
         
             <br />
        <br />
        <h1 style="text-align:center;">Customers</h1>

            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">

            <ContentTemplate>
                 <div  class="container" style="text-align:center;">
                                <asp:TextBox  class="form-control form-group col-md-4"  ID="searchTextbox" runat="server"></asp:TextBox>
<asp:Button class="btn btn-primary" ID="searchButton" Text="Search" runat="server" OnClick="searchButton_Click" />

</div>
<%--<div class="container">
                <div class="form-group col-md-6">
      <label for="inputEmail4">Name</label>
 
        <asp:TextBox ID="TextBox5" runat="server" type="text" class="form-control" placeholder="name" required></asp:TextBox>
    </div>
    <div class="form-group col-md-6">
      <label for="inputPassword4">Age</label>
        <asp:TextBox ID="TextBox6" runat="server" type="number" class="form-control" placeholder="age" required></asp:TextBox>
    </div>
</div>--%>


          <br />
                   <div class="container" style="text-align:center;">
       
      
                        <h3 class="form-group col-md-4" >Count<br /><asp:Label ID="Label1" runat="server" Text="Label" class="label label-default"></asp:Label>
             </h3> 
                         <h3 class="form-group col-md-4">avarge<br /><asp:Label ID="Label2" runat="server" Text="Label" class="label label-default"></asp:Label>
             </h3>
        <h3 class="form-group col-md-4">max<br /><asp:Label ID="Label3" runat="server" Text="Label" class="label label-default"></asp:Label>
             </h3>
            </div>
        <br />
        
    
        <div  class="container">
            <asp:GridView ID="GridView1"  class="table table-bordered table-condensed table-responsive table-hover  ListGridViewHeader" runat="server" OnRowDataBound="GridView1_RowDataBound" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" >
            </asp:GridView>
              <br />
            <hr />
      
         
        </div>
           </ContentTemplate>
        </asp:UpdatePanel>
     
    </form>
  
</body>
</html>
