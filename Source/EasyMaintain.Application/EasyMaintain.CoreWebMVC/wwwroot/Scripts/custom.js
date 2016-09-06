function pushMessage(t) {
    var mes = 'Info|Implement independently';
    $.Notify({
        caption: mes.split("|")[0],
        content: mes.split("|")[1],
        type: t
    });
}

$(function () {
    $('.sidebar').on('click', 'li', function () {
        if (!$(this).hasClass('active')) {
            $('.sidebar li').removeClass('active');
            $(this).addClass('active');
        }
    })
})

var $loading = $('#loadingDiv').hide();
$(document)
  .ajaxStart(function () {
      $loading.show();
  })
  .ajaxStop(function () {
      $loading.hide();
  });