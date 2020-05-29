var ur = {
    init: function () {
        ur.registerEvents();
    },
    registerEvents: function () {
        $('.btn-cont').off('click').on('click', function (e) {

            e.preventDefault();
            var btn = $(this)
            var id = btn.data('id');
            $.ajax({
                url: "/DanhMuc/DMBill/ChangeStatusCont",
                data: { id: id },
                dataType: "json",
                type: "POST",
                success: function (response) {
                    if (response.status == true) {
                        btn.text('Còn');
                        btn.toggleClass("red");
                    } else {
                        btn.text('Hết');
                        btn.toggleClass("default");
                    }
                }
            });
        });
        $('.btn-bai').off('click').on('click', function (e) {

            e.preventDefault();
            var btn = $(this)
            var id = btn.data('id');
            $.ajax({
                url: "/DanhMuc/DMBill/ChangeStatusBai",
                data: { id: id },
                dataType: "json",
                type: "POST",
                success: function (response) {
                    if (response.status == true) {
                        btn.text('Còn');
                        btn.toggleClass("red");
                    } else {
                        btn.text('hết');
                        btn.toggleClass("default");
                    }
                }
            });
        });
        $('.btn-rong').off('click').on('click', function (e) {

            e.preventDefault();
            var btn = $(this)
            var id = btn.data('id');
            $.ajax({
                url: "/DanhMuc/DMBill/ChangeStatusRong",
                data: { id: id },
                dataType: "json",
                type: "POST",
                success: function (response) {
                    if (response.status == true) {
                        btn.text('Còn');
                        btn.toggleClass("red");
                    } else {
                        btn.text('Hết');
                        btn.toggleClass("default");
                        
                    }
                }
            });
        });
    }
}
ur.init();