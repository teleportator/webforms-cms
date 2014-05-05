<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ImageUploader.ascx.cs"
            Inherits="SharpCMS.UI.Shared.Controls.ImageUploader" %>

<asp:Image runat="server" ID="imgLogoPreview" CssClass="item-details-property" />
<asp:FileUpload runat="server" ID="fupImageUploader" CssClass="item-details-property" Width="400px" />
<asp:Button runat="server" ID="btnUpload" onclick="btnUpload_Click" Text="Загрузить" CausesValidation="false"
    CssClass="item-details-property" />
<asp:Button runat="server" ID="btnClear" Text="Очистить" onclick="btnClear_Click" CausesValidation="false"
    CssClass="item-details-property" />