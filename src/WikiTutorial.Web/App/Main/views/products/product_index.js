(function () {
    'use strict';
    
    angular
        .module('app')
        .controller('app.views.products.product_index', ProductController)
    
    ProductController.$inject =
        [
            '$uibModal',
            'abp.services.app.product',
            '$location',
            '$state',
            '$timeout'
        ];

    function ProductController($uibModal, productService, $location, $state, $timeout) {
        /* jshint validthis:true */
        
        var vm = this;
        vm.createProduct = createProduct;
        vm.editProduct = editProduct;
        vm.delete = Delete;
        vm.refresh = refresh;
        vm.optionSelected = optionSelected;

        vm.selected = "";
        vm.products = [];

        activate();

        function activate() {
            abp.ui.block();
            getProducts();
        }

        function refresh(){
            getProducts();
        }

        function getProducts() {
            productService.getAllProducts({})
                .then(fillProducts, errorMessage);

            function fillProducts(result) {
                vm.products = result.data.products;
                abp.ui.unblock();
            }
        }

        function errorMessage(result) {
            abp.notify.error(result);
        }

        function optionSelected(prod) {
            if (vm.selected == 'Edit') {
                editProduct(prod);
            }
            else if (vm.selected == 'Delete') {
                Delete(prod);
            }
        }

        function createProduct() {
            var modalInstance = $uibModal.open({
                templateUrl: '/App/Main/views/products/product_add.cshtml',
                controller: 'app.views.products.product_addModal as vm',
                backdrop: 'static'
            });

            modalInstance.result.then(function () {
                getProducts();
            });
        }

        function editProduct(prod) {
            var modalInstance = $uibModal.open({
                templateUrl: '/App/Main/views/products/product_edit.cshtml',
                controller: 'app.views.products.product_editModal as vm',
                backdrop: 'static',
                resolve: {
                    id: function () {
                        return prod.id;
                    }
                }
            });

            modalInstance.result.then(function () {
                getProducts();
            });
        }

        function Delete(prod) {
            abp.message.confirm(
                "Delete product '" + prod.name + "'",
                "Are you sure?",
                function (result) {
                    if (result) {
                        productService.delete(prod.id)
                            .then(deletedMessage, errorMessage);
                    }
                });

            function deletedMessage() {
                abp.notify.info('SavedSuccessfully');
                getProducts();
            }
        }

    }
})();