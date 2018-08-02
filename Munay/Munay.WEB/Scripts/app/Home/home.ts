/// <reference path="../../typings/jquery/jquery.d.ts" />
/// <reference path="../../typings/knockout/knockout.d.ts" />
/// <reference path="../../typings/devextreme/devextreme.d.ts" />

namespace Home {
    export class home {
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
            
        }
    }
}
