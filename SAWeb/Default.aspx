<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="SAWeb.Default" %>

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
    <link rel="stylesheet" href="MainCSS.css">
</head>
<body>
      <script type="text/javascript">
         
          function showToastSucess() {
              $('#toastsucess').toast('show');
          }

      </script>
    <form class="container" id="form1" runat="server">
        <div class="row my-4">
            <label class="col-sm-1">Search</label>
            <asp:TextBox CssClass="col-sm-6 form-control" ID="TextBoxSearch" runat="server"></asp:TextBox>
            <asp:Button ID="btnSearch" Text="Search" CssClass="ml-2 col-sm-1 btn btn-light" runat="server" OnClick="btnSearch_Click" />
        </div>

        <asp:GridView ID="GridView1" CssClass="table" AutoGenerateSelectButton="true" runat="server" OnSelectedIndexChanged="GridView1_SelectedIndexChanged"></asp:GridView>
        <div class="row mt-1" style="padding-left: 20px;">
            <label class="col-sm-1">Code</label>
            <asp:TextBox CssClass="col-sm-2 form-control" ID="TextBoxCode" runat="server" Enabled="True" ReadOnly="True"></asp:TextBox>
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
            <asp:Button ID="btnAdd" runat="server" Text="Add" CssClass="mr-1 col-sm-1 btn btn-success" OnClick="btSubmit_Click1" />
            <asp:Button ID="btnEdit" runat="server" Text="Edit" CssClass="mr-1 col-sm-1 btn btn-info" OnClick="btnEdit_Click" />
            <asp:Button ID="btnDelete" runat="server" Text="Delete" CssClass="mr-1 col-sm-1 btn btn-danger" data-toggle="modal" data-target="#pnlModal" OnClientClick="javascript:return false;" OnClick="btnDelete_Click" />

        </div>
        <asp:Panel ID="pnlModal" runat="server" role="dialog"
            CssClass="modal fade">
            <div class="modal-dialog" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title" id="exampleModalLabel">Are you Sure ?</h5>
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                    </div>

                    <div class="modal-footer">
                        <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
                        <asp:Button runat="server" Text="Detele" type="button" CssClass="btn btn-danger" ID="btnDeleteConfirm" OnClick="btnDeleteConfirm_Click" />
                    </div>
                </div>
            </div>
        </asp:Panel>
        <div id="toastsucess" class="toast" role="alert" aria-live="assertive" style="position: absolute; top: 100px; right: 20px; width: 300px" data-delay="2000"   aria-atomic="true">
            <div style="background-color: #4aac4e" class="toast-header">
                <strong style="color: white" class="mr-auto">System</strong>
               
                <button type="button" class="ml-2 mb-1 close" style="color: white!important; opacity:1!important;" data-dismiss="toast" aria-label="Close">
                    <span aria-hidden="true">&times;</span>
                </button>
            </div>
            <div class="toast-body">
                Successful ^.^
            </div>
        </div>
          <div id="toastfail" class="toast" role="alert" aria-live="assertive" style="position: absolute; top: 100px; right: 20px; width: 300px" data-delay="2000"   aria-atomic="true">
            <div style="background-color: #C82333" class="toast-header">
                <strong style="color: white" class="mr-auto">System</strong>
               
                <button type="button" class="ml-2 mb-1 close" style="color: white!important; opacity:1!important;" data-dismiss="toast" aria-label="Close">
                    <span aria-hidden="true">&times;</span>
                </button>
            </div>
            <div class="toast-body">
                Something Wrong is here T.T
            </div>
        </div>
    </form>
  
</body>
</html>
