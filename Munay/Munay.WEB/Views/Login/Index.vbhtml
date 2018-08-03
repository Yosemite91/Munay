@Code
    ViewData("Title") = "Inicio Sesión"
End Code

<div id="titulo" class="long-title" style="background-color:#ba007c"><h3>Munay</h3></div>
<div data-bind="dxLoadPanel: { visible: loading }"></div>

<div id="loginCuerpo">
    <div id="form-login" data-bind="dxForm: formOptions"></div>
    <div style="margin-top: 10px" data-bind="dxButton: buttonOptionsLogin"></div>
</div>

@Section Scripts
    <script src="~/Scripts/app/Login/index.js"></script>
    <script>
    ko.applyBindings(new Login.index);
    </script>
End Section
