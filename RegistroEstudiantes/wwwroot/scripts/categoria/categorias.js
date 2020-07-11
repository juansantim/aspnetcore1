/// <reference path="../angular.js" />

angular.module('categorias', []);

angular.module('categorias').controller('categoriasCtrl', ['$scope', '$http', function ($scope, $http) {

    const urlParams = new URLSearchParams(window.location.search);
    const myParam = urlParams.get('Id');

    $scope.Categoria = {
        Id: 0,
        Nombre: '',
        Productos: []
    }

    if (myParam)
    {
        let id = parseInt(urlParams.get('Id'));
        $http.get(`/api/Categorias/GetCategoria?Id=${id}`, id).then(response => {

            var categoria = response.data;

            $scope.Categoria.Id = categoria.id;
            $scope.Categoria.Nombre = categoria.nombre;

            if (categoria.productos)
            {
                categoria.productos.forEach(item => {
                    $scope.Categoria.Productos.push({
                        Id: item.id,
                        Nombre: item.nombre,
                        CategoriaId: item.categoriaid
                    })
                })
            }
            

            console.log(categoria);
        })
    }

    $scope.GuardarCambios = function () {
            $http.post('/api/Categorias/Guardar', $scope.Categoria)
            .then(response => {
                var data = response.data;

                if (data && data > 0) {
                    alert('Registro Guardado Satisfactoriamente');
                    window.location.replace("/Categorias/Lista");
                }
                else {
                    alert('Ocurrio un error al procesar solicitud. Intente de nuevo');                    
                }
            });
    }


    $scope.AgregarProducto = function () {
        $scope.Categoria.Productos.push({});
    }

}]);