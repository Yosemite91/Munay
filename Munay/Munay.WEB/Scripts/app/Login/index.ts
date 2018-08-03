/// <reference path="../../typings/jquery/jquery.d.ts" />
/// <reference path="../../typings/knockout/knockout.d.ts" />
/// <reference path="../../typings/devextreme/devextreme.d.ts" />
/// <reference path="../app.ts" />

namespace Login {
    'use strict';
    export class index {
        public usuario: KnockoutObservableArray<any> = ko.observableArray<any>();
        public loading: KnockoutObservable<boolean> = ko.observable<boolean>(false);

        PostLogin(): void {
            let formData: any = $("#form-login").dxForm('option').formData;
            let usr: App.Usuario = {
                ID: 0,
                Password: formData.Password,
                Email: formData.Email
            };
            let ruta = App.apiRoot + '/login';
            $.ajax({
                type: 'POST',
                url: ruta,
                data: usr,
                success: (data: any): void => {                    
                    localStorage.setItem('Token', data.password);
                    localStorage.setItem('esAdministrador', data.email);
                    window.location.replace(window.location.origin + '/Home');
                },
                error: (data: any): void => {
                    this.loading(false);
                    DevExpress.ui.notify(data.responseJSON, "error", 3000);
                }
            })
        }

        formInstance;

        formOptions: any = {
            formData: this.usuario,
            onInitialized: (e) => {
                this.formInstance = e.component;
            },
            items: [{
                itemType: "group",
                items: [{
                    dataField: "Email",
                    editorOptions: {
                        placeholder: "Email"
                    }
                }, {
                    dataField: "Password",
                    editorOptions: {
                        mode: "password",
                        placeholder: "Contraseña"
                    }
                }]
            }]
        };

        buttonOptionsLogin: DevExpress.ui.dxButtonOptions = {
            text: "Ingresar",
            icon: "key",
            width: '100%',
            onClick: () => {
                this.loading(true);
                this.PostLogin();
            }
        }
    }
}