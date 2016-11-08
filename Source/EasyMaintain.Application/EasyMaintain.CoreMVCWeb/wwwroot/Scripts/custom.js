function pushMessage(t) {
    var mes = 'Info|Implement independently';
    $.Notify({
        caption: mes.split("|")[0],
        content: mes.split("|")[1],
        type: t
    });
}

var button;

function setButtons(input) {
    debugger;
    button = input;
}



$(function () {
    $('.sidebar').on('click', 'li', function () {
        if (!$(this).hasClass('active')) {
            $('.sidebar li').removeClass('active');
            $(this).addClass('active');
        }
    })
})

$(document)
  .ajaxStart(function () {
      $('#loadingDiv').delay(100).fadeIn();
  })
  .ajaxStop(function () {
      setTimeout(function () {          
          $('#loadingDiv').delay(100).fadeOut();
      }, 500);
  });

$(document).ready(function () {
   $('#loadingDiv').hide();
});