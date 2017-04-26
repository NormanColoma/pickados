var pageTF = 15;
var pageTP = 15;
var pageA = 15;
var scrolltopTF = 0;
var scrolltopTP = 0;
var scrolltopA = 0;

$('#contenedor-tipsters-free').bind('scroll', function () {
    if ($(this).scrollTop() != scrolltopTF)
    {
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

$(".nav a").on("click", function () {
    $('.' + $(".nav").find(".active").attr('id')).hide()
    $(".nav").find(".active").removeClass("active");
    
    $(this).parent().addClass("active");
    $('.' + $(".nav").find(".active").attr('id')).show()
});

$(document).ready(function () {
    $('.admins').hide();
    $('.tipstersp').hide();
});