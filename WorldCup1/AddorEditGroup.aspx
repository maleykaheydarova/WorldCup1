<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddorEditGroup.aspx.cs" Inherits="WorldCup1.AddorEditGroup" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-T3c6CoIi6uLrA9TneNEoa7RxnatzjcDSCmG1MXxSR1GAsXEV/Dwwykc2MPK8M2HN" crossorigin="anonymous" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="row mt-5">
            <div class="col-6">
                <asp:Label Text="ID" runat="server" />

            </div>
            <div class="col-6">
                <asp:TextBox runat="server" ID="textId" CssClass="form-control" Enabled="false" />
            </div>
        </div>
        <div class="row mt-3">
            <div class="col-6">
                <asp:Label Text="Name" runat="server" />

            </div>
            <div class="col-6">
                <asp:TextBox runat="server" ID="textName" CssClass="form-control" />
            </div>
        </div>
        <div class="row mt-3">
            <asp:Button Text="Save" CssClass="btn btn-primary" ID="buttonSave" runat="server" OnClick="btnSave_Click" />
            <asp:Button Text="Cancel" CssClass="btn btn-primary ms-3" ID="buttonCancel" runat="server" OnClick="btnCancel_Click" />
        </div>
    </form>
</body>
</html>