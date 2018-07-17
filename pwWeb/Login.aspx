<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Login.aspx.cs" Inherits="pwWeb.Login" %>
<asp:Content ContentPlaceHolderID="MainContent" runat="server">
    <style type="text/css" media="screen">
        .txtLogin {
            float: right;
            max-width: 60%;
            border: 1px solid #ccc;
            height: 40px;
        }

        .lblLogin {
            float: left;
            line-height: 40px;
            max-width: 30%;
            width: 30%;
        }

        .checkB {
            height: 16px;
            width: 16px;
            display: inline-block;
            padding: 0 0 0 0px;
            margin-right: 5px;
        }

            .checkB label {
                position: relative;
                top: -2px;
            }
    </style>
    <script type="text/javascript">
        $(document).ready(function () {
        });
    </script>
    <asp:Panel runat="server" ID="pnlBody">
        <div style="width: 40%; text-align: center; justify-content: center; margin: 0 auto;">
            <div style="width: 100%; height: 40px; margin-bottom: 5px; float: left;">
                <asp:Label runat="server" ID="lblUsername" CssClass="lblLogin"></asp:Label>
                <asp:TextBox runat="server" ID="txtUsername" CssClass="txtLogin form-control"></asp:TextBox>
            </div>
            <div style="width: 100%; height: 40px; margin-bottom: 5px; float: left;">
                <asp:Label runat="server" ID="lblPassword" CssClass="lblLogin"></asp:Label>
                <asp:TextBox runat="server" ID="txtPassword" TextMode="Password" CssClass="txtLogin form-control"></asp:TextBox>
            </div>
            <div>
                <asp:CheckBox runat="server" ID="chkRemember" Checked="true"  />
            </div>
            <div>
                <asp:Button runat="server" ID="btnConfirm" OnClick="btnConfirm_Click" CssClass="btn btn-secondary" />
            </div>
            <asp:Label runat="server" ID="lblWrongData"></asp:Label>
        </div>

    </asp:Panel>

</asp:Content>


