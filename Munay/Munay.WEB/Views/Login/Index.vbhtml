@Code
    ViewData("Title") = "Inicio Sesión"
End Code

<header id="top" class="bacgraun">
    <div class="text-vertical-center">
        <img id="logo" src="~/Content/img/logo.png" style="width: 15%" />
    </div>
</header>
<div id="titulo" class="long-title" style="background-color:#337ab7"><h3>Iniciar Sesión</h3></div>
<div data-bind="dxLoadPanel: { visible: loading }"></div>

<aside style="margin-bottom:5%; margin-top: 5%;">
    <section id="services">
        <div class="container">
            <div class="row text-center">
                <div class="col-lg-10 col-lg-offset-1">
                    <div class="dx-field" style="padding-left: 10%; padding-right: 10%;">
                        <div id="form-login" data-bind="dxForm: formOptions"></div>
                        <div style="margin-top: 10px" data-bind="dxButton: buttonOptionsLogin"></div>
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
    <script src="~/Scripts/app/Login/index.js"></script>
    <script>
    ko.applyBindings(new Login.index);
    </script>
End Section
