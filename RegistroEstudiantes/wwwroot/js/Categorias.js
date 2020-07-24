/// <reference path="../scripts/angular.js" />

angular.module('Categorias', []);

angular.module('Categorias').controller('CategoriaCtrl', ['$scope', '$http', function ($scope, $http) {

    $scope.Categoria = {
        Id: 0,
        Nombre: "",
        Productos: []
    }

    
    const urlParams = new URLSearchParams(window.location.search);
    const myParam = urlParams.get('Id');

    if (myParam)
    {
        let id = parseInt(myParam);

        $http.get(`/api/Categorias/GetCategoria?Id=${id}`).then(response =>
        {
            var categoria = response.data;
            console.log('La categoria es =>',categoria);

            $scope.Categoria.Id = categoria.id;
            $scope.Categoria.Nombre = categoria.nombre;

            if (categoria.productos)
            {
                categoria.productos.forEach(item => {
                    $scope.Categoria.Productos.push({
                        Id: item.id,
                        Codigo: item.codigo,
                        Nombre: item.nombre,
                        CategoriaId: item.categoriaId,
                        Visible: item.visible
                    })
                })
            }
        })
    }

    $scope.AgregarProducto = function ()
    {
        $scope.Categoria.Productos.push({});
    }

    $scope.GuardarCambios = function ()
    {
        //$scope.Categoria.Area = parseInt($scope.Categoria.Area);
        $http.post('/api/Categorias/Guardar', $scope.Categoria).then(response =>
        {
            var categoria = response.data;

            if (categoria.id > 0) {
                alert('El registro fue guardado satisfactoriamente');
                window.location.replace('/Cafeteria/Categorias/Lista');
            }
            else
            {
                alert('Hubo un error al procesar la solicitud');
            }

        })
    }

    //$scope.Areas = [{ id: 0, nombre: 'N/A' }, { id: 1, nombre: 'Ingenieria' }, { id: 2, nombre: 'Informatica' }]

    $http.get('/api/Categorias/GetAreas').then(response =>
    {
        var data = response.data;
        $scope.Areas = data
    })

    $scope.Eliminar = function (producto)
    {
        producto.Visible = false;
    }

    $scope.Deshacer = function (producto) {
        producto.Visible = true;
    }

}])

