<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MainForm.aspx.cs" Inherits="SAWeb.MainForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    
    <!-- UIkit CSS -->
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/uikit@3.5.8/dist/css/uikit.min.css" />

    <!-- UIkit JS -->
    <script src="https://cdn.jsdelivr.net/npm/uikit@3.5.8/dist/js/uikit.min.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/uikit@3.5.8/dist/js/uikit-icons.min.js"></script>

    <script src="https://code.jquery.com/jquery-3.5.1.slim.min.js" integrity="sha384-DfXdz2htPH0lsSSs5nCTpuj/zy4C+OGpamoFVy38MVBnE+IbbVYUew+OrCXaRkfj" crossorigin="anonymous"></script>
<script src="https://cdn.jsdelivr.net/npm/popper.js@1.16.1/dist/umd/popper.min.js" integrity="sha384-9/reFTGAW83EW2RDu2S0VKaIzap3H66lZH81PoYlFhbGU+6BZp6G7niu735Sk7lN" crossorigin="anonymous"></script>
<script src="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js" integrity="sha384-B4gt1jrGC7Jh4AgTPSdUtOBvfO8shuf57BaghqFfPlYxofvL8/KUEfYiJOMMV+rV" crossorigin="anonymous"></script>
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" integrity="sha384-JcKb8q3iqJ61gNV9KGb8thSsNjpSL0n8PARn9HuZOnIxN0hoP+VmmDGMN5t9UJ0Z" crossorigin="anonymous">
</head>
<body>

    <form class="container" id="form1" runat="server">
        <div class="row mt-1" style="padding-left: 20px;">
            <label class="col-sm-1">Code</label>
            <asp:TextBox CssClass="col-sm-2 form-control" ID="TextBox1" runat="server"></asp:TextBox>
        </div>
        <div class="row mt-1" style="padding-left: 20px;">
            <label class="col-sm-1">Name</label>
            <asp:TextBox CssClass="col-sm-2 form-control" ID="TextBoxName" runat="server"></asp:TextBox>
            <br />
        </div>
        <div class="row mt-1" style="padding-left: 20px;">
            <label class="col-sm-1">Price</label>
            <asp:TextBox CssClass="col-sm-2 form-control" ID="TextBoxPrice" runat="server"></asp:TextBox><br />
        </div>
        <div class="row mt-1" style="padding-left: 20px;">
            <label class="col-sm-1">Brand</label>
            <asp:TextBox CssClass="col-sm-2 form-control" ID="TextBoxBrand" runat="server"></asp:TextBox><br />
        </div>
        <div class="row mt-1" style="padding-left: 20px;">
            <label class="col-sm-1">Color</label>
            <asp:TextBox CssClass="col-sm-2 form-control" ID="TextBoxColor" runat="server"></asp:TextBox><br />
            

        </div>
        <div class="row mt-1" style="padding-left: 20px;">
        <asp:Button ID="btnAdd" runat="server"  Text="Add" CssClass="mr-1 col-sm-1 btn btn-success" OnClick="btSubmit_Click1" />
        <asp:Button ID="btnEdit" runat="server" Text="Edit" CssClass="mr-1 col-sm-1 btn btn-info" />
        <asp:Button ID="btnDelete" runat="server" Text="Delete" CssClass="mr-1 col-sm-1 btn btn-danger" />
        </div>

    </form>
</body>
</html>
