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
            columns: [{ dataField: 'ID', visible: false }, 'Nombre', 'Descripcion','Precio', 'Categoria'],
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