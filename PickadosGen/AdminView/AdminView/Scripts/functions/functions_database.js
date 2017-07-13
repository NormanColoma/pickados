$

$("#loaddata").on("change", function (e) {

    $.ajax({
        url: "/database/cargardatos",
        type: "post",
        data: {
            categoria: $('#loaddata').find(":selected").attr('data-tokens'),
        }
    }).done(function (result) {
        var json = $.parseJSON(result);
        createcontainer(json);
    })
});

function createcontainer(json)
{
    for (var i = 0; i < json.length; i++) {

        var country_name = json[i].country_name;
        var country_name_id = country_name.toLowerCase().replace(/ /g, '').replace(/[^\w\s]/gi, '');

        var league_name = json[i].league_name;
        var league_name_id = league_name.toLowerCase().replace(/ /g, '').replace(/[^\w\s]/gi, '');

        var panel = $('#' + country_name_id + '_panel');

        if (panel.length == 0) {
            panel = '<div class="panel panel-default" id="' + country_name_id + '_panel">';

            var cierre_div = '</div>';

            var panel_heading = '<div class="panel-heading">';
            var container = '<div class="row">';
            var panel_title = '<h4 class="panel-title col-md-6"><a data-toggle="collapse" data-target="#' + country_name_id + '" href="#' + country_name_id + '" class="collapsed">' + country_name + '</a></h4>';

            var radio = '<div class="radio_competitions">';
            var radio1 = '<label class="radio-inline col-md-2"><input type="radio" name="' + country_name_id + '" value="0">Internacional</label>';
            var radio2 = '<label class="radio-inline col-md-2"><input type="radio" name="' + country_name_id + '" value="1">Nacional</label>';

            var radios = radio + radio1 + cierre_div + radio + radio2 + cierre_div;
            panel += panel_heading + container + panel_title + radios + cierre_div + cierre_div;

            var panel_collapse = '<div id="' + country_name_id + '" class="panel-collapse collapse">';
            var panel_body = '<div class="panel-body">';
            var ul_panel_body = '<ul id="leagues_' + country_name_id + '" class="list-group">';

            panel += panel_collapse + panel_body + ul_panel_body;

            var league = '<li class="list-group-item">' + league_name + '</li>';
            panel += league;

            var cierre = '</ul>' + '</div>';

            var panel_footer = '<div class="panel-footer footer_' + country_name_id + '"><button type="button" class="btn btn-default" onclick="insertdatabase(this)">Insertar datos en la BD</button></div>';

            panel += cierre + panel_footer + '</div>' + '</div>';

            $('#data').append(panel);
        }
        else {
            $('#leagues_' + country_name_id).append('<li class="list-group-item">' + league_name + '</li>');
        }
    }
}

function insertdatabase(element) {
    var country_name = element.parentElement.parentElement.parentElement.getElementsByTagName('h4')[0].getElementsByTagName('a')[0].text;
    var country_name_id = country_name.toLowerCase().replace(/ /g, '').replace(/[^\w\s]/gi, '');

    $('#error_' + country_name_id).remove();

    var leagues = element.parentElement.parentElement.getElementsByTagName('ul')[0].getElementsByTagName('li');
    var json_leagues = "";

    for (var i = 0; i < leagues.length; i++) {
        json_leagues += "{\"value\": \"" + leagues[i].textContent + "\"},";
    }

    var json = "{\"name\":\"" + country_name + "\", \"leagues\": [" + json_leagues.substring(0, json_leagues.length - 1) + "]}"
   
    $.ajax({
        url: "/database/cargarcompeticionesfutbol",
        type: "post",
        data: {
            json: json,
            club: $('input[name="' + country_name_id + '"]:checked').val()
        },
        beforeSend: function () {
            if (!$('input[name="' + country_name_id + '"]:radio').is(':checked')) {
                $('.footer_' + country_name_id).append('<span id="error_' + country_name_id + '" class="alert-danger">Tienes que indicar si la competición es nacional o internacional</span>');
                return false;
            }
        },
        success: function () {
            $("#insertsuccessmodal").dialog();
        }
    })
}

function cerrardialog() {
    $("#insertsuccessmodal").dialog("close");
}