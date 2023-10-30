<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Groups.aspx.cs" Inherits="WorldCup1.Groups" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-T3c6CoIi6uLrA9TneNEoa7RxnatzjcDSCmG1MXxSR1GAsXEV/Dwwykc2MPK8M2HN" crossorigin="anonymous" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="row mt-5">
            <div class="col-4">
                <asp:Button Text="Add" ID="btnAdd" CssClass="btn btn-primary" runat="server" OnClick="btnAdd_Click" />
            </div>
        </div>
        <div class="row mt-3">
            <div class="col-12">
                <table class="table table-bordered table-striped table-hover border-dark">
                    <thead>
                        <tr>
                            <th colspan="2"></th>
                            <th>ID</th>
                            <th>Name</th>
                        </tr>
                    </thead>
                    <tbody>
                        <asp:Repeater runat="server" ID="rptData" OnItemCommand="rptData_ItemCommand">
                            <ItemTemplate>
                                <tr>
                                    <td>
                                        <asp:LinkButton CommandArgument='<%# Eval("ID") %>' CommandName="Edit" Text="Edit" ID="btnEdit" CssClass="btn btn-warning" runat="server" />
                                    </td>
                                    <td>
                                        <asp:LinkButton CommandArgument='<%# Eval("ID") %>' CommandName="Remove" Text="Remove" ID="btnRemove" CssClass="btn btn-secondary" runat="server" />
                                    </td>
                                    <td>
                                        <asp:Label Text='<%# Eval("ID") %>' runat="server" />
                                    </td>
                                     <td>
                                        <asp:Label Text='<%# Eval("Name") %>' runat="server" />
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </tbody>
                </table>
            </div>
        </div>

    </form>
</body>
</html>
