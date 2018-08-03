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
<section id="about" class="about" style="background-color: #409a55; color:white">
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

@* DX SLIDER *@
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
<section id="about" class="about" style="background-color: #ba007c; color:white">
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
<section id="portfolio" class="bacgraun">
    <div class="container">
        <div class="row">
            <div class="col-lg-10 col-lg-offset-1 text-center">
                <div class="row">
                    @* dxList *@

                    <div data-bind="dxList: listOptions">
                        <div data-options="dxTemplate: {name: 'item'}">
                            <div class="product">
                                <img data-bind="attr: {src: $data.Foto}" />
                                <h2><div data-bind="text: $data.Titulo"></div></h2>
                                <h4><div data-bind="text: $data.Descripcion"></div></h4>
                                <a href="mailto:name@example.com">
                                    <div data-bind="text: $data.Link"></div></div>
                                </a>
                        </div>
                    </div>

                    @*<div id="list" class="list-container">
                        <div data-bind="dxList: listOptions">
                            <div data-options="dxTemplate: {name: 'item'}">
                                <div class="product" style="display: block">
                                    <h4 data-bind="text: $data.titulo"></h4>
                                    <img id="imgList" data-bind="attr: {src: $data.foto}" />
                                    <br />
                                    @*<div data-bind="text: $data.descripcion"></div>
                                </div>
                            </div>
                        </div>
                    </div>*@
                    @* dxList *@
                </div>
                <!-- /.row (nested) -->
            </div>
            <!-- /.col-lg-10 -->
        </div>
        <!-- /.row -->
    </div>
    <!-- /.container -->
</section>

@*Acerca de nosotros*@
<aside id="acercaDe" class="call-to-action bg-primary">
    <div class="container">
        <div class="row">
            <div class="col-lg-12 text-center">
                <h3>Acerca de Nosotros</h3>
                <div id="aboutUs" style="font-size: 16px">
                    <h4>
                        La empresa cuenta sólo con Doña Fabiola Vidal, quien cumple las funciones de Dueña de Empresa,<br />
                        compradora de los materiales, confeccionadora de los productos, diseñadora de las imágenes y<br />
                        vendedora de los productos.
                    </h4>

                    <img src="~/Content/img/munay.jpg" style="width:40%; height:auto"/>
                </div>                
            </div>
        </div>
    </div>
</aside>

@*Footer solo para Index*@
<footer class="bacgraunFooter">
    <div id="contact" class="container">
        <div class="row">
            <div class="col-lg-10 col-lg-offset-1 text-center">
                <h4>
                    <strong>Contacto</strong>
                </h4>
                <p>
                    Horario: 9:00 a 17:00 hrs.
                    <br>Arica, Chile
                </p>
                <ul class="list-unstyled">
                    <li><i class="fa fa-phone fa-fw"></i> +569 691 819 03</li>
                    <li>
                        <i class="fa fa-envelope-o fa-fw"></i> <a href="mailto:name@example.com">fabiolavid32@gmail.com</a>
                    </li>
                </ul>
                <ul class="list-inline">
                    <li>
                        <a href="#"><img id="feisbuc" src="~/Content/img/face.png" style="height:50px" /></a>
                    </li>
                    <li>
                        <a href="#"><img id="insta" src="~/Content/img/insta.png" style="height:50px" /></a>
                    </li>
                </ul>
            </div>
        </div>
    </div>
</footer>

@Section Scripts
    <script type="text/javascript" src="~/Scripts/app/Home/home.js"></script>
    <script>
        $(document).ready(function () {
            $("#feisbuc").click(function () {
                window.location.href = "https://web.facebook.com/MunayJuguetesAndinos/";
            })
            $("#insta").click(function () {
                window.location.href = "https://www.instagram.com/munayjuguetesandinos/?hl=es-la";
            })            
        });

        ko.applyBindings(new Home.home);
    </script>
End Section
