<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="WebFormHost.aspx.cs" Inherits="pwWeb.WebFormHost" %>

<asp:Content runat="server" ContentPlaceHolderID="MainContent">
    <script type="text/javascript">
        setTimeout("window.location.reload()", 7000);
    </script>

    <style type="text/css">
        .roomDiv {
            text-align: center;
            font-family: Lucida Sans Unicode,sans-serif;
            font-size: 17px;
            font-weight: 600;
        }
    </style>

    <asp:Panel runat="server" ID="pnlBody">

        <div>
            <asp:DropDownList runat="server" ID="ddlFloors" AppendDataBoundItems="true" CssClass="form-control" Style="margin: 0 auto;" AutoPostBack="True" ViewStateMode="Enabled" OnSelectedIndexChanged="ddlFloors_SelectedIndexChanged">
                <asp:ListItem Text="-Scegliere Piano-" />
            </asp:DropDownList>
        </div>
            <asp:Repeater runat="server" ID="rpt" OnItemDataBound="rpt_ItemDataBound">
                <headertemplate>
                <br />
            </headertemplate>
                <itemtemplate>
                <div class="form-control" style="height: auto">
                    <div class="roomDiv">
                        <asp:Label runat="server" ID="lblRoom" Text='<%# "Camera " + Eval("Camera") %>'></asp:Label>
                    </div>
                    <div style="margin: 10px;">
                        <asp:Label runat="server" Style="float: left; line-height: 25px; padding: 5px;" ID="lblTemp">Temperatura</asp:Label>
                        <asp:TextBox runat="server" Style="float: left; margin-right: 10px;" ID="txtTemp" CssClass="form-control" Text='<%# Eval("Temperatura") %>'></asp:TextBox>
                        <asp:Button runat="server" ID="btnSetTemp" CssClass="btn" OnClick="btnSetTemp_Click" Text="Setta" />
                    </div>
                    <div style="padding: 10px;">
                        <asp:Button runat="server" ID="btnOpen" CssClass="btn" OnClick="btnOpen_Click" Text='<%# (bool.Parse(Eval("Porta").ToString()) == true) ? "Chiudi porta" : "Apri Porta" %>' />
                    </div>
                </div>
            </itemtemplate>
                <separatortemplate>
                <br />
            </separatortemplate>
            </asp:Repeater>
    </asp:Panel>
</asp:Content>
