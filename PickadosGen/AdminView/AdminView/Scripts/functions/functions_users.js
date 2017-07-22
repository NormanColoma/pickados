var pageTF = 1;
var pageTP = 1;
var pageA = 1;
var scrolltopTF = 0;
var scrolltopTP = 0;
var scrolltopA = 0;

function dialogdelete(element) {
    $('.modal-body').empty();
    var p = document.createElement('p');
    p.innerHTML = '¿Desea elminar a <span class="username">' + element.getAttribute('data-alias') + '</span> del sistema?';
    $('.modal-body').append(p);

    $('#deleteModal form').removeAttr('action');
    var id = element.getAttribute('data-id');
    $('#deleteModal form').attr('action', "/user/delete/" + id);
}

$('#contenedor-tipstersf').bind('scroll', function () {
    if ($(this).scrollTop() != scrolltopTF) {
        if ($(this).scrollTop() + $(this).innerHeight() >= $(this)[0].scrollHeight) {
            $.ajax({
                type: 'GET',
                url: '/user/_listatipstersfree',
                data: { page: pageTF },
                cache: false,
                async: false,
                success: function (result) {
                    $('#contenedor-tipstersf > table > tbody').append(result);
                    pageTF += 1;
                    scrolltopTF = $(this).scrollTop();
                }
            });
        }
    }
});

$('#contenedor-tipstersp').bind('scroll', function () {
    if ($(this).scrollTop() != scrolltopTP) {
        if ($(this).scrollTop() + $(this).innerHeight() >= $(this)[0].scrollHeight) {
            $.ajax({
                type: 'GET',
                url: '/user/_listatipsterspremium',
                data: { page: pageTF },
                cache: false,
                async: false,
                success: function (result) {
                    $('#contenedor-tipstersp').append(result);
                    pageTP += 1;
                    scrolltopTP = $(this).scrollTop();
                }
            });
        }
    }
});

$('#contenedor-admins').bind('scroll', function () {
    if ($(this).scrollTop() != scrolltopA) {
        if ($(this).scrollTop() + $(this).innerHeight() >= $(this)[0].scrollHeight) {
            $.ajax({
                type: 'GET',
                url: '/user/_listaadmins',
                data: { page: pageA },
                cache: false,
                async: false,
                success: function (result) {
                    $('#contenedor-admins').append(result);
                    pageA += 1;
                    scrolltopA = $(this).scrollTop();
                }
            });
        }
    }
});

$('[id^="tipsters"], [id^="admins"]').on("click", function () {
    $('[id^="contenedor-tipsters"], [id^="contenedor-admins"]').hide()
    $('#contenedor-' + $(this).attr('id')).show();

    $(this).siblings().removeClass('active')
    $(this).addClass("active");
});

$(document).ready(function () {
    $('.admins').hide();
    $('.tipstersp').hide();
});