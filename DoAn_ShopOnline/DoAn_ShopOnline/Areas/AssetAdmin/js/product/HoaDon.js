var hoadon = {
    init: function () {
        hoadon.registerEvents();
    },
    registerEvents: function () {

        $('.btn-chitiet').off('click').on('click', function (e) {
            e.preventDefault();
            $('#ChiTietModal').modal('show');
            $('#mahoadon').val($(this).data('id'));
           hoadon.loadImages();
        });
    },
    loadImages: function () {
        $.ajax({
            url: '/HoaDonAdmin/ChiTiet',
            type: 'GET',
            data: {
                id: $('#mahoadon').val()
            },
            dataType: 'json',
            success: function (response) {
                var data = response.data;
                var html = '';
                $.each(data, function (i, item) {
                    html += '<div style="float:left" class="col-md-12" >' +
                            '<span class=col-md-2>' +  item.OrderID  + '</span>' +
                            '<span class=col-md-2 >' + item.MaSanPham + '</span>' +
                            '<span class=col-md-2 >' + item.TenSanPham + '</span>' +
                            '<span class=col-md-2 >' + item.SoLuong + '</span>' +
                            '<span class=col-md-2 >' + item.Gia + '</span>' +
                            '<span class=col-md-2 >' + item.TongTien + '</span>' +
                            '</div>';
                });
                $('#ListChiTiet').html(html);
                //thong bao thanh cong
            }
        });
    }
}
hoadon.init();