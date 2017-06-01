var pageTF = 15;
var pageTP = 15;
var pageA = 15;
var scrolltopTF = 0;
var scrolltopTP = 0;
var scrolltopA = 0;

$('#contenedor-tipsters-free').bind('scroll', function () {
    if ($(this).scrollTop() != scrolltopTF) {
        if ($(this).scrollTop() + $(this).innerHeight() >= $(this)[0].scrollHeight) {
            $.ajax({
                type: 'GET',
                url: '/User/_ListaTipstersFree',
                data: { page: pageTF },
                cache: false,
                success: function (result) {
                    $('#contenedor-tipsters-free').append(result);
                    pageTF += 15;
                    scrolltopTF = $(this).scrollTop();
                }
            });
        }
    }
});

$('#contenedor-tipsters-premium').bind('scroll', function () {
    if ($(this).scrollTop() != scrolltopTP) {
        if ($(this).scrollTop() + $(this).innerHeight() >= $(this)[0].scrollHeight) {
            $.ajax({
                type: 'GET',
                url: '/User/_ListaTipstersPremium',
                data: { page: pageTF },
                cache: false,
                success: function (result) {
                    $('#contenedor-tipsters-premium').append(result);
                    pageTP += 15;
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
                url: '/User/_ListaAdmins',
                data: { page: pageA },
                cache: false,
                success: function (result) {
                    $('#contenedor-admins').append(result);
                    pageA += 15;
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

$('.fa-trash-o').on("click", function () {
    $('.modal-body').empty();
    var p = document.createElement('p');
    p.textContent = '¿Desea elminar al usuario "' + this.getAttribute('data-alias') + '" del sistema?';
    $('.modal-body').append(p);

    var action = $('#deleteModal form').attr('action');
    var id = this.getAttribute('data-id');
    $('#deleteModal form').attr('action', action + "/" + id);
});

$(document).ready(function () {
    $('.admins').hide();
    $('.tipstersp').hide();
});