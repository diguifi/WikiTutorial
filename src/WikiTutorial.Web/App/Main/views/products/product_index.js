(function () {
    'use strict';
    
    angular
        .module('app')
        .controller('app.views.products.product_index', ProductController)
    
        ProductController.$inject =
        [
            '$uibModal',
            'abp.services.app.product',
            '$state',
            '$timeout'
        ];

    function ProductController($uibModal, productService, $state, $timeout) {
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
            abp.ui.setBusy();
            getProducts();
        }

        function refresh(){
            getProducts();
        }

        function getProducts() {
            productService.getAllProducts({})
                .then(fillProducts, errorMessage)
                .catch(unblockByError);

            function fillProducts(result) {
                vm.products = result.data.products;
                abp.ui.clearBusy();
            }

            function unblockByError() {
                abp.ui.clearBusy();
            }
        }

        function errorMessage(result) {
            abp.ui.clearBusy();
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
                templateUrl: '/App/Main/views/products/product_create_or_edit.cshtml',
                controller: 'app.views.products.product_create_or_edit as vm',
                backdrop: 'static',
                resolve: {
                    id: function () {
                        return 0;
                    },
                    isEditing: function () {
                        return false;
                    }
                }
            });

            modalInstance.result.then(function () {
                getProducts();
            });
        }

        function editProduct(prod) {
            var modalInstance = $uibModal.open({
                templateUrl: '/App/Main/views/products/product_create_or_edit.cshtml',
                controller: 'app.views.products.product_create_or_edit as vm',
                backdrop: 'static',
                resolve: {
                    id: function () {
                        return prod.id;
                    },
                    isEditing: function () {
                        return true;
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
                        productService.deleteProduct(prod.id)
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