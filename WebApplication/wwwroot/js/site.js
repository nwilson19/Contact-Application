// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function HTTPCall(verb, record) {
    var xmlhttp = new XMLHttpRequest();
    var results = ""

    xmlhttp.onreadystatechange = function () {
        if (this.readyState == 4 && this.status == 200) {
            var jsonResults = JSON.parse(this.responseText);
            for (contact in jsonResults) {
                results += "<li>" + jsonResults[contact].contactID + " " + jsonResults[contact].firstName + " " + jsonResults[contact].lastName + "</li>";
            }
        }
    };
    var call = "/api/contact";
    call += record;
    xmlhttp.open(verb, call, true);
    xmlhttp.send();
    return results;
}