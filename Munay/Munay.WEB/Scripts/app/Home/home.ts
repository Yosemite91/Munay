/// <reference path="../../typings/jquery/jquery.d.ts" />
/// <reference path="../../typings/knockout/knockout.d.ts" />
/// <reference path="../../typings/devextreme/devextreme.d.ts" />

namespace Home {
    export class home {

        /*DataSource de Nuestra Ruta */
        public fotos: KnockoutObservable<any> = ko.observable<any>();
        
        public nuestraRuta: DevExpress.ui.dxGalleryOptions = {
            dataSource: this.fotos,
            animationDuration: 700,
            animationEnabled: true,
            loop: true,
            width: 1000,
            slideshowDelay: 3000,
            showNavButtons: true,
            showIndicator: true,
            stretchImages: true,
            swipeEnabled: true
        }

        /*DataSource de Noticias */
        public noticias: KnockoutObservable<any> = ko.observable<any>();

        public listOptions: DevExpress.ui.dxListOptions = {
            dataSource: this.noticias,
            height: "100%",
            indicateLoading: true,
            menuMode: "slide",
            nextButtonText: "Más",
            noDataText: "Sin noticias por mostrar",            
            pageLoadingText: "Cargando...",
            refreshingText: "Recargando...",
            onItemClick: (e) => {
                
            }
        };

        constructor() {
            this.getFotos();

            var BDfotos = ["Content/img/mu1.png", "Content/img/mu2.png", "Content/img/mu3.png", "Content/img/mu4.png", "Content/img/mu5.png", "Content/img/mu6.png", "Content/img/mu7.png", "Content/img/mu8.png"];
            this.fotos(BDfotos);

            var products = [
                {
                    "Titulo": "Noticia 1",
                    "Descripcion": "Esto es un texto de relleno para la noticia, Esto es un texto de relleno para la noticia",
                    "Link": "www.paginaQueNoExiste.com",
                    "Foto": "Content/img/n1.jpg"
                }, {
                    "Titulo": "Noticia 2",
                    "Descripcion": "Esto es un texto de relleno para la noticia",
                    "Link": "www.paginaQueNoExiste.com",
                    "Foto": "Content/img/n2.jpg"
                }, {
                    "Titulo": "Noticia 3",
                    "Descripcion": "Esto es un texto de relleno para la noticia, Esto es un texto de relleno para la noticia, Esto es un texto de relleno para la noticia",
                    "Link": "www.paginaQueNoExiste.com",
                    "Foto": "Content/img/n3.jpg"
                }
            ];
            this.noticias(products);
        }

        getFotos(): void {
            $.ajax({
                url: App.apiRoot + '/redsociales/get-fotos',
                type: 'GET',
                cache: false,
                contentType: 'application/json; charset=utf-8',
                dataType: 'json',
                success: (data: any): void => {
                    for (var i: number = 0; i < data.length; i++) {
                        var tam: number = data.length;
                        var arreglo = new Array(tam);

                        for (var i = 0; i < tam; i++) {
                            arreglo[i] = data[i].foto;
                        }
                        this.fotos(arreglo);
                    }
                },
                error: (data: any): void => {
                    DevExpress.ui.notify(data.responseJSON, "error", 3000);
                }
            });
        }
    }
}
