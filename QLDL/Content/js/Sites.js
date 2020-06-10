$(document).ready(function () {
    $('#dataTable').DataTable({
        "scrollY": "200px",
        "scrollCollapse": true,
    });
    $('.dataTables_length').addClass('bs-select');
});

var $ngayguibai = $('#themngayguibai')


//Xử lý  dropdown
$(document).ready(function () {
    $('#Cont').on('change', function () {
        var ContId = $(this).val();
        if (ContId) {
            $.ajax({
                type: 'POST',
                url: 'ajaxDataBill/' + ContId,
                data: 'Id=' + ContId,
                success: function (html) {
                    $('#Bill').html(html);
                }
            });
        } else {
            $('#Bill').html('<option value="">Vui lòng chọn Cont trước </option>')
        }
    });
});

// xử lý dropboxdown với select2
$(".js-example-tags").select2({
    placeholder: "Select a state",
    allowClear: true
});

// Hide - Show column in table
$('.hide-column').click(function (e) {
    var $btn = $(this);
    var $cell = $btn.closest('th,td')
    var $table = $btn.closest('table')

    // get cell location - https://stackoverflow.com/a/4999018/1366033
    var cellIndex = $cell[0].cellIndex + 1;

    $table.find(".show-column-footer").show()
    $table.find("tbody tr, thead tr")
        .children(":nth-child(" + cellIndex + ")")
        .hide()
})

$(".show-column-footer").click(function (e) {
    var $table = $(this).closest('table')
    $table.find(".show-column-footer").hide()
    $table.find("th, td").show()

})


$("#themngayguibai").click(function () {
    var checkboxes = document.querySelectorAll('input[name="chkId[]"]:checked').length;
    if (checkboxes > 0) {
        return true;
    } else {
        alert("không có cont nào được chọn!!");
        return false;
    }

});

$("#themngaygiao").click(function () {
    var checkboxes = document.querySelectorAll('input[name="chkId[]"]:checked').length;
    if (checkboxes > 0) {
        return true;
    } else {
        alert("không có cont nào được chọn!!");
        return false;
    }

});

// Xóa những hàng được tích ô
$("#delete").click(function () {
    var checkboxes = document.querySelectorAll('input[name="chkId[]"]:checked').length;
    if (checkboxes > 0) {
        if (!confirm("Bạn có chắc chắn muốn xóa không?")) {
            return false;
        }
    } else {
        alert("Không có giá trị nào được chọn để xóa!!");
        return false;
    }
    
});

// Chức năng chọn hết
document.getElementById("check").onclick = function () {
    // Lấy danh sách checkbox
    var checkboxes = document.getElementsByName('chkId[]');
    if (document.getElementById("check").checked) {
        // Lặp và thiết lập checked
        for (var i = 0; i < checkboxes.length; i++) {
            checkboxes[i].checked = true;
        }
    } else {
        // Lặp và thiết lập Uncheck
        for (var i = 0; i < checkboxes.length; i++) {
            checkboxes[i].checked = false;
        }
    }

};



$(function () {
    $('#AlertBox').removeClass('hide');
    $('#AlertBox').delay(3000).slideUp(500);

});

(function ($) {
  "use strict"; // Start of use strict

  // Toggle the side navigation
  $("#sidebarToggle, #sidebarToggleTop").on('click', function(e) {
    $("body").toggleClass("sidebar-toggled");
    $(".sidebar").toggleClass("toggled");
    if ($(".sidebar").hasClass("toggled")) {
      $('.sidebar .collapse').collapse('hide');
    };
  });

  // Close any open menu accordions when window is resized below 768px
  $(window).resize(function() {
    if ($(window).width() < 768) {
      $('.sidebar .collapse').collapse('hide');
    };
  });

  // Prevent the content wrapper from scrolling when the fixed side navigation hovered over
  $('body.fixed-nav .sidebar').on('mousewheel DOMMouseScroll wheel', function(e) {
    if ($(window).width() > 768) {
      var e0 = e.originalEvent,
        delta = e0.wheelDelta || -e0.detail;
      this.scrollTop += (delta < 0 ? 1 : -1) * 30;
      e.preventDefault();
    }
  });

  // Scroll to top button appear
  $(document).on('scroll', function() {
    var scrollDistance = $(this).scrollTop();
    if (scrollDistance > 100) {
      $('.scroll-to-top').fadeIn();
    } else {
      $('.scroll-to-top').fadeOut();
    }
  });

  // Smooth scrolling using jQuery easing
  $(document).on('click', 'a.scroll-to-top', function(e) {
    var $anchor = $(this);
    $('html, body').stop().animate({
      scrollTop: ($($anchor.attr('href')).offset().top)
    }, 1000, 'easeInOutExpo');
    e.preventDefault();
  });

})(jQuery); // End of use strict
