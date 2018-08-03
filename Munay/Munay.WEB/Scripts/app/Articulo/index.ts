/// <reference path="../../typings/jquery/jquery.d.ts" />
/// <reference path="../../typings/knockout/knockout.d.ts" />
/// <reference path="../../typings/devextreme/devextreme.d.ts" />

namespace Articulo {
    export class index {

        /*DataSource de "productos" */
        public articulos: KnockoutObservableArray<any> = ko.observableArray<any>();
        public categos: KnockoutObservableArray<any> = ko.observableArray<any>();

        public categorias: DevExpress.ui.dxTabsOptions = {
            dataSource: this.categos,
            selectionMode: 'single',
            scrollByContent: true,
            showNavButtons: true,
            onItemClick: function (e) {               
                /*controlador para q traiga los articulos*/
            }
        }

        public productos: DevExpress.ui.dxTileViewOptions = {
            dataSource: this.articulos,
            baseItemHeight: 150,
            baseItemWidth: 150,
            direction: 'vertical',
            itemMargin: 20,
            itemTemplate: function(itemData, itemIndex, itemElement) {
                itemElement.append("<div class=\"image\" style=\"background-image: url(" + itemData.Foto + ")\"></div>");
            },
            noDataText: 'Sin artículos',
            showScrollbar: true,
            onItemClick: (e) => {
                localStorage.setItem('Carrito', e.value);
            }
        }
                    
        constructor() {
            /*contralador fotos para RRSS*/           
            var homes = [{             
                Nombre: "652 Avonwick Gate",                
                Precio: 780000,
                Foto: "Content/img/mu1.png"
            }, {                
                Nombre: "328 S Kerema Ave",
                Precio: 350000,
                Foto: "Content/img/mu2.png"
            }, {                
                Nombre: "8512 Tanglewood Cir",                
                Precio: 250000,
                Foto: "Content/img/mu3.png"                
            }, {              
                Nombre: "6351 Forrest St",                
                Precio: 320000,
                Foto: "Content/img/mu4.png"
            }, {               
                Nombre: "61207 16th St N",
                Precio: 1700000,
                Foto: "Content/img/mu5.png"
            }
            ];
            var nombresCategos = [
                'hola', 'hola', 'hola'
            ];

            this.categos(nombresCategos);
            this.articulos(homes);            
        }
    }
}