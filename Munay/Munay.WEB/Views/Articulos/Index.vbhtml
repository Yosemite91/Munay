@Code
    ViewData("Title") = "ARTICULOS"
End Code

<div id="titulo" class="long-title"><h3>ARTICULOS</h3></div>
<div id="cuerpo" style="margin-bottom:70px" class="dx-fieldset">
    <div class="dx-field">
        <div id="form-tortas" data-bind="dxForm: formOptions"></div>
    </div>
    <br />
    <br />

    <div class="dx-field">
        <div id="botonesDetalle" class="btn-group" role="group">
            <div id="botonCrear" data-bind="dxButton: buttonOptionsClear"></div>
            <div id="botonCrear" data-bind="dxButton: buttonOptionsDelete"></div>
            <div id="botonCrear" data-bind="dxButton: buttonOptionsAdd"></div>
        </div>
    </div>
    <br />
    <br />
    <div class="dx-field">
        <div id="grid-tortas" data-bind="dxDataGrid: dataGridOptions"></div>
    </div>
    <br />
    <br />
</div>
@Section scripts
    <script type="text/javascript" src="~/Scripts/app/Articulos/index.js"></script>
    <script>
        ko.applyBindings(new Articulos.ArticulosIndexViewModel())
    </script>
End Section