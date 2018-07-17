<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="AddGuest.aspx.cs" Inherits="pwWeb.AddGuest" %>

<asp:Content runat="server" ContentPlaceHolderID="MainContent">

    <style type="text/css" media="screen">
        .CenterRow {
            justify-content: center;
            text-align: center;
        }

        .row{
            padding-bottom: 10px;
        }
    </style>
    <%--<script type="text/javascript" src="Scripts/jquery-3.3.1.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $("#<%=datepicker.ClientID %>").datepicker().on('changeDate', function (ev) {
                $(this).datepicker('hide');
            });

        })
    </script>--%>


    <div class="container">
        <div class="row CenterRow">
            <div class="col-lg-6 col-lg-offset-3 text-center">
                <div class="row">
                    <div class="col-md-6">
              
                        <h4>Nome : </h4>
                    </div>
                    <div class="col-md-6" id="divNome" runat="server">
                        <div class="input-group">
                            <input type="text" class="form-control" runat="server" aria-describedby="basic-addon1" id="setNome" />
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-6">
                        <h4>Cognome : </h4>
                    </div>
                    <div class="col-md-6" id="divCognome" runat="server">
                        <div class="input-group">
                            <input type="text" class="form-control" runat="server" aria-describedby="basic-addon1" id="setCognome" />
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-6">
                        <h4>Camera : </h4>
                    </div>
                    <div class="col-md-6" id="divCamera">
                        <asp:DropDownList runat="server" ID="downCaemra" AppendDataBoundItems="true" CssClass="form-control" Style="margin: 0 auto;" AutoPostBack="True">
                            <asp:ListItem Text="-Scegliere Camera/-" />
                        </asp:DropDownList>
                    </div>
                </div>

                <div class="row">
                    <div class="col-md-6">
                        <h4>Data Arrivo : </h4>
                    </div>
                    <div class="col-md-6" id="divArrivo">
                        <%--<input type="text" id="datepicker" runat="server" />--%>
                        <div class="input-group">
                            <input type="text" class="form-control" runat="server" aria-describedby="basic-addon1" id="setDataArrivo" />
                        </div>

                    </div>
                </div>

                <div class="row">
                    <div class="col-md-6">
                        <h4>Data Partenza : </h4>
                    </div>
                    <div class="col-md-6" id="divPartenza">
                        <%--<input type="text" id="datepicker" runat="server" />--%>
                        <div class="input-group">
                            <input type="text" class="form-control" runat="server" aria-describedby="basic-addon1" id="setDataPartenza" />
                        </div>

                    </div>
                </div>

                <br />
                 <div class="row">
                    <div class="col-md-6 col-md-offset-3">
                        <h4>Data Arrivo : </h4>
                    </div>
                </div>
                <div class="row">
                    <div class="col-sm-4" id="divArrivGiorno">
                        <%--<input type="text" id="datepicker" runat="server" />--%>
                        <%--<div class="input-group">
                            <input type="text" class="form-control" runat="server" aria-describedby="basic-addon1" id="Text1" />
                        </div>--%>
                         <asp:DropDownList runat="server" ID="DropDownList1" AppendDataBoundItems="true" CssClass="form-control" Style="margin: 0 auto;" AutoPostBack="True">
                            <asp:ListItem Text="-Scegliere Giorno/-" />
                        </asp:DropDownList>

                    </div>

                     <div class="col-sm-4" id="divArrivMese">
                        <%--<input type="text" id="datepicker" runat="server" />--%>
                        <%--<div class="input-group">
                            <input type="text" class="form-control" runat="server" aria-describedby="basic-addon1" id="Text1" />
                        </div>--%>
                         <asp:DropDownList runat="server" ID="DropDownList2" AppendDataBoundItems="true" CssClass="form-control" Style="margin: 0 auto;" AutoPostBack="True">
                            <asp:ListItem Text="-Scegliere Mese/-" />
                        </asp:DropDownList>

                    </div>

                     <div class="col-sm-4" id="divArrivAnno">
                        <%--<input type="text" id="datepicker" runat="server" />--%>
                        <%--<div class="input-group">
                            <input type="text" class="form-control" runat="server" aria-describedby="basic-addon1" id="Text1" />
                        </div>--%>
                         <asp:DropDownList runat="server" ID="DropDownList3" AppendDataBoundItems="true" CssClass="form-control" Style="margin: 0 auto;" AutoPostBack="True">
                            <asp:ListItem Text="-Scegliere Anno/-" />
                        </asp:DropDownList>

                    </div>
                </div>

                <div class="row">
                    <div class="col-md-6 col-md-offset-3">
                        <h4>Data Arrivo : </h4>
                    </div>
                </div>
                <div class="row">
                    <div class="col-sm-4" id="divPartenzaGiorno">
                        <%--<input type="text" id="datepicker" runat="server" />--%>
                        <%--<div class="input-group">
                            <input type="text" class="form-control" runat="server" aria-describedby="basic-addon1" id="Text1" />
                        </div>--%>
                         <asp:DropDownList runat="server" ID="DropDownList4" AppendDataBoundItems="true" CssClass="form-control" Style="margin: 0 auto;" AutoPostBack="True">
                            <asp:ListItem Text="-Scegliere Giorno/-" />
                        </asp:DropDownList>

                    </div>

                     <div class="col-sm-4" id="divPartenzaMese">
                        <%--<input type="text" id="datepicker" runat="server" />--%>
                        <%--<div class="input-group">
                            <input type="text" class="form-control" runat="server" aria-describedby="basic-addon1" id="Text1" />
                        </div>--%>
                         <asp:DropDownList runat="server" ID="DropDownList5" AppendDataBoundItems="true" CssClass="form-control" Style="margin: 0 auto;" AutoPostBack="True">
                            <asp:ListItem Text="-Scegliere Mese/-" />
                        </asp:DropDownList>

                    </div>

                     <div class="col-sm-4" id="divPartenzaAnno">
                        <%--<input type="text" id="datepicker" runat="server" />--%>
                        <%--<div class="input-group">
                            <input type="text" class="form-control" runat="server" aria-describedby="basic-addon1" id="Text1" />
                        </div>--%>
                         <asp:DropDownList runat="server" ID="DropDownList6" AppendDataBoundItems="true" CssClass="form-control" Style="margin: 0 auto;" AutoPostBack="True">
                            <asp:ListItem Text="-Scegliere Anno/-" />
                        </asp:DropDownList>

                    </div>
                </div>

                <br>

                <div class="row CenterRow">
                    <div class="col-md-6 col-md-offset-3" id="saveSettings">
                        <div class="btn-group" role="group">
                            <asp:Button runat="server" ID="btnSalva" class="btn btn-success" Text="Salva" OnClick="btnSalva_Click" />

                        </div>
                    </div>
                </div>

            </div>


        </div>
    </div>
</asp:Content>
