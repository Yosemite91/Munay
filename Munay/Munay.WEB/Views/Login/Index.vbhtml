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

@Section Scripts
    <script src="~/Scripts/app/Login/index.js"></script>
    <script>
        ko.applyBindings(new Login.index);
    </script>
End Section
