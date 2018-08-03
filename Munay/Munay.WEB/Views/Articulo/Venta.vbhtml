@Code
    ViewData("Title") = "Index"
End Code

@*HEADER MUNAY*@
<header id="top" class="bacgraun">
    <div class="text-vertical-center">
        <img id="logo" src="~/Content/img/logo.png" style="width: 15%"/>
    </div>
</header>

@*Articulos*@
<div id="titulo" class="long-title" style="background-color:#ba007c; margin-bottom: -15px; padding-bottom: 15px"><h3>Descubra nuestros productos</h3></div>

<aside class="bacgraun" style="padding-top: 30px">
    <section id="services">
        <div class="container">
            <div class="row text-center">
                <div class="col-lg-10 col-lg-offset-1">                    
                    <div class="dx-field">
                        <div id="categoriaTorta" data-bind="dxTabs: categorias"></div>
                    </div>
                    <!-- /.row (nested) -->
                </div>
                <!-- /.col-lg-10 -->
            </div>
            <!-- /.row -->
        </div>
        <!-- /.container -->
    </section>
</aside>

<aside class="bacgraun">
    <section id="services">
        <div class="container">
            <div class="row text-center">
                <div class="col-lg-10 col-lg-offset-1">
                    <div data-bind="dxTileView: productos"></div>
                    <!-- /.row (nested) -->
                </div>
                <!-- /.col-lg-10 -->
            </div>
            <!-- /.row -->
        </div>
        <!-- /.container -->
    </section>
</aside>

@Section Scripts
    <script type="text/javascript" src="~/Scripts/app/Articulo/venta.js"></script>
    <script>
        ko.applyBindings(new Articulo.venta);
    </script>
End Section
