@Code
    ViewData("Title") = "RRSS"
End Code

<div id="titulo" class="long-title" style="background-color:#ba007c"><h3>Nuestra Ruta</h3></div>
<div data-bind="dxLoadPanel: { visible: loading }"></div>

<div class="container">    
    <div id="customPadding">
        <div id="titulo" class="long-title" style="background-color:#ba007c">
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

        <div id="titulo" class="long-title" style="background-color:#ba007c">
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




