<!DOCTYPE html>
<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>@ViewBag.Title - Mi aplicación ASP.NET</title>
    @Styles.Render("~/Content/css")
    @Scripts.Render("~/bundles/modernizr")
</head>

<body>
    <!-- Navigation -->
    <a id="menu-toggle" href="#" class="btn btn-dark btn-lg toggle">
        <i class="glyphicon glyphicon-menu-hamburger"></i>
    </a>
    <nav id="sidebar-wrapper">
        <ul class="sidebar-nav">
            <a id="menu-close" class="btn btn-light btn-lg pull-right toggle">
                <i class="glyphicon glyphicon-remove"> </i>
            </a>
            <li class="sidebar-brand">@Html.ActionLink("Inicio", "Index", "Home")</li> 
            <li><a>@Html.ActionLink("Ir a la Tienda", "Venta", "Articulo")</a></li>
            
            <!-- ko if: esAdministrador === 'DANILO.UTA@GMAIL.COM' -->
                <li>@Html.ActionLink("Nuestra Ruta", "Index", "RRSS")</li>
                <li>@Html.ActionLink("Categorías", "Index", "Categorias")</li>
                <li>@Html.ActionLink("Articulos", "Index", "Articulos")</li>
            <!-- /ko -->

            <!-- ko if: Token === null -->
                <li>@Html.ActionLink("Iniciar Sesión", "Index", "Login")</li>
            <!-- /ko -->             

            <!-- ko if: Token !== null -->
                <li><a href="#" onClick="Salir();"> Cerrar Sesión</a></li>
            <!-- /ko -->
        </ul>
    </nav>

    <div class="container body-content">
        @RenderBody()
        <hr />
        @*Footer*@
        <footer2 id="footer2">
            <p style="margin-bottom:30px" id="footerTexto">&copy; @DateTime.Now.Year - Munay</p>
            <a id="to-top" href="#top" class="btn btn-dark btn-lg">
                <i class="glyphicon glyphicon-chevron-up"></i>
            </a>
        </footer2>
    </div>

    @Scripts.Render("~/bundles/jquery")
    @Scripts.Render("~/bundles/bootstrap")
    @Scripts.Render("~/bundles/knockout")
    @Scripts.Render("~/bundles/devextreme")
    @Scripts.Render("~/bundles/app")

    @* LOGIN *@
    <script>
        esAdministrador = App.esAdministrador;

        App.apiRoot = '@Url.Content("~/")api/';
        App.appRoot = '@Url.Content("~/")';
        var Token = localStorage.getItem('Token');

        function Salir(){
            App.goToLogin();
        }

        // Closes the sidebar menu
        $("#menu-close").click(function (e) {
            e.preventDefault();
            $("#sidebar-wrapper").toggleClass("active");
            //$('html,body').animate({ scrollTop: $(document).height() }, 1500);
        });
        //Opens the sidebar menu
        $("#menu-toggle").click(function (e) {
            e.preventDefault();
            $("#sidebar-wrapper").toggleClass("active");
        });
        //#to-top button appears after scrolling
        var fixed = false;
        $(document).scroll(function () {
            if ($(this).scrollTop() > 250) {
                if (!fixed) {
                    fixed = true;
                    //$('#to-top').css({position:'fixed', display:'block'});
                    $('#to-top').show("slow", function () {
                        $('#to-top').css({
                            position: 'fixed',
                            display: 'block'
                        });
                    });
                }
            } else {
                if (fixed) {
                    fixed = false;
                    $('#to-top').hide("slow", function () {
                        $('#to-top').css({
                            display: 'none'
                        });
                    });
                }
            }
        });
        //Scrolling functions
        $(document).ready(function () {
            $('#to-top').click(function () {
                $('html,body').animate({ scrollTop: 0 }, 1500);
            });
        });
        //OTRO TOGGLES
        $("#contact").click(function (e) {
            e.preventDefault();
            $('html,body').animate({ scrollTop: $(document).height() }, 1500);
        });
        $("#acercaDe").click(function (e) {
            e.preventDefault();
            $('html,body').animate({ scrollTop: $(document).height() }, 1500);
        });
    </script>

    @RenderSection("scripts", required:=False)
</body>
</html>
