var page = {};
page.functions = {};
page.data = {};
page.data.exportFile = 'Parts Export File\r\n';
page.data.exportArray = [];
page.data.results = [];

page.functions.setSelectAll = function () {
    $('#selectAll').change(function () {
        page.functions.selectAll();
    });
}

page.functions.selectAll = function () {
    page.data.exportArray = [];
    var isChecked = $('#selectAll').prop('checked');
    for (var i = 0; i < page.data.results.length; i++) {
        if (isChecked) {
            page.data.exportArray.push(i);
        }
        $('#' + i).prev().attr('aria-checked', isChecked);
    }
    page.functions.showHideExportButton();
}

page.functions.showHideExportButton = function () {
    if (page.data.exportArray.length > 0) {
        $('#export').css("visibility", "visible");
    }
    else {
        $('#export').css("visibility", "hidden");
    }
}

page.functions.buildExport = function (id) {
    switch ($('#' + id).prop('checked')) {
        case true:
            page.data.exportArray.push(id);
            break;
        case false:
            for (var i = 0; i < page.data.exportArray.length; i++) {
                if (page.data.exportArray[i] == id) {
                    page.data.exportArray.splice(i, 1);
                    i--;
                }
            }
            break;
    }
    page.functions.showHideExportButton();
}

page.functions.export = function () {
    page.data.export = 'Title,URL,Snippet,Source\r\n';
    $.each(page.data.exportArray, function (k, v) {
        var name = $('#a-' + v).html().replace(/,/g, '-').replace(/(\r\n|\n|\r)/gm, "");
        var uri = $('#a-' + v).attr('href').replace(/,/g, '-').replace(/(\r\n|\n|\r)/gm, "");
        var snippet = $('#sn-' + v).html().replace(/,/g, '-').replace(/(\r\n|\n|\r)/gm, "");
        var source = $('#so-' + v).html().replace(/,/g, '-').replace(/(\r\n|\n|\r)/gm, "");
        page.data.export += name + ',' + uri + ',' + snippet + ',' + source + '\r\n';
    });
    var hiddenElement = document.createElement('a');
    hiddenElement.href = 'data:text/csv;charset=utf-8,' + encodeURI(page.data.export);
    hiddenElement.target = '_blank';
    hiddenElement.download = 'CarPartsExport.csv';
    hiddenElement.click();
}

page.functions.buildTable = function (data) {
    page.data.results = data;
    $('#selectAllDiv').append('<input type="checkbox" id="selectAll" />');
    page.functions.setSelectAll();
    $.each(data, function (k, v) {
        $('#results').append('<div class="row"><div class="col-md-11"><div><h2><a id="a-' + k + '" href=' + v.DisplayUrl + '>' + v.Name +
            '</a></h2></div><div><a style="color:green" href=' + v.DisplayUrl + '>' + v.DisplayUrl + '</a></div><div id="sn-' + k +
            '">' + v.Snippet + '</div><div style="color:red" id="so-' + k + '">' + v.Source +
            '</div></div><div class="col-md-1"><h2 title="Select for export"><input onchange="page.functions.buildExport(this.id)" id="' + k +
            '" type="checkbox"/></h2></div></div>');
    })
    $.switcher();
}

if (typeof resultsView != 'undefined') {
    page.functions.buildTable(resultsView.data);
}

page.functions.getParameterByName = function (name) {
    var regexS = '[\\?&]' + name + '=([^&#]*)',
        regex = new RegExp(regexS),
        results = regex.exec(window.location.search);
    if (results == null) {
        return "";
    } else {
        return decodeURIComponent(results[1].replace(/\+/g, " "));
    }
}

page.functions.initilise = function () {
    $('#searchTerm').val(page.functions.getParameterByName('searchTerm'));
    $('#export').click(function () {
        page.functions.export();
    });

    page.functions.setSelectAll();

    $('#search').click(function () {
        $('#results').html('');
        $('#selectAllDiv').html('');

        switch ($('#page').val()) {
            case 'search':
                $(location).attr('href', '../partoogle/postsearch?searchTerm=' + $("#searchTerm").val() + '&searchMode=' + $("#searchMode").val());
                break;
            case 'result':
                var jqxhr = $.post('../partoogle/ajaxsearch', { searchTerm: $('#searchTerm').val(), searchMode: $('#searchMode').val() }, function (data) {
                    page.functions.buildTable(data);
                })
                    .fail(function (data) {
                        console.log("error = " + data);
                    })
                break;
        }

    });
}

$(document).ready(function () {
    page.functions.initilise();
});