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
    for (var i in json) {

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
            var radio1 = '<label class="radio-inline col-md-2"><input type="radio" name="opciones_' + league_name_id + '" id="league_name_id" value="0">Internacional</label>';
            var radio2 = '<label class="radio-inline col-md-2"><input type="radio" name="opciones_' + league_name_id + '" id="league_name_id" value="1">Nacional</label>';

            var radios = radio + radio1 + cierre_div + radio + radio2 + cierre_div;
            panel += panel_heading + container + panel_title + radios + cierre_div + cierre_div;

            var panel_collapse = '<div id="' + country_name_id + '" class="panel-collapse collapse">';
            var panel_body = '<div class="panel-body">';
            var ul_panel_body = '<ul id="leagues_' + country_name_id + '" class="list-group">';

            panel += panel_collapse + panel_body + ul_panel_body;

            var league = '<li class="list-group-item">' + league_name + '</li>';
            panel += league;

            var cierre = '</ul>' + '</div>' + '</div>' + '</div>';
            panel += cierre;

            $('#data').append(panel);
        }
        else {
            $('#leagues_' + country_name_id).append('<li class="list-group-item">' + league_name + '</li>');
        }
    }
}


function createRadioButtons(league_name, league_name_id)
{
    var radio = '<div class="radio_competitions">'; var cierre = '</div>';
    var radio1 = '<label><input type="radio" name="opciones" id="league_name_id" value="0" checked>Club team</label>';
    var radio2 = '<label><input type="radio" name="opciones" id="league_name_id" value="1" checked>International team</label>';

    var radios = radio + radio1 + cierre + radio + radio2 + cierre;
    return radios;
}
