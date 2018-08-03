/// <reference path='Utils.ts' />

namespace App {
    'use strict';
    export var appRoot: string;
    export var apiRoot: string;
    export var appPrefix: string = 'MUNAY';    
    export var esAdministrador: string = localStorage.getItem('esAdministrador');

    $.ajaxSetup({
        headers: GetAutorizationHeaders(),
        error: (jqXHR: any, textStatus: any, errorThrown: any): void => {
            Utils.getErrores('', jqXHR, textStatus, errorThrown);
        }
    });

    function GetAutorizationHeaders(): { [key: string]: any; } {
        let token: string = localStorage.getItem(appPrefix + 'login.token');
        if (token) {
            return { 'Authorization': 'Basic ' + token };
        } else {
            return { 'Authorization': 'Anonymous' };
        }
    }

    export function goToLogin(): any {
        localStorage.removeItem('Token');
        localStorage.removeItem('esAdministrador');
        window.location.replace(window.location.origin + '/Home');
        return false;
    };

    export function anioMinimo(): any {
        var actual = new Date();
        var anioMinimo = actual.getFullYear() - 18;
        return anioMinimo;
    };

    export function alertaFormulario(anyObj: any): boolean {
        var i: number;
        var error: boolean = true;

        for (i = 0; i < Object.keys(anyObj).length; i++) {
            if (anyObj[Object.keys(anyObj)[i]] === null || anyObj[Object.keys(anyObj)[i]] === '' || anyObj[Object.keys(anyObj)[i]] === 0 || anyObj[Object.keys(anyObj)[i]] === undefined || anyObj[Object.keys(anyObj)[i]] === error || anyObj[Object.keys(anyObj)[i]].length === 0) {
                let name: any = Object.keys(anyObj)[i];
                DevExpress.ui.notify({
                    message: 'Seleccione :  ' + name,
                    type: "error",
                    displayTime: 3000,
                    closeOnClick: true,
                    width: 300,
                });
                error = false;
                return error;
            }
        }

        return true;
    };

    export interface Usuario {
        ID: number,
        Email: string,
        Password: string
    }

    export interface Categoria {
        ID: number,
        Nombre: string
    }

}

