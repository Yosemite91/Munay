@Code
    ViewData("Title") = "Munay"
End Code

@*HEADER MUNAY*@
<header id="top" class="bacgraun">
    <div class="text-vertical-center">
        <img id="logo" src="~/Content/img/logo.png" />
        <h2 style="color:#ba007c">Juguetes Andinos</h2>
    </div>
</header>

@*Motivados por un cambio*@
<section id="about" class="about" style="background-color: #a76a3d; color:white">
    <div class="container">
        <div class="row">
            <div class="col-lg-12 text-center">
                <h2>Motivados por lograr un cambio</h2>
            </div>
        </div>
        <!-- /.row -->
    </div>
    <!-- /.container -->
</section>

@*TRABAJO ENFOCADO*@
<aside class="callout">
    <div class="text-vertical-center">
        <h2>Trabajo Enfocado</h2>
        <div class="btn btn-lg btn-light" id="conocerMas">
            <a>@Html.ActionLink("Ir a la Tienda", "Venta", "Articulo")</a>
        </div>

        @*<p id="conocerMas" class="btn btn-lg btn-light">Ir a la Tienda</p>*@
    </div>
</aside>

@*NUESTRA RUTA*@
<section id="about" class="about" style="background-color: #ba007c; color:white">
    <div class="container">
        <div class="row">
            <div class="col-lg-12 text-center">
                <h2>Nuestra Ruta</h2>
            </div>
        </div>
        <!-- /.row -->
    </div>
    <!-- /.container -->
</section>

@* DX SLIDER NUESTRA RUTA *@
<aside class="bacgraun">
    <section id="services">
        <div class="container">
            <div class="row text-center">
                <div class="col-lg-10 col-lg-offset-1">
                    <div id="dxSlider" style="align-items:center; margin-top: 10%; margin-bottom: 10%;">
                            <div id="gallery" data-bind="dxGallery: nuestraRuta"></div>
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

@*NOTICIAS*@
<section id="about" class="about" style="background-color: #a76a3d; color:white">
    <div class="container">
        <div class="row">
            <div class="col-lg-12 text-center">
                <h2>Noticias</h2>
            </div>
        </div>
        <!-- /.row -->
    </div>
    <!-- /.container -->
</section>

@* DX NOTICIAS*@
<section id="portfolio" class="bacgraun" style="padding-top: 5%; padding-bottom: 5%;">
        <div class="row">
            <div class="col-lg-10 col-lg-offset-1 text-center">
                <div class="row">                    
                    <div data-bind="dxList: listOptions">
                        <div data-options="dxTemplate: {name: 'item'}">
                            <div class="product">
                                <div style="width:100%; height: 100%">
                                    <div style="float:left; width:50%;">
                                        <img style="height:auto; width:80%;" data-bind="attr: {src: $data.Foto}" />
                                    </div>

                                    <div style="float:right; width:50%;">
                                        <h2><div data-bind="text: $data.Titulo"></div></h2>

                                        <p style="width:100%; height:auto"><div data-bind="text: $data.Descripcion"></div></p>
                                        
                                        <a><div data-bind="text: $data.Link"></div></a>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <!-- /.row (nested) -->
            </div>
            <!-- /.col-lg-10 -->
        </div>
        <!-- /.row -->
    <!-- /.container -->
</section>

@*Acerca de nosotros*@
<section id="about" class="about" style="background-color: #ba007c; color:white">
    <div class="container">
        <div class="row">
            <div class="col-lg-12 text-center">
                <h2>Acerca de Nosotros</h2>
            </div>
        </div>
        <!-- /.row -->
    </div>
    <!-- /.container -->
</section>

<aside class="bacgraun" style="padding-top: 5%; padding-bottom: 5%;">
    <section id="services">
        <div class="container">
            <div class="row">
                <div class="col-lg-12 text-center">
                    <div id="aboutUs" style="width:100%; height: 100%">
                        <div style="float:left; width:50%;">
                            <img style="height:350px; width:auto;" src="~/Content/img/munay.jpg" />
                        </div>

                        <div style="float:right; width:50%;">
                            <h4>
                                La empresa cuenta sólo con Doña Fabiola Vidal, quien cumple las funciones de Dueña de Empresa,<br />
                                compradora de los materiales, confeccionadora de los productos, diseñadora de las imágenes y<br />
                                vendedora de los productos.
                            </h4>
                        </div>
                    </div>                    
                </div>
            </div>
        </div>
    </section>
</aside>

@Section Scripts
    <script type="text/javascript" src="~/Scripts/app/Home/home.js"></script>
    <script>
        ko.applyBindings(new Home.home);
    </script>
End Section
