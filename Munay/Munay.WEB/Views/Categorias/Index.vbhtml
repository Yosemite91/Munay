@Code
    ViewData("Title") = "CATEGORÍA"
End Code

<div class="row">
    <div class="col-sm-12">
        <div id="titulo" class="long-title"><h3>Categorías</h3></div>
        <div id="cuerpo" style="margin-bottom:70px" class="dx-fieldset">
            <div class="dx-field">
                <label for="nombre">Nombre:</label>

                <div id="text-nombre" data-bind="dxTextBox: textBoxOptions"></div>
            </div>

            <div class="dx-field">
                <div id="botonesDetalle" class="btn-group" role="group">
                    <div id="botonCrear" data-bind="dxButton: buttonOptionsDelete"></div>
                    <div id="botonCrear" data-bind="dxButton: buttonOptionsAdd"></div>
                </div>
            </div>

            <div class="dx-field">
                <div id="grid-cate" data-bind="dxDataGrid: dataGridOptions"></div>
            </div>
        </div>
    </div>
</div>

@Section scripts
    <script type="text/javascript" src="~/Scripts/app/Categorias/Index.js"></script>
    <script>
        ko.applyBindings(new Categorias.CategoriasIndexViewModel());
    </script>
End Section
