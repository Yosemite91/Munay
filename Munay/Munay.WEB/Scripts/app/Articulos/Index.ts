/// <reference path='../../typings/jquery/jquery.d.ts' />
/// <reference path='../../typings/knockout/knockout.d.ts' />
/// <reference path='../../typings/devextreme/devextreme.d.ts' />

namespace Articulos {
    interface IFoto {
        usuarioID: number;
        id: number;
        nombre: string;
        cuerpo: string;
    }
    'use strict';
    export class ArticulosIndexViewModel {
        public articulos: KnockoutObservableArray<any> = ko.observableArray<any>();
        public enable: KnockoutObservable<boolean> = ko.observable(true);
        public idRow: KnockoutObservable<number> = ko.observable(0);
        public idRowIndex: KnockoutObservable<number> = ko.observable(-1);
        public categorias: KnockoutObservableArray<any> = ko.observableArray<any>();
        public FotoUsuario: KnockoutObservable<IFoto> = ko.observable<IFoto>();
        public fotoDX: KnockoutObservable<string> = ko.observable<string>();

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
            columns: [{ dataField: 'ID', visible: false },
                'Nombre',
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
                let foto: IFoto = {
                    cuerpo: e.data.Foto,
                    usuarioID: null,
                    nombre: "fake",
                    id: null
                }
                this.FotoUsuario(foto);                
                formData.formData = tortaData;
                let form = $('#form-tortas').dxForm('instance');
                form.repaint();
            }
        }

        public subirImagen: DevExpress.ui.dxFileUploaderOptions = {
            allowCanceling: true,
            multiple: false,
            readyToUploadMessage: 'Listo para cargar',
            selectButtonText: 'Seleccione imagen',
            uploadButtonText: 'Subir',
            uploadedMessage: 'Archivo cargado',
            uploadMethod: 'POST',
            uploadMode: 'useButtons',
            focusStateEnabled: true,
            uploadUrl: '/',
            labelText: '',
            accept: 'image/*',
            onValueChanged: (e) => {
                let createLoadHandler = (nombre: string) => {
                    return (event) => {
                        let foto: IFoto = {
                            cuerpo: event.target.result,
                            usuarioID: null,
                            nombre: nombre,
                            id: null
                        }
                        this.FotoUsuario(foto); //aqui se guarda la foto
                    }
                }
                let frb = new FileReader();
                frb.onload = createLoadHandler(e.value[0].name);
                frb.readAsDataURL(e.value[0]);
            },
            onUploadStarted: (e) => {
                /*controlador para subir*/
                this.FotoUsuario;
            }
        }

        //Métodos
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
            if (this.FotoUsuario() === undefined) {
                let foto: IFoto = {
                    cuerpo: "data:image/jpeg;base64,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",
                    usuarioID: null,
                    nombre: "nombre",
                    id: null
                }
                this.FotoUsuario(foto);
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
                    FotoStr: this.FotoUsuario().cuerpo,
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