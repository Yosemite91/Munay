@Code
    ViewData("Title") = "ARTICULOS"
End Code

<header id="top" class="bacgraun">
    <div class="text-vertical-center">
        <img id="logo" src="~/Content/img/logo.png" style="width: 15%" />
    </div>
</header>
<div id="titulo" class="long-title"><h3>Artículos</h3></div>

<div class="container">
    <div id="customPadding">
        
        <div id="cuerpo" style="margin-bottom:70px" class="dx-fieldset">
            <div class="dx-field">
                <div id="form-tortas" data-bind="dxForm: formOptions"></div>
            </div>
            <br />
            <br />

            <div class="dx-field">
                <div id="botonesDetalle" class="btn-group" role="group" >
                    <div id="botonCrear" style="margin:5px" data-bind="dxButton: buttonOptionsClear"></div>
                    <div id="botonCrear"style="margin:5px" data-bind="dxButton: buttonOptionsDelete"></div>
                    <div id="botonCrear" style="margin:5px" data-bind="dxButton: buttonOptionsAdd"></div>
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

    </div>
</div>
@Section scripts
    <script type="text/javascript" src="~/Scripts/app/Articulos/index.js"></script>
    <script>
        ko.applyBindings(new Articulos.ArticulosIndexViewModel())
    </script>
End Section