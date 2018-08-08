@Code
    ViewData("Title") = "RRSS"
End Code

<header id="top" class="bacgraun">
    <div class="text-vertical-center">
        <img id="logo" src="~/Content/img/logo.png" style="width: 15%" />
    </div>
</header>

<div id="titulo" class="long-title" style="background-color:#409a55"><h3>Nuestra Ruta</h3></div>
<div data-bind="dxLoadPanel: { visible: loading }"></div>

<div class="container">    
    <div id="customPadding">
        <div id="titulo" class="long-title" style="background-color:#409a55">
            <h3>
                <span class="dx-icon-arrowup icon"></span>
                Subir Foto
            </h3>
        </div>
        <div class="dx-field">
            <div class="dx-field-value">
                <div data-bind="dxFileUploader: subirImagen"></div>
            </div>
        </div>
        <br />

        <div id="titulo" class="long-title" style="background-color:#409a55">
            <h3>
                <span class="dx-icon-image icon"></span>
                Fotos RRSS
            </h3>
        </div>
        <div id="grid" data-bind="dxDataGrid: grillaFotosRRSS"></div>
    </div>
</div>

@Section Scripts
    <script src="~/Scripts/app/RRSS/rrss.js"></script>
    <script>
        ko.applyBindings(new RRSS.rrss);
    </script>
End Section




