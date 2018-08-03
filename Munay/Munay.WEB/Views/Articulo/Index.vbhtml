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
<section id="about" class="about" style="background-color: #a76a3d; color:white">
    <div class="container">
        <div class="row">
            <div class="col-lg-12 text-center">
                <h2>Descubra nuestros productos</h2>
            </div>
        </div>
        <!-- /.row -->
    </div>
    <!-- /.container -->
</section>

<aside class="bacgraun">
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
    <script type="text/javascript" src="~/Scripts/app/Articulo/index.js"></script>
    <script>
        ko.applyBindings(new Articulo.index);
    </script>
End Section
