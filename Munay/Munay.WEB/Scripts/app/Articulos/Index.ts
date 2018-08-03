/// <reference path='../../typings/jquery/jquery.d.ts' />
/// <reference path='../../typings/knockout/knockout.d.ts' />
/// <reference path='../../typings/devextreme/devextreme.d.ts' />

namespace Articulos {
    'use strict';
    export class ArticulosIndexViewModel {
        public articulos: KnockoutObservableArray<any> = ko.observableArray<any>();
        public enable: KnockoutObservable<boolean> = ko.observable(true);
        public idRow: KnockoutObservable<number> = ko.observable(0);
        public idRowIndex: KnockoutObservable<number> = ko.observable(-1);
        public categorias: KnockoutObservableArray<any> = ko.observableArray<any>();

        constructor()
        {
            this.getCategoria();
            this.getTortas();
        }

        formOptions: any = {
            formData: this.articulos,
            labelLocation: "top",
            items: [{
                itemType: "group",
                colCount: 3,
                items: [{
                    dataField: "Nombre",
                    editorType: "dxTextBox",
                    editorOptions: {
                        label: "Nombre",
                        showClearButton: true
                    }
                }, {
                    dataField: "Descripcion",
                    editorType: "dxTextBox",
                    editorOptions: {
                        label: "Descripcion",
                        showClearButton: true
                    }
                }
                    , {
                    dataField: "Categorias",
                    editorType: "dxLookup",
                    editorOptions: {
                        displayExpr: 'Nombre',
                        dataSource: this.categorias,
                        closeOnOutsideClick: true
                    }
                }, {
                    dataField: "Precio",
                    editorType: "dxTextBox",
                    editorOptions: {
                        label: "Precio",
                        showClearButton: true
                    }
                }]
            }]
        };

        buttonOptionsAdd: any = {
            text: "Agregar",
            icon: "plus",
            type: 'success',
            onClick: () => {
                this.addTortas();
            }
        }

        buttonOptionsDelete: any = {
            text: "Borrar",
            icon: "remove",
            type: 'danger',
            disabled: this.enable,
            onClick: () => {
                let grid = $('#grid-tortas').dxDataGrid('instance');
                let index = this.idRow();
                grid.deleteRow(this.idRowIndex());
                grid.repaint();
                this.deleteTorta(index);
            }
        }

        buttonOptionsClear: any = {
            text: "Limpiar",
            icon: "refresh",
            type: "default",
            disabled: this.enable,
            onClick: () => {
                $('#form-tortas').dxForm('instance').resetValues();
                this.idRow(0);

            }
        }

        dataGridOptions: any = {
            dataSource: this.articulos,
            selection: {
                mode: "single"
            },
            loadPanel: {
                enabled: true,
                text: 'Cargando datos...'
            },
            columns: [{ dataField: 'ID', visible: false }, 'Nombre',
                {
                    dataField: 'Foto',
                    width: 300,
                    allowFiltering: false,
                    allowSorting: false,
                    cellTemplate: function (container, options) {
                        $('<div>')
                            .append($('<img>', { 'src': options.value }))
                            .appendTo(container);
                    }
                },'Descripcion', 'Precio', 'Categoria'],
            editing: {
                texts: {
                    confirmDeleteMessage: 'Esta seguro en eliminar registro?'
                }
            }, grouping: {
                allowCollapsing: true
            }, groupPanel: {
                allowColumnDragging: true,
                visible: true,
                emptyPanelText: 'Arrastre algunas columnas para agrupar'
            }, export: {
                allowExportSelectedData: true,
                enabled: true,
                fileName: 'ingresos'
            }, columnChooser: {
                allowSearch: true
            },
            showBorders: true
            , rowAlternationEnabled: true
            , showRowLines: true
            , showColumnLines: false
            , filterRow: {
                visible: true,
                showOperationChooser: false
            }, onRowClick: (e) => {
                this.enable(false);
                let formData: any = $('#form-tortas').dxForm('option');
                let tortaData: any = {
                    ID: e.data.ID,
                    Nombre: e.data.Nombre,
                    Categoria: e.data.Categoria,
                    Descripcion: e.data.Descripcion,
                    Precio: e.data.Precio
                }
                this.idRow(tortaData.ID);
                this.idRowIndex(e.rowIndex);
                formData.formData = tortaData;
                let form = $('#form-tortas').dxForm('instance');
                form.repaint();
            }
        }	

        getCategoria(): void {
            this.categorias([]);
            let url = window.location.origin + '/api/categorias';
            $.ajax({
                type: 'GET',
                url: url,
                success: (data: any): void => {
                    for (var i: number = 0; i < data.length; i++) {
                        let cate = {
                            ID: data[i].id,
                            Nombre: data[i].nombre
                        }
                        this.categorias.push(cate);
                    }
                }
            });
        }

        addTortas(): void {
            let formData: any = $('#form-tortas').dxForm('option').formData;

            if (formData.Nombre === "") {
                DevExpress.ui.notify("No se Puede Crear Articulo, Falta Nombre", "error", 3000);
                return;
            }
            if (formData.Precio === "") {
                DevExpress.ui.notify("No se Puede Crear Articulo, Falta Precio", "error", 3000);
                return;
            }
            if (formData.Categorias === "") {
                DevExpress.ui.notify("No se Puede Crear Articulo, Falta Tipo", "error", 3000);
                return;
            }



            let url = window.location.origin + '/api/articulos';
            $.ajax({
                type: 'POST',
                url: url,
                data: {
                    ID: formData.ID,
                    Nombre: formData.Nombre,
                    Precio: formData.Precio,
                    Descripcion: formData.Descripcion,
                    FotoStr: "data:image/jpeg;base64,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",
                    Categoria: formData.Categorias
                },
                success: (data: any): void => {
                    DevExpress.ui.notify("Datos Guardados Satisfactoriamente", "success", 2000);
                    $('#form-tortas').dxForm('instance').resetValues();
                }
            }).done((result) => {
                this.getTortas();
                let grid = $('#grid-tortas').dxDataGrid('instance');
                grid.option('dataSource', []);
                grid.refresh();
                grid.repaint();
            });
        }

        getTortas(): void {
            this.articulos([]);
            let url = window.location.origin + '/api/articulos';
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

        deleteTorta(id: number): void {
            let url = window.location.origin + '/api/articulos/' + id;
            $.ajax({
                type: 'DELETE',
                url: url
            }).done((result) => {
                $('#form-tortas').dxForm('instance').resetValues();
            });;
        }
    }
}