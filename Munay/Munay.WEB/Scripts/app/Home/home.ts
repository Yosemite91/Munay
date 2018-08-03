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
            menuMode: "content",
            nextButtonText: "Más",
            noDataText: "Sin datos por mostrar",
            pageLoadingText: "Cargando...",
            refreshingText: "Recargando...",
            onItemClick: (e) => {
                var datoItem = e.itemData;
                window.location.assign(App.appRoot + 'Publicacion/DetallePublicacion?id=' + datoItem.id);
            }
        };

        constructor() {
            this.getFotos();
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
