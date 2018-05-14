(function () {
    'use strict';

    angular
        .module('app')
        .controller('app.views.products.product_create_or_edit', ProductModalController)

        ProductModalController.$inject =
        [
            '$scope',
            '$uibModalInstance',
            'abp.services.app.product',
            'id',
            'isEditing'
        ];
            
    function ProductModalController($scope, $uibModalInstance, productService, id, isEditing) {
        /* jshint validthis:true */
        var vm = this;
        vm.save = save;
        vm.cancel = cancel;

        vm.isEditing = isEditing;
        vm.product = {};

        activate();

        function activate() {
            if (isEditing) {
                abp.ui.setBusy();
                getProduct();
            }
        }

        function getProduct() {
            productService.getById(id)
                .then(fillProduct, errorMessage)
                .catch(unblockByError);

            function fillProduct(result) {
                abp.ui.clearBusy();
                vm.product = result.data;
            }
        }

        function create() {
            abp.ui.setBusy();
            productService.createProduct(vm.product)
                .then(success)
                .catch(unblockByError);
        }

        function update() {
            abp.ui.setBusy();
            productService.updateProduct(vm.product)
                .then(success)
                .catch(unblockByError);
        }

        function success() {
            abp.ui.clearBusy();
            //abp.notify.info(App.localize('SavedSuccessfully'));
            $uibModalInstance.close({});
        }

        function errorMessage(result) {
            abp.ui.clearBusy();
            abp.notify.error(result);
        }

        function unblockByError(error) {
            console.log(error);
            abp.ui.clearBusy();
        }

        function save() {
            if (isEditing) {
                update();
            } else {
                create();
            }
        };

        function cancel() {
            $uibModalInstance.dismiss({});
        };
            
    }
})();