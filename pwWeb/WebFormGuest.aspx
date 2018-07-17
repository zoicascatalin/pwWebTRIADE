<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="WebFormGuest.aspx.cs" Inherits="pwWeb.WebFormGuest" %>


<asp:Content runat="server" ContentPlaceHolderID="MainContent">

    <style type="text/css" media="screen">
        .CenterRow {
            justify-content: center;
            text-align: center;
        }
    </style>

    <div class="container">
        <div class="row CenterRow">
            <div class="col-lg-6 col-lg-offset-3 text-center">
                <div class="row">
                    <div class="col-md-6">
                        <h4>Piano : </h4>
                    </div>
                    <div class="col-md-6" id="pianoNumber" runat="server">
                        ****
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-6">
                        <h4>Camera : </h4>
                    </div>
                    <div class="col-md-6" id="cameraNumber" runat="server">
                        ****
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-6">
                        <h4>Temperatura : </h4>
                    </div>
                    <div class="col-md-6" id="setTemperatura">
                        <div class="input-group">
                            <%--<asp:TextBox runat="server" ID="tempControl" class="form-control" placeholder="0.00°C"/>--%>
                            <input type="number" class="form-control" placeholder="0.00°C" aria-describedby="basic-addon1" runat="server" id="tempControl" max="30" min="10">
                            <span class="input-group-btn">
                                <%--<button class="btn btn-default" type="button"runat="server" >Go!</button>--%>
                                <asp:Button runat="server" class="btn btn-default" type="button" Text="Modifica" ID="btnTemperatura" OnClick="btnTemperatura_Click" />
                            </span>
                        </div>
                    </div>

                </div>
                <br>
                <div class="row CenterRow">
                    <div class="col-md-6 col-md-offset-3" id="setPorta">
                        <div class="btn-group" role="group">
                            <asp:Button runat="server" ID="btnOpen" style="display: inline-block;padding: 6px 12px;margin-bottom: 0;font-size: 14px;font-weight: normal;line-height: 1.42857143;text-align: center;white-space: nowrap;vertical-align: middle;-ms-touch-action: manipulation;touch-action: manipulation;cursor: pointer;-webkit-user-select: none;-moz-user-select: none;-ms-user-select: none;user-select: none;background-image: none;border: 1px solid transparent;border-radius: 4px;" class="btn btn-success" Text="Apri Porta" OnClick="btnOpen_Click" />
                            <asp:Button runat="server" ID="btnClose" style="display: inline-block;padding: 6px 12px;margin-bottom: 0;font-size: 14px;font-weight: normal;line-height: 1.42857143;text-align: center;white-space: nowrap;vertical-align: middle;-ms-touch-action: manipulation;touch-action: manipulation;cursor: pointer;-webkit-user-select: none;-moz-user-select: none;-ms-user-select: none;user-select: none;background-image: none;border: 1px solid transparent;border-radius: 4px;" class="btn btn-danger" Text="Chiudi Porta" OnClick="btnClose_Click" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>


