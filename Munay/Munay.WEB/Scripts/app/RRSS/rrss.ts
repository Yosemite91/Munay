/// <reference path="../../typings/jquery/jquery.d.ts" />
/// <reference path="../../typings/knockout/knockout.d.ts" />
/// <reference path="../../typings/devextreme/devextreme.d.ts" />

namespace RRSS {
    interface IFoto {
        usuarioID: number;
        id: number;
        nombre: string;
        cuerpo: string;
    }

    export class rrss {        

        public loading: KnockoutObservable<boolean> = ko.observable(false);

        /*DataSource de grillaFotosRRSS */
        public fotos: KnockoutObservable<any> = ko.observable<any>();
        public grillaFotosRRSS: DevExpress.ui.dxDataGridOptions = {
            dataSource: this.fotos,
            paging: 12,
            editing: {
                mode: 'row',
                allowDeleting: true
            },
            onCellPrepared: function (e: any) {
                if (e.rowType === "data" && e.column.command === "edit") {
                    var isEditing = e.row.isEditing,
                        $links = e.cellElement.find(".dx-link");

                    $links.text("");

                    if (isEditing) {
                        $links.filter(".dx-link-save").addClass("dx-icon-save");
                        $links.filter(".dx-link-cancel").addClass("dx-icon-revert");
                    } else {
                        $links.filter(".dx-link-delete").addClass("dx-icon-trash");
                    }
                }
            }
        }

        public FotoUsuario: KnockoutObservable<IFoto> = ko.observable<IFoto>();
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

        constructor() {
            /*contralador fotos para RRSS*/
            var BDgrilla = [
                {
                    'Foto': "Content/img/mu1.png",
                    'Fecha':'20/07/2017'
                },
                {
                    'Foto': "Content/img/mu2.png",
                    'Fecha': '20/07/2017'
                },
                {
                    'Foto': "Content/img/mu3.png",
                    'Fecha': '20/07/2017'
                },
                {
                    'Foto': "Content/img/mu4.png",
                    'Fecha': '20/07/2017'
                },
                {
                    'Foto': "Content/img/mu5.png",
                    'Fecha': '20/07/2017'
                },
                {
                    'Foto': "Content/img/mu6.png",
                    'Fecha': '20/07/2017'
                },
                {
                    'Foto': "Content/img/mu7.png",
                    'Fecha': '20/07/2017'
                },
                {
                    'Foto': "Content/img/mu8.png",
                    'Fecha': '20/07/2017'
                }
            ];

            this.fotos(BDgrilla);
        }
    }
}