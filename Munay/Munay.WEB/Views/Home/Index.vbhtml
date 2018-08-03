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
            <a>@Html.ActionLink("Ir a la Tienda", "Index", "Articulo")</a>
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
                    <div id="list" class="list-container">
                        <div data-bind="dxList: listOptions">
                            <div data-options="dxTemplate: {name: 'item'}">
                                <div class="product" style="display: block">
                                    <h4 data-bind="text: $data.titulo"></h4>
                                    <img id="imgList" data-bind="attr: {src: $data.foto}" />
                                    <br />
                                    @*<div data-bind="text: $data.descripcion"></div>*@
                                </div>
                            </div>
                        </div>
                    </div>
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
                    Tras una extensa experiencia en la comercialización de productos alternativos en perfumería, y
                    con la reciente venta de toallas higiénicas, GPC pretende dar un salto a su visión negociadora
                    mediante la gestación de una red de socios que deseen obtener mayores ingresos a su
                    presupuesto familiar.
                    <p id="revelar" style="font-size: 16px; display: none; margin-top: 0">
                        GPC representa a dos grandes empresas:
                        Parfum D´Parfum, empresa Chilena dedicada a la venta de más de 160 tipos alternativos de
                        perfumes de reconocimiento internacional, con un buen apoyo de marketing y con interesantes
                        márgenes de ganancia.
                        JM Internacional, empresa internacional que distribuye toallas higiénicas y otros productos que
                        tienen una creciente demanda comercial.
                    <p id="mision" class="btn btn-dark btn-lg" style="display:none">Misión</p>
                    <p id="vision" class="btn btn-dark btn-lg" style="display:none">Visión</p>
                    </p>
                </div>

                <div style="display:">
                    <div id="mision2" style="display:none; margin-left:auto; margin-right:auto">
                        <p>
                            <h3>Misión:</h3>
                            GPC tiene como misión la comercialización de productos de uso personal a precios accesibles y de alta calidad, con aromas reconocidos a nivel mundial. Además, aspira brindar oportunidades de negocio a socios (as) independientes que se incorporen una red comercial multinivel con incentivos y promociones.
                        </p>
                    </div>

                    <div id="vision2" style="display:none; margin-left:auto; margin-right:auto">
                        <p>
                            <h3>Visión:</h3>
                            GCP tiene como visión consolidar su emprendimiento comercial como la mejor opción para sus
                            clientes y socios, tanto en cumplimiento y entrega de servicio de calidad, como en la innovación de
                            productos de comprobada demanda. Asimismo, la creación de redes comerciales para tener una
                            fuente de generación de dinero en forma inmediata y permanente.
                        </p>
                    </div>
                </div>

                <p id="conocerMas" class="btn btn-lg btn-light">Conocer más</p>
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
                    3481 Melrose Place
                    <br>Beverly Hills, CA 90210
                </p>
                <ul class="list-unstyled">
                    <li><i class="fa fa-phone fa-fw"></i> (123) 456-7890</li>
                    <li>
                        <i class="fa fa-envelope-o fa-fw"></i> <a href="mailto:name@example.com">name@example.com</a>
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

            $("#conocerMas").click(function () {
                $("#revelar").toggle(500);
                $("#mision").toggle(500);
                $("#vision").toggle(500);
                $("#mision2").hide(500);
                $("#vision2").hide(500);
            });

            $("#mision").click(function () {
                $("#mision2").toggle(500);
            });
            $("#vision").click(function () {
                $("#vision2").toggle(500);
            });
        });

        ko.applyBindings(new Home.home);
    </script>
End Section
