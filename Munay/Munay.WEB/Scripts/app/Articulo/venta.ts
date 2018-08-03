/// <reference path="../../typings/jquery/jquery.d.ts" />
/// <reference path="../../typings/knockout/knockout.d.ts" />
/// <reference path="../../typings/devextreme/devextreme.d.ts" />

namespace Articulo {
    export class venta {

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
                this.getTortas(e.itemData.id);
            }
        }

        public productos: DevExpress.ui.dxTileViewOptions = {
            dataSource: this.articulos,
            baseItemHeight: 150,
            baseItemWidth: 150,
            direction: 'vertical',
            itemMargin: 20,
            itemTemplate: function(itemData, itemIndex, itemElement) {
                itemElement.append($('<img>', { 'src': itemData.Foto }));
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

            //this.categos(nombresCategos);
            //this.articulos(homes);            
            this.getCategoria();
        }

        getCategoria(): void {
            this.categos();
            $.ajax({
                type: 'GET',
                url: '/api/categorias',
                success: (data: any): void => {
                    for (var i: number = 0; i < data.length; i++) {
                        let cate = {
                            id: data[i].id,
                            text: data[i].nombre
                        }
                        this.categos.push(cate);
                    }
                }
            });
        }

        getTortas(id: number): void {
            this.articulos([]);
            let url = window.location.origin + '/api/articulos/articulos-por-categoria/'+ id;
            $.ajax({
                type: 'GET',
                url: url,
                success: (data: any): void => {
                    for (var i: number = 0; i < data.length; i++) {
                        let produ = {
                            ID: data[i].id,
                            Nombre: data[i].nombre,
                            Precio: data[i].precio,
                            Descripcion: data[i].descripcion,
                            Categoria: data[i].categoria.nombre,
                            Foto: data[i].fotoStr
                        }
                        this.articulos.push(produ);
                    }
                },
                error: (data: any): void => {
                    DevExpress.ui.notify(data.responseJSON, "error", 3000);
                }
            });
        }
    }
}